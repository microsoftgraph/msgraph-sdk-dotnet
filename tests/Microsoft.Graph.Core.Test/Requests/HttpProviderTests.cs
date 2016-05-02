// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Requests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Moq;

    [TestClass]
    public class HttpProviderTests
    {
        private HttpProvider httpProvider;
        private MockSerializer serializer = new MockSerializer();
        private TestHttpMessageHandler testHttpMessageHandler;

        [TestInitialize]
        public void Setup()
        {
            this.testHttpMessageHandler = new TestHttpMessageHandler();
            this.httpProvider = new HttpProvider(this.testHttpMessageHandler, true, this.serializer.Object);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.httpProvider.Dispose();
        }

        [TestMethod]
        public void HttpProvider_CustomCacheHeaderAndTimeout()
        {
            var timeout = TimeSpan.FromSeconds(200);
            var cacheHeader = new CacheControlHeaderValue();
            using (var defaultHttpProvider = new HttpProvider(null) { CacheControlHeader = cacheHeader, OverallTimeout = timeout })
            {
                Assert.IsFalse(defaultHttpProvider.httpClient.DefaultRequestHeaders.CacheControl.NoCache, "NoCache true.");
                Assert.IsFalse(defaultHttpProvider.httpClient.DefaultRequestHeaders.CacheControl.NoStore, "NoStore true.");

                Assert.AreEqual(timeout, defaultHttpProvider.httpClient.Timeout, "Unexpected default timeout set.");
                Assert.IsNotNull(defaultHttpProvider.Serializer, "Serializer not initialized.");
                Assert.IsInstanceOfType(defaultHttpProvider.Serializer, typeof(Serializer), "Unexpected serializer initialized.");
            }
        }

        [TestMethod]
        public void HttpProvider_CustomHttpClientHandler()
        {
            using (var httpClientHandler = new HttpClientHandler())
            using (var httpProvider = new HttpProvider(httpClientHandler, false, null))
            {
                Assert.AreEqual(httpClientHandler, httpProvider.httpMessageHandler, "Unexpected message handler set.");
                Assert.IsFalse(httpProvider.disposeHandler, "Dispose handler set to true.");
            }
        }

        [TestMethod]
        public void HttpProvider_DefaultConstructor()
        {
            using (var defaultHttpProvider = new HttpProvider())
            {
                Assert.IsTrue(defaultHttpProvider.httpClient.DefaultRequestHeaders.CacheControl.NoCache, "NoCache false.");
                Assert.IsTrue(defaultHttpProvider.httpClient.DefaultRequestHeaders.CacheControl.NoStore, "NoStore false.");

                Assert.IsTrue(defaultHttpProvider.disposeHandler, "Dispose handler set to false.");
                Assert.IsNotNull(defaultHttpProvider.httpMessageHandler, "HttpClientHandler not initialized.");
                Assert.IsFalse(((HttpClientHandler)defaultHttpProvider.httpMessageHandler).AllowAutoRedirect, "AllowAutoRedirect set to true.");

                Assert.AreEqual(TimeSpan.FromSeconds(100), defaultHttpProvider.httpClient.Timeout, "Unexpected default timeout set.");

                Assert.IsInstanceOfType(defaultHttpProvider.Serializer, typeof(Serializer), "Unexpected serializer initialized.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
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
                this.httpProvider.OverallTimeout = new TimeSpan(0, 0, 30);
            }
            catch (ServiceException serviceException)
            {
                Assert.IsTrue(serviceException.IsMatch("notAllowed"), "Unexpected error code thrown.");
                Assert.AreEqual(
                    "Overall timeout cannot be set after the first request is sent.",
                    serviceException.Error.Message,
                    "Unexpected error message thrown.");
                Assert.IsInstanceOfType(serviceException.InnerException, typeof(InvalidOperationException), "Unexpected inner exception thrown.");

                throw;
            }
        }

        [TestMethod]
        public async Task SendAsync()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);
                var returnedResponseMessage = await this.httpProvider.SendAsync(httpRequestMessage);

                Assert.AreEqual(httpResponseMessage, returnedResponseMessage, "Unexpected response returned.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public async Task SendAsync_ClientGeneralException()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            {
                this.httpProvider.Dispose();

                var clientException = new Exception();
                this.httpProvider = new HttpProvider(new ExceptionHttpMessageHandler(clientException), /* disposeHandler */ true, null);

                try
                {
                    await this.httpProvider.SendRequestAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
                }
                catch (ServiceException exception)
                {
                    Assert.IsNotNull(exception.Error, "No error body returned.");
                    Assert.AreEqual("generalException", exception.Error.Code, "Incorrect error code returned.");
                    Assert.AreEqual("An error occurred sending the request.", exception.Error.Message, "Unexpected error message.");
                    Assert.AreEqual(clientException, exception.InnerException, "Inner exception not set.");

                    throw;
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public async Task SendAsync_ClientTimeout()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            {
                this.httpProvider.Dispose();

                var clientException = new TaskCanceledException();
                this.httpProvider = new HttpProvider(new ExceptionHttpMessageHandler(clientException), /* disposeHandler */ true, null);

                try
                {
                    await this.httpProvider.SendRequestAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
                }
                catch (ServiceException exception)
                {
                    Assert.IsNotNull(exception.Error, "No error body returned.");
                    Assert.AreEqual("timeout", exception.Error.Code, "Incorrect error code returned.");
                    Assert.AreEqual("The request timed out.", exception.Error.Message, "Unexpected error message.");
                    Assert.AreEqual(clientException, exception.InnerException, "Inner exception not set.");

                    throw;
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
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
                    var returnedResponseMessage = await this.httpProvider.SendAsync(httpRequestMessage);
                }
                catch (ServiceException exception)
                {
                    Assert.IsNotNull(exception.Error, "Error not set in exception.");
                    Assert.AreEqual("generalException", exception.Error.Code, "Unexpected error code returned.");
                    Assert.AreEqual(
                        "Location header not present in redirection response.",
                        exception.Error.Message,
                        "Unexpected error message returned.");

                    throw;
                }
            }
        }

        [TestMethod]
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

                Assert.AreEqual(3, finalResponseMessage.RequestMessage.Headers.Count(), "Unexpected number of headers on redirect request message.");
                
                foreach (var header in httpRequestMessage.Headers)
                {
                    var actualValues = finalResponseMessage.RequestMessage.Headers.GetValues(header.Key);

                    Assert.AreEqual(actualValues.Count(), header.Value.Count(), "Unexpected header on redirect request message.");

                    foreach (var headerValue in header.Value)
                    {
                        Assert.IsTrue(actualValues.Contains(headerValue), "Unexpected header on redirect request message.");
                    }
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
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
                    await this.httpProvider.HandleRedirect(
                        redirectResponseMessage,
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None,
                        5);
                }
                catch (ServiceException exception)
                {
                    Assert.IsNotNull(exception.Error, "Error not set in exception.");
                    Assert.AreEqual("tooManyRedirects", exception.Error.Code, "Unexpected error code returned.");
                    Assert.AreEqual(
                        "More than 5 redirects encountered while sending the request.",
                        exception.Error.Message,
                        "Unexpected error message returned.");

                    throw;
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
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
                    await this.httpProvider.SendAsync(httpRequestMessage);
                }
                catch (ServiceException exception)
                {
                    Assert.IsNotNull(exception.Error, "No error body returned.");
                    Assert.AreEqual("itemNotFound", exception.Error.Code, "Incorrect error code returned.");
                    Assert.IsTrue(string.IsNullOrEmpty(exception.Error.Message), "Unexpected error message returned.");

                    throw;
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public async Task SendAsync_NotFoundWithBody()
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://localhost"))
            using (var stringContent = new StringContent("test"))
            using (var httpResponseMessage = new HttpResponseMessage())
            {
                httpResponseMessage.Content = stringContent;
                httpResponseMessage.StatusCode = HttpStatusCode.InternalServerError;

                this.testHttpMessageHandler.AddResponseMapping(httpRequestMessage.RequestUri.ToString(), httpResponseMessage);

                var notFoundErrorString = "itemNotFound";

                var expectedError = new ErrorResponse
                {
                    Error = new Error
                    {
                        Code = notFoundErrorString,
                        Message = "Error message"
                    }
                };

                this.serializer.Setup(serializer => serializer.DeserializeObject<ErrorResponse>(It.IsAny<Stream>())).Returns(expectedError);

                try
                {
                    await this.httpProvider.SendAsync(httpRequestMessage);
                }
                catch (ServiceException exception)
                {
                    Assert.IsNotNull(exception.Error, "No error body returned.");
                    Assert.AreEqual(notFoundErrorString, exception.Error.Code, "Incorrect error code returned.");
                    Assert.AreEqual("Error message", exception.Error.Message, "Unexpected error message.");

                    throw;
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
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
                    var returnedResponseMessage = await this.httpProvider.SendAsync(httpRequestMessage);
                }
                catch (ServiceException exception)
                {
                    Assert.IsNotNull(exception.Error, "Error not set in exception.");
                    Assert.AreEqual(
                        throwSite,
                        exception.Error.ThrowSite,
                        "Unexpected error throw site returned.");

                    throw;
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
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
                    var returnedResponseMessage = await this.httpProvider.SendAsync(httpRequestMessage);
                }
                catch (ServiceException exception)
                {
                    Assert.IsNotNull(exception.Error, "Error not set in exception.");
                    Assert.AreEqual(
                        throwSiteBodyValue,
                        exception.Error.ThrowSite,
                        "Unexpected error throw site returned.");

                    throw;
                }
            }
        }
    }
}
