// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests
{
    public class BaseRequestBuilderTests
    {
        [Fact]
        public void BaseRequestBuilder()
        {
            var requestUrl = "https://localhost";
            var client = new Mock<IBaseClient>().Object;

            var requestBuilder = new BaseRequestBuilder(requestUrl, client);

            Assert.Equal(requestUrl, requestBuilder.RequestUrl);
            Assert.Equal(client, requestBuilder.Client);
        }

        [Fact]
        public void AppendSegmentToRequestUrl()
        {
            var requestUrl = "https://localhost";
            var newUrlSegment = "segment";

            var requestBuilder = new BaseRequestBuilder(requestUrl, new Mock<IBaseClient>().Object);

            var appendedUrl = requestBuilder.AppendSegmentToRequestUrl(newUrlSegment);

            Assert.Equal(string.Join("/", requestUrl, newUrlSegment), appendedUrl);
        }
    }
}
