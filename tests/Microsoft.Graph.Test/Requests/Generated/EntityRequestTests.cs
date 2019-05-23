// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Requests.Generated
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Graph;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class EntityRequestTests : RequestTestBase
    {
        [TestMethod]
        public async System.Threading.Tasks.Task GetAsync_InitializeCollectionProperties()
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
                    .Returns(System.Threading.Tasks.Task.FromResult<HttpResponseMessage>(httpResponseMessage));

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

                Assert.IsNotNull(item, "DriveItem not returned.");
                Assert.IsNotNull(item.Children, "DriveItem children not returned.");
                Assert.AreEqual(1, item.Children.CurrentPage.Count, "Unexpected number of children in page.");
                Assert.AreEqual("id", item.Children.CurrentPage[0].Id, "Unexpected child ID in page.");
                Assert.AreEqual(expectedItemResponse.AdditionalData, item.Children.AdditionalData, "Additional data not initialized correctly.");
                var nextPageRequest = item.Children.NextPageRequest as DriveItemChildrenCollectionRequest;
                Assert.IsNotNull(nextPageRequest, "Children next page request not initialized correctly.");
                Assert.AreEqual(new Uri(requestUrl + "/next"), new Uri(nextPageRequest.RequestUrl), "Unexpected request URL for next page request.");
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task DeleteAsync()
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
                    .Returns(System.Threading.Tasks.Task.FromResult(httpResponseMessage));

                await this.graphServiceClient.Me.Drive.Items["id"].Request().DeleteAsync();
            }
        }

        [TestMethod]
        public void Expand()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id");
            var itemRequest = this.graphServiceClient.Me.Drive.Items["id"].Request().Expand("value") as DriveItemRequest;

            Assert.IsNotNull(itemRequest, "Unexpected request.");
            Assert.AreEqual(expectedRequestUri, new Uri(itemRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, itemRequest.QueryOptions.Count, "Unexpected query options present.");
            Assert.AreEqual("$expand", itemRequest.QueryOptions[0].Name, "Unexpected expand query name.");
            Assert.AreEqual("value", itemRequest.QueryOptions[0].Value, "Unexpected expand query value.");
        }

        [TestMethod]
        public void Select()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id");
            var itemRequest = this.graphServiceClient.Me.Drive.Items["id"].Request().Select("value") as DriveItemRequest;

            Assert.IsNotNull(itemRequest, "Unexpected request.");
            Assert.AreEqual(expectedRequestUri, new Uri(itemRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, itemRequest.QueryOptions.Count, "Unexpected query options present.");
            Assert.AreEqual("$select", itemRequest.QueryOptions[0].Name, "Unexpected select query name.");
            Assert.AreEqual("value", itemRequest.QueryOptions[0].Value, "Unexpected select query value.");
        }

        [TestMethod]
        public async System.Threading.Tasks.Task UpdateAsync_EntityWithNoCollecitonProperties()
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
                        .Returns(System.Threading.Tasks.Task.FromResult(httpResponseMessage));

                var contactToUpdate = new Contact { Id = "id" };

                this.serializer.Setup(serializer => serializer.SerializeObject(contactToUpdate)).Returns("body");
                this.serializer.Setup(serializer => serializer.DeserializeObject<Contact>(It.IsAny<string>())).Returns(contactToUpdate);

                var contactResponse = await this.graphServiceClient.Me.Contacts["id"].Request().UpdateAsync(contactToUpdate);

                Assert.AreEqual(contactToUpdate, contactResponse, "Unexpected item returned.");
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task UpdateAsync_EntityWithResponseHeadersAndStatusCode()
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
                        .Returns(System.Threading.Tasks.Task.FromResult(httpResponseMessage));

                var contactToUpdate = new Contact
                {
                    Id = "id",
                    AdditionalData = new Dictionary<string, object>
                    {
                        { Constants.HttpPropertyNames.ResponseHeaders, new { Value = "Response headers test value" } },
                        { Constants.HttpPropertyNames.StatusCode, new { Value = "Status code test value" }}
                    }
                };

                this.serializer.Setup(serializer => serializer.SerializeObject(contactToUpdate)).Returns("body");
                this.serializer.Setup(serializer => serializer.DeserializeObject<Contact>(It.IsAny<string>())).Returns(contactToUpdate);

                try
                {
                    await Assert.ThrowsExceptionAsync<ClientException>(async () => await this.graphServiceClient.Me.Contacts["id"].Request().UpdateAsync(contactToUpdate));
                }
                catch (ClientException exception)
                {
                    Assert.Equals(ErrorConstants.Codes.NotAllowed, exception.Error.Code);
                    Assert.Equals(String.Format(ErrorConstants.Messages.ResponseObjectUsedForUpdate, contactToUpdate.GetType().Name),
                                exception.Error.Message);
                }
            }
        }

        [TestMethod]
        public async System.Threading.Tasks.Task UpdateAsync()
        {
            await this.RequestWithItemInBody(true);
        }
        
        private async System.Threading.Tasks.Task RequestWithItemInBody(bool isUpdate)
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
                        .Returns(System.Threading.Tasks.Task.FromResult(httpResponseMessage));

                this.serializer.Setup(serializer => serializer.SerializeObject(It.IsAny<DriveItem>())).Returns("body");
                this.serializer.Setup(serializer => serializer.DeserializeObject<DriveItem>(It.IsAny<string>())).Returns(new DriveItem { Id = "id" });

                var itemResponse = isUpdate
                    ? await this.graphServiceClient.Me.Drive.Items["id"].Request().UpdateAsync(new DriveItem())
                    : await this.graphServiceClient.Me.Drive.Items["id"].Request().CreateAsync(new DriveItem());

                Assert.AreEqual("id", itemResponse.Id, "Unexpected item returned.");
            }
        }
    }
}
