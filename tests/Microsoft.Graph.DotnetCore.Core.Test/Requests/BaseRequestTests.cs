// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph.DotnetCore.Core.Test.TestModels;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests
{
    public class BaseRequestTests : RequestTestBase
    {
        [Fact]
        public void BaseRequest_InitializeWithEmptyBaseUrl()
        {
            try
            {
                Assert.Throws<ServiceException>(() => new BaseRequest(null, this.baseClient));
            }
            catch (ServiceException exception)
            {
                Assert.Equal(ErrorConstants.Codes.InvalidRequest, exception.Error.Code);
                Assert.Equal(ErrorConstants.Messages.BaseUrlMissing, exception.Error.Message);
                throw;
            }
        }

        [Fact]
        public void BaseRequest_InitializeWithQueryStringAndOptions()
        {
            var baseUrl = string.Concat(this.baseUrl, "/me/drive/items/id");
            var requestUrl = baseUrl + "?key=value&key2";

            var options = new List<Option>
            {
                new QueryOption("key3", "value3"),
                new HeaderOption("header", "value"),
            };

            var baseRequest = new BaseRequest(requestUrl, this.baseClient, options);

            Assert.Equal(new Uri(baseUrl), new Uri(baseRequest.RequestUrl));
            Assert.Equal(3, baseRequest.QueryOptions.Count);
            Assert.True(baseRequest.QueryOptions[0].Name.Equals("key") && baseRequest.QueryOptions[0].Value.Equals("value"));
            Assert.True(baseRequest.QueryOptions[1].Name.Equals("key2") && string.IsNullOrEmpty(baseRequest.QueryOptions[1].Value));
            Assert.True(baseRequest.QueryOptions[2].Name.Equals("key3") && baseRequest.QueryOptions[2].Value.Equals("value3"));
            Assert.Equal(1, baseRequest.Headers.Count);
            Assert.True(baseRequest.Headers[0].Name.Equals("header") && baseRequest.Headers[0].Value.Equals("value"));
        }

        [Fact]
        public void GetWebRequestWithHeadersAndQueryOptions()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var options = new List<Option>
            {
                new HeaderOption("header1", "value1"),
                new HeaderOption("header2", "value2"),
                new QueryOption("query1", "value1"),
                new QueryOption("query2", "value2"),
            };

            var baseRequest = new BaseRequest(requestUrl, this.baseClient, options) { Method = "PUT" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();
            Assert.Equal(HttpMethod.Put, httpRequestMessage.Method);
            Assert.Equal(requestUrl + "?query1=value1&query2=value2",
                httpRequestMessage.RequestUri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.Unescaped));
            Assert.Equal("value1", httpRequestMessage.Headers.GetValues("header1").First());
            Assert.Equal("value2", httpRequestMessage.Headers.GetValues("header2").First());

            var expectedVersion = typeof(BaseRequest).GetTypeInfo().Assembly.GetName().Version;
            Assert.Equal(
                string.Format("Graph-dotnet-{0}.{1}.{2}", expectedVersion.Major, expectedVersion.Minor, expectedVersion.Build),
                httpRequestMessage.Headers.GetValues(CoreConstants.Headers.SdkVersionHeaderName).First());
        }

        [Fact]
        public void GetWebRequestNoOptions()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { Method = "DELETE" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();
            Assert.Equal(HttpMethod.Delete, httpRequestMessage.Method);
            Assert.Equal(requestUrl,
                httpRequestMessage.RequestUri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.Unescaped));
            Assert.Equal(1, httpRequestMessage.Headers.Count());

            var expectedVersion = typeof(BaseRequest).GetTypeInfo().Assembly.GetName().Version;
            Assert.Equal(
                string.Format("Graph-dotnet-{0}.{1}.{2}", expectedVersion.Major, expectedVersion.Minor, expectedVersion.Build),
                httpRequestMessage.Headers.GetValues(CoreConstants.Headers.SdkVersionHeaderName).First());
        }

        [Fact]
        public void GetWebRequest_OverrideCustomTelemetryHeader()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new CustomRequest(requestUrl, this.baseClient);

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.Equal(
                CustomRequest.SdkHeaderValue,
                httpRequestMessage.Headers.GetValues(CustomRequest.SdkHeaderName).First());

            Assert.False(
                httpRequestMessage.Headers.Contains(CoreConstants.Headers.SdkVersionHeaderName));
        }

        [Fact]
        public async Task SendAsync()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json" };

            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request =>
                                string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")
                               && request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                        .Returns(Task.FromResult(httpResponseMessage));

                var expectedResponseItem = new DerivedTypeClass { Id = "id" };
                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<string>()))
                    .Returns(string.Empty);
                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DerivedTypeClass>(It.IsAny<string>()))
                    .Returns(expectedResponseItem);

                var responseItem = await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);

                Assert.NotNull(responseItem);
                Assert.Equal(expectedResponseItem.Id, responseItem.Id);

                this.authenticationProvider.Verify(provider => provider.AuthenticateRequestAsync(It.IsAny<HttpRequestMessage>()), Times.Once);
            }
        }

        [Fact]
        public async Task SendAsync_AuthenticationProviderNotSet()
        {
            var client = new BaseClient("https://localhost", null);

            var baseRequest = new BaseRequest("https://localhost", client);

            try
            {
                await Assert.ThrowsAsync<ServiceException>(async () => await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None));
            }
            catch (ServiceException exception)
            {
                Assert.Equal(ErrorConstants.Codes.InvalidRequest, exception.Error.Code);
                Assert.Equal(ErrorConstants.Messages.AuthenticationProviderMissing, exception.Error.Message);
                throw;
            }
        }

        [Fact]
        public async Task SendAsync_NoReturnObject()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json" };

            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request =>
                                string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")
                               && request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<string>()))
                    .Returns(string.Empty);

                await baseRequest.SendAsync("string", CancellationToken.None);

                this.authenticationProvider.Verify(provider => provider.AuthenticateRequestAsync(It.IsAny<HttpRequestMessage>()), Times.Once);
            }
        }

        [Fact]
        public async Task SendAsync_NullResponseBody()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json" };

            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            {
                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request =>
                                string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")
                               && request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<string>()))
                    .Returns(string.Empty);

                var instance = await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);

                Assert.Null(instance);

                this.authenticationProvider.Verify(provider => provider.AuthenticateRequestAsync(It.IsAny<HttpRequestMessage>()), Times.Once);
            }
        }

        [Fact]
        public async Task SendAsync_RequestUrlNotSet()
        {
            var baseRequest = new BaseRequest("https://localhost", this.baseClient);

            baseRequest.RequestUrl = null;

            try
            {
                await Assert.ThrowsAsync<ServiceException>(async () => await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None));
            }
            catch (ServiceException exception)
            {
                Assert.Equal(ErrorConstants.Codes.InvalidRequest, exception.Error.Code);
                Assert.Equal(ErrorConstants.Messages.RequestUrlMissing, exception.Error.Message);
                throw;
            }
        }

        [Fact]
        public async Task SendStreamRequestAsync()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/photo/$value");
            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json", Method = "PUT" };

            using (var requestStream = new MemoryStream())
            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream())
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request => request.RequestUri.ToString().StartsWith(requestUrl)
                                && request.Method == HttpMethod.Put),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                    .Returns(Task.FromResult(httpResponseMessage));

                using (var returnedResponseStream = await baseRequest.SendStreamRequestAsync(requestStream, CancellationToken.None))
                {
                    Assert.Equal(await httpResponseMessage.Content.ReadAsStreamAsync(), returnedResponseStream);
                }
            }
        }

        [Fact]
        public void BuildQueryString_NullQueryOptions()
        {
            var baseRequest = new BaseRequest("https://localhost", this.baseClient);

            baseRequest.QueryOptions = null;

            var queryString = baseRequest.BuildQueryString();

            Assert.Null(queryString);
        }
    }
}