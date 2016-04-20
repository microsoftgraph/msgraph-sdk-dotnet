// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Requests.Generated
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Graph;
    using Microsoft.Graph.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    using Constants = Microsoft.Graph.Constants;

    [TestClass]
    public class CollectionReferencesRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for the $ref navigation of an entity collection.
        /// </summary>
        [TestMethod]
        public void BuildRequest()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/groups/groupId/members/$ref");
            var membersReferencesCollectionRequestBuilder = this.graphServiceClient.Groups["groupId"].Members.References as GroupMembersCollectionReferencesRequestBuilder;

            Assert.IsNotNull(membersReferencesCollectionRequestBuilder, "Unexpected request builder.");
            Assert.AreEqual(expectedRequestUri, new Uri(membersReferencesCollectionRequestBuilder.RequestUrl), "Unexpected request URL.");

            var membersReferencesCollectionRequest = membersReferencesCollectionRequestBuilder.Request() as GroupMembersCollectionReferencesRequest;
            Assert.IsNotNull(membersReferencesCollectionRequest, "Unexpected request.");
            Assert.AreEqual(expectedRequestUri, new Uri(membersReferencesCollectionRequest.RequestUrl), "Unexpected request URL.");
        }

        /// <summary>
        /// Tests the AddAsync() method on the $ref navigation of an entity collection.
        /// </summary>
        [TestMethod]
        public async Task AddAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                var requestUrl = string.Format("{0}/groups/groupId/members/$ref", this.graphBaseUrl);

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().Equals(requestUrl)
                                && request.Method == HttpMethod.Post
                                && string.Equals(request.Content.Headers.ContentType.ToString(), "application/json"))))
                    .Returns(Task.FromResult(httpResponseMessage));

                var userToCreate = new User { Id = "id" };

                var expectedRequestBody = new ReferenceRequestBody
                {
                    ODataId = string.Format("{0}/directoryObjects/{1}", this.graphBaseUrl, userToCreate.Id),
                };

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.Is<ReferenceRequestBody>(requestBody => string.Equals(expectedRequestBody.ODataId, requestBody.ODataId))))
                    .Returns("RequestBodyString");

                await this.graphServiceClient.Groups["groupId"].Members.References.Request().AddAsync(userToCreate);
            }
        }

        /// <summary>
        /// Tests the AddAsync() method on the $ref navigation of an entity collection errors if ID isn't set on the supplied directoryObject.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public async Task AddAsync_IdRequired()
        {
            var userToCreate = new User();

            try
            {
                await this.graphServiceClient.Groups["groupId"].Members.References.Request().AddAsync(userToCreate);
            }
            catch (ServiceException serviceException)
            {
                Assert.IsTrue(serviceException.IsMatch(GraphErrorCode.InvalidRequest.ToString()), "Unexpected error code thrown.");
                Assert.AreEqual(
                    "ID is required to add a reference.",
                    serviceException.Error.Message,
                    "Unexpected message thrown.");

                throw;
            }
        }

        /// <summary>
        /// Tests the Expand() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void Expand()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Expand("value") as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$expand", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Select() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void Select()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Select("value") as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$select", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Top() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void Top()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Top(1) as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$top", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("1", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Filter() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void Filter()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Filter("value") as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$filter", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the Skip() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void Skip()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Skip(1) as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$skip", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("1", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }

        /// <summary>
        /// Tests the OrderBy() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [TestMethod]
        public void OrderBy()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().OrderBy("value") as GroupMembersCollectionWithReferencesRequest;

            Assert.IsNotNull(groupMembersRequest, "Unexpected request.");
            Assert.AreEqual(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(1, groupMembersRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.AreEqual("$orderby", groupMembersRequest.QueryOptions[0].Name, "Unexpected query option name.");
            Assert.AreEqual("value", groupMembersRequest.QueryOptions[0].Value, "Unexpected query option value.");
        }
    }
}
