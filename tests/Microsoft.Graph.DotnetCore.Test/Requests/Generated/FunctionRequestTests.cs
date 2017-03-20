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
    public class FunctionRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for a function with no parameteres (delta).
        /// </summary>
        [Fact]
        public void NoParameters()
        {
            var expectedRequestUrl = string.Format("{0}/me/drive/root/microsoft.graph.delta", graphBaseUrl);

            var deltaRequestBuilder = this.graphServiceClient.Me.Drive.Root.Delta() as DriveItemDeltaRequestBuilder;

            Assert.NotNull(deltaRequestBuilder);
            Assert.Equal(expectedRequestUrl, deltaRequestBuilder.RequestUrl);

            var deltaRequest = deltaRequestBuilder.Request() as DriveItemDeltaRequest;
            Assert.NotNull(deltaRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(deltaRequest.RequestUrl));
            Assert.Equal("GET", deltaRequest.Method);
        }

        /// <summary>
        /// Tests building a request while passing a null value to a function's only parameter, which is nullable (search).
        /// </summary>
        [Fact]
        public void OptionalParameter_ParameterNull()
        {
            var methodBaseUrl = string.Format("{0}/me/drive/root/microsoft.graph.search", this.graphBaseUrl);
            var expectedRequestUrl = string.Format("{0}(q=null)", methodBaseUrl);

            var searchRequestBuilder = this.graphServiceClient.Me.Drive.Root.Search() as DriveItemSearchRequestBuilder;

            Assert.NotNull(searchRequestBuilder);
            Assert.Equal(methodBaseUrl, searchRequestBuilder.RequestUrl);

            var searchRequest = searchRequestBuilder.Request() as DriveItemSearchRequest;
            Assert.NotNull(searchRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(searchRequest.RequestUrl));
            Assert.Equal("GET", searchRequest.Method);
        }

        /// <summary>
        /// Tests building a request while passing a value to a function's only parameter, which is nullable (search).
        /// </summary>
        [Fact]
        public void OptionalParameter_ParameterSet()
        {
            var q = "value";

            var methodBaseUrl = string.Format("{0}/me/drive/root/microsoft.graph.search", this.graphBaseUrl);
            var expectedRequestUrl = string.Format("{0}(q='{1}')", methodBaseUrl, q);

            var searchRequestBuilder = this.graphServiceClient.Me.Drive.Root.Search(q) as DriveItemSearchRequestBuilder;

            Assert.NotNull(searchRequestBuilder);
            Assert.Equal(methodBaseUrl, searchRequestBuilder.RequestUrl);

            var searchRequest = searchRequestBuilder.Request() as DriveItemSearchRequest;
            Assert.NotNull(searchRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(searchRequest.RequestUrl));
            Assert.Equal("GET", searchRequest.Method);
        }

        /// <summary>
        /// Tests building a request while passing a null value to a function's nullable parameter (reminderView).
        /// </summary>
        [Fact]
        public void RequiredAndOptionalParameters_OptionalParameterNull()
        {
            var startDateTime = "now";

            var methodBaseUrl = string.Format("{0}/me/microsoft.graph.reminderView", this.graphBaseUrl);
            var expectedRequestUrl = string.Format("{0}(startDateTime='{1}',endDateTime=null)", methodBaseUrl, startDateTime);

            var reminderViewRequestBuilder = this.graphServiceClient.Me.ReminderView(startDateTime) as UserReminderViewRequestBuilder;

            Assert.NotNull(reminderViewRequestBuilder);
            Assert.Equal(methodBaseUrl, reminderViewRequestBuilder.RequestUrl);

            var reminderViewRequest = reminderViewRequestBuilder.Request() as UserReminderViewRequest;
            Assert.NotNull(reminderViewRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl));
            Assert.Equal("GET", reminderViewRequest.Method);
        }

        /// <summary>
        /// Tests building a request while passing a value to a function's nullable parameter (reminderView).
        /// </summary>
        [Fact]
        public void RequiredAndOptionalParameters_AllParametersSet()
        {
            var startDateTime = "now";
            var endDateTime = "later";

            var methodBaseUrl = string.Format("{0}/me/microsoft.graph.reminderView", this.graphBaseUrl);
            var expectedRequestUrl = string.Format("{0}(startDateTime='{1}',endDateTime='{2}')", methodBaseUrl, startDateTime, endDateTime);

            var reminderViewRequestBuilder = this.graphServiceClient.Me.ReminderView(startDateTime, endDateTime) as UserReminderViewRequestBuilder;

            Assert.NotNull(reminderViewRequestBuilder);
            Assert.Equal(methodBaseUrl, reminderViewRequestBuilder.RequestUrl);

            var reminderViewRequest = reminderViewRequestBuilder.Request() as UserReminderViewRequest;
            Assert.NotNull(reminderViewRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl));
            Assert.Equal("GET", reminderViewRequest.Method);
        }

        /// <summary>
        /// Tests the GetAsync() method for a function that returns a collection (reminderView).
        /// </summary>
        [Fact]
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
                                && request.Method == HttpMethod.Get),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
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

                Assert.NotNull(returnedCollectionPage);
                Assert.Equal(userReminderViewCollectionPage, returnedCollectionPage);
                Assert.Equal(
                    userReminderViewCollectionResponse.AdditionalData,
                    returnedCollectionPage.AdditionalData);

                var nextPageRequest = returnedCollectionPage.NextPageRequest as UserReminderViewRequest;

                Assert.NotNull(nextPageRequest);
                Assert.Equal(new Uri(requestUrl), new Uri(nextPageRequest.RequestUrl));
                Assert.Equal(1, nextPageRequest.QueryOptions.Count);
                Assert.Equal(nextQueryKey, nextPageRequest.QueryOptions[0].Name);
                Assert.Equal(nextQueryValue, nextPageRequest.QueryOptions[0].Value);
            }
        }

        /// <summary>
        /// Tests that an exception is thrown when null is passed during request building for a non-nullable function parameter (reminderView).
        /// </summary>
        [Fact]
        public void RequiredAndOptionalParameters_RequiredParameterNull()
        {
            try
            {
                Assert.Throws<ServiceException>(() => this.graphServiceClient.Me.ReminderView(null).Request());
            }
            catch (ServiceException serviceException)
            {
                Assert.True(serviceException.IsMatch(GraphErrorCode.InvalidRequest.ToString()));
                Assert.Equal(
                    "startDateTime is a required parameter for this method request.",
                    serviceException.Error.Message);

                throw;
            }
        }

        /// <summary>
        /// Tests the Expand() method on a function request (reminderView).
        /// </summary>
        [Fact]
        public void Expand()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Expand("value") as UserReminderViewRequest;

            Assert.NotNull(reminderViewRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl));
            Assert.Equal(1, reminderViewRequest.QueryOptions.Count);
            Assert.Equal("$expand", reminderViewRequest.QueryOptions[0].Name);
            Assert.Equal("value", reminderViewRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Select() method on a function request (reminderView).
        /// </summary>
        [Fact]
        public void Select()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Select("value") as UserReminderViewRequest;

            Assert.NotNull(reminderViewRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl));
            Assert.Equal(1, reminderViewRequest.QueryOptions.Count);
            Assert.Equal("$select", reminderViewRequest.QueryOptions[0].Name);
            Assert.Equal("value", reminderViewRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Top() method on a function request that returns a collection (reminderView).
        /// </summary>
        [Fact]
        public void Top()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Top(1) as UserReminderViewRequest;

            Assert.NotNull(reminderViewRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl));
            Assert.Equal(1, reminderViewRequest.QueryOptions.Count);
            Assert.Equal("$top", reminderViewRequest.QueryOptions[0].Name);
            Assert.Equal("1", reminderViewRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Filter() method on a function request that returns a collection (reminderView).
        /// </summary>
        [Fact]
        public void Filter()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Filter("value") as UserReminderViewRequest;

            Assert.NotNull(reminderViewRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl));
            Assert.Equal(1, reminderViewRequest.QueryOptions.Count);
            Assert.Equal("$filter", reminderViewRequest.QueryOptions[0].Name);
            Assert.Equal("value", reminderViewRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the Skip() method on a function request that returns a collection (reminderView).
        /// </summary>
        [Fact]
        public void Skip()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().Skip(1) as UserReminderViewRequest;

            Assert.NotNull(reminderViewRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl));
            Assert.Equal(1, reminderViewRequest.QueryOptions.Count);
            Assert.Equal("$skip", reminderViewRequest.QueryOptions[0].Name);
            Assert.Equal("1", reminderViewRequest.QueryOptions[0].Value);
        }

        /// <summary>
        /// Tests the OrderBy() method on a function request that returns a collection (reminderView).
        /// </summary>
        [Fact]
        public void OrderBy()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.reminderView(startDateTime='now',endDateTime=null)", this.graphBaseUrl);

            var reminderViewRequest = this.graphServiceClient.Me.ReminderView("now").Request().OrderBy("value") as UserReminderViewRequest;

            Assert.NotNull(reminderViewRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(reminderViewRequest.RequestUrl));
            Assert.Equal(1, reminderViewRequest.QueryOptions.Count);
            Assert.Equal("$orderby", reminderViewRequest.QueryOptions[0].Name);
            Assert.Equal("value", reminderViewRequest.QueryOptions[0].Value);
        }
    }
}