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
        private const string expectedAccessToken = "graph-client-factory-infused-token";
        private MockAuthenticationProvider testAuthenticationProvider;

        public GraphClientFactoryTests()
        {
            this.testHttpMessageHandler = new MockRedirectHandler();
            testAuthenticationProvider = new MockAuthenticationProvider(expectedAccessToken);
            handlers = GraphClientFactory.CreateDefaultHandlers(testAuthenticationProvider.Object).ToArray();
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
            using (AuthenticationHandler authenticationHandler = (AuthenticationHandler)GraphClientFactory.CreatePipeline(handlers))
            using (CompressionHandler compressionHandler = (CompressionHandler)authenticationHandler.InnerHandler)
            using (RetryHandler retryHandler = (RetryHandler)compressionHandler.InnerHandler)
            using (RedirectHandler redirectHandler = (RedirectHandler)retryHandler.InnerHandler)
            using (HttpMessageHandler innerMost = redirectHandler.InnerHandler)
            {
                Assert.NotNull(authenticationHandler);
                Assert.NotNull(compressionHandler);
                Assert.NotNull(retryHandler);
                Assert.NotNull(redirectHandler);
                Assert.NotNull(innerMost);
                Assert.IsType(typeof(AuthenticationHandler), authenticationHandler);
                Assert.IsType(typeof(CompressionHandler), compressionHandler);
                Assert.IsType(typeof(RetryHandler), retryHandler);
                Assert.IsType(typeof(RedirectHandler), redirectHandler);
                Assert.True(innerMost is HttpMessageHandler);
            }
        }

        [Fact]
        public void CreatePipelineWithHttpMessageHandlerInput()
        {
            using (AuthenticationHandler authenticationHandler = (AuthenticationHandler)GraphClientFactory.CreatePipeline(handlers, this.testHttpMessageHandler))
            using (CompressionHandler compressionHandler = (CompressionHandler)authenticationHandler.InnerHandler)
            using (RetryHandler retryHandler = (RetryHandler)compressionHandler.InnerHandler)
            using (RedirectHandler redirectHandler = (RedirectHandler)retryHandler.InnerHandler)
            using (MockRedirectHandler innerMost = (MockRedirectHandler)redirectHandler.InnerHandler)
            {
                Assert.NotNull(authenticationHandler);
                Assert.NotNull(compressionHandler);
                Assert.NotNull(retryHandler);
                Assert.NotNull(redirectHandler);
                Assert.NotNull(innerMost);
                Assert.IsType(typeof(AuthenticationHandler), authenticationHandler);
                Assert.IsType(typeof(CompressionHandler), compressionHandler);
                Assert.IsType(typeof(RetryHandler), retryHandler);
                Assert.IsType(typeof(RedirectHandler), redirectHandler);
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
        public void CreatePipeline_Should_Throw_Exception_With_Duplicate_Handlers()
        {
            var handlers = GraphClientFactory.CreateDefaultHandlers(testAuthenticationProvider.Object);
            handlers.Add(new AuthenticationHandler(testAuthenticationProvider.Object));

            ArgumentException exception =  Assert.Throws<ArgumentException>(() => GraphClientFactory.CreatePipeline(handlers));

            Assert.Contains($"{typeof(AuthenticationHandler)} has a duplicate handler.", exception.Message);
        }

        [Fact]
        public void CreateClient_CustomHttpHandlingBehaviors()
        {
            var timeout = TimeSpan.FromSeconds(200);
            var baseAddress = new Uri("https://localhost");
            var cacheHeader = new CacheControlHeaderValue();
            
            using (HttpClient client = GraphClientFactory.Create(testAuthenticationProvider.Object))
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
            using (HttpClient httpClient = GraphClientFactory.Create(testAuthenticationProvider.Object, version: "beta", nationalCloud: GraphClientFactory.Germany_Cloud))
            {
                Assert.NotNull(httpClient);
                Uri clouldEndpoint = new Uri("https://graph.microsoft.de/beta/");
                Assert.Equal(httpClient.BaseAddress, clouldEndpoint);
                Assert.Equal(httpClient.Timeout, TimeSpan.FromSeconds(100));
            }
        }

        [Fact]
        public void CreateClient_SelectedCloudWithExceptions()
        {
            string nation = "Canada";
            try
            {
                HttpClient httpClient = GraphClientFactory.Create(testAuthenticationProvider.Object, nationalCloud: nation);
            }
            catch (ArgumentException exception)
            {
                Assert.IsType(typeof(ArgumentException), exception);
                Assert.Equal(exception.Message, String.Format("{0} is an unexpected national cloud.", nation));
            }
        }

        [Fact]
        public void CreateClient_WithInnerHandler()
        {
            using (HttpClient httpClient = GraphClientFactory.Create(authenticationProvider: testAuthenticationProvider.Object, finalHandler: this.testHttpMessageHandler))
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
            using (HttpClient client = GraphClientFactory.Create(handlers: GraphClientFactory.CreateDefaultHandlers(testAuthenticationProvider.Object)))
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

            using (HttpClient client = GraphClientFactory.Create(authenticationProvider: testAuthenticationProvider.Object, finalHandler: this.testHttpMessageHandler))
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

            using (HttpClient client = GraphClientFactory.Create(authenticationProvider: testAuthenticationProvider.Object, finalHandler: this.testHttpMessageHandler))
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.Same(response, response_2);
                IEnumerable<string> values;
                Assert.True(response.RequestMessage.Headers.TryGetValues("Retry-Attempt", out values), "Don't set Retry-Attemp Header");
                Assert.Equal(values.Count(), 1);
                Assert.Equal(values.First(), 1.ToString());
                Assert.NotSame(response.RequestMessage, httpRequestMessage);
            }

        }

        [Fact(Skip = "In order to support HttpProvider, we'll skip authentication if no provider is set. We will add enable this once we re-write a new HttpProvider.")]
        public async Task SendRequest_UnauthorizedWithNoAuthenticationProvider()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "https://example.com/bar");
            httpRequestMessage.Content = new StringContent("Hello World");

            var unauthorizedResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var okResponse = new HttpResponseMessage(HttpStatusCode.OK);

            testHttpMessageHandler.SetHttpResponse(unauthorizedResponse, okResponse);

            IList<DelegatingHandler> handlersWithNoAuthProvider = GraphClientFactory.CreateDefaultHandlers(null);

            using (HttpClient client = GraphClientFactory.Create(handlers: handlersWithNoAuthProvider, finalHandler: this.testHttpMessageHandler))
            {
                ServiceException ex = await Assert.ThrowsAsync<ServiceException>(() => client.SendAsync(httpRequestMessage, new CancellationToken()));
                Assert.Equal(ErrorConstants.Codes.InvalidRequest, ex.Error.Code);
                Assert.Equal(ErrorConstants.Messages.AuthenticationProviderMissing, ex.Error.Message);
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

            using (HttpClient client = GraphClientFactory.Create(handlers: handlers, finalHandler: this.testHttpMessageHandler))
            {
                var response = await client.SendAsync(httpRequestMessage, new CancellationToken());
                Assert.Same(response, okResponse);
                Assert.Equal(response.RequestMessage.Headers.Authorization, new AuthenticationHeaderValue(CoreConstants.Headers.Bearer, expectedAccessToken));
            }
        }

        [Fact]
        public void CreateClient_WithHandlersHasExceptions()
        {
            var pipelineHandlers = GraphClientFactory.CreateDefaultHandlers(testAuthenticationProvider.Object).ToArray();
            pipelineHandlers[pipelineHandlers.Length - 1] = null;
            try
            {
                HttpClient client = GraphClientFactory.Create(handlers: pipelineHandlers);
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsType(typeof(ArgumentNullException), exception);
                Assert.Equal(exception.ParamName, "handlers");
            }

            pipelineHandlers[pipelineHandlers.Length - 1] = new RetryHandler(this.testHttpMessageHandler);
            try
            {
                HttpClient client = GraphClientFactory.Create(handlers: pipelineHandlers);
            }
            catch (ArgumentException exception)
            {
                Assert.IsType(typeof(ArgumentException), exception);
                Assert.Equal(exception.Message, String.Format("DelegatingHandler array has unexpected InnerHandler. {0} has unexpected InnerHandler.", pipelineHandlers[pipelineHandlers.Length - 1]));

            }

        }

        [Fact]
        public void CreatePipelineWithFeatureFlags_Should_Set_FeatureFlag_For_Default_Handlers()
        {
            FeatureFlag expectedFlag = FeatureFlag.AuthHandler | FeatureFlag.CompressionHandler | FeatureFlag.RetryHandler | FeatureFlag.RedirectHandler;
            string expectedFlagHeaderValue = Enum.Format(typeof(FeatureFlag), expectedFlag, "x");
            var handlers = GraphClientFactory.CreateDefaultHandlers(null);
            var pipelineWithHandlers = GraphClientFactory.CreatePipelineWithFeatureFlags(handlers);

            Assert.NotNull(pipelineWithHandlers.Pipeline);
            Assert.True(pipelineWithHandlers.FeatureFlags.HasFlag(expectedFlag));
        }

        [Fact]
        public void CreatePipelineWithFeatureFlags_Should_Set_FeatureFlag_For_Speficied_Handlers()
        {
            FeatureFlag expectedFlag = FeatureFlag.AuthHandler | FeatureFlag.CompressionHandler | FeatureFlag.RetryHandler;
            var handlers = GraphClientFactory.CreateDefaultHandlers(null);
            handlers.RemoveAt(3);
            var pipelineWithHandlers = GraphClientFactory.CreatePipelineWithFeatureFlags(handlers);

            Assert.NotNull(pipelineWithHandlers.Pipeline);
            Assert.True(pipelineWithHandlers.FeatureFlags.HasFlag(expectedFlag));
        }
    }
}
