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
    public class EntityWithReferenceRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for an entity that has a $ref navigation.
        /// </summary>
        [Fact]
        public void BuildRequest()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/me/manager");
            var managerRequestBuilder = this.graphServiceClient.Me.Manager as DirectoryObjectWithReferenceRequestBuilder;

            Assert.NotNull(managerRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(managerRequestBuilder.RequestUrl));

            var namagerRequest = managerRequestBuilder.Request() as DirectoryObjectWithReferenceRequest;
            Assert.NotNull(namagerRequest);
            Assert.Equal(expectedRequestUri, new Uri(namagerRequest.RequestUrl));
        }

        /// <summary>
        /// Tests the GetAsync() method on an entity that has a $ref navigation.
        /// </summary>
        [Fact]
        public async Task GetAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                var requestUrl = string.Format("{0}/me/manager", this.graphBaseUrl);

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Get),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                var expectedManager = new User();

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DirectoryObject>(It.IsAny<string>()))
                    .Returns(expectedManager);

                var returnedManager = await this.graphServiceClient.Me.Manager.Request().GetAsync();

                Assert.Equal(expectedManager, returnedManager);
            }
        }

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows expand.
        /// <summary>
        /// Tests the Expand() method on the request for an entity with a $ref navigation.
        /// </summary>
        [Fact]
        public void Expand()
        {
            var expectedRequestUrl = string.Format("{0}/me/manager", this.graphBaseUrl);

            var managerRequest = this.graphServiceClient.Me.Manager.Request().Expand("value") as DirectoryObjectWithReferenceRequest;

            Assert.NotNull(managerRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(managerRequest.RequestUrl));
            Assert.Equal(1, managerRequest.QueryOptions.Count);
            Assert.Equal("$expand", managerRequest.QueryOptions[0].Name);
            Assert.Equal("value", managerRequest.QueryOptions[0].Value);
        }
#endif

#if false // This test can no longer run at this time since the Graph does not have a $ref navigation that allows select.
        /// <summary>
        /// Tests the Select() method on the request for an entity with a $ref navigation.
        /// </summary>
        [Fact]
        public void Select()
        {
            var expectedRequestUrl = string.Format("{0}/me/manager", this.graphBaseUrl);

            var managerRequest = this.graphServiceClient.Me.Manager.Request().Select("value") as DirectoryObjectWithReferenceRequest;

            Assert.NotNull(managerRequest);
            Assert.Equal(new Uri(expectedRequestUrl), new Uri(managerRequest.RequestUrl));
            Assert.Equal(1, managerRequest.QueryOptions.Count);
            Assert.Equal("$select", managerRequest.QueryOptions[0].Name);
            Assert.Equal("value", managerRequest.QueryOptions[0].Value);
        }
#endif
    }
}
