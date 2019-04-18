// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A <see cref="HttpContent"/> implementation to handle json batch requests.
    /// </summary>
    public class BatchRequestContent: HttpContent
    {
        /// <summary>
        /// A BatchRequestSteps property.
        /// </summary>
        public IReadOnlyDictionary<string, BatchRequestStep> BatchRequestSteps { get; private set; }

        /// <summary>
        /// Constructs a new <see cref="BatchRequestContent"/>.
        /// </summary>
        public BatchRequestContent()
            :this(new BatchRequestStep[] { })
        {
        }

        /// <summary>
        /// Constructs a new <see cref="BatchRequestContent"/>.
        /// </summary>
        /// <param name="batchRequestSteps">A list of <see cref="BatchRequestStep"/> to add to the batch request content.</param>
        public BatchRequestContent(params BatchRequestStep[] batchRequestSteps)
        {
            if (batchRequestSteps == null)
                throw new ClientException(new Error
                {
                    Code = ErrorConstants.Codes.InvalidArgument,
                    Message = string.Format(ErrorConstants.Messages.NullParameter, nameof(batchRequestSteps))
                });

            if (batchRequestSteps.Count() > CoreConstants.BatchRequest.MaxNumberOfRequests)
                throw new ClientException(new Error {
                    Code = ErrorConstants.Codes.MaximumValueExceeded,
                    Message = string.Format(ErrorConstants.Messages.MaximumValueExceeded, "Number of batch request steps", CoreConstants.BatchRequest.MaxNumberOfRequests)
                });

            this.Headers.ContentType = new MediaTypeHeaderValue(CoreConstants.MimeTypeNames.Application.Json);

            BatchRequestSteps = new Dictionary<string, BatchRequestStep>();

            foreach (BatchRequestStep requestStep in batchRequestSteps)
            {
                if(requestStep.DependsOn != null && !ContainsCorrespondingRequestId(requestStep.DependsOn))
                {
                    throw new ClientException(new Error
                    {
                        Code = ErrorConstants.Codes.InvalidArgument,
                        Message = ErrorConstants.Messages.InvalidDependsOnRequestId
                    });
                }
                AddBatchRequestStep(requestStep);
            }
        }

        /// <summary>
        /// Adds a <see cref="BatchRequestStep"/> to batch request content if doesn't exists.
        /// </summary>
        /// <param name="batchRequestStep">A <see cref="BatchRequestStep"/> to add.</param>
        /// <returns>True or false based on addition or not addition of the provided <see cref="BatchRequestStep"/>. </returns>
        public bool AddBatchRequestStep(BatchRequestStep batchRequestStep)
        {
            if (batchRequestStep == null || BatchRequestSteps.ContainsKey(batchRequestStep.RequestId))
                return false;
            (BatchRequestSteps as IDictionary<string, BatchRequestStep>).Add(batchRequestStep.RequestId, batchRequestStep);
            return true;
        }

        /// <summary>
        /// Removes a <see cref="BatchRequestStep"/> from batch request content for the specified id.
        /// </summary>
        /// <param name="requestId">A unique batch request id to remove.</param>
        /// <returns>True or false based on removal or not removal of a <see cref="BatchRequestStep"/>.</returns>
        public bool RemoveBatchRequestStepWithId(string requestId)
        {
            if (string.IsNullOrEmpty(requestId))
                throw new ClientException(
                    new Error
                        {
                            Code = ErrorConstants.Codes.InvalidArgument,
                            Message = string.Format(ErrorConstants.Messages.NullParameter, nameof(requestId))
                        });

            bool isRemoved = false;
            if (BatchRequestSteps.ContainsKey(requestId)) {
                (BatchRequestSteps as IDictionary<string, BatchRequestStep>).Remove(requestId);
                isRemoved = true;
                foreach (KeyValuePair<string, BatchRequestStep> batchRequestStep in BatchRequestSteps)
                {
                    if (batchRequestStep.Value != null && batchRequestStep.Value.DependsOn != null)
                        while (batchRequestStep.Value.DependsOn.Remove(requestId)) ;
                }
            }
            return isRemoved;
        }

        internal async Task<JObject> GetBatchRequestContentAsync()
        {
            JObject batchRequest = new JObject();
            JArray batchRequestItems = new JArray();

            foreach (KeyValuePair<string, BatchRequestStep> batchRequestStep in BatchRequestSteps)
                batchRequestItems.Add(await GetBatchRequestContentFromStepAsync(batchRequestStep.Value));

            batchRequest.Add(CoreConstants.BatchRequest.Requests, batchRequestItems);

            return batchRequest;
        }

        private bool ContainsCorrespondingRequestId(IList<string> dependsOn)
        {
        	return dependsOn.All(requestId => BatchRequestSteps.ContainsKey(requestId));
        }

        private async Task<JObject> GetBatchRequestContentFromStepAsync(BatchRequestStep batchRequestStep)
        {
            JObject jRequestContent = new JObject
            {
                { CoreConstants.BatchRequest.Id, batchRequestStep.RequestId },
                { CoreConstants.BatchRequest.Url, GetRelativeUrl(batchRequestStep.Request.RequestUri) },
                { CoreConstants.BatchRequest.Method, batchRequestStep.Request.Method.Method }
            };
            if (batchRequestStep.DependsOn != null && batchRequestStep.DependsOn.Count() > 0)
                jRequestContent.Add(CoreConstants.BatchRequest.DependsOn, new JArray(batchRequestStep.DependsOn));

            if (batchRequestStep.Request.Content?.Headers != null && batchRequestStep.Request.Content.Headers.Count() > 0)
                jRequestContent.Add(CoreConstants.BatchRequest.Headers, GetContentHeader(batchRequestStep.Request.Content.Headers));

            if(batchRequestStep.Request != null && batchRequestStep.Request.Content != null)
            {
                jRequestContent.Add(CoreConstants.BatchRequest.Body, await GetRequestContentAsync(batchRequestStep.Request));
            }

            return jRequestContent;
        }

        private async Task<JObject> GetRequestContentAsync(HttpRequestMessage request)
        {
            try
            {
                HttpRequestMessage clonedRequest = await request.CloneAsync();

                using (Stream streamContent = await clonedRequest.Content.ReadAsStreamAsync())
                using (StreamReader streamReader = new StreamReader(streamContent))
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    return JObject.Load(jsonTextReader);
                }
            }
            catch (Exception ex)
            {
                throw new ClientException(new Error
                {
                    Code = ErrorConstants.Codes.InvalidRequest,
                    Message = ErrorConstants.Messages.UnableToDeserializexContent
                }, ex);
            }
        }

        private JObject GetContentHeader(HttpContentHeaders headers)
        {
            JObject jHeaders = new JObject();
            foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
            {
                jHeaders.Add(header.Key, GetHeaderValuesAsString(header.Value));
            }
            return jHeaders;
        }

        private string GetHeaderValuesAsString(IEnumerable<string> headerValues)
        {
            if (headerValues == null || headerValues.Count() == 0)
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            foreach (string headerValue in headerValues)
            {
                builder.Append(headerValue);
            }

            return builder.ToString();
        }

        private string GetRelativeUrl(Uri requestUri)
        {
            string version = "v1.0";
            if (requestUri.AbsoluteUri.Contains("beta"))
                version = "beta";

            return requestUri.AbsoluteUri.Substring(requestUri.AbsoluteUri.IndexOf(version) + version.ToCharArray().Count());
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            using (StreamWriter streamWritter = new StreamWriter(stream))
            using (JsonTextWriter textWritter = new JsonTextWriter(streamWritter))
            {
                JObject batchContent = await GetBatchRequestContentAsync();
                batchContent.WriteTo(textWritter);
            }
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}
