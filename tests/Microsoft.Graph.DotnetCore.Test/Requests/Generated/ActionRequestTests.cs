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
    public class ActionRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for an action with multiple required parameters (assignLicence).
        /// </summary>
        [Fact]
        public void MultipleRequiredParameters()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.assignLicense", this.graphBaseUrl);

            var addLicenses = new List<AssignedLicense> { new AssignedLicense() };
            var removeLicenses = new List<Guid> { new Guid() };

            var assignLicenseRequestBuilder = this.graphServiceClient.Me.AssignLicense(addLicenses, removeLicenses) as UserAssignLicenseRequestBuilder;

            Assert.NotNull(assignLicenseRequestBuilder);
            Assert.Equal(expectedRequestUrl, assignLicenseRequestBuilder.RequestUrl);

            var assignLicenseRequest = assignLicenseRequestBuilder.Request() as UserAssignLicenseRequest;
            Assert.NotNull(assignLicenseRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(assignLicenseRequest.RequestUrl));
            Assert.Equal(addLicenses, assignLicenseRequest.RequestBody.AddLicenses);
            Assert.Equal(removeLicenses, assignLicenseRequest.RequestBody.RemoveLicenses);
        }

        /// <summary>
        /// Tests building a request for an action with an optional parameter set to null that's not a nullable type.
        /// </summary>
        [Fact]
        public void OptionalParameterWithNonNullableType_NullValue()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.getMemberGroups", this.graphBaseUrl);

            var getMemberGroupsRequestBuilder = this.graphServiceClient.Me.GetMemberGroups() as DirectoryObjectGetMemberGroupsRequestBuilder;

            Assert.NotNull(getMemberGroupsRequestBuilder);
            Assert.Equal(expectedRequestUrl, getMemberGroupsRequestBuilder.RequestUrl);

            var getMemberGroupsRequest = getMemberGroupsRequestBuilder.Request() as DirectoryObjectGetMemberGroupsRequest;
            Assert.NotNull(getMemberGroupsRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(getMemberGroupsRequest.RequestUrl));
            Assert.Null(getMemberGroupsRequest.RequestBody.SecurityEnabledOnly);
        }

        /// <summary>
        /// Tests building a request for an action with an optional parameter that's not a nullable type.
        /// </summary>
        [Fact]
        public void OptionalParameterWithNonNullableType_ValueSet()
        {
            var expectedRequestUrl = string.Format("{0}/me/microsoft.graph.getMemberGroups", this.graphBaseUrl);

            var getMemberGroupsRequestBuilder = this.graphServiceClient.Me.GetMemberGroups(true) as DirectoryObjectGetMemberGroupsRequestBuilder;

            Assert.NotNull(getMemberGroupsRequestBuilder);
            Assert.Equal(expectedRequestUrl, getMemberGroupsRequestBuilder.RequestUrl);

            var getMemberGroupsRequest = getMemberGroupsRequestBuilder.Request() as DirectoryObjectGetMemberGroupsRequest;
            Assert.NotNull(getMemberGroupsRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(getMemberGroupsRequest.RequestUrl));
            Assert.True(getMemberGroupsRequest.RequestBody.SecurityEnabledOnly.Value);
        }

        /// <summary>
        /// Tests building a request for an action that takes in no parameters (send).
        /// </summary>
        [Fact]
        public void NoParameters()
        {
            var messageId = "messageId";

            var expectedRequestUrl = string.Format("{0}/me/mailFolders/Drafts/messages/{1}/microsoft.graph.send", this.graphBaseUrl, messageId);

            var sendRequestBuilder = this.graphServiceClient.Me.MailFolders.Drafts.Messages[messageId].Send() as MessageSendRequestBuilder;

            Assert.NotNull(sendRequestBuilder);
            Assert.Equal(expectedRequestUrl, sendRequestBuilder.RequestUrl);

            var sendRequest = sendRequestBuilder.Request() as MessageSendRequest;
            Assert.NotNull(sendRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(sendRequest.RequestUrl));
        }

        /// <summary>
        /// Tests that an exception is thrown when the first of required parameters passed to an action request is null (assignLicence).
        /// </summary>
        [Fact]
        public void MultipleRequiredParameters_FirstParameterNull()
        {
            var removeLicenses = new List<Guid> { new Guid() };

            try
            {
                Assert.Throws<ServiceException>(() => this.graphServiceClient.Me.AssignLicense(null, removeLicenses).Request());
            }
            catch (ServiceException serviceException)
            {
                Assert.True(serviceException.IsMatch(GraphErrorCode.InvalidRequest.ToString()));
                Assert.Equal(
                    "addLicenses is a required parameter for this method request.",
                    serviceException.Error.Message);

                throw;
            }
        }

        /// <summary>
        /// Tests that an exception is thrown when the second of required parameters passed to an action request is null (assignLicence).
        /// </summary>
        [Fact]
        public void MultipleRequiredParameters_LastParameterNull()
        {
            var addLicenses = new List<AssignedLicense> { new AssignedLicense() };

            try
            {
                Assert.Throws<ServiceException>(() => this.graphServiceClient.Me.AssignLicense(addLicenses, null).Request());
            }
            catch (ServiceException serviceException)
            {
                Assert.True(serviceException.IsMatch(GraphErrorCode.InvalidRequest.ToString()));
                Assert.Equal(
                    "removeLicenses is a required parameter for this method request.",
                    serviceException.Error.Message);

                throw;
            }
        }

        /// <summary>
        /// Tests the PostAsync() method for an action that returns a collection of primitives (checkMemberGroups).
        /// The action is also inherited from the base class.
        /// </summary>
        [Fact]
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
                                && request.Method == HttpMethod.Post),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
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

                Assert.NotNull(returnedCollectionPage);
                Assert.Equal(checkMemberGroupsCollectionPage, returnedCollectionPage);
                Assert.Equal(
                    checkMemberGroupsCollectionPage.AdditionalData,
                    returnedCollectionPage.AdditionalData);

                var nextPageRequest = returnedCollectionPage.NextPageRequest as DirectoryObjectCheckMemberGroupsRequest;

                Assert.NotNull(nextPageRequest);
                Assert.Equal(new Uri(requestUrl), new Uri(nextPageRequest.RequestUrl));
                Assert.Equal(1, nextPageRequest.QueryOptions.Count);
                Assert.Equal(nextQueryKey, nextPageRequest.QueryOptions[0].Name);
                Assert.Equal(nextQueryValue, nextPageRequest.QueryOptions[0].Value);
            }
        }

        /// <summary>
        /// Tests the PostAsync() method for an action that returns a single entity (createLink).
        /// </summary>
        [Fact]
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
                                && request.Method == HttpMethod.Post),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                var expectedPermission = new Permission { Id = "id", Link = new SharingLink { Type = "edit" } };

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<DriveItemCreateLinkRequestBody>()))
                    .Returns("request body value");

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<Permission>(It.IsAny<string>()))
                    .Returns(expectedPermission);

                var permission = await this.graphServiceClient.Me.Drive.Items["id"].CreateLink("edit", "scope").Request().PostAsync();

                Assert.NotNull(permission);
                Assert.Equal(expectedPermission, permission);
            }
        }

        /// <summary>
        /// Tests the PostAsync() method for an action that returns nothing (send).
        /// </summary>
        [Fact]
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
                            request => request.RequestUri.ToString().StartsWith(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                await this.graphServiceClient.Me.MailFolders.Drafts.Messages["messageId"].Send().Request().PostAsync();
            }
        }
    }
}