// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests
{
    using Microsoft.Graph.DotnetCore.Core.Test.Mocks;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    public class RedirectHandlerTests : IDisposable
    {
        private MockRedirectHandler testHttpMessageHandler;
        private RedirectHandler redirectHandler;
        private HttpMessageInvoker invoker;


        public RedirectHandlerTests()
        {
            this.testHttpMessageHandler = new MockRedirectHandler();
            this.redirectHandler = new RedirectHandler(this.testHttpMessageHandler);
            this.invoker = new HttpMessageInvoker(this.redirectHandler);
        }

        public void Dispose()
        {
            this.invoker.Dispose();
        }

        [Fact]
        public void RedirectHandler_Constructor()
        {
            using (RedirectHandler redirect = new RedirectHandler())
            {
                Assert.Null(redirect.InnerHandler);
                Assert.NotNull(redirect.RedirectOption);
                Assert.Equal(5, redirect.RedirectOption.MaxRedirect); // default MaxRedirects is 5
                Assert.IsType(typeof(RedirectHandler), redirect);
            }
        }

        [Fact]
        public void RedirectHandler_HttpMessageHandlerConstructor()
        {
            Assert.NotNull(this.redirectHandler.InnerHandler);
            Assert.NotNull(redirectHandler.RedirectOption);
            Assert.Equal(5, redirectHandler.RedirectOption.MaxRedirect); // default MaxRedirects is 5
            Assert.Equal(this.redirectHandler.InnerHandler, this.testHttpMessageHandler);
            Assert.IsType(typeof(RedirectHandler), this.redirectHandler);
        }

        [Fact]
        public void RedirectHandler_RedirectOptionConstructor()
        {
            using (RedirectHandler redirect = new RedirectHandler(new RedirectHandlerOption { MaxRedirect = 2 }))
            {
                Assert.Null(redirect.InnerHandler);
                Assert.NotNull(redirect.RedirectOption);
                Assert.Equal(2, redirect.RedirectOption.MaxRedirect);
                Assert.IsType(typeof(RedirectHandler), redirect);
            }
        }

        [Fact]
        public async Task OkStatusShouldPassThrough()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");

            var redirectResponse = new HttpResponseMessage(HttpStatusCode.OK);
            this.testHttpMessageHandler.SetHttpResponse(redirectResponse);

            var response = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Same(response.RequestMessage, httpRequestMessage);
        }

        [Theory]
        [InlineData(HttpStatusCode.MovedPermanently)]  // 301
        [InlineData(HttpStatusCode.Found)]  // 302
        [InlineData(HttpStatusCode.TemporaryRedirect)]  // 307
        [InlineData(308)] // 308
        public async Task ShouldRedirectSameMethodAndContent(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Hello World");

            var redirectResponse = new HttpResponseMessage(statusCode);
            redirectResponse.Headers.Location = new Uri("http://example.org/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.Equal(response.RequestMessage.Method, httpRequestMessage.Method);
            Assert.NotSame(response.RequestMessage, httpRequestMessage);
            Assert.NotNull(response.RequestMessage.Content);
            Assert.Equal(response.RequestMessage.Content.ReadAsStringAsync().Result, "Hello World");

        }

        [Fact]
        public async Task ShouldRedirectChangeMethodAndContent()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Hello World");

            var redirectResponse = new HttpResponseMessage(HttpStatusCode.SeeOther);
            redirectResponse.Headers.Location = new Uri("http://example.org/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.NotEqual(response.RequestMessage.Method, httpRequestMessage.Method);
            Assert.Equal(response.RequestMessage.Method, HttpMethod.Get);
            Assert.NotSame(response.RequestMessage, httpRequestMessage);
            Assert.Null(response.RequestMessage.Content);
        }

        [Theory]
        [InlineData(HttpStatusCode.MovedPermanently)]  // 301
        [InlineData(HttpStatusCode.Found)]  // 302
        [InlineData(HttpStatusCode.TemporaryRedirect)]  // 307
        [InlineData((HttpStatusCode)308)] // 308
        public async Task RedirectWithDifferentHostShouldRemoveAuthHeader(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("fooAuth", "aparam");

            var redirectResponse = new HttpResponseMessage(statusCode);
            redirectResponse.Headers.Location = new Uri("http://example.net/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.NotSame(response.RequestMessage, httpRequestMessage);
            Assert.NotSame(response.RequestMessage.RequestUri.Host, httpRequestMessage.RequestUri.Host);
            Assert.Null(response.RequestMessage.Headers.Authorization);
        }

        [Theory]
        [InlineData(HttpStatusCode.MovedPermanently)]  // 301
        [InlineData(HttpStatusCode.Found)]  // 302
        [InlineData(HttpStatusCode.TemporaryRedirect)]  // 307
        [InlineData((HttpStatusCode)308)] // 308
        public async Task RedirectWithDifferentSchemeShouldRemoveAuthHeader(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://example.org/foo");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("fooAuth", "aparam");

            var redirectResponse = new HttpResponseMessage(statusCode);
            redirectResponse.Headers.Location = new Uri("http://example.org/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.NotSame(response.RequestMessage, httpRequestMessage);
            Assert.NotSame(response.RequestMessage.RequestUri.Scheme, httpRequestMessage.RequestUri.Scheme);
            Assert.Null(response.RequestMessage.Headers.Authorization);
        }

        [Fact]
        public async Task RedirectWithSameHostShouldKeepAuthHeader()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("fooAuth", "aparam");

            var redirectResponse = new HttpResponseMessage(HttpStatusCode.Redirect);
            redirectResponse.Headers.Location = new Uri("http://example.org/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.NotSame(response.RequestMessage, httpRequestMessage);
            Assert.Equal(response.RequestMessage.RequestUri.Host, httpRequestMessage.RequestUri.Host);
            Assert.NotNull(response.RequestMessage.Headers.Authorization);
        }

        [Fact]
        public async Task ExceedMaxRedirectsShouldThrowsException()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");

            var _response1 = new HttpResponseMessage(HttpStatusCode.Redirect);
            _response1.Headers.Location = new Uri("http://example.org/bar");

            var _response2 = new HttpResponseMessage(HttpStatusCode.Redirect);
            _response2.Headers.Location = new Uri("http://example.org/foo");

            this.testHttpMessageHandler.SetHttpResponse(_response1, _response2);

            ServiceException exception = await Assert.ThrowsAsync<ServiceException>(async () => await this.invoker.SendAsync(
                   httpRequestMessage, CancellationToken.None));

            Assert.True(exception.IsMatch(ErrorConstants.Codes.TooManyRedirects));
            Assert.Equal(String.Format(ErrorConstants.Messages.TooManyRedirectsFormatString, 5), exception.Error.Message);
            Assert.IsType(typeof(ServiceException), exception);
        }
    }
}
