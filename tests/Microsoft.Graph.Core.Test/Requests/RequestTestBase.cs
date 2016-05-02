// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Requests
{
    using System.Net.Http;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    [TestClass]
    public class RequestTestBase
    {
        protected string baseUrl = "https://localhost/v1.0";

        protected MockAuthenticationProvider authenticationProvider;
        protected MockHttpProvider httpProvider;
        protected HttpResponseMessage httpResponseMessage;
        protected IBaseClient baseClient;
        protected MockSerializer serializer;

        [TestInitialize]
        public void Setup()
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

        [TestCleanup]
        public void Teardown()
        {
            this.httpResponseMessage.Dispose();
        }
    }
}
