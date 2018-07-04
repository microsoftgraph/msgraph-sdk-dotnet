// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The base request class.
    /// </summary>
    public class BaseRequest : IBaseRequest
    {
        /// The key for the SDK version header.
        protected string sdkVersionHeaderName;
        /// The value for the SDK version header.
        protected string sdkVersionHeaderValue;

        /// <summary>
        /// Constructs a new <see cref="BaseRequest"/>.
        /// </summary>
        /// <param name="requestUrl">The URL for the request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">The header and query options for the request.</param>
        public BaseRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options = null)
        {
            this.Method = "GET";
            this.Client = client;
            this.Headers = new List<HeaderOption>();
            this.QueryOptions = new List<QueryOption>();

            this.RequestUrl = this.InitializeUrl(requestUrl);

            this.sdkVersionHeaderName = CoreConstants.Headers.SdkVersionHeaderName;
            this.SdkVersionHeaderPrefix = "Graph";

            if (options != null)
            {
                var headerOptions = options.OfType<HeaderOption>();
                if (headerOptions != null)
                {
                    ((List<HeaderOption>)this.Headers).AddRange(headerOptions);
                }

                var queryOptions = options.OfType<QueryOption>();
                if (queryOptions != null)
                {
                    ((List<QueryOption>)this.QueryOptions).AddRange(queryOptions);
                }
            }
        }

        /// <summary>
        /// Gets or sets the content type for the request.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets the <see cref="HeaderOption"/> collection for the request.
        /// </summary>
        public IList<HeaderOption> Headers { get; private set; }

        /// <summary>
        /// Gets the <see cref="IBaseClient"/> for handling requests.
        /// </summary>
        public IBaseClient Client { get; private set; }

        /// <summary>
        /// Gets or sets the HTTP method string for the request.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets the <see cref="QueryOption"/> collection for the request.
        /// </summary>
        public IList<QueryOption> QueryOptions { get; set; }

        /// <summary>
        /// Gets the URL for the request, without query string.
        /// </summary>
        public string RequestUrl { get; internal set; }
        
        /// <summary>
        /// Gets or sets the telemetry header prefix for requests.
        /// </summary>
        protected string SdkVersionHeaderPrefix { get; set; }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="serializableObject">The serializable object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The task to await.</returns>
        public async Task SendAsync(
            object serializableObject,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            using (var response = await this.SendRequestAsync(serializableObject, cancellationToken, completionOption).ConfigureAwait(false))
            {
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <typeparam name="T">The expected response object type for deserialization.</typeparam>
        /// <param name="serializableObject">The serializable object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The deserialized response object.</returns>
        public async Task<T> SendAsync<T>(
            object serializableObject,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            using (var response = await this.SendRequestAsync(serializableObject, cancellationToken, completionOption).ConfigureAwait(false))
            {
                if (response.Content != null)
                {
                    var responseString = await GetResponseString(response);
                    return this.Client.HttpProvider.Serializer.DeserializeObject<T>(responseString);
                }

                return default(T);
            }
        }

        /// <summary>
        /// Sends the multipart request.
        /// </summary>
        /// <typeparam name="T">The expected response object type for deserialization.</typeparam>
        /// <param name="multipartContent">The multipart object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The deserialized response object.</returns>
        public async Task<T> SendMultiPartAsync<T>(
            MultipartContent multipartContent,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            using (var response = await this.SendMultiPartRequestAsync(multipartContent, cancellationToken, completionOption).ConfigureAwait(false))
            {
                if (response.Content != null)
                {
                    var responseString = await GetResponseString(response);
                    return this.Client.HttpProvider.Serializer.DeserializeObject<T>(responseString);
                }

                return default(T);
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="serializableObject">The serializable object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The stream.</returns>
        public async Task<Stream> SendStreamRequestAsync(
            object serializableObject,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            var response = await this.SendRequestAsync(serializableObject, cancellationToken, completionOption).ConfigureAwait(false);
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Sends the multipart request.
        /// </summary>
        /// <param name="multipartContent">The multipart object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The <see cref="HttpResponseMessage"/> object.</returns>
        public async Task<HttpResponseMessage> SendMultiPartRequestAsync(
            MultipartContent multipartContent,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            if (string.IsNullOrEmpty(this.RequestUrl))
            {
                throw new ServiceException(
                    new Error
                    {
                        Code = ErrorConstants.Codes.InvalidRequest,
                        Message = ErrorConstants.Messages.RequestUrlMissing,
                    });
            }

            if (this.Client.AuthenticationProvider == null)
            {
                throw new ServiceException(
                    new Error
                    {
                        Code = ErrorConstants.Codes.InvalidRequest,
                        Message = ErrorConstants.Messages.AuthenticationProviderMissing,
                    });
            }

            if (multipartContent != null)
            {
                using (var request = this.GetHttpRequestMessage())
                {
                    await this.AuthenticateRequest(request).ConfigureAwait(false);

                    request.Content = multipartContent;

                    return await this.Client.HttpProvider.SendAsync(request, completionOption, cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {
                throw new Exception("The Multipart content is null. Set the multipart content.");
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="serializableObject">The serializable object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The <see cref="HttpResponseMessage"/> object.</returns>
        public async Task<HttpResponseMessage> SendRequestAsync(
            object serializableObject,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            if (string.IsNullOrEmpty(this.RequestUrl))
            {
                throw new ServiceException(
                    new Error
                    {
                        Code = ErrorConstants.Codes.InvalidRequest,
                        Message = ErrorConstants.Messages.RequestUrlMissing,
                    });
            }

            if (this.Client.AuthenticationProvider == null)
            {
                throw new ServiceException(
                    new Error
                    {
                        Code = ErrorConstants.Codes.InvalidRequest,
                        Message = ErrorConstants.Messages.AuthenticationProviderMissing,
                    });
            }

            using (var request = this.GetHttpRequestMessage())
            {
                await this.AuthenticateRequest(request).ConfigureAwait(false);

                if (serializableObject != null)
                {
                    var inputStream = serializableObject as Stream;

                    if (inputStream != null)
                    {
                        request.Content = new StreamContent(inputStream);
                    }
                    else
                    {
                        request.Content = new StringContent(this.Client.HttpProvider.Serializer.SerializeObject(serializableObject));
                    }

                    if (!string.IsNullOrEmpty(this.ContentType))
                    {
                        request.Content.Headers.ContentType = new MediaTypeHeaderValue(this.ContentType);
                    }
                }

                return await this.Client.HttpProvider.SendAsync(request, completionOption, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the <see cref="HttpRequestMessage"/> representation of the request.
        /// </summary>
        /// <returns>The <see cref="HttpRequestMessage"/> representation of the request.</returns>
        public HttpRequestMessage GetHttpRequestMessage()
        {
            var queryString = this.BuildQueryString();
            var request = new HttpRequestMessage(new HttpMethod(this.Method), string.Concat(this.RequestUrl, queryString));

            this.AddHeadersToRequest(request);

            return request;
        }

        /// <summary>
        /// Gets a URL that is the request builder's request URL with the segment appended.
        /// </summary>
        /// <param name="urlSegment">The segment to append to the request URL.</param>
        /// <returns>A URL that is the request builder's request URL with the segment appended.</returns>
        public void AppendSegmentToRequestUrl(string urlSegment)
        {
            this.RequestUrl = string.Format("{0}/{1}", this.RequestUrl, urlSegment);
        }

        /// <summary>
        /// Builds the query string for the request from the query option collection.
        /// </summary>
        /// <returns>The constructed query string.</returns>
        internal string BuildQueryString()
        {
            if (this.QueryOptions != null)
            {
                var stringBuilder = new StringBuilder();

                foreach (var queryOption in this.QueryOptions)
                {
                    if (stringBuilder.Length == 0)
                    {
                        stringBuilder.AppendFormat("?{0}={1}", queryOption.Name, queryOption.Value);
                    }
                    else
                    {
                        stringBuilder.AppendFormat("&{0}={1}", queryOption.Name, queryOption.Value);
                    }
                }

                return stringBuilder.ToString();
            }

            return null;
        }

        /// <summary>
        /// Adds all of the headers from the header collection to the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> representation of the request.</param>
        private void AddHeadersToRequest(HttpRequestMessage request)
        {
            if (this.Headers != null)
            {
                foreach (var header in this.Headers)
                {
                    request.Headers.TryAddWithoutValidation(header.Name, header.Value);
                }
            }

            if (string.IsNullOrEmpty(this.sdkVersionHeaderValue))
            {
                var assemblyVersion = this.GetType().GetTypeInfo().Assembly.GetName().Version;
                this.sdkVersionHeaderValue = string.Format(
                    CoreConstants.Headers.SdkVersionHeaderValueFormatString,
                    this.SdkVersionHeaderPrefix,
                    assemblyVersion.Major,
                    assemblyVersion.Minor,
                    assemblyVersion.Build);
            }

            // Append SDK version header for telemetry
            request.Headers.Add(
                this.sdkVersionHeaderName,
                this.sdkVersionHeaderValue);
        }

        /// <summary>
        /// Adds the authentication header to the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> representation of the request.</param>
        /// <returns>The task to await.</returns>
        private Task AuthenticateRequest(HttpRequestMessage request)
        {
            return this.Client.AuthenticationProvider.AuthenticateRequestAsync(request);
        }

        /// <summary>
        /// Initializes the request URL for the request, breaking it into query options and base URL.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <returns>The request URL minus query string.</returns>
        private string InitializeUrl(string requestUrl)
        {
            if (string.IsNullOrEmpty(requestUrl))
            {
                throw new ServiceException(
                    new Error
                    {
                        Code = ErrorConstants.Codes.InvalidRequest,
                        Message = ErrorConstants.Messages.BaseUrlMissing,
                    });
            }

            var uri = new Uri(requestUrl);
            
            if (!string.IsNullOrEmpty(uri.Query))
            {
                var queryString = uri.Query;
                if (queryString[0] == '?')
                {
                    queryString = queryString.Substring(1);
                }

                var queryOptions = queryString.Split('&').Select(
                        queryValue =>
                        {
                            // We want to split on the first occurrence of = since there are scenarios where a query option can 
                            // have 'sub-query' options on navigation properties for $expand scenarios. This way we can properly
                            // split the query option name/value into the QueryOption object. Take this for example:
                            // $expand=extensions($filter=Id%20eq%20'SMB'%20)
                            // We want to get '$expand' as the name and 'extensions($filter=Id%20eq%20'SMB'%20)' as the value
                            // for QueryOption object.
                            // OData URL conventions 5.1.2 System Query Option $expand
                            // http://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part2-url-conventions/odata-v4.0-errata03-os-part2-url-conventions-complete.html#_Toc453752359

                            var segments = queryValue.Split(new[] { '=' }, 2);
                            return new QueryOption(
                                segments[0],
                                segments.Length > 1 ? segments[1] : string.Empty);
                        });

                foreach(var queryOption in queryOptions)
                {
                    this.QueryOptions.Add(queryOption);
                }
            }

            return new UriBuilder(uri) { Query = string.Empty }.ToString();
        }

        /// <summary>
        /// Get the response content string
        /// </summary>
        /// <param name="hrm">The response object</param>
        /// <returns>The full response string to return</returns>
        private async Task<string> GetResponseString(HttpResponseMessage hrm)
        {
            var responseContent = "";

            var content = await hrm.Content.ReadAsStringAsync().ConfigureAwait(false);

            //Only add headers if we are going to return a response body
            if (content.Length > 0)
            {
                var responseHeaders = hrm.Headers;
                var statusCode = hrm.StatusCode;

                Dictionary<string, string[]> headerDictionary = responseHeaders.ToDictionary(x => x.Key, x => x.Value.ToArray());
                var responseHeaderString = this.Client.HttpProvider.Serializer.SerializeObject(headerDictionary);

                responseContent = content.Substring(0, content.Length - 1) + ", ";
                responseContent += "\"responseHeaders\": " + responseHeaderString + ", ";
                responseContent += "\"statusCode\": \"" + statusCode + "\"}";
            }

            return responseContent;
        }
    }
}
