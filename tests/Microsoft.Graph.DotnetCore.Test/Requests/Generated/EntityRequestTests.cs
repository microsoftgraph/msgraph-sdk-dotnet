// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Generated
{
    public class EntityRequestTests : RequestTestBase
    {
        [Fact]
        public async Task GetAsync_InitializeCollectionProperties()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id";
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult<HttpResponseMessage>(httpResponseMessage));

                var expectedChildrenPage = new DriveItemChildrenCollectionPage
                {
                    new DriveItem { Id = "id" }
                };

                var expectedItemResponse = new DriveItem
                {
                    AdditionalData = new Dictionary<string, object>
                    {
                        { "children@odata.nextLink", requestUrl + "/next" }
                    },
                    Children = expectedChildrenPage,
                };

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DriveItem>(It.IsAny<string>()))
                    .Returns(expectedItemResponse);

                var item = await this.graphServiceClient.Me.Drive.Items["id"].Request().GetAsync();

                Assert.NotNull(item);
                Assert.NotNull(item.Children);
                Assert.Equal(1, item.Children.CurrentPage.Count);
                Assert.Equal("id", item.Children.CurrentPage[0].Id);
                Assert.Equal(expectedItemResponse.AdditionalData, item.Children.AdditionalData);
                var nextPageRequest = item.Children.NextPageRequest as DriveItemChildrenCollectionRequest;
                Assert.NotNull(nextPageRequest);
                Assert.Equal(new Uri(requestUrl + "/next"), new Uri(nextPageRequest.RequestUrl));
            }
        }

        [Fact]
        public async Task DeleteAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NoContent))
            {
                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id";
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request =>
                                request.Method == HttpMethod.Delete
                                && request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                await this.graphServiceClient.Me.Drive.Items["id"].Request().DeleteAsync();
            }
        }

        [Fact]
        public void Expand()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id");
            var itemRequest = this.graphServiceClient.Me.Drive.Items["id"].Request().Expand("value") as DriveItemRequest;

            Assert.NotNull(itemRequest);
            Assert.Equal(expectedRequestUri, new Uri(itemRequest.RequestUrl));
            Assert.Equal(1, itemRequest.QueryOptions.Count);
            Assert.Equal("$expand", itemRequest.QueryOptions[0].Name);
            Assert.Equal("value", itemRequest.QueryOptions[0].Value);
        }

        [Fact]
        public void Select()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id");
            var itemRequest = this.graphServiceClient.Me.Drive.Items["id"].Request().Select("value") as DriveItemRequest;

            Assert.NotNull(itemRequest);
            Assert.Equal(expectedRequestUri, new Uri(itemRequest.RequestUrl));
            Assert.Equal(1, itemRequest.QueryOptions.Count);
            Assert.Equal("$select", itemRequest.QueryOptions[0].Name);
            Assert.Equal("value", itemRequest.QueryOptions[0].Value);
        }

        [Fact]
        public async Task UpdateAsync_EntityWithNoCollecitonProperties()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/contacts/id";
                this.httpProvider.Setup(
                        provider => provider.SendAsync(
                            It.Is<HttpRequestMessage>(
                                request =>
                                    string.Equals(request.Method.ToString().ToUpperInvariant(), "PATCH")
                                    && string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")
                                    && request.RequestUri.ToString().Equals(requestUrl)),
                            HttpCompletionOption.ResponseContentRead,
                            CancellationToken.None))
                        .Returns(Task.FromResult(httpResponseMessage));

                var contactToUpdate = new Contact { Id = "id" };

                this.serializer.Setup(serializer => serializer.SerializeObject(contactToUpdate)).Returns("body");
                this.serializer.Setup(serializer => serializer.DeserializeObject<Contact>(It.IsAny<string>())).Returns(contactToUpdate);

                var contactResponse = await this.graphServiceClient.Me.Contacts["id"].Request().UpdateAsync(contactToUpdate);

                Assert.Equal(contactToUpdate, contactResponse);
            }
        }

        [Fact]
        public async Task UpdateAsync()
        {
            await this.RequestWithItemInBody(true);
        }

        private async Task RequestWithItemInBody(bool isUpdate)
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id";
                this.httpProvider.Setup(
                        provider => provider.SendAsync(
                            It.Is<HttpRequestMessage>(
                                request =>
                                    string.Equals(request.Method.ToString().ToUpperInvariant(), isUpdate ? "PATCH" : "PUT")
                                    && string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")
                                    && request.RequestUri.ToString().Equals(requestUrl)),
                            HttpCompletionOption.ResponseContentRead,
                            CancellationToken.None))
                        .Returns(Task.FromResult(httpResponseMessage));

                this.serializer.Setup(serializer => serializer.SerializeObject(It.IsAny<DriveItem>())).Returns("body");
                this.serializer.Setup(serializer => serializer.DeserializeObject<DriveItem>(It.IsAny<string>())).Returns(new DriveItem { Id = "id" });

                var itemResponse = isUpdate
                    ? await this.graphServiceClient.Me.Drive.Items["id"].Request().UpdateAsync(new DriveItem())
                    : await this.graphServiceClient.Me.Drive.Items["id"].Request().CreateAsync(new DriveItem());

                Assert.Equal("id", itemResponse.Id);
            }
        }
    }
}