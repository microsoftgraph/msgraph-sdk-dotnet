// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Requests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    [TestClass]
    public class GraphClientFactoryTests
    {
        private DelegatingHandler[] handlers = new DelegatingHandler[3];
        private MockRedirectHandler testHttpMessageHandler;
        private MockAuthenticationProvider authenticationProvider = new MockAuthenticationProvider();

        [TestInitialize]
        public void Setup()
        {
            this.testHttpMessageHandler = new MockRedirectHandler();
            handlers[0] = new RetryHandler();
            handlers[1] = new RedirectHandler();
            handlers[2] = new AuthenticationHandler(authenticationProvider.Object);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.testHttpMessageHandler.Dispose();
        }

        [TestMethod]
        public void CreatePipelineWithoutHttpMessageHandlerInput()
        {
            using (RetryHandler retryHandler = (RetryHandler)GraphClientFactory.CreatePipeline(handlers))
            using (RedirectHandler redirectHandler = (RedirectHandler)retryHandler.InnerHandler)
            using (AuthenticationHandler authenticationHandler = (AuthenticationHandler) redirectHandler.InnerHandler)
            using (HttpMessageHandler innerMost = authenticationHandler.InnerHandler)
            {
                Assert.IsNotNull(retryHandler, "Create a middleware pipeline failed.");
                Assert.IsNotNull(redirectHandler, "Create a middleware pipeline failed.");
                Assert.IsNotNull(authenticationHandler, "Create a middleware pipeline failed");
                Assert.IsNotNull(innerMost, "Create inner most HttpMessageHandler failed.");
                Assert.IsInstanceOfType(retryHandler, typeof(RetryHandler), "Pass pipeline failed in first level.");
                Assert.IsInstanceOfType(redirectHandler, typeof(RedirectHandler), "Pass pipeline failed in seconde level.");
                Assert.IsInstanceOfType(authenticationHandler, typeof(AuthenticationHandler), "Pass pipeline failed in third level.");
                Assert.IsInstanceOfType(innerMost, typeof(HttpMessageHandler), "Inner most HttpMessageHandler class error.");
            }

        }

        [TestMethod]
        public void CreatePipelineWithHttpMessageHandlerInput()
        {
            using (RetryHandler retryHandler = (RetryHandler)GraphClientFactory.CreatePipeline(handlers,this.testHttpMessageHandler))
            using (RedirectHandler redirectHandler = (RedirectHandler)retryHandler.InnerHandler)
            using (AuthenticationHandler authenticationHandler = (AuthenticationHandler)redirectHandler.InnerHandler)
            using (MockRedirectHandler innerMost = (MockRedirectHandler)authenticationHandler.InnerHandler)
            {
                Assert.IsNotNull(retryHandler, "Create a middleware pipeline failed.");
                Assert.IsNotNull(redirectHandler, "Create a middleware pipeline failed.");
                Assert.IsNotNull(authenticationHandler, "Create a middleware pipeline failed.");
                Assert.IsNotNull(innerMost, "Create inner most HttpMessageHandler failed.");
                Assert.IsInstanceOfType(retryHandler, typeof(RetryHandler), "Pass pipeline failed in first level.");
                Assert.IsInstanceOfType(redirectHandler, typeof(RedirectHandler), "Pass pipeline failed in seconde level.");
                Assert.IsInstanceOfType(authenticationHandler, typeof(AuthenticationHandler), "Pass pipeline failed in third level.");
                Assert.IsInstanceOfType(innerMost, typeof(MockRedirectHandler), "Inner most HttpMessageHandler class error.");
            }
        }


        [TestMethod]
        public void CreatePipelineWithoutPipeline()
        {
            GraphClientFactory.DefaultHttpHandler = () => this.testHttpMessageHandler;
            using (RetryHandler handler = (RetryHandler)GraphClientFactory.CreatePipeline(handlers: handlers))
            {
                Assert.IsNotNull(handler, "Create a middleware pipeline failed.");
                Assert.IsInstanceOfType(handler, typeof(RetryHandler), "Inner most HttpMessageHandler class error.");
            }
        }

        [TestMethod]
        public void CreateClient_CustomHttpHandlingBehaviors()
        {
            var timeout = TimeSpan.FromSeconds(200);
            var baseAddress = new Uri("https://localhost");
            var cacheHeader = new CacheControlHeaderValue();
            GraphClientFactory.Proxy = new WebProxy("http://127.0.0.1:8888");

            using (HttpClient client = GraphClientFactory.Create())
            {
                client.Timeout = timeout;
                client.BaseAddress = baseAddress;
                Assert.IsNotNull(client, "Create Http client failed.");
                Assert.AreEqual(client.Timeout, timeout, "Unexpected default timeout set.");
                Assert.AreEqual(client.BaseAddress, baseAddress, "Unexpected default baseAddress set.");
            }
        }

        [TestMethod]
        public void CreateClient_SelectedCloudAndVersion()
        {
            using (HttpClient httpClient = GraphClientFactory.Create(version: "beta", nationalCloud: GraphCloud.Germany))
            {
                Assert.IsNotNull(httpClient, "Create Http client failed.");
                Uri clouldEndpoint = new Uri("https://graph.microsoft.de/beta");
                Assert.AreEqual(httpClient.BaseAddress, clouldEndpoint, "Unexpected endpoint set.");
                Assert.AreEqual(httpClient.Timeout, TimeSpan.FromSeconds(100), "Default timeout not set.");
            }
        }

        [TestMethod]
        public void CreateClient_SelectedCloudWithExceptions()
        {
            try
            {
                HttpClient httpClient = GraphClientFactory.Create(nationalCloud: (GraphCloud)7);
            }
            catch (ArgumentException exception)
            {
                Assert.IsInstanceOfType(exception, typeof(ArgumentException), "Eeception is not the right type");
                Assert.AreEqual(exception.Message, String.Format("{0} is an unexpected national cloud.", 7));
            }
        }

        [TestMethod]
        public void CreateClient_WithInnerHandler()
        {
            GraphClientFactory.DefaultHttpHandler = () => this.testHttpMessageHandler;
            using (HttpClient httpClient = GraphClientFactory.Create())
            {
                Assert.IsNotNull(httpClient, "Create Http client failed.");
                Assert.IsTrue(httpClient.DefaultRequestHeaders.Contains(CoreConstants.Headers.SdkVersionHeaderName), "SDK version not set.");
                Version assemblyVersion = typeof(GraphClientFactory).GetTypeInfo().Assembly.GetName().Version;
                string value = string.Format(
                    CoreConstants.Headers.SdkVersionHeaderValueFormatString,
                    "Graph",
                    assemblyVersion.Major,
                    assemblyVersion.Minor,
                    assemblyVersion.Build);
                IEnumerable<string> values;
                Assert.IsTrue(httpClient.DefaultRequestHeaders.TryGetValues(CoreConstants.Headers.SdkVersionHeaderName, out values), "SDK version value not set");
                Assert.AreEqual(values.Count(), 1);
                Assert.AreEqual(values.First(), value);
            }
        }


        [TestMethod]
        public void CreateClient_WithHandlers()
        {
            using (HttpClient client = GraphClientFactory.Create())
            {
                Assert.IsNotNull(client, "Create Http client failed.");
            }
        }


        [TestMethod]
        public async Task SendRequest_Redirect()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            var redirectResponse = new HttpResponseMessage(HttpStatusCode.MovedPermanently);

            redirectResponse.Headers.Location = new Uri("http://example.org/bar");
            var oKResponse = new HttpResponseMessage(HttpStatusCode.OK);
            this.testHttpMessageHandler.SetHttpResponse(redirectResponse, oKResponse);
            GraphClientFactory.DefaultHttpHandler = () => this.testHttpMessageHandler;

            using (HttpClient client = GraphClientFactory.Create())
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.AreEqual(response, oKResponse, "Middleware pipeline not work.");
                Assert.AreEqual(response.RequestMessage.Method, httpRequestMessage.Method);
                Assert.AreNotSame(response.RequestMessage, httpRequestMessage);
            }

        }

        [TestMethod]
        public async Task SendRequest_Retry()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Hello World");

            var retryResponse = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            retryResponse.Headers.TryAddWithoutValidation("Retry-After", 30.ToString());
            var response_2 = new HttpResponseMessage(HttpStatusCode.OK);

            this.testHttpMessageHandler.SetHttpResponse(retryResponse, response_2);
            GraphClientFactory.DefaultHttpHandler = () => this.testHttpMessageHandler;

            using (HttpClient client = GraphClientFactory.Create())
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.AreSame(response, response_2);
                IEnumerable<string> values;
                Assert.IsTrue(response.RequestMessage.Headers.TryGetValues("Retry-Attempt", out values), "Don't set Retry-Attemp Header");
                Assert.AreEqual(values.Count(), 1);
                Assert.AreEqual(values.First(), 1.ToString());
                Assert.AreNotSame(response.RequestMessage, httpRequestMessage);
            }
        }

        [TestMethod]
        public async Task SendRequest_UnauthorizedWithNoAuthenticationProvider()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "https://example.com/bar");
            httpRequestMessage.Content = new StringContent("Hello World");

            var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK);

            testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, okResponse);
            GraphClientFactory.DefaultHttpHandler = () => this.testHttpMessageHandler;

            using (HttpClient client = GraphClientFactory.Create())
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.AreSame(response, unauthorizedResponse);
                Assert.AreSame(response.RequestMessage, httpRequestMessage);
            }
        }

        [TestMethod]
        public async Task SendRequest_UnauthorizedWithAuthenticationProvider()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "https://example.com/bar");
            httpRequestMessage.Content = new StringContent("Hello World");

            var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK);

            testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, okResponse);

            handlers[2] = new AuthenticationHandler(new MockAuthenticationProvider().Object);

            GraphClientFactory.DefaultHttpHandler = () => this.testHttpMessageHandler;

            using (HttpClient client = GraphClientFactory.Create( handlers: handlers))
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.AreSame(response, okResponse);
                Assert.AreNotSame(response.RequestMessage, httpRequestMessage);
            }
        }

        [TestMethod]
        public void CreateClient_WithHandlersHasExceptions()
        {
            handlers[handlers.Length - 1] = null;
            try
            {
                HttpClient client = GraphClientFactory.Create(handlers: handlers);
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsInstanceOfType(exception, typeof(ArgumentNullException), "Exception is not the right type");
                Assert.AreEqual(exception.ParamName, "handlers", "ParamName not right.");
            }
            handlers[handlers.Length - 1] = new RetryHandler(this.testHttpMessageHandler);
            try
            {
                HttpClient client = GraphClientFactory.Create(handlers: handlers);
            }
            catch (ArgumentException exception)
            {
                Assert.IsInstanceOfType(exception, typeof(ArgumentException), "Exception is not the right type");
                Assert.AreEqual(
                    exception.Message,
                    String.Format("DelegatingHandler array has unexpected InnerHandler. {0} has unexpected InnerHandler.",
                    handlers[handlers.Length - 1]));

            }

        }
    }
}
