// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Requests
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Graph.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Moq;

    [TestClass]
    public class BaseClientTests
    {
        private MockAuthenticationProvider authenticationProvider;

        [TestInitialize]
        public void Setup()
        {
            this.authenticationProvider = new MockAuthenticationProvider();
        }

        [TestMethod]
        public void BaseClient_InitializeBaseUrlWithoutTrailingSlash()
        {
            var expectedBaseUrl = "https://localhost";

            var baseClient = new BaseClient(expectedBaseUrl, this.authenticationProvider.Object);

            Assert.AreEqual(expectedBaseUrl, baseClient.BaseUrl, "Unexpected base URL initialized.");
        }

        [TestMethod]
        public void BaseClient_InitializeBaseUrlWithTrailingSlash()
        {
            var expectedBaseUrl = "https://localhost";

            var baseClient = new BaseClient("https://localhost/", this.authenticationProvider.Object);

            Assert.AreEqual(expectedBaseUrl, baseClient.BaseUrl, "Unexpected base URL initialized.");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void BaseClient_InitializeEmptyBaseUrl()
        {
            try
            {
                var baseClient = new BaseClient(null, this.authenticationProvider.Object);
            }
            catch (ServiceException exception)
            {
                Assert.AreEqual("invalidRequest", exception.Error.Code, "Unexpected error code.");
                Assert.AreEqual("Base URL cannot be null or empty.", exception.Error.Message, "Unexpected error message.");
                throw;
            }
        }
    }
}
