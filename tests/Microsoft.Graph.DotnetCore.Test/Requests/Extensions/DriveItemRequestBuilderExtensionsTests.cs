// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Extensions
{
    public class DriveItemRequestBuilderExtensionsTests : RequestTestBase
    {
        [Fact]
        public void ItemById_BuildRequest()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id");
            var itemRequestBuilder = this.graphServiceClient.Me.Drive.Items["id"] as DriveItemRequestBuilder;

            Assert.NotNull(itemRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(itemRequestBuilder.RequestUrl));

            var itemRequest = itemRequestBuilder.Request() as DriveItemRequest;
            Assert.NotNull(itemRequest);
            Assert.Equal(expectedRequestUri, new Uri(itemRequest.RequestUrl));
        }

        [Fact]
        public void ItemByPath_BuildRequest()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/root:/item/with/path:");
            var itemRequestBuilder = this.graphServiceClient.Me.Drive.Root.ItemWithPath("item/with/path") as DriveItemRequestBuilder;

            Assert.NotNull(itemRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(itemRequestBuilder.RequestUrl));

            var itemRequest = itemRequestBuilder.Request() as DriveItemRequest;
            Assert.NotNull(itemRequest);
            Assert.Equal(expectedRequestUri, new Uri(itemRequest.RequestUrl));
        }

        [Fact]
        public void ItemByPath_BuildRequestWithLeadingSlash()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/root:/item/with/path:");
            var itemRequestBuilder = this.graphServiceClient.Me.Drive.Root.ItemWithPath("/item/with/path") as DriveItemRequestBuilder;

            Assert.NotNull(itemRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(itemRequestBuilder.RequestUrl));

            var itemRequest = itemRequestBuilder.Request() as DriveItemRequest;
            Assert.NotNull(itemRequest);
            Assert.Equal(expectedRequestUri, new Uri(itemRequest.RequestUrl));
        }
    }
}
