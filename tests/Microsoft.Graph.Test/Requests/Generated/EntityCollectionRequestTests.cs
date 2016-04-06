// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Requests.Generated
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq.Expressions;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Graph;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class EntityCollectionRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for an entity collection.
        /// </summary>
        [TestMethod]
        public void BuildRequest()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/calendars");
            var calendarsCollectionRequestBuilder = this.graphServiceClient.Me.Calendars as UserCalendarsCollectionRequestBuilder;
            
            Assert.IsNotNull(calendarsCollectionRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(expectedRequestUri, new Uri(calendarsCollectionRequestBuilder.RequestUrl), "Unexpected request URL.");

            var calendarsCollectionRequest = calendarsCollectionRequestBuilder.Request() as UserCalendarsCollectionRequest;
            Assert.IsNotNull(calendarsCollectionRequest, "Unexpected request.");
            Assert.AreEqual(expectedRequestUri, new Uri(calendarsCollectionRequest.RequestUrl), "Unexpected request URL.");
        }

        /// <summary>
        /// Tests the GetAsync() method on an entity collection request.
        /// </summary>
        [TestMethod]
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
                                && request.Method == HttpMethod.Get)))
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

                Assert.IsNotNull(returnedCollectionPage, "Collection page not returned.");
                Assert.AreEqual(calendarsCollectionPage, returnedCollectionPage, "Unexpected collection page returned.");
                Assert.AreEqual(
                    calendarsCollectionResponse.AdditionalData,
                    returnedCollectionPage.AdditionalData,
                    "Additional data not initialized on collection page.");

                var nextPageRequest = returnedCollectionPage.NextPageRequest as UserCalendarsCollectionRequest;

                Assert.IsNotNull(nextPageRequest, "Next page request not returned.");
                Assert.AreEqual(new Uri(requestUrl), new Uri(nextPageRequest.RequestUrl), "Unexpected URL initialized for next page request.");
                Assert.AreEqual(1, nextPageRequest.QueryOptions.Count, "Unexpected query options initialized.");
                Assert.AreEqual(nextQueryKey, nextPageRequest.QueryOptions[0].Name, "Unexpected query option name initialized.");
                Assert.AreEqual(nextQueryValue, nextPageRequest.QueryOptions[0].Value, "Unexpected query option value initialized.");
            }
        }

        /// <summary>
        /// Tests the AddAsync() method on an entity collection request.
        /// </summary>
        [TestMethod]
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
                                && request.Method == HttpMethod.Post)))
                    .Returns(Task.FromResult(httpResponseMessage));

                var addedCalendar = new Calendar();

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(addedCalendar))
                    .Returns("body string");

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<Calendar>(It.IsAny<string>()))
                    .Returns(addedCalendar);

                var returnedCalendar = await this.graphServiceClient.Me.Calendars.Request().AddAsync(addedCalendar);
                
                Assert.AreEqual(addedCalendar, returnedCalendar, "Unexpected calendar returned.");
            }
        }

        /// <summary>
        /// Tests that the AddAsync() method on an abstract entity collection request includes @odata.type.
        /// </summary>
        [TestMethod]
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
                                && request.Method == HttpMethod.Post)))
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

                Assert.AreEqual(attachmentToAdd, returnedAttachment, "Unexpected attachment returned.");
            }
        }

        /// <summary>
        /// Tests the Expand() method on an entity collection request (contactFolders).
        /// </summary>
        [TestMethod]
        public void Expand()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Expand("value") as UserContactFoldersCollectionRequest;

            Assert.IsNotNull(contactFoldersCollectionRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, contactFoldersCollectionRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$expand", contactFoldersCollectionRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", contactFoldersCollectionRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Select() method on an entity collection request (contactFolders).
        /// </summary>
        [TestMethod]
        public void Select()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Select("value") as UserContactFoldersCollectionRequest;

            Assert.IsNotNull(contactFoldersCollectionRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, contactFoldersCollectionRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$select", contactFoldersCollectionRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", contactFoldersCollectionRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Select() method with an expression on an entity collection request (calendarEvents).
        /// </summary>
        [TestMethod]
        public void SelectExpression()
        {
            var expectedRequestUrl = $"{this.graphBaseUrl}/me/events";

            IUserEventsCollectionRequest collectionRequest = this.graphServiceClient.Me.Events.Request().Select( s => new { NotBody=s.Body, NotSubject=s.Subject}) as UserEventsCollectionRequest;

            Assert.IsNotNull(collectionRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(collectionRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, collectionRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$select", collectionRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("Body,Subject", collectionRequest.QueryOptions[0].Value, "Unexpected query option values.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SelectExpressionNull()
        {
            IUserEventsCollectionRequest collectionRequest = this.graphServiceClient.Me.Events.Request().Select((Expression<Func<Microsoft.Graph.Event, object>>)null) as UserEventsCollectionRequest;
        }


        /// <summary>
        /// Tests the Top() method on an entity collection request (contactFolders).
        /// </summary>
        [TestMethod]
        public void Top()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Top(1) as UserContactFoldersCollectionRequest;

            Assert.IsNotNull(contactFoldersCollectionRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, contactFoldersCollectionRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$top", contactFoldersCollectionRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("1", contactFoldersCollectionRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Filter() method on an entity collection request (contactFolders).
        /// </summary>
        [TestMethod]
        public void Filter()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Filter("value") as UserContactFoldersCollectionRequest;

            Assert.IsNotNull(contactFoldersCollectionRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, contactFoldersCollectionRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$filter", contactFoldersCollectionRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", contactFoldersCollectionRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Skip() method on an entity collection request (contactFolders).
        /// </summary>
        [TestMethod]
        public void Skip()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().Skip(1) as UserContactFoldersCollectionRequest;

            Assert.IsNotNull(contactFoldersCollectionRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, contactFoldersCollectionRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$skip", contactFoldersCollectionRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("1", contactFoldersCollectionRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the OrderBy() method on an entity collection request (contactFolders).
        /// </summary>
        [TestMethod]
        public void OrderBy()
        {
            var expectedRequestUrl = string.Format("{0}/me/contactFolders", this.graphBaseUrl);

            var contactFoldersCollectionRequest = this.graphServiceClient.Me.ContactFolders.Request().OrderBy("value") as UserContactFoldersCollectionRequest;

            Assert.IsNotNull(contactFoldersCollectionRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(contactFoldersCollectionRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, contactFoldersCollectionRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$orderby", contactFoldersCollectionRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", contactFoldersCollectionRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }
    }
}
