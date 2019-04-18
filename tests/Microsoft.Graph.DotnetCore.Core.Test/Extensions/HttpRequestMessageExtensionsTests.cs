// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Extensions
{
    using Microsoft.Graph.DotnetCore.Core.Test.Requests;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    public class HttpRequestMessageExtensionsTests: BaseRequestTests
    {
        [Fact]
        public void IsBuffered_Get()
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://example.com");
            var response = httpRequest.IsBuffered();

            Assert.True(response, "Unexpected content type");
        }
        [Fact]
        public void IsBuffered_PostWithNoContent()
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://example.com");
            var response = httpRequest.IsBuffered();

            Assert.True(response, "Unexpected content type");
        }
        [Fact]
        public void IsBuffered_PostWithBufferStringContent()
        {
            byte[] data = new byte[] { 1, 2, 3, 4, 5 };
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://example.com");
            httpRequest.Content = new ByteArrayContent(data);
            var response = httpRequest.IsBuffered();

            Assert.True(response, "Unexpected content type");
        }

        [Fact]
        public void IsBuffered_PutWithStreamStringContent()
        {
            var stringContent = new StringContent("Hello World");
            var byteArrayContent = new ByteArrayContent(new byte[] { 1, 2, 3, 4, 5 });
            var mutliformDataContent = new MultipartFormDataContent();
            mutliformDataContent.Add(stringContent);
            mutliformDataContent.Add(byteArrayContent);

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Put, "http://example.com");
            httpRequest.Content = mutliformDataContent;
            httpRequest.Content.Headers.ContentLength = -1;
            var response = httpRequest.IsBuffered();

            Assert.False(response, "Unexpected content type");
        }

        [Fact]
        public void IsBuffered_PatchWithStreamStringContent()
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(new HttpMethod("PATCH"), "http://example.com");
            httpRequest.Content = new StringContent("Hello World");
            httpRequest.Content.Headers.ContentLength = null;
            var response = httpRequest.IsBuffered();

            Assert.False(response, "Unexpected content type");
        }

        [Fact]
        public void GetRequestContext_ShouldReturnRequestContext()
        {
            string requestUrl = "https://foo.bar";
            var baseRequest = new BaseRequest(requestUrl, this.baseClient);

            HttpRequestMessage httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.NotNull(httpRequestMessage.GetRequestContext());
        }

        [Fact]
        public void GetMiddlewareControl_ShouldReturnIMiddlewareOptionObject()
        {
            string requestUrl = "https://localhost/v2";
            var baseRequest = new BaseRequest(requestUrl, this.baseClient);

            HttpRequestMessage httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.NotNull(httpRequestMessage.GetMiddlewareOption<AuthenticationHandlerOption>());
        }

        [Fact]
        public async Task CloneAsync_WithEmptyHttpContent()
        {
            HttpRequestMessage originalRequest = new HttpRequestMessage(HttpMethod.Post, "http://example.com");

            HttpRequestMessage clonedRequest = await originalRequest.CloneAsync();

            Assert.NotNull(clonedRequest);
            Assert.Equal(originalRequest.Method, clonedRequest.Method);
            Assert.Equal(originalRequest.RequestUri, clonedRequest.RequestUri);
            Assert.Null(clonedRequest.Content);
        }

        [Fact]
        public async Task CloneAsync_WithHttpContent()
        {
            HttpRequestMessage originalRequest = new HttpRequestMessage(HttpMethod.Post, "http://example.com");
            originalRequest.Content = new StringContent("Sample Content", Encoding.UTF8, "application/json");

            HttpRequestMessage clonedRequest = await originalRequest.CloneAsync();

            Assert.NotNull(clonedRequest);
            Assert.Equal(originalRequest.Method, clonedRequest.Method);
            Assert.Equal(originalRequest.RequestUri, clonedRequest.RequestUri);
            Assert.Equal(await originalRequest.Content.ReadAsStringAsync(), await clonedRequest.Content.ReadAsStringAsync());
            Assert.Equal(originalRequest.Content.Headers.ContentType, clonedRequest.Content.Headers.ContentType);
        }
    }
}
