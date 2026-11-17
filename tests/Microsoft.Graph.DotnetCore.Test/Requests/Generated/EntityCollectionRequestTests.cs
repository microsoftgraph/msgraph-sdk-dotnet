// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Moq;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using Xunit;
using Microsoft.Graph.DotnetCore.Test.Mocks;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Generated
{
    public class EntityCollectionRequestTests
    {
        /// <summary>
        /// Tests building a request for an entity collection.
        /// </summary>
        [Fact]
        public void BuildRequest()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/users/TokenToReplace/calendars");
            var requestInformation = graphServiceClient.Me.Calendars.ToGetRequestInformation();
            
            Assert.NotNull(requestInformation);
            Assert.Equal(expectedRequestUri, requestInformation.URI);
        }

        /// <summary>
        /// Tests the GetAsync() method on an entity collection request.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task GetAsync()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            
            var nextQueryKey = "key";
            var nextQueryValue = "value";

            var requestUrl = string.Format("{0}/me/calendars", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));
            var nextPageRequestUrl = string.Format("{0}?{1}={2}", requestUrl, nextQueryKey, nextQueryValue);
            var nextPageRequestUrlElement = JsonDocument.Parse(string.Format("\"{0}\"", nextPageRequestUrl)).RootElement;

            var calendarsCollectionPage = new List<Calendar>
            {
                new Calendar(),
            };

            var calendarsCollectionResponse = new CalendarCollectionResponse
            {
                Value = calendarsCollectionPage,
                OdataNextLink = nextPageRequestUrl
            };
            
            mockRequestAdapter.Setup(
                adapter => adapter.SendAsync(It.IsAny<RequestInformation>(),CalendarCollectionResponse.CreateFromDiscriminatorValue, It.IsAny<Dictionary<string, ParsableFactory<IParsable>>>(),It.IsAny<CancellationToken>() )
            ).ReturnsAsync(calendarsCollectionResponse);
            
            var returnedCollectionPage = await graphServiceClient.Me.Calendars.GetAsync();

            Assert.NotNull(returnedCollectionPage);
            Assert.Equal(calendarsCollectionPage, returnedCollectionPage.Value);
            Assert.Equal(
                calendarsCollectionResponse.AdditionalData,
                returnedCollectionPage.AdditionalData);

            var nextPageRequest = returnedCollectionPage.OdataNextLink;

            Assert.NotNull(nextPageRequest);
        }

        /// <summary>
        /// Tests the AddAsync() method on an entity collection request.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task AddAsync()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            
            var addedCalendar = new Calendar();
            
            mockRequestAdapter.Setup(
                adapter => adapter.SendAsync(It.IsAny<RequestInformation>(),Calendar.CreateFromDiscriminatorValue, It.IsAny<Dictionary<string, ParsableFactory<IParsable>>>(),It.IsAny<CancellationToken>() )
            ).ReturnsAsync(addedCalendar);
            
            mockRequestAdapter.Setup(
                adapter => adapter.SerializationWriterFactory.GetSerializationWriter(It.IsAny<string>())
            ).Returns(new JsonSerializationWriter());
            
            var returnedCalendar = await graphServiceClient.Me.Calendars.PostAsync(addedCalendar);
            

            
            Assert.Equal(addedCalendar, returnedCalendar);
        }

        /// <summary>
        /// Tests that the AddAsync() method on an abstract entity collection request includes @odata.type.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task AddAsync_AbstractEntityContainsODataType()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);

            var attachmentToAdd = new FileAttachment();

            mockRequestAdapter.Setup(
                adapter => adapter.SendAsync(It.IsAny<RequestInformation>(),Attachment.CreateFromDiscriminatorValue, It.IsAny<Dictionary<string, ParsableFactory<IParsable>>>(),It.IsAny<CancellationToken>() )
            ).ReturnsAsync(attachmentToAdd);
            
            mockRequestAdapter.Setup(
                adapter => adapter.SerializationWriterFactory.GetSerializationWriter(It.IsAny<string>())
            ).Returns(new JsonSerializationWriter()); 
            
            var returnedAttachment = await graphServiceClient
                .Groups["groupId"]
                .Threads["threadId"]
                .Posts["postId"]
                .Attachments
                .PostAsync(attachmentToAdd);
            
            Assert.Equal(attachmentToAdd, returnedAttachment);
        }

        /// <summary>
        /// Tests the Expand() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Expand()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            
            var expectedRequestUrl = string.Format("{0}/users/TokenToReplace/contactFolders?%24select=contacts", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            var requestInformation = graphServiceClient.Me.ContactFolders.ToGetRequestInformation( requestConfiguration => requestConfiguration.QueryParameters.Select = new []{"contacts"});
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }

        /// <summary>
        /// Tests the Select() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Select()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = string.Format("{0}/users/TokenToReplace/contactFolders?%24select=value", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            var requestInformation = graphServiceClient.Me.ContactFolders.ToGetRequestInformation( requestConfiguration => requestConfiguration.QueryParameters.Select = new []{"value"});
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }

        /// <summary>
        /// Tests the Top() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Top()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = string.Format("{0}/users/TokenToReplace/contactFolders?%24top=1", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            var requestInformation = graphServiceClient.Me.ContactFolders.ToGetRequestInformation( requestConfiguration => requestConfiguration.QueryParameters.Top = 1);
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }

        /// <summary>
        /// Tests the Filter() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Filter()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = string.Format("{0}/users/TokenToReplace/contactFolders?%24filter=value", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            var requestInformation = graphServiceClient.Me.ContactFolders.ToGetRequestInformation( requestConfiguration => requestConfiguration.QueryParameters.Filter = "value");
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }

        /// <summary>
        /// Tests the Skip() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void Skip()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = string.Format("{0}/users/TokenToReplace/contactFolders?%24skip=2", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            var requestInformation = graphServiceClient.Me.ContactFolders.ToGetRequestInformation( requestConfiguration => requestConfiguration.QueryParameters.Skip = 2);
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }

        /// <summary>
        /// Tests the OrderBy() method on an entity collection request (contactFolders).
        /// </summary>
        [Fact]
        public void OrderBy()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = string.Format("{0}/users/TokenToReplace/contactFolders?%24orderby=value", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            var requestInformation = graphServiceClient.Me.ContactFolders.ToGetRequestInformation( requestConfiguration => requestConfiguration.QueryParameters.Orderby = new []{"value"});
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }
    }
}
