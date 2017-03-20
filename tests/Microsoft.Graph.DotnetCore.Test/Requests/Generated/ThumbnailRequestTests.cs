// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Generated
{
    public class ThumbnailRequestTests : RequestTestBase
    {
        [Fact]
        public void ThumbnailContentStreamRequest_RequestBuilder()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id/thumbnails/0/id/content");
            var thumbnailContentRequestBuilder = this.graphServiceClient.Me.Drive.Items["id"].Thumbnails["0"]["id"].Content as ThumbnailContentRequestBuilder;

            Assert.NotNull(thumbnailContentRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(thumbnailContentRequestBuilder.RequestUrl));
        }

        [Fact]
        public async Task ThumbnailContentStreamRequest_GetAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var stringContent = new StringContent("body"))
            {
                httpResponseMessage.Content = stringContent;

                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id/thumbnails/0/id/content";
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Get),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                using (var response = await this.graphServiceClient.Me.Drive.Items["id"].Thumbnails["0"]["id"].Content.Request().GetAsync())
                {
                    Assert.NotNull(response);

                    using (var streamReader = new StreamReader(response))
                    {
                        var responseString = await streamReader.ReadToEndAsync();
                        Assert.Equal("body", responseString);
                    }
                }
            }
        }

        [Fact]
        public async Task ThumbnailContentStreamRequest_PutAsync()
        {
            using (var requestStream = new MemoryStream())
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id/thumbnails/0/id/content";
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Put),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                var expectedThumbnail = new Thumbnail { Url = "https://localhost" };

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<Thumbnail>(It.IsAny<string>()))
                    .Returns(expectedThumbnail);

                var responseThumbnail = await this.graphServiceClient.Me.Drive.Items["id"].Thumbnails["0"]["id"].Content.Request().PutAsync<Thumbnail>(requestStream);

                Assert.NotNull(responseThumbnail);
                Assert.Equal(expectedThumbnail, responseThumbnail);
            }
        }

        [Fact]
        public void ThumbnailSetExtensions_AdditionalDataNull()
        {
            var thumbnailSet = new ThumbnailSet();

            var thumbnail = thumbnailSet["custom"];

            Assert.Null(thumbnail);
        }

        [Fact]
        public void ThumbnailSetExtensions_CustomThumbnail()
        {
            var expectedThumbnail = new Thumbnail { Url = "https://localhost" };
            var thumbnailSet = new ThumbnailSet
            {
                AdditionalData = new Dictionary<string, object>
                {
                    { "custom", expectedThumbnail }
                }
            };

            var thumbnail = thumbnailSet["custom"];

            Assert.NotNull(thumbnail);
            Assert.Equal(expectedThumbnail.Url, thumbnail.Url);
        }

        [Fact]
        public void ThumbnailSetExtensions_CustomThumbnailNotFound()
        {
            var expectedThumbnail = new Thumbnail { Url = "https://localhost" };
            var thumbnailSet = new ThumbnailSet
            {
                AdditionalData = new Dictionary<string, object>
                {
                    { "custom", expectedThumbnail }
                }
            };

            var thumbnail = thumbnailSet["custom2"];

            Assert.Null(thumbnail);
        }
    }
}
