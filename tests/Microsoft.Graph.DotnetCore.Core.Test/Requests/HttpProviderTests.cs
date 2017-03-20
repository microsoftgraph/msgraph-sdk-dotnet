// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph.DotnetCore.Core.Test.Mocks;
using Microsoft.Graph;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests
{
    public class HttpProviderTests : IDisposable
    {
        private HttpProvider httpProvider;
        private MockSerializer serializer = new MockSerializer();
        private TestHttpMessageHandler testHttpMessageHandler;

        public HttpProviderTests()
        {
            this.testHttpMessageHandler = new TestHttpMessageHandler();
            this.httpProvider = new HttpProvider(this.testHttpMessageHandler, true, this.serializer.Object);
        }

        public void Dispose()
        {
            this.httpProvider.Dispose();
        }

        [Fact]
        public void HttpProvider_CustomCacheHeaderAndTimeout()
        {
            var timeout = TimeSpan.FromSeconds(200);
            var cacheHeader = new CacheControlHeaderValue();
            using (var defaultHttpProvider = new HttpProvider(null) { CacheControlHeader = cacheHeader, OverallTimeout = timeout })
            {
                Assert.False(defaultHttpProvider.httpClient.DefaultRequestHeaders.CacheControl.NoCache);
                Assert.False(defaultHttpProvider.httpClient.DefaultRequestHeaders.CacheControl.NoStore);

                Assert.Equal(timeout, defaultHttpProvider.httpClient.Timeout);
                Assert.NotNull(defaultHttpProvider.Serializer);
                Assert.IsType(typeof(Serializer), defaultHttpProvider.Serializer);
            }
        }

        [Fact]
        public void HttpProvider_CustomHttpClientHandler()
        {
            using (var httpClientHandler = new HttpClientHandler())
            using (var httpProvider = new HttpProvider(httpClientHandler, false, null))
            {
                Assert.Equal(httpClientHandler, httpProvider.httpMessageHandler);
                Assert.False(httpProvider.disposeHandler);
            }
        }

        [Fact]
        public void HttpProvider_DefaultConstructor()
        {
            using (var defaultHttpProvider = new HttpProvider())
            {
                Assert.True(defaultHttpProvider.httpClient.DefaultRequestHeaders.CacheControl.NoCache);
                Assert.True(defaultHttpProvider.httpClient.DefaultRequestHeaders.CacheControl.NoStore);

                Assert.True(defaultHttpProvider.disposeHandler);
                Assert.NotNull(defaultHttpProvider.httpMessageHandler);
                Assert.False(((HttpClientHandler)defaultHttpProvider.httpMessageHandler).AllowAutoRedirect);

                Assert.Equal(TimeSpan.FromSeconds(100), defaultHttpProvider.httpClient.Timeout);

                Assert.IsType(typeof(Serializer), defaultHttpProvider.Serializer);
            }
        }

        [Fact]
        public async Task OverallTimeout_RequestAlreadySent()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);
                var returnedResponseMessage = await this.httpProvider.SendAsync(httpRequestMessage);
            }

            try
            {
                Assert.Throws<ServiceException>( () => this.httpProvider.OverallTimeout = new TimeSpan(0, 0, 30));
            }
            catch (ServiceException serviceException)
            {
                Assert.True(serviceException.IsMatch(ErrorConstants.Codes.NotAllowed));
                Assert.Equal(
                    ErrorConstants.Messages.OverallTimeoutCannotBeSet,
                    serviceException.Error.Message);
                Assert.IsType(typeof(InvalidOperationException), serviceException.InnerException);

                throw;
            }
        }

        [Fact]
        public async Task SendAsync()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);
                var returnedResponseMessage = await this.httpProvider.SendAsync(httpRequestMessage);

                Assert.Equal(httpResponseMessage, returnedResponseMessage);
            }
        }

        [Fact]
        public async Task SendAsync_ClientGeneralException()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            {
                this.httpProvider.Dispose();

                var clientException = new Exception();
                this.httpProvider = new HttpProvider(new ExceptionHttpMessageHandler(clientException), /* disposeHandler */ true, null);

                try
                {
                    await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.SendRequestAsync(
                        httpRequestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None));
                }
                catch (ServiceException exception)
                {
                    Assert.True(exception.IsMatch(ErrorConstants.Codes.GeneralException));
                    Assert.Equal(ErrorConstants.Messages.UnexpectedExceptionOnSend, exception.Error.Message);
                    Assert.Equal(clientException, exception.InnerException);

                    throw;
                }
            }
        }

        [Fact]
        public async Task SendAsync_ClientTimeout()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            {
                this.httpProvider.Dispose();

                var clientException = new TaskCanceledException();
                this.httpProvider = new HttpProvider(new ExceptionHttpMessageHandler(clientException), /* disposeHandler */ true, null);

                try
                {
                    await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.SendRequestAsync(
                        httpRequestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None));
                }
                catch (ServiceException exception)
                {
                    Assert.True(exception.IsMatch(ErrorConstants.Codes.Timeout));
                    Assert.Equal(ErrorConstants.Messages.RequestTimedOut, exception.Error.Message);
                    Assert.Equal(clientException, exception.InnerException);

                    throw;
                }
            }
        }

        [Fact]
        public async Task SendAsync_InvalidRedirectResponse()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                httpResponseMessage.StatusCode = HttpStatusCode.Redirect;
                httpResponseMessage.RequestMessage = httpRequestMessage;

                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);

                try
                {
                    await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.SendAsync(httpRequestMessage));
                }
                catch (ServiceException exception)
                {
                    Assert.True(exception.IsMatch(ErrorConstants.Codes.GeneralException));
                    Assert.Equal(
                        ErrorConstants.Messages.LocationHeaderNotSetOnRedirect,
                        exception.Error.Message);

                    throw;
                }
            }
        }

        [Fact]
        public async Task SendAsync_RedirectResponse_VerifyHeadersOnRedirect()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var redirectResponseMessage = new HttpResponseMessage())
            using (var finalResponseMessage = new HttpResponseMessage())
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", "token");
                httpRequestMessage.Headers.Add("testHeader", "testValue");
                httpRequestMessage.Headers.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };

                redirectResponseMessage.StatusCode = HttpStatusCode.Redirect;
                redirectResponseMessage.Headers.Location = new Uri("https://localhost/redirect");
                redirectResponseMessage.RequestMessage = httpRequestMessage;

                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), redirectResponseMessage);
                this.testHttpMessageHandler.AddResponseMapping(redirectResponseMessage.Headers.Location.ToString(), finalResponseMessage);

                var returnedResponseMessage = await this.httpProvider.SendAsync(httpRequestMessage);

                Assert.Equal(3, finalResponseMessage.RequestMessage.Headers.Count());

                foreach (var header in httpRequestMessage.Headers)
                {
                    var actualValues = finalResponseMessage.RequestMessage.Headers.GetValues(header.Key);

                    Assert.Equal(actualValues.Count(), header.Value.Count());

                    foreach (var headerValue in header.Value)
                    {
                        Assert.True(actualValues.Contains(headerValue));
                    }
                }
            }
        }

        [Fact]
        public async Task SendAsync_MaxRedirects()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var redirectResponseMessage = new HttpResponseMessage())
            using (var tooManyRedirectsResponseMessage = new HttpResponseMessage())
            {
                redirectResponseMessage.StatusCode = HttpStatusCode.Redirect;
                redirectResponseMessage.Headers.Location = new Uri("https://localhost/redirect");
                tooManyRedirectsResponseMessage.StatusCode = HttpStatusCode.Redirect;

                redirectResponseMessage.RequestMessage = httpRequestMessage;

                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), redirectResponseMessage);
                this.testHttpMessageHandler.AddResponseMapping(redirectResponseMessage.Headers.Location.ToString(), tooManyRedirectsResponseMessage);

                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(CoreConstants.Headers.Bearer, "ticket");

                try
                {
                    await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.HandleRedirect(
                        redirectResponseMessage,
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None,
                        5));
                }
                catch (ServiceException exception)
                {
                    Assert.True(exception.IsMatch(ErrorConstants.Codes.TooManyRedirects));
                    Assert.Equal(
                        string.Format(ErrorConstants.Messages.TooManyRedirectsFormatString, "5"),
                        exception.Error.Message);

                    throw;
                }
            }
        }

        [Fact]
        public async Task SendAsync_NotFoundWithoutErrorBody()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost"))
            using (var stringContent = new StringContent("test"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                httpResponseMessage.Content = stringContent;
                httpResponseMessage.StatusCode = HttpStatusCode.NotFound;

                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<ErrorResponse>(
                        It.IsAny<Stream>()))
                    .Returns((ErrorResponse)null);

                try
                {
                    await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.SendAsync(httpRequestMessage));
                }
                catch (ServiceException exception)
                {
                    Assert.True(exception.IsMatch(ErrorConstants.Codes.ItemNotFound));
                    Assert.True(string.IsNullOrEmpty(exception.Error.Message));

                    throw;
                }
            }
        }

        [Fact]
        public async Task SendAsync_NotFoundWithBody()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var stringContent = new StringContent("test"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                httpResponseMessage.Content = stringContent;
                httpResponseMessage.StatusCode = HttpStatusCode.InternalServerError;

                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);

                var expectedError = new ErrorResponse
                {
                    Error = new Error
                    {
                        Code = ErrorConstants.Codes.ItemNotFound,
                        Message = "Error message"
                    }
                };

                this.serializer.Setup(serializer => serializer.DeserializeObject<ErrorResponse>(It.IsAny<Stream>())).Returns(expectedError);

                try
                {
                    await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.SendAsync(httpRequestMessage));
                }
                catch (ServiceException exception)
                {
                    Assert.Equal(expectedError.Error.Code, exception.Error.Code);
                    Assert.Equal(expectedError.Error.Message, exception.Error.Message);

                    throw;
                }
            }
        }

        [Fact]
        public async Task SendAsync_CopyThrowSiteHeader()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                const string throwSite = "throw site";

                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add(CoreConstants.Headers.ThrowSiteHeaderName, throwSite);
                httpResponseMessage.RequestMessage = httpRequestMessage;

                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<ErrorResponse>(
                        It.IsAny<Stream>()))
                    .Returns(new ErrorResponse { Error = new Error() });

                try
                {
                    await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.SendAsync(httpRequestMessage));
                }
                catch (ServiceException exception)
                {
                    Assert.NotNull(exception.Error);
                    Assert.Equal(
                        throwSite,
                        exception.Error.ThrowSite);

                    throw;
                }
            }
        }

        [Fact]
        public async Task SendAsync_CopyThrowSiteHeader_ThrowSiteAlreadyInError()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var stringContent = new StringContent("test"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                httpResponseMessage.Content = stringContent;

                const string throwSiteBodyValue = "throw site in body";
                const string throwSiteHeaderValue = "throw site in header";

                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Headers.Add(CoreConstants.Headers.ThrowSiteHeaderName, throwSiteHeaderValue);
                httpResponseMessage.RequestMessage = httpRequestMessage;

                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<ErrorResponse>(
                        It.IsAny<Stream>()))
                    .Returns(new ErrorResponse { Error = new Error { ThrowSite = throwSiteBodyValue } });

                try
                {
                    await Assert.ThrowsAsync<ServiceException>(async () => await this.httpProvider.SendAsync(httpRequestMessage));
                }
                catch (ServiceException exception)
                {
                    Assert.NotNull(exception.Error);
                    Assert.Equal(
                        throwSiteBodyValue,
                        exception.Error.ThrowSite);

                    throw;
                }
            }
        }
    }
}
