// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph.DotnetCore.Test.Mocks;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Extensions
{
    using System;
    using Xunit;

    public class DriveItemRequestBuilderExtensionsTests
    {
        [Fact]
        public void ItemById_BuildRequest()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/items/id");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Items["id"].ToGetRequestInformation();
            
            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
        }

        [Fact]
        public void ItemByPath_BuildRequest()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/root:/item/with/path:");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Root.ItemWithPath("item/with/path").ToGetRequestInformation();
            
            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
        }
        
        [Fact]
        public void ItemByPath_BuildRequest2()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/items/itemId:/item/with/path:");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Items["itemId"].ItemWithPath("item/with/path").ToGetRequestInformation();
            
            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
        }

        [Fact]
        public void ItemByPath_BuildRequestWithLeadingSlash()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/root:/item/with/path:");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Root.ItemWithPath("/item/with/path").ToGetRequestInformation();
            
            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
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
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/root:/" + expectedEncodedPath + ":");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Root.ItemWithPath(pathInput).ToGetRequestInformation();
            
            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);

        }
        
        [Fact]
        public void ItemByPath_BuildRequestWithNestedPathSlash()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/root:/item/with/path:/children");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Root.ItemWithPath("/item/with/path").Children.ToGetRequestInformation();
            
            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
        }
        
        [Fact]
        public void ItemByPath_BuildRequestWithNestedPathSlash2()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/root:/item/with/path:/versions");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Root.ItemWithPath("/item/with/path").Versions.ToGetRequestInformation();
            
            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
        }
        
        [Fact]
        public void ItemByPath_BuildRequestWithNestedPathSlashAndQueryParameters()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/root:/item/with/path:?%24expand=children");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Root.ItemWithPath("/item/with/path").ToGetRequestInformation( requestConfiguration => requestConfiguration.QueryParameters.Expand = new []{"children"});
            
            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
        }
        
        [Fact]
        public void ItemByPath_BuildRequestWithNestedPathSlashAndQueryParameters2()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/root:/item/with/path:/versions?%24count=true");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Root.ItemWithPath("/item/with/path").Versions.ToGetRequestInformation( requestConfiguration => requestConfiguration.QueryParameters.Count = true);
            
            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
        }

        [Fact]
        public void ItemByPath_BuildRequestWithNestedPathSlashAndOneParameter()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/root:/item/with/path:/search(q='doc.docx')");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Root.ItemWithPath("/item/with/path").SearchWithQ("doc.docx").ToGetRequestInformation();

            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
        }

        [Fact]
        public void ItemByPath_BuildRequestWithNestedPathSlashAndMoreThanOneParameter()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/drives/driveId/root:/item/with/path:/getActivitiesByInterval(startDateTime='2023-12-11',endDateTime='2023-12-13',interval='week')");
            var itemRequestInformation = graphServiceClient.Drives["driveId"].Root.ItemWithPath("/item/with/path").GetActivitiesByIntervalWithStartDateTimeWithEndDateTimeWithInterval("2023-12-13", "week", "2023-12-11").ToGetRequestInformation();

            Assert.NotNull(itemRequestInformation);
            Assert.Equal(expectedRequestUri, itemRequestInformation.URI);
        }
        [Fact]
        public void ItemByPath_ThrowsArgumentNullException_WhenPathIsNull_Root()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var ex = Assert.Throws<ArgumentNullException>(() => graphServiceClient.Drives["driveId"].Root.ItemWithPath(null));
            Assert.Equal("path", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void ItemByPath_ThrowsArgumentException_WhenPathIsEmptyOrWhitespace_Root(string path)
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var ex = Assert.Throws<ArgumentException>(() => graphServiceClient.Drives["driveId"].Root.ItemWithPath(path));
            Assert.Equal("path", ex.ParamName);
        }

        [Fact]
        public void ItemByPath_ThrowsArgumentNullException_WhenPathIsNull_DriveItem()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var ex = Assert.Throws<ArgumentNullException>(() => graphServiceClient.Drives["driveId"].Items["itemId"].ItemWithPath(null));
            Assert.Equal("path", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void ItemByPath_ThrowsArgumentException_WhenPathIsEmptyOrWhitespace_DriveItem(string path)
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var ex = Assert.Throws<ArgumentException>(() => graphServiceClient.Drives["driveId"].Items["itemId"].ItemWithPath(path));
            Assert.Equal("path", ex.ParamName);
        }

    }
}
