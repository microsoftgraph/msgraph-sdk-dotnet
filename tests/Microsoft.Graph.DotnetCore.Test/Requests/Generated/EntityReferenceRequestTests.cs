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
    public class EntityReferenceRequestTests : RequestTestBase
    {
        /// <summary>
        /// Tests building a request for an entity's $ref navigation.
        /// </summary>
        [Fact]
        public void BuildRequest()
        {
            var expectedRequestUri = new Uri(string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0") + "/groups/groupId/members/memberId/$ref");
            var memberReferenceRequestBuilder = this.graphServiceClient.Groups["groupId"].Members["memberId"].Reference as DirectoryObjectReferenceRequestBuilder;

            Assert.NotNull(memberReferenceRequestBuilder);
            Assert.Equal(expectedRequestUri, new Uri(memberReferenceRequestBuilder.RequestUrl));

            var memberReferenceRequest = memberReferenceRequestBuilder.Request() as DirectoryObjectReferenceRequest;
            Assert.NotNull(memberReferenceRequest);
            Assert.Equal(expectedRequestUri, new Uri(memberReferenceRequest.RequestUrl));
        }

        /// <summary>
        /// Tests the DeleteAsync() method on an entity's $ref navigation.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task DeleteAsync()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                var requestUrl = string.Format("{0}/groups/groupId/members/memberId/$ref", this.graphBaseUrl);

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().Equals(requestUrl)
                                && request.Method == HttpMethod.Delete),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(System.Threading.Tasks.Task.FromResult(httpResponseMessage));

                await this.graphServiceClient.Groups["groupId"].Members["memberId"].Reference.Request().DeleteAsync();
            }
        }
    }
}
