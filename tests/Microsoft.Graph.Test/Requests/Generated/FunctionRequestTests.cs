// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Requests.Generated
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Graph.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class FunctionRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for a function with no parameteres (delta).
        /// </summary>
        [TestMethod]
        public void NoParameters()
        {
            var expectedRequestUrl = string.Format("{0}/me/drive/root/microsoft.graph.delta", graphBaseUrl);

            var deltaRequestBuilder = this.graphServiceClient.Me.Drive.Root.Delta() as DriveItemDeltaRequestBuilder;

            Assert.IsNotNull(deltaRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(expectedRequestUrl, deltaRequestBuilder.RequestUrl, "Unexpected request builder URL.");

            var deltaRequest = deltaRequestBuilder.Request() as DriveItemDeltaRequest;
            Assert.IsNotNull(deltaRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(deltaRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual("GET", deltaRequest.Method, "Unexpected HTTP method.");
        }

        /// <summary>
        /// Tests building a request while passing a null value to a function's only parameter, which is nullable (search).
        /// </summary>
        [TestMethod]
        public void OptionalParameter_ParameterNull()
        {
            var methodBaseUrl = string.Format("{0}/me/drive/root/microsoft.graph.search", this.graphBaseUrl);
            var expectedRequestUrl = string.Format("{0}(q=null)", methodBaseUrl);

            var searchRequestBuilder = this.graphServiceClient.Me.Drive.Root.Search() as DriveItemSearchRequestBuilder;

            Assert.IsNotNull(searchRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(methodBaseUrl, searchRequestBuilder.RequestUrl, "Unexpected request builder URL.");

            var searchRequest = searchRequestBuilder.Request() as DriveItemSearchRequest;
            Assert.IsNotNull(searchRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(searchRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual("GET", searchRequest.Method, "Unexpected HTTP method.");
        }

        /// <summary>
        /// Tests building a request while passing a value to a function's only parameter, which is nullable (search).
        /// </summary>
        [TestMethod]
        public void OptionalParameter_ParameterSet()
        {
            var q = "value";
            
            var methodBaseUrl = string.Format("{0}/me/drive/root/microsoft.graph.search", this.graphBaseUrl);
            var expectedRequestUrl = string.Format("{0}(q='{1}')", methodBaseUrl, q);

            var searchRequestBuilder = this.graphServiceClient.Me.Drive.Root.Search(q) as DriveItemSearchRequestBuilder;

            Assert.IsNotNull(searchRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(methodBaseUrl, searchRequestBuilder.RequestUrl, "Unexpected request builder URL.");

            var searchRequest = searchRequestBuilder.Request() as DriveItemSearchRequest;
            Assert.IsNotNull(searchRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(searchRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual("GET", searchRequest.Method, "Unexpected HTTP method.");
        }

        /// <summary>
        /// Tests building a request while passing a null value to a function's nullable parameter (reminderView).
        /// </summary>
        [TestMethod]
        public void RequiredAndOptionalParameters_OptionalParameterNull()
        {
            var startDateTime = "now";
            
            var methodBaseUrl = string.Format("{0}/me/microsoft.graph.reminderView", this.graphBaseUrl);
            var expectedRequestUrl = string.Format("{0}(startDateTime='{1}',endDateTime=null)", methodBaseUrl, startDateTime);

            var reminderViewRequestBuilder = this.graphServiceClient.Me.ReminderView(startDateTime) as UserReminderViewRequestBuilder;

            Assert.IsNotNull(reminderViewRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(methodBaseUrl, reminderViewRequestBuilder.RequestUrl, "Unexpected request builder URL.");

            var reminderViewRequest = reminderViewRequestBuilder.Request() as UserReminderViewRequest;
            Assert.IsNotNull(reminderViewRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual("GET", reminderViewRequest.Method, "Unexpected HTTP method.");
        }

        /// <summary>
        /// Tests building a request while passing a value to a function's nullable parameter (reminderView).
        /// </summary>
        [TestMethod]
        public void RequiredAndOptionalParameters_AllParametersSet()
        {
            var startDateTime = "now";
            var endDateTime = "later";
            
            var methodBaseUrl = string.Format("{0}/me/microsoft.graph.reminderView", this.graphBaseUrl);
            var expectedRequestUrl = string.Format("{0}(startDateTime='{1}',endDateTime='{2}')", methodBaseUrl, startDateTime, endDateTime);

            var reminderViewRequestBuilder = this.graphServiceClient.Me.ReminderView(startDateTime, endDateTime) as UserReminderViewRequestBuilder;

            Assert.IsNotNull(reminderViewRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(methodBaseUrl, reminderViewRequestBuilder.RequestUrl, "Unexpected request builder URL.");

            var reminderViewRequest = reminderViewRequestBuilder.Request() as UserReminderViewRequest;
            Assert.IsNotNull(reminderViewRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual("GET", reminderViewRequest.Method, "Unexpected HTTP method.");
        }

        /// <summary>
        /// Tests the GetAsync() method for a function that returns a collection (reminderView).
        /// </summary>
        [TestMethod]
        public async Task CollectionReturnType_GetAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;
                
                var nextQueryKey = "key";
                var nextQueryValue = "value";

                var methodBaseUrl = string.Format("{0}/me/microsoft.graph.reminderView", this.graphBaseUrl);
                var requestUrl = string.Format("{0}(startDateTime='now',endDateTime='later')", methodBaseUrl);
                var nextPageRequestUrl = string.Format("{0}?{1}={2}", requestUrl, nextQueryKey, nextQueryValue);

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Get)))
                    .Returns(Task.FromResult(httpResponseMessage));

                var userReminderViewCollectionPage = new UserReminderViewCollectionPage
                {
                    new Reminder { EventId = "id 1" },
                    new Reminder { EventId = "id 2" },
                };

                var userReminderViewCollectionResponse = new UserReminderViewCollectionResponse
                {
                    Value = userReminderViewCollectionPage,
                    AdditionalData = new Dictionary<string, object> { { "@odata.nextLink", nextPageRequestUrl } },
                };

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<UserReminderViewCollectionResponse>(It.IsAny<string>()))
                    .Returns(userReminderViewCollectionResponse);

                var returnedCollectionPage = await this.graphServiceClient.Me.ReminderView("now", "later").Request().GetAsync() as UserReminderViewCollectionPage;

                Assert.IsNotNull(returnedCollectionPage, "Collection page not returned.");
                Assert.AreEqual(userReminderViewCollectionPage, returnedCollectionPage, "Unexpected collection page returned.");
                Assert.AreEqual(
                    userReminderViewCollectionResponse.AdditionalData,
                    returnedCollectionPage.AdditionalData,
                    "Additional data not initialized on collection page.");

                var nextPageRequest = returnedCollectionPage.NextPageRequest as UserReminderViewRequest;

                Assert.IsNotNull(nextPageRequest, "Next page request not returned.");
                Assert.AreEqual(new Uri(requestUrl), new Uri(nextPageRequest.RequestUrl), "Unexpected URL initialized for next page request.");
                Assert.AreEqual(1, nextPageRequest.QueryOptions.Count, "Unexpected query options initialized.");
                Assert.AreEqual(nextQueryKey, nextPageRequest.QueryOptions[0].Name, "Unexpected query option name initialized.");
                Assert.AreEqual(nextQueryValue, nextPageRequest.QueryOptions[0].Value, "Unexpected query option value initialized.");
            }
        }

        /// <summary>
        /// Tests that an exception is thrown when null is passed during request building for a non-nullable function parameter (reminderView).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void RequiredAndOptionalParameters_RequiredParameterNull()
        {
            try
            {
                var reminderViewRequestBuilder = this.graphServiceClient.Me.ReminderView(null).Request();
            }
            catch (ServiceException serviceException)
            {
                Assert.IsTrue(serviceException.IsMatch(GraphErrorCode.InvalidRequest.ToString()), "Unexpected error code thrown.");
                Assert.AreEqual(
                    "startDateTime is a required parameter for this method request.",
                    serviceException.Error.Message,
                    "Unexpected error code thrown.");

                throw;
            }
        }

        /// <summary>
        /// Tests the Expand() method on a function request (reminderView).
        /// </summary>
        [TestMethod]
        public void Expand()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Expand("value") as UserReminderViewRequest;

            Assert.IsNotNull(reminderViewRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, reminderViewRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$expand", reminderViewRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", reminderViewRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Select() method on a function request (reminderView).
        /// </summary>
        [TestMethod]
        public void Select()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Select("value") as UserReminderViewRequest;

            Assert.IsNotNull(reminderViewRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, reminderViewRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$select", reminderViewRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", reminderViewRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Top() method on a function request that returns a collection (reminderView).
        /// </summary>
        [TestMethod]
        public void Top()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Top(1) as UserReminderViewRequest;

            Assert.IsNotNull(reminderViewRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, reminderViewRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$top", reminderViewRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("1", reminderViewRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Filter() method on a function request that returns a collection (reminderView).
        /// </summary>
        [TestMethod]
        public void Filter()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Filter("value") as UserReminderViewRequest;

            Assert.IsNotNull(reminderViewRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, reminderViewRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$filter", reminderViewRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", reminderViewRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Skip() method on a function request that returns a collection (reminderView).
        /// </summary>
        [TestMethod]
        public void Skip()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Skip(1) as UserReminderViewRequest;

            Assert.IsNotNull(reminderViewRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, reminderViewRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$skip", reminderViewRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("1", reminderViewRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the OrderBy() method on a function request that returns a collection (reminderView).
        /// </summary>
        [TestMethod]
        public void OrderBy()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().OrderBy("value") as UserReminderViewRequest;

            Assert.IsNotNull(reminderViewRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, reminderViewRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$orderby", reminderViewRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", reminderViewRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }
    }
}