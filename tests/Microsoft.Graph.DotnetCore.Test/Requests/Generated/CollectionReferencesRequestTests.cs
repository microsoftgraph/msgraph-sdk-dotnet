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
    public class CollectionReferencesRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for the $ref navigation of an entity collection.
        /// </summary>
        [Fact]
        public void BuildRequest()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/groups/groupId/members/$ref");
            var membersReferencesCollectionRequestBuilder = this.graphServiceClient.Groups["groupId"].Members.References as GroupMembersCollectionReferencesRequestBuilder;

            Assert.NotNull(membersReferencesCollectionRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(membersReferencesCollectionRequestBuilder.RequestUrl));

            var membersReferencesCollectionRequest = membersReferencesCollectionRequestBuilder.Request() as GroupMembersCollectionReferencesRequest;
            Assert.NotNull(membersReferencesCollectionRequest);
            Assert.Equal(expectedRequestUri, new Uri(membersReferencesCollectionRequest.RequestUrl));
        }

        /// <summary>
        /// Tests the AddAsync() method on the $ref navigation of an entity collection.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task AddAsync()
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
                                && string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(System.Threading.Tasks.Task.FromResult(httpResponseMessage));

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
        [Fact]
        public async System.Threading.Tasks.Task AddAsync_IdRequired()
        {
            var userToCreate = new User();

            try
            {
                await Assert.ThrowsAsync<ServiceException>(async () => await this.graphServiceClient.Groups["groupId"].Members.References.Request().AddAsync(userToCreate));
            }
            catch (ServiceException serviceException)
            {
                Assert.True(serviceException.IsMatch(GraphErrorCode.InvalidRequest.ToString()));
                Assert.Equal(
                    "ID is required to add a reference.",
                    serviceException.Error.Message);

                throw;
            }
        }

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows expand.
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
#endif

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows select.
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
#endif

        /// <summary>
        /// Tests the Top() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [Fact]
        public void Top()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().Top(1) as GroupMembersCollectionWithReferencesRequest;

            Assert.NotNull(groupMembersRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl));
            Assert.Equal(1, groupMembersRequest.QueryOptions.Count);
            Assert.Equal("$top", groupMembersRequest.QueryOptions[0].Name);
            Assert.Equal("1", groupMembersRequest.QueryOptions[0].Value);
        }

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows filter.
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
#endif

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows skip.
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
#endif

        /// <summary>
        /// Tests the OrderBy() method on the request for an entity collection that has a $ref navigation.
        /// </summary>
        [Fact]
        public void OrderBy()
        {
            var expectedRequestUrl = string.Format("{0}/groups/groupId/members", this.graphBaseUrl);

            var groupMembersRequest = this.graphServiceClient.Groups["groupId"].Members.Request().OrderBy("value") as GroupMembersCollectionWithReferencesRequest;

            Assert.NotNull(groupMembersRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(groupMembersRequest.RequestUrl));
            Assert.Equal(1, groupMembersRequest.QueryOptions.Count);
            Assert.Equal("$orderby", groupMembersRequest.QueryOptions[0].Name);
            Assert.Equal("value", groupMembersRequest.QueryOptions[0].Value);
        }
    }
}
