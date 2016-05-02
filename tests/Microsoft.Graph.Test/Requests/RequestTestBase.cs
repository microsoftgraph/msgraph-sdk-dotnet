// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Requests
{
    using System.Net.Http;

    using Microsoft.Graph;
    using Microsoft.Graph.Core.Test.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RequestTestBase
    {
        protected string graphBaseUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0");

        protected MockAuthenticationProvider authenticationProvider;
        protected MockHttpProvider httpProvider;
        protected HttpResponseMessage httpResponseMessage;
        protected IGraphServiceClient graphServiceClient;
        protected MockSerializer serializer;

        [TestInitialize]
        public void Setup()
        {
            this.authenticationProvider = new MockAuthenticationProvider();
            this.serializer = new MockSerializer();
            this.httpResponseMessage = new HttpResponseMessage();
            this.httpProvider = new MockHttpProvider(this.httpResponseMessage, this.serializer.Object);
            
            this.graphServiceClient = new GraphServiceClient(
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
