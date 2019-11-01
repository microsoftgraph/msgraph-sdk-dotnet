// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Extensions
{
    using System;
    using Xunit;

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


        // These tests are from the OneDrive docs found here to verify correct functionality
        // https://docs.microsoft.com/en-us/onedrive/developer/rest-api/concepts/addressing-driveitems?view=odsp-graph-online#examples-1
        [Theory]
        [InlineData("Test#1.txt", "Test%231.txt")]
        [InlineData("Ryan's Files", "Ryan's%20Files")]
        [InlineData("doc (1).docx", "doc%20(1).docx")]
        [InlineData("estimate%s.docx", "estimate%25s.docx")]
        [InlineData("Break#Out", "Break%23Out")]
        [InlineData("saved_game[1].bin", "saved_game[1].bin")]
        public void ItemByPath_BuildRequestWithSpecialPoundCharacter(string pathInput, string expectedEncodedPath)
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/root:/" + expectedEncodedPath + ":");
            var itemRequestBuilder = this.graphServiceClient.Me.Drive.Root.ItemWithPath(pathInput) as DriveItemRequestBuilder;

            Assert.NotNull(itemRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(itemRequestBuilder.RequestUrl));

            var itemRequest = itemRequestBuilder.Request() as DriveItemRequest;
            Assert.NotNull(itemRequest);
            Assert.Equal(expectedRequestUri, new Uri(itemRequest.RequestUrl));
        }
    }
}
