// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests
{
    using Microsoft.Graph.DotnetCore.Core.Test.Mocks;
    using System;
    using System.Net.Http;
    public class RequestTestBase : IDisposable
    {
        protected string baseUrl = "https://localhost/v1.0";

        protected MockAuthenticationProvider authenticationProvider;
        protected MockHttpProvider httpProvider;
        protected HttpResponseMessage httpResponseMessage;
        protected IBaseClient baseClient;
        protected MockSerializer serializer;

        public RequestTestBase()
        {
            this.authenticationProvider = new MockAuthenticationProvider();
            this.serializer = new MockSerializer();
            this.httpResponseMessage = new HttpResponseMessage();
            this.httpProvider = new MockHttpProvider(this.httpResponseMessage, this.serializer.Object);

            this.baseClient = new BaseClient(
                this.baseUrl,
                this.authenticationProvider.Object,
                this.httpProvider.Object);
        }

        public void Dispose()
        {
            this.httpResponseMessage.Dispose();
        }
    }
}
