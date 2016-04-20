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

    using Constants = Microsoft.Graph.Constants;

    [TestClass]
    public class ActionRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for an action with multiple required parameters (assignLicence).
        /// </summary>
        [TestMethod]
        public void MultipleRequiredParameters()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.assignLicense", this.graphBaseUrl);

            var addLicenses = new List<AssignedLicense> { new AssignedLicense() };
            var removeLicenses = new List<Guid> { new Guid() };

            var assignLicenseRequestBuilder = this.graphServiceClient.Me.AssignLicense(addLicenses, removeLicenses) as UserAssignLicenseRequestBuilder;

            Assert.IsNotNull(assignLicenseRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(expectedRequestUrl, assignLicenseRequestBuilder.RequestUrl, "Unexpected request builder URL.");
            Assert.AreEqual(addLicenses, assignLicenseRequestBuilder.AddLicenses, "Unexpected value for AddLicenses.");
            Assert.AreEqual(removeLicenses, assignLicenseRequestBuilder.RemoveLicenses, "Unexpected value for RemoveLicenses.");

            var assignLicenseRequest = assignLicenseRequestBuilder.Request() as UserAssignLicenseRequest;
            Assert.IsNotNull(assignLicenseRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(assignLicenseRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual("POST", assignLicenseRequest.Method, "Unexpected HTTP method.");
            Assert.AreEqual(addLicenses, assignLicenseRequest.RequestBody.AddLicenses, "Unexpected value for AddLicenses in request body.");
            Assert.AreEqual(removeLicenses, assignLicenseRequest.RequestBody.RemoveLicenses, "Unexpected value for RemoveLicenses in request body.");
        }

        /// <summary>
        /// Tests building a request for an action with an optional parameter set to null that's not a nullable type.
        /// </summary>
        [TestMethod]
        public void OptionalParameterWithNonNullableType_NullValue()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.getMemberGroups", this.graphBaseUrl);

            var getMemberGroupsRequestBuilder = this.graphServiceClient.Me.GetMemberGroups() as DirectoryObjectGetMemberGroupsRequestBuilder;

            Assert.IsNotNull(getMemberGroupsRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(expectedRequestUrl, getMemberGroupsRequestBuilder.RequestUrl, "Unexpected request builder URL.");

            var getMemberGroupsRequest = getMemberGroupsRequestBuilder.Request() as DirectoryObjectGetMemberGroupsRequest;
            Assert.IsNotNull(getMemberGroupsRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(getMemberGroupsRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual("POST", getMemberGroupsRequest.Method, "Unexpected HTTP method.");
            Assert.IsNull(getMemberGroupsRequest.RequestBody.SecurityEnabledOnly, "Unexpected value for SecurityEnabledOnly in request body.");
        }

        /// <summary>
        /// Tests building a request for an action with an optional parameter that's not a nullable type.
        /// </summary>
        [TestMethod]
        public void OptionalParameterWithNonNullableType_ValueSet()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.getMemberGroups", this.graphBaseUrl);

            var getMemberGroupsRequestBuilder = this.graphServiceClient.Me.GetMemberGroups(true) as DirectoryObjectGetMemberGroupsRequestBuilder;

            Assert.IsNotNull(getMemberGroupsRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(expectedRequestUrl, getMemberGroupsRequestBuilder.RequestUrl, "Unexpected request builder URL.");

            var getMemberGroupsRequest = getMemberGroupsRequestBuilder.Request() as DirectoryObjectGetMemberGroupsRequest;
            Assert.IsNotNull(getMemberGroupsRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(getMemberGroupsRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual("POST", getMemberGroupsRequest.Method, "Unexpected HTTP method.");
            Assert.IsTrue(getMemberGroupsRequest.RequestBody.SecurityEnabledOnly.Value, "Unexpected value for SecurityEnabledOnly in request body.");
        }

        /// <summary>
        /// Tests that an exception is thrown when the first of required parameters passed to an action request is null (assignLicence).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void MultipleRequiredParameters_FirstParameterNull()
        {
            var removeLicenses = new List<Guid> { new Guid() };

            try
            {
                var assignLicenseRequestBuilder = this.graphServiceClient.Me.AssignLicense(null, removeLicenses).Request();
            }
            catch (ServiceException serviceException)
            {
                Assert.IsTrue(serviceException.IsMatch(GraphErrorCode.InvalidRequest.ToString()), "Unexpected error code thrown.");
                Assert.AreEqual(
                    "addLicenses is a required parameter for this method request.",
                    serviceException.Error.Message,
                    "Unexpected error code thrown.");

                throw;
            }
        }

        /// <summary>
        /// Tests that an exception is thrown when the second of required parameters passed to an action request is null (assignLicence).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void MultipleRequiredParameters_LastParameterNull()
        {
            var addLicenses = new List<AssignedLicense> { new AssignedLicense() };

            try
            {
                var assignLicenseRequestBuilder = this.graphServiceClient.Me.AssignLicense(addLicenses, null).Request();
            }
            catch (ServiceException serviceException)
            {
                Assert.IsTrue(serviceException.IsMatch(GraphErrorCode.InvalidRequest.ToString()), "Unexpected error code thrown.");
                Assert.AreEqual(
                    "removeLicenses is a required parameter for this method request.",
                    serviceException.Error.Message,
                    "Unexpected error code thrown.");

                throw;
            }
        }

        /// <summary>
        /// Tests building a request for an action that takes in no parameters (send).
        /// </summary>
        [TestMethod]
        public void NoParameters()
        {
            var messageId = "messageId";
            
            var expectedRequestUrl = string.Format("{0}/me/mailFolders/Drafts/messages/{1}/microsoft.graph.send", this.graphBaseUrl, messageId);
            
            var sendRequestBuilder = this.graphServiceClient.Me.MailFolders.Drafts.Messages[messageId].Send() as MessageSendRequestBuilder;

            Assert.IsNotNull(sendRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(expectedRequestUrl, sendRequestBuilder.RequestUrl, "Unexpected request builder URL.");

            var sendRequest = sendRequestBuilder.Request() as MessageSendRequest;
            Assert.IsNotNull(sendRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(sendRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual("POST", sendRequest.Method, "Unexpected HTTP method.");
        }

        /// <summary>
        /// Tests the PostAsync() method for an action that returns a collection of primitives (checkMemberGroups).
        /// The action is also inherited from the base class.
        /// </summary>
        [TestMethod]
        public async Task PostAsync_CollectionOfPrimitivesReturnType()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;
                
                var nextQueryKey = "key";
                var nextQueryValue = "value";

                var requestUrl = string.Format("{0}/me/microsoft.graph.checkMemberGroups", this.graphBaseUrl);
                var nextPageRequestUrl = string.Format("{0}?{1}={2}", requestUrl, nextQueryKey, nextQueryValue);

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Post)))
                    .Returns(Task.FromResult(httpResponseMessage));

                var checkMemberGroupsCollectionPage = new DirectoryObjectCheckMemberGroupsCollectionPage
                {
                    "value 1",
                    "value 2",
                };

                var checkMemberGroupsCollectionResponse = new DirectoryObjectCheckMemberGroupsCollectionResponse
                {
                    Value = checkMemberGroupsCollectionPage,
                    AdditionalData = new Dictionary<string, object> { { "@odata.nextLink", nextPageRequestUrl } },
                };
                
                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<DirectoryObjectCheckMemberGroupsRequestBody>()))
                    .Returns("request body string");

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DirectoryObjectCheckMemberGroupsCollectionResponse>(It.IsAny<string>()))
                    .Returns(checkMemberGroupsCollectionResponse);

                var returnedCollectionPage = await this.graphServiceClient.Me.CheckMemberGroups(new List<string>()).Request().PostAsync();

                Assert.IsNotNull(returnedCollectionPage, "Collection page not returned.");
                Assert.AreEqual(checkMemberGroupsCollectionPage, returnedCollectionPage, "Unexpected collection page returned.");
                Assert.AreEqual(
                    checkMemberGroupsCollectionPage.AdditionalData,
                    returnedCollectionPage.AdditionalData,
                    "Additional data not initialized on collection page.");

                var nextPageRequest = returnedCollectionPage.NextPageRequest as DirectoryObjectCheckMemberGroupsRequest;

                Assert.IsNotNull(nextPageRequest, "Next page request not returned.");
                Assert.AreEqual(new Uri(requestUrl), new Uri(nextPageRequest.RequestUrl), "Unexpected URL initialized for next page request.");
                Assert.AreEqual(1, nextPageRequest.QueryOptions.Count, "Unexpected query options initialized.");
                Assert.AreEqual(nextQueryKey, nextPageRequest.QueryOptions[0].Name, "Unexpected query option name initialized.");
                Assert.AreEqual(nextQueryValue, nextPageRequest.QueryOptions[0].Value, "Unexpected query option value initialized.");
            }
        }

        /// <summary>
        /// Tests the PostAsync() method for an action that returns a single entity (createLink).
        /// </summary>
        [TestMethod]
        public async Task PostAsync_NonCollectionReturnType()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/drive/items/id/microsoft.graph.createLink";
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Post)))
                    .Returns(Task.FromResult(httpResponseMessage));

                var expectedPermission = new Permission { Id = "id", Link = new SharingLink { Type = "edit" } };

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<DriveItemCreateLinkRequestBody>()))
                    .Returns("request body value");

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<Permission>(It.IsAny<string>()))
                    .Returns(expectedPermission);

                var permission = await this.graphServiceClient.Me.Drive.Items["id"].CreateLink("edit", "scope").Request().PostAsync();

                Assert.IsNotNull(permission, "Permission not returned.");
                Assert.AreEqual(expectedPermission, permission, "Unexpected permission returned.");
            }
        }

        /// <summary>
        /// Tests the PostAsync() method for an action that returns nothing (send).
        /// </summary>
        [TestMethod]
        public async Task PostAsync_NoReturnValue()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/mailFolders/Drafts/messages/messageId/microsoft.graph.send";
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl))))
                    .Returns(Task.FromResult(httpResponseMessage));

                await this.graphServiceClient.Me.MailFolders.Drafts.Messages["messageId"].Send().Request().PostAsync();
            }
        }
    }
}