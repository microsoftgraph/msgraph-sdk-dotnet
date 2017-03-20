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
    public class EntityCollectionRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for an entity collection.
        /// </summary>
        [Fact]
        public void BuildRequest()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/calendars");
            var calendarsCollectionRequestBuilder = this.graphServiceClient.Me.Calendars as UserCalendarsCollectionRequestBuilder;

            Assert.NotNull(calendarsCollectionRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(calendarsCollectionRequestBuilder.RequestUrl));

            var calendarsCollectionRequest = calendarsCollectionRequestBuilder.Request() as UserCalendarsCollectionRequest;
            Assert.NotNull(calendarsCollectionRequest);
            Assert.Equal(expectedRequestUri, new Uri(calendarsCollectionRequest.RequestUrl));
        }

        /// <summary>
        /// Tests the GetAsync() method on an entity collection request.
        /// </summary>
        [Fact]
        public async Task GetAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var nextQueryKey = "key";
                var nextQueryValue = "value";

                var requestUrl = string.Format("{0}/me/calendars", this.graphBaseUrl);
                var nextPageRequestUrl = string.Format("{0}?{1}={2}", requestUrl, nextQueryKey, nextQueryValue);

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Get),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                var calendarsCollectionPage = new UserCalendarsCollectionPage
                {
                    new Calendar(),
                };

                var calendarsCollectionResponse = new UserCalendarsCollectionResponse
                {
                    Value = calendarsCollectionPage,
                    AdditionalData = new Dictionary<string, object> { { "@odata.nextLink", nextPageRequestUrl } },
                };

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<UserCalendarsCollectionResponse>(It.IsAny<string>()))
                    .Returns(calendarsCollectionResponse);

                var returnedCollectionPage = await this.graphServiceClient.Me.Calendars.Request().GetAsync();

                Assert.NotNull(returnedCollectionPage);
                Assert.Equal(calendarsCollectionPage, returnedCollectionPage);
                Assert.Equal(
                    calendarsCollectionResponse.AdditionalData,
                    returnedCollectionPage.AdditionalData);

                var nextPageRequest = returnedCollectionPage.NextPageRequest as UserCalendarsCollectionRequest;

                Assert.NotNull(nextPageRequest);
                Assert.Equal(new Uri(requestUrl), new Uri(nextPageRequest.RequestUrl));
                Assert.Equal(1, nextPageRequest.QueryOptions.Count);
                Assert.Equal(nextQueryKey, nextPageRequest.QueryOptions[0].Name);
                Assert.Equal(nextQueryValue, nextPageRequest.QueryOptions[0].Value);
            }
        }

        /// <summary>
        /// Tests the AddAsync() method on an entity collection request.
        /// </summary>
        [Fact]
        public async Task AddAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format("{0}/me/calendars", this.graphBaseUrl);

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Post),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                var addedCalendar = new Calendar();

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(addedCalendar))
                    .Returns("body string");

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<Calendar>(It.IsAny<string>()))
                    .Returns(addedCalendar);

                var returnedCalendar = await this.graphServiceClient.Me.Calendars.Request().AddAsync(addedCalendar);

                Assert.Equal(addedCalendar, returnedCalendar);
            }
        }

        /// <summary>
        /// Tests that the AddAsync() method on an abstract entity collection request includes @odata.type.
        /// </summary>
        [Fact]
        public async Task AddAsync_AbstractEntityContainsODataType()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format("{0}/groups/groupId/threads/threadId/posts/postId/attachments", this.graphBaseUrl);

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Post),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                var attachmentToAdd = new FileAttachment();

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(
                        It.Is<FileAttachment>(attachment => string.Equals("#microsoft.graph.fileAttachment", attachment.ODataType))))
                    .Returns("body string");

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<Attachment>(It.IsAny<string>()))
                    .Returns(attachmentToAdd);

                var returnedAttachment = await this.graphServiceClient
                    .Groups["groupId"]
                    .Threads["threadId"]
                    .Posts["postId"]
                    .Attachments
                    .Request()
                    .AddAsync(attachmentToAdd);

                Assert.Equal(attachmentToAdd, returnedAttachment);
            }
        }

        /// <summary>
        /// Tests the Expand() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Expand()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Expand("contacts") as UserContactFoldersCollectionRequest;

            Assert.NotNull(contactFoldersCollectionRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl));
            Assert.Equal(1, contactFoldersCollectionRequest.QueryOptions.Count);
            Assert.Equal("$expand", contactFoldersCollectionRequest.QueryOptions[0].Name);
            Assert.Equal("contacts", contactFoldersCollectionRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Expand() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void ExpandExpression()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Expand(cf => cf.Contacts) as UserContactFoldersCollectionRequest;

            Assert.NotNull(contactFoldersCollectionRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl));
            Assert.Equal(1, contactFoldersCollectionRequest.QueryOptions.Count);
            Assert.Equal("$expand", contactFoldersCollectionRequest.QueryOptions[0].Name);
            Assert.Equal("contacts", contactFoldersCollectionRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Select() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Select()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Select("value") as UserContactFoldersCollectionRequest;

            Assert.NotNull(contactFoldersCollectionRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl));
            Assert.Equal(1, contactFoldersCollectionRequest.QueryOptions.Count);
            Assert.Equal("$select", contactFoldersCollectionRequest.QueryOptions[0].Name);
            Assert.Equal("value", contactFoldersCollectionRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Select() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void SelectExpression()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Select(cf => cf.Contacts) as UserContactFoldersCollectionRequest;

            Assert.NotNull(contactFoldersCollectionRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl));
            Assert.Equal(1, contactFoldersCollectionRequest.QueryOptions.Count);
            Assert.Equal("$select", contactFoldersCollectionRequest.QueryOptions[0].Name);
            Assert.Equal("contacts", contactFoldersCollectionRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Top() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Top()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Top(1) as UserContactFoldersCollectionRequest;

            Assert.NotNull(contactFoldersCollectionRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl));
            Assert.Equal(1, contactFoldersCollectionRequest.QueryOptions.Count);
            Assert.Equal("$top", contactFoldersCollectionRequest.QueryOptions[0].Name);
            Assert.Equal("1", contactFoldersCollectionRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Filter() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Filter()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Filter("value") as UserContactFoldersCollectionRequest;

            Assert.NotNull(contactFoldersCollectionRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl));
            Assert.Equal(1, contactFoldersCollectionRequest.QueryOptions.Count);
            Assert.Equal("$filter", contactFoldersCollectionRequest.QueryOptions[0].Name);
            Assert.Equal("value", contactFoldersCollectionRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Skip() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Skip()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Skip(1) as UserContactFoldersCollectionRequest;

            Assert.NotNull(contactFoldersCollectionRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl));
            Assert.Equal(1, contactFoldersCollectionRequest.QueryOptions.Count);
            Assert.Equal("$skip", contactFoldersCollectionRequest.QueryOptions[0].Name);
            Assert.Equal("1", contactFoldersCollectionRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the OrderBy() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void OrderBy()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().OrderBy("value") as UserContactFoldersCollectionRequest;

            Assert.NotNull(contactFoldersCollectionRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl));
            Assert.Equal(1, contactFoldersCollectionRequest.QueryOptions.Count);
            Assert.Equal("$orderby", contactFoldersCollectionRequest.QueryOptions[0].Name);
            Assert.Equal("value", contactFoldersCollectionRequest.QueryOptions[0].Value);
        }
    }
}