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
    public class BaseRequestBuilderTests
    {
        [TestMethod]
        public void BaseRequestBuilder()
        {
            var requestUrl = "https://localhost";
            var client = new Mock<IBaseClient>().Object;

            var requestBuilder = new BaseRequestBuilder(requestUrl, client);

            Assert.AreEqual(requestUrl, requestBuilder.RequestUrl, "Unexpected request URL initialized.");
            Assert.AreEqual(client, requestBuilder.Client, "Unexpected client initialized.");
        }

        [TestMethod]
        public void AppendSegmentToRequestUrl()
        {
            var requestUrl = "https://localhost";
            var newUrlSegment = "segment";

            var requestBuilder = new BaseRequestBuilder(requestUrl, new Mock<IBaseClient>().Object);

            var appendedUrl = requestBuilder.AppendSegmentToRequestUrl(newUrlSegment);

            Assert.AreEqual(string.Join("/", requestUrl, newUrlSegment), appendedUrl, "Unexpected appended URL returned.");
        }
    }
}
