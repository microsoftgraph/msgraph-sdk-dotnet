// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Mocks
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    public class MockCustomHttpProvider : IHttpProvider
    {
        private MockSerializer serializer = new MockSerializer();
        internal HttpClient httpClient;
        public MockCustomHttpProvider(HttpMessageHandler httpMessageHandler)
        {
            httpClient = new HttpClient(httpMessageHandler);
        }
        public ISerializer Serializer => serializer.Object;

        public TimeSpan OverallTimeout
        {
            get
            {
                return this.httpClient.Timeout;
            }

            set
            {
                try
                {
                    this.httpClient.Timeout = value;
                }
                catch (InvalidOperationException exception)
                {
                    throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.NotAllowed,
                            Message = ErrorConstants.Messages.OverallTimeoutCannotBeSet,
                        },
                        exception);
                }
            }
        }

        public void Dispose()
        {
            if (this.httpClient != null)
            {
                this.httpClient.Dispose();
            }
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return await this.httpClient.SendAsync(request, completionOption, cancellationToken);
        }
    }
}
