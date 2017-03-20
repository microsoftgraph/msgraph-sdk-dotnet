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
    public class MediaEntityStreamRequestTests : RequestTestBase
    {
        [Fact]
        public void RequestBuilder()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/photo/$value");
            var profilePhotoContentRequestBuilder = this.graphServiceClient.Me.Photo.Content as ProfilePhotoContentRequestBuilder;

            Assert.NotNull(profilePhotoContentRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(profilePhotoContentRequestBuilder.RequestUrl));
        }

        [Fact]
        public async Task GetAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/photo/$value";
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Get),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                using (var returnedResponseStream = await this.graphServiceClient.Me.Photo.Content.Request().GetAsync())
                {
                    Assert.Equal(await httpResponseMessage.Content.ReadAsStreamAsync(), returnedResponseStream);
                }
            }
        }

        [Fact]
        public async Task PutAsync()
        {
            using (var requestStream = new MemoryStream())
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/photo/$value";
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Put),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                using (var returnedResponseStream = await this.graphServiceClient.Me.Photo.Content.Request().PutAsync(requestStream))
                {
                    Assert.Equal(await httpResponseMessage.Content.ReadAsStreamAsync(), returnedResponseStream);
                }
            }
        }
    }
}