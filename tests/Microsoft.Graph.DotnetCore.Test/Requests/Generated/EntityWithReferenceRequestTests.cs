// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using Xunit;
using Microsoft.Graph.DotnetCore.Test.Mocks;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Generated
{
    public class EntityWithReferenceRequestTests
    {
        /// <summary>
        /// Tests building a request for an entity that has a $ref navigation.
        /// </summary>
        [Fact]
        public void BuildRequest()
        {            
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/users/TokenToReplace/manager");
            var requestInformation = graphServiceClient.Me.Manager.ToGetRequestInformation();
            
            Assert.NotNull(requestInformation);
            Assert.Equal(expectedRequestUri, requestInformation.URI);
        }

        /// <summary>
        /// Tests the GetAsync() method on an entity that has a $ref navigation.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task GetAsync()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            var expectedManager = new User();
            
            mockRequestAdapter.Setup(
                adapter => adapter.SendAsync(It.IsAny<RequestInformation>(),DirectoryObject.CreateFromDiscriminatorValue, It.IsAny<Dictionary<string, ParsableFactory<IParsable>>>(),It.IsAny<CancellationToken>() )
            ).ReturnsAsync(expectedManager);
            
            mockRequestAdapter.Setup(
                adapter => adapter.SerializationWriterFactory.GetSerializationWriter(It.IsAny<string>())
            ).Returns(new JsonSerializationWriter()); 
            
            var returnedManager = await graphServiceClient.Me.Manager.GetAsync();

            Assert.Equal(expectedManager, returnedManager);
        }
    }
}
