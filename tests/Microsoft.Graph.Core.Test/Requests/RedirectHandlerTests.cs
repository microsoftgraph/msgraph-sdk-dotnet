// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Requests
{
    using System;
    using Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;


    [TestClass]
    public class RedirectHandlerTests 
    {
        private MockRedirectHandler testHttpMessageHandler;
        private RedirectHandler redirectHandler;
        private HttpMessageInvoker invoker;

        [TestInitialize]
        public void Setup()
        {
            this.testHttpMessageHandler = new MockRedirectHandler();
            this.redirectHandler = new RedirectHandler(this.testHttpMessageHandler);
            this.invoker = new HttpMessageInvoker(this.redirectHandler);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.invoker.Dispose();
        }

        [TestMethod]
        public void RedirectHandler_HttpMessageHandlerConstructor()
        {
            Assert.IsNotNull(redirectHandler.InnerHandler, "HttpMessageHandler not initialized.");
            Assert.AreEqual(redirectHandler.InnerHandler, testHttpMessageHandler, "Unexpected message handler set.");
            Assert.IsInstanceOfType(redirectHandler, typeof(RedirectHandler), "Unexpected redirect handler set.");
        }

        [TestMethod]
        public async Task OkStatusShouldPassThrough()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");

            var redirectResponse = new HttpResponseMessage(HttpStatusCode.OK);
            this.testHttpMessageHandler.SetHttpResponse(redirectResponse);

            var response = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, "Http response message with non redirect status passes failed.");
            Assert.AreSame(response.RequestMessage, httpRequestMessage, "Http response message sets request wrongly.");
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.MovedPermanently)]  // 301
        [DataRow(HttpStatusCode.Found)]  // 302
        [DataRow(HttpStatusCode.TemporaryRedirect)]  // 307
        [DataRow(308)] // 308
        public async Task ShouldRedirectSameMethodAndContent(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Hello World");

            var redirectResponse = new HttpResponseMessage(statusCode);
            redirectResponse.Headers.Location = new Uri("http://example.org/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreEqual(response.RequestMessage.Method, httpRequestMessage.Method, "Http request method changes");
            Assert.AreNotSame(response.RequestMessage, httpRequestMessage, "Doesn't reissue new http request");
            Assert.IsNotNull(response.RequestMessage.Content, "Request content is removed.");
            Assert.AreEqual(response.RequestMessage.Content.ReadAsStringAsync().Result, "Hello World", "Request content changes.");
        }

        [TestMethod]
        public async Task ShouldRedirectChangeMethodAndContent()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Hello World");

            var redirectResponse = new HttpResponseMessage(HttpStatusCode.SeeOther);
            redirectResponse.Headers.Location = new Uri("http://example.org/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreNotEqual(response.RequestMessage.Method, httpRequestMessage.Method, "Http request method doesn't change");
            Assert.AreEqual(response.RequestMessage.Method, HttpMethod.Get, "Http request method changes wrongly.");
            Assert.AreNotSame(response.RequestMessage, httpRequestMessage, "Doesn't reissue new http request");
            Assert.IsNull(response.RequestMessage.Content, "Request content still exists.");
        }

        [TestMethod]
        public async Task RedirectWithSameHostShouldKeepAuthHeader()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("fooAuth", "aparam");

            var redirectResponse = new HttpResponseMessage(HttpStatusCode.Redirect);
            redirectResponse.Headers.Location = new Uri("http://example.org/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());
            Assert.AreNotSame(response.RequestMessage, httpRequestMessage, "Doesn't reissue new http request");
            Assert.AreEqual(response.RequestMessage.Headers.Authorization.Scheme, "fooAuth", "AuthHeader changes");
            Assert.AreEqual(response.RequestMessage.RequestUri.Host, httpRequestMessage.RequestUri.Host, "Http request hosts are not euqal.");
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.MovedPermanently)]  // 301
        [DataRow(HttpStatusCode.Found)]  // 302
        [DataRow(HttpStatusCode.SeeOther)]  //303
        [DataRow(HttpStatusCode.TemporaryRedirect)]  // 307
        [DataRow(308)] // 308
        public async Task RedirectWithDifferentHostShouldRemoveAuthHeader(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("fooAuth", "aparam");

            var redirectResponse = new HttpResponseMessage(statusCode);
            redirectResponse.Headers.Location = new Uri("http://example.net/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreNotSame(response.RequestMessage, httpRequestMessage, "Doesn't reissue a new http request");
            Assert.AreNotEqual(response.RequestMessage.RequestUri.Host, httpRequestMessage.RequestUri.Host, "Hosts are same.");
            Assert.IsNull(response.RequestMessage.Headers.Authorization, "Authorization doesn't be removed.");
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.MovedPermanently)]  // 301
        [DataRow(HttpStatusCode.Found)]  // 302
        [DataRow(HttpStatusCode.SeeOther)]  //303
        [DataRow(HttpStatusCode.TemporaryRedirect)]  // 307
        [DataRow(308)] // 308
        public async Task RedirectWithDifferentSchemeShouldRemoveAuthHeader(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://example.org/foo");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("fooAuth", "aparam");

            var redirectResponse = new HttpResponseMessage(statusCode);
            redirectResponse.Headers.Location = new Uri("http://example.org/bar");

            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, new HttpResponseMessage(HttpStatusCode.OK));

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreNotSame(response.RequestMessage, httpRequestMessage, "Doesn't reissue a new http request");
            Assert.AreNotEqual(response.RequestMessage.RequestUri.Scheme, httpRequestMessage.RequestUri.Scheme, "Schemes are same.");
            Assert.IsNull(response.RequestMessage.Headers.Authorization, "Authorization doesn't be removed.");
        }

        [TestMethod]
        public async Task ExceedMaxRedirectsShouldReturn()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");

            var _response1 = new HttpResponseMessage(HttpStatusCode.Redirect);
            _response1.Headers.Location = new Uri("http://example.org/bar");

            var _response2 = new HttpResponseMessage(HttpStatusCode.Redirect);
            _response2.Headers.Location = new Uri("http://example.org/foo");

            this.testHttpMessageHandler.SetHttpResponse(_response1, _response2);
            
            try
            {
                await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());
            }
            catch (ServiceException exception)
            {
                Assert.IsTrue(exception.IsMatch(ErrorConstants.Codes.TooManyRedirects), "Unexpected error code returned.");
                Assert.AreEqual(String.Format(ErrorConstants.Messages.TooManyRedirectsFormatString, 5), exception.Error.Message, "Unexpected error message.");
                Assert.IsInstanceOfType(exception, typeof(ServiceException), "Eeception is not the right type");
            }
        }

    }
}
