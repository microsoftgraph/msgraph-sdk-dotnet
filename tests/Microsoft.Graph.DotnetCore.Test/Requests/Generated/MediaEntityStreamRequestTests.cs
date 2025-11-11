// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Kiota.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using Xunit;
using Microsoft.Graph.DotnetCore.Test.Mocks;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Generated
{
    public class MediaEntityStreamRequestTests
    {
        [Fact]
        public void RequestBuilder()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/photo/$value");
            var requestInformation = graphServiceClient.Me.Photo.Content.ToGetRequestInformation();

            Assert.NotNull(requestInformation);
            Assert.Equal(expectedRequestUri, requestInformation.URI);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAsync()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            using var httpResponseMessage = new HttpResponseMessage();

            var requestUrl = string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/photo/$value";

            mockRequestAdapter.Setup(
                adapter => adapter.SendPrimitiveAsync<Stream>(
                    It.IsAny<RequestInformation>(),
                    It.IsAny<Dictionary<string, ParsableFactory<IParsable>>>(),
                    It.IsAny<CancellationToken>())
            ).ReturnsAsync(await httpResponseMessage.Content.ReadAsStreamAsync());

            mockRequestAdapter.Setup(
                adapter => adapter.SerializationWriterFactory.GetSerializationWriter(It.IsAny<string>())
            ).Returns(new JsonSerializationWriter());

            using var returnedResponseStream = await graphServiceClient.Me.Photo.Content.GetAsync();
            Assert.Equal(await httpResponseMessage.Content.ReadAsStreamAsync(), returnedResponseStream);
        }

        [Fact]
        public async System.Threading.Tasks.Task PutAsync()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            using var httpResponseMessage = new HttpResponseMessage();
            var responseHandler = new NativeResponseHandler() { Value = httpResponseMessage };
            using var contentStream = new MemoryStream();

            var requestInformation = graphServiceClient.Me.Photo.Content.ToPutRequestInformation(contentStream);
            requestInformation.SetResponseHandler(responseHandler);

            await graphServiceClient.RequestAdapter.SendPrimitiveAsync<Stream>(requestInformation);

            using var returnedResponseStream = await ((HttpResponseMessage)responseHandler.Value).Content.ReadAsStreamAsync();
            Assert.Equal(await httpResponseMessage.Content.ReadAsStreamAsync(), returnedResponseStream);
        }
    }
}
