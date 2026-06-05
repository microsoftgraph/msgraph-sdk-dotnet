// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Graph.Drives.Item.Items.Item.CreateLink;
using Microsoft.Graph.Me.AssignLicense;
using Microsoft.Graph.Me.CheckMemberGroups;
using Microsoft.Graph.Me.GetMemberGroups;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using Xunit;
using Microsoft.Graph.DotnetCore.Test.Mocks;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Generated
{
    public class ActionRequestTests
    {
        /// <summary>
        /// Tests building a request for an action with multiple required parameters (assignLicence).
        /// </summary>
        [Fact]
        public void MultipleRequiredParameters()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = $"{string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0")}/me/assignLicense";
            
            
            var addLicenses = new List<AssignedLicense> { new AssignedLicense() };

            var requestBody = new AssignLicensePostRequestBody
            {
                AddLicenses = addLicenses,
                RemoveLicenses = new ()
            };
            
            var requestInformation = graphServiceClient.Me.AssignLicense.ToPostRequestInformation(requestBody);
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }

        /// <summary>
        /// Tests building a request for an action with an optional parameter set to null that's not a nullable type.
        /// </summary>
        [Fact]
        public void OptionalParameterWithNonNullableType_NullValue()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = $"{string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0")}/me/getMemberGroups";
            
            
            var requestBody = new GetMemberGroupsPostRequestBody { };
            var requestInformation = graphServiceClient.Me.GetMemberGroups.ToPostRequestInformation(requestBody);
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
            Assert.False(requestBody.SecurityEnabledOnly);
        }

        /// <summary>
        /// Tests building a request for an action with an optional parameter that's not a nullable type.
        /// </summary>
        [Fact]
        public void OptionalParameterWithNonNullableType_ValueSet()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = string.Format("{0}/me/getMemberGroups", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            
            var requestBody = new GetMemberGroupsPostRequestBody { SecurityEnabledOnly = true};
            var requestInformation = graphServiceClient.Me.GetMemberGroups.ToPostRequestInformation(requestBody);
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
            Assert.True(requestBody.SecurityEnabledOnly.Value);
        }

        /// <summary>
        /// Tests building a request for an action that takes in no parameters (send).
        /// </summary>
        [Fact]
        public void NoParameters()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var messageId = "messageId";
            var expectedRequestUrl = string.Format("{0}/me/mailFolders/Drafts/messages/{1}/send", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"), messageId);

            var requestInformation = graphServiceClient.Me.MailFolders["Drafts"].Messages[messageId].Send.ToPostRequestInformation();
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }

        /// <summary>
        /// Tests that an exception is thrown when the first of required parameters passed to an action request is null (assignLicence).
        /// </summary>
        [Fact]
        public async Task MultipleRequiredParameters_FirstParameterNull()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            var removeLicenses = new List<Guid> { new Guid() };
            
            await Assert.ThrowsAsync<ArgumentNullException>(() => graphServiceClient.Me.AssignLicense.PostAsync(null));
        }

        /// <summary>
        /// Tests the PostAsync() method for an action that returns a collection of primitives (checkMemberGroups).
        /// The action is also inherited from the base class.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task PostAsync_CollectionOfPrimitivesReturnType()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            var nextQueryKey = "key";
            var nextQueryValue = "value";

            var requestUrl = string.Format("{0}/me/microsoft.graph.checkMemberGroups", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));
            var nextPageRequestUrl = string.Format("{0}?{1}={2}", requestUrl, nextQueryKey, nextQueryValue);

            var checkMemberGroupsCollectionPage = new List<string>()
            {
                "value 1",
                "value 2",
            };

            var checkMemberGroupsCollectionResponse = new CheckMemberGroupsPostResponse
            {
                Value = checkMemberGroupsCollectionPage,
                OdataNextLink = nextPageRequestUrl
            };

            mockRequestAdapter.Setup(
                adapter => adapter.SendAsync(It.IsAny<RequestInformation>(),CheckMemberGroupsPostResponse.CreateFromDiscriminatorValue, It.IsAny<Dictionary<string, ParsableFactory<IParsable>>>(),It.IsAny<CancellationToken>() )
                ).ReturnsAsync(checkMemberGroupsCollectionResponse);
            
            mockRequestAdapter.Setup(
                adapter => adapter.SerializationWriterFactory.GetSerializationWriter(It.IsAny<string>())
            ).Returns(new JsonSerializationWriter());
            
            var requestBody = new CheckMemberGroupsPostRequestBody
            {
                GroupIds = new List<string>()
            };
            var returnedCollectionPage = await graphServiceClient.Me.CheckMemberGroups.PostAsCheckMemberGroupsPostResponseAsync(requestBody);

            Assert.NotNull(returnedCollectionPage);
            Assert.Equal(checkMemberGroupsCollectionPage, returnedCollectionPage.Value);

            var nextPageRequest = returnedCollectionPage.OdataNextLink;

            Assert.NotNull(nextPageRequest);
        }

        /// <summary>
        /// Tests the PostAsync() method for an action that returns a single entity (createLink).
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task PostAsync_NonCollectionReturnType()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            var expectedPermission = new Permission { Id = "id", Link = new SharingLink { Type = "edit" } };

            var requestBody = new CreateLinkPostRequestBody { };
            
            mockRequestAdapter.Setup(
                adapter => adapter.SendAsync(It.IsAny<RequestInformation>(),Permission.CreateFromDiscriminatorValue, It.IsAny<Dictionary<string, ParsableFactory<IParsable>>>(),It.IsAny<CancellationToken>() )
            ).ReturnsAsync(expectedPermission);
            
            mockRequestAdapter.Setup(
                adapter => adapter.SerializationWriterFactory.GetSerializationWriter(It.IsAny<string>())
            ).Returns(new JsonSerializationWriter());
            
            var permission = await graphServiceClient.Drives["driveId"].Items["id"].CreateLink.PostAsync(requestBody);

            Assert.NotNull(permission);
            Assert.Equal(expectedPermission, permission);
        }

        /// <summary>
        /// Tests the PostAsync() method for an action that returns nothing (send).
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task PostAsync_NoReturnValue()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            mockRequestAdapter.Setup(
                adapter => adapter.SendNoContentAsync(It.IsAny<RequestInformation>(), It.IsAny<Dictionary<string, ParsableFactory<IParsable>>>(),It.IsAny<CancellationToken>() )
            ).Callback(() => {}).Returns(Task.CompletedTask);
            
            await graphServiceClient.Me.MailFolders["Drafts"].Messages["messageId"].Send.PostAsync();
        }
    }
}
