// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests
{
    using Mocks;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Net;
    using Xunit;

    public class GraphClientFactoryTests : IDisposable
    {
        private MockRedirectHandler testHttpMessageHandler;
        private DelegatingHandler[] handlers;
        private MockAuthenticationProvider authenticationProvider = new MockAuthenticationProvider();

        public GraphClientFactoryTests()
        {
            this.testHttpMessageHandler = new MockRedirectHandler();
            handlers = new DelegatingHandler[3];
            handlers[0] = new RetryHandler();
            handlers[1] = new RedirectHandler();
            handlers[2] = new AuthenticationHandler(authenticationProvider.Object);

        }

        public void Dispose()
        {
            this.testHttpMessageHandler.Dispose();
        }

        // Note:
        // 1. Xunit's IsType doesn't consider inheritance behind the classes.
        // 2. We can't control the order of execution for the tests
        // and 'GraphClientFactory.DefaultHttpHandler' can easily be modified
        // by other tests since it's a static delegate.
        [Fact]
        public void CreatePipelineWithoutHttpMessageHandlerInput()
        {
            using (RetryHandler retryHandler = (RetryHandler)GraphClientFactory.CreatePipeline(handlers))
            using (RedirectHandler redirectHandler = (RedirectHandler)retryHandler.InnerHandler)
            using (AuthenticationHandler authenticationHandler = (AuthenticationHandler)redirectHandler.InnerHandler)
            using (HttpMessageHandler innerMost = authenticationHandler.InnerHandler)
            {
                Assert.NotNull(retryHandler);
                Assert.NotNull(redirectHandler);
                Assert.NotNull(authenticationHandler);
                Assert.NotNull(innerMost);
                Assert.IsType(typeof(RetryHandler), retryHandler);
                Assert.IsType(typeof(RedirectHandler), redirectHandler);
                Assert.IsType(typeof(AuthenticationHandler), authenticationHandler);
                Assert.True(innerMost is HttpMessageHandler);
            }

        }

        [Fact]
        public void CreatePipelineWithHttpMessageHandlerInput()
        {
            using (RetryHandler retryHandler = (RetryHandler)GraphClientFactory.CreatePipeline(handlers, this.testHttpMessageHandler))
            using (RedirectHandler redirectHandler = (RedirectHandler)retryHandler.InnerHandler)
            using (AuthenticationHandler authenticationHandler = (AuthenticationHandler)redirectHandler.InnerHandler)
            using (MockRedirectHandler innerMost = (MockRedirectHandler)authenticationHandler.InnerHandler)
            {
                Assert.NotNull(retryHandler);
                Assert.NotNull(redirectHandler);
                Assert.NotNull(authenticationHandler);
                Assert.NotNull(innerMost);
                Assert.IsType(typeof(RetryHandler), retryHandler);
                Assert.IsType(typeof(RedirectHandler), redirectHandler);
                Assert.IsType(typeof(AuthenticationHandler), authenticationHandler);
                Assert.IsType(typeof(MockRedirectHandler), innerMost);
            }
        }

        [Fact]
        public void CreatePipelineWithoutPipeline()
        {
            using (MockRedirectHandler handler = (MockRedirectHandler)GraphClientFactory.CreatePipeline(null, this.testHttpMessageHandler))
            {
                Assert.NotNull(handler);
                Assert.IsType(typeof(MockRedirectHandler), handler);
            }
        }

        [Fact]
        public void CreateClient_CustomHttpHandlingBehaviors()
        {
            var timeout = TimeSpan.FromSeconds(200);
            var baseAddress = new Uri("https://localhost");
            var cacheHeader = new CacheControlHeaderValue();
            
            using (HttpClient client = GraphClientFactory.Create())
            {
                client.Timeout = timeout;
                client.BaseAddress = baseAddress;
                Assert.NotNull(client);
                Assert.Equal(client.Timeout, timeout);
                Assert.Equal(client.BaseAddress, baseAddress);
            }
        }

        [Fact]
        public void CreateClient_SelectedCloud()
        {
            using (HttpClient httpClient = GraphClientFactory.Create(version: "beta", nationalCloud: GraphCloud.Germany))
            {
                Assert.NotNull(httpClient);
                Uri clouldEndpoint = new Uri("https://graph.microsoft.de/beta");
                Assert.Equal(httpClient.BaseAddress, clouldEndpoint);
                Assert.Equal(httpClient.Timeout, TimeSpan.FromSeconds(100));
            }
        }

        [Fact]
        public void CreateClient_SelectedCloudWithExceptions()
        {
             try
            {
                HttpClient httpClient = GraphClientFactory.Create(nationalCloud: (GraphCloud)7);
            }
            catch (ArgumentException exception)
            {
                Assert.IsType(typeof(ArgumentException), exception);
                Assert.Equal(exception.Message, String.Format("{0} is an unexpected national cloud.", 7));
            }
        }

        [Fact]
        public void CreateClient_WithInnerHandler()
        {
            GraphClientFactory.DefaultHttpHandler = () => this.testHttpMessageHandler;

            using (HttpClient httpClient = GraphClientFactory.Create())
            {
                Assert.NotNull(httpClient);
                Assert.True(httpClient.DefaultRequestHeaders.Contains(CoreConstants.Headers.SdkVersionHeaderName), "SDK version not set.");
                Version assemblyVersion = typeof(GraphClientFactory).GetTypeInfo().Assembly.GetName().Version;
                string value = string.Format(
                    CoreConstants.Headers.SdkVersionHeaderValueFormatString,
                    "Graph",
                    assemblyVersion.Major,
                    assemblyVersion.Minor,
                    assemblyVersion.Build);
                IEnumerable<string> values;
                Assert.True(httpClient.DefaultRequestHeaders.TryGetValues(CoreConstants.Headers.SdkVersionHeaderName, out values), "SDK version value not set");
                Assert.Equal(values.Count(), 1);
                Assert.Equal(values.First(), value);
            }
        }

        [Fact]
        public void CreateClient_WithHandlers()
        {
            using (HttpClient client = GraphClientFactory.Create(handlers: GraphClientFactory.CreateDefaultHandlers()))
            {
                Assert.NotNull(client);

            }

        }

        [Fact]
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
                Assert.Equal(response, oKResponse);
                Assert.Equal(response.RequestMessage.Method, httpRequestMessage.Method);
                Assert.NotSame(response.RequestMessage, httpRequestMessage);
            }

        }

        [Fact]
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
                Assert.Same(response, response_2);
                IEnumerable<string> values;
                Assert.True(response.RequestMessage.Headers.TryGetValues("Retry-Attempt", out values), "Don't set Retry-Attemp Header");
                Assert.Equal(values.Count(), 1);
                Assert.Equal(values.First(), 1.ToString());
            }

        }

        [Fact]
        public async Task SendRequest_UnauthorizedWithNoAuthenticationProvider()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "https://example.com/bar");
            httpRequestMessage.Content = new StringContent("Hello World");

            var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK);

            testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, okResponse);

            GraphClientFactory.DefaultHttpHandler = () => testHttpMessageHandler;
            using (HttpClient client = GraphClientFactory.Create())
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.Same(response, unauthorizedResponse);
                Assert.Same(response.RequestMessage, httpRequestMessage);
            }
        }

        [Fact]
        public async Task SendRequest_UnauthorizedWithAuthenticationProvider()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "https://example.com/bar");
            httpRequestMessage.Content = new StringContent("Hello World");

            var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK);

            testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, okResponse);

            handlers[2] = new AuthenticationHandler(new MockAuthenticationProvider().Object);

            GraphClientFactory.DefaultHttpHandler = () => this.testHttpMessageHandler;
            using (HttpClient client = GraphClientFactory.Create(handlers: handlers))
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.Same(response, okResponse);
                Assert.NotSame(response.RequestMessage, httpRequestMessage);
            }
        }

        [Fact]
        public void CreateClient_WithHandlersHasExceptions()
        {
            var handlers = GraphClientFactory.CreateDefaultHandlers().ToArray();
            handlers[handlers.Length - 1] = null;
            try
            {
                HttpClient client = GraphClientFactory.Create(handlers: handlers);
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsType(typeof(ArgumentNullException), exception);
                Assert.Equal(exception.ParamName, "handlers");
            }

            handlers[handlers.Length - 1] = new RetryHandler(this.testHttpMessageHandler);
            try
            {
                HttpClient client = GraphClientFactory.Create(handlers: handlers);
            }
            catch (ArgumentException exception)
            {
                Assert.IsType(typeof(ArgumentException), exception);
                Assert.Equal(exception.Message, String.Format("DelegatingHandler array has unexpected InnerHandler. {0} has unexpected InnerHandler.", handlers[handlers.Length - 1]));

            }

        }
    }
}
