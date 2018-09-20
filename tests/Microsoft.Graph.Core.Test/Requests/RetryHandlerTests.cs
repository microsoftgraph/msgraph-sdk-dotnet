// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------
 
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Graph.Core.Test.Requests
{
    using Mocks;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    

    [TestClass]
    public class RetryHandlerTests 
    {
        private MockRedirectHandler testHttpMessageHandler;
        private RetryHandler retryHandler;
        private HttpMessageInvoker invoker;
        private const string RETRY_AFTER = "Retry-After";
        private const string RETRY_ATTEMPT = "Retry-Attempt";

        [TestInitialize]
        public void Setup()
        {
            this.testHttpMessageHandler = new MockRedirectHandler();
            this.retryHandler = new RetryHandler(this.testHttpMessageHandler);
            this.invoker = new HttpMessageInvoker(this.retryHandler);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.invoker.Dispose();
        }

        [TestMethod]
        public void retryHandler_HttpMessageHandlerConstructor()
        {
            Assert.IsNotNull(retryHandler.InnerHandler, "HttpMessageHandler not initialized.");
            Assert.AreEqual(retryHandler.InnerHandler, testHttpMessageHandler, "Unexpected message handler set.");
            Assert.IsInstanceOfType(retryHandler, typeof(RetryHandler), "Unexpected redirect handler set.");
        }

        [TestMethod]
        public async Task OkStatusShouldPassThrough()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");

            var retryResponse = new HttpResponseMessage(HttpStatusCode.OK);
            this.testHttpMessageHandler.SetHttpResponse(retryResponse);

            var response = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreSame(response, retryResponse, "Return a successful response fail");
            Assert.AreSame(response.RequestMessage, httpRequestMessage, "Http response message sets request wrong.");
            Assert.IsFalse(response.RequestMessage.Headers.Contains(RETRY_ATTEMPT), "The request add header wrong.");

        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.ServiceUnavailable)]  // 503
        [DataRow(429)] // 429
        public async Task ShouldRetryWithAddRetryAttemptHeader(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");

            var retryResponse = new HttpResponseMessage(statusCode);

            var response_2 = new HttpResponseMessage(HttpStatusCode.OK);

            this.testHttpMessageHandler.SetHttpResponse(retryResponse, response_2);

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreSame(response, response_2, "Retry failed.");
            Assert.AreSame(response.RequestMessage, httpRequestMessage, "The request is set wrong.");
            Assert.IsNotNull(response.RequestMessage.Headers, "The request header is null");
            Assert.IsTrue(response.RequestMessage.Headers.Contains(RETRY_ATTEMPT), "Doesn't set Retry-Attemp header to request");
            IEnumerable<string> values;
            Assert.IsTrue(response.RequestMessage.Headers.TryGetValues(RETRY_ATTEMPT, out values), "Get Retry-Attemp Header values");
            Assert.AreEqual(values.Count(), 1, "There are multiple values for Retry-Attemp header.");
            Assert.AreEqual(values.First(), 1.ToString(), "The value of  Retry-Attemp header is wrong.");
        }


        [DataTestMethod]
        [DataRow(HttpStatusCode.ServiceUnavailable)]  // 503
        [DataRow(429)] // 429
        public async Task ShouldRetryWithBufferedContent(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Hello World");
            
            var retryResponse = new HttpResponseMessage(statusCode);

            var response_2 = new HttpResponseMessage(HttpStatusCode.OK);

            this.testHttpMessageHandler.SetHttpResponse(retryResponse, response_2);

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreSame(response, response_2, "Didn't retry.");
            Assert.IsNotNull(response.RequestMessage.Content, "The request content is null");
            Assert.IsNotNull(response.RequestMessage.Content.Headers.ContentLength, "The content length is null");
            Assert.AreNotEqual(response.RequestMessage.Content.Headers.ContentLength, -1, "The content length is set to -1.");
            Assert.AreEqual(response.RequestMessage.Content.ReadAsStringAsync().Result, "Hello World", "The content changed.");

        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.ServiceUnavailable)]  // 503
        [DataRow(429)] // 429
        public async Task ShouldNotRetryWithPostStreaming(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Test Content");
            httpRequestMessage.Content.Headers.ContentLength = -1;

            var retryResponse = new HttpResponseMessage(statusCode);

            var response_2 = new HttpResponseMessage(HttpStatusCode.OK);

            this.testHttpMessageHandler.SetHttpResponse(retryResponse, response_2);

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreNotSame(response, response_2, "Retried.");
            Assert.AreSame(response, retryResponse, "Retried.");
            Assert.IsNotNull(response.RequestMessage.Content, "The request content is null");
            Assert.IsNotNull(response.RequestMessage.Content.Headers.ContentLength, "The content length is null");
            Assert.AreEqual(response.RequestMessage.Content.Headers.ContentLength, -1, "The content length is not set to -1.");
           
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.ServiceUnavailable)]  // 503
        [DataRow(429)] // 429
        public async Task ShouldNotRetryWithPutStreaming(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Test Content");
            httpRequestMessage.Content.Headers.ContentLength = null;

            var retryResponse = new HttpResponseMessage(statusCode);

            var response_2 = new HttpResponseMessage(HttpStatusCode.OK);

            this.testHttpMessageHandler.SetHttpResponse(retryResponse, response_2);

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreNotSame(response, response_2, "Retried.");
            Assert.AreSame(response, retryResponse, "Retried.");
            Assert.IsNotNull(response.RequestMessage.Content, "The request content is null");
            Assert.IsNull(response.RequestMessage.Content.Headers.ContentLength,"The content length is not null.");

        }

        [DataTestMethod]
        [Ignore]
        [DataRow(HttpStatusCode.ServiceUnavailable)]  // 503
        [DataRow(429)] // 429
        public async Task ExceedMaxRetryShouldReturn(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");

            var retryResponse = new HttpResponseMessage(statusCode);
            var response_2 = new HttpResponseMessage(statusCode);

            this.testHttpMessageHandler.SetHttpResponse(retryResponse, response_2);
            try
            {
                var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());
               
            }
            catch (ServiceException exception)
            {
                
                Assert.IsTrue(exception.IsMatch(ErrorConstants.Codes.TooManyRetries), "Unexpected error code returned.");
                Assert.AreEqual(String.Format(ErrorConstants.Messages.TooManyRetriesFormatString, 10), exception.Error.Message, "Unexpected error message.");
                Assert.IsInstanceOfType(exception, typeof(ServiceException), "Eeception is not the right type");

                Assert.IsTrue(httpRequestMessage.Headers.Contains(RETRY_ATTEMPT), "Doesn't set Retry-Attemp header to request");
                IEnumerable<string> values;
                Assert.IsTrue(httpRequestMessage.Headers.TryGetValues(RETRY_ATTEMPT, out values), "Get Retry-Attemp Header values");
                Assert.AreEqual(values.Count(), 1, "There are multiple values for Retry-Attemp header.");
                Assert.AreEqual(values.First(), 10.ToString(), "The value of  Retry-Attemp header is wrong.");
            }

           

        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.ServiceUnavailable)]  // 503
        [DataRow(429)] // 429
        public async Task ShouldRetrytBasedOnRetryAfter(HttpStatusCode statusCode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://example.org/foo");
            httpRequestMessage.Content = new StringContent("Hello World");

            var retryResponse = new HttpResponseMessage(statusCode);
            retryResponse.Headers.TryAddWithoutValidation(RETRY_AFTER, 30.ToString());

            var response_2 = new HttpResponseMessage(HttpStatusCode.OK);

            this.testHttpMessageHandler.SetHttpResponse(retryResponse, response_2);

            var response = await invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.AreSame(response, response_2);
            IEnumerable<string> values;
            Assert.IsTrue(httpRequestMessage.Headers.TryGetValues(RETRY_ATTEMPT, out values), "Don't set Retry-Attemp Header");
            Assert.AreEqual(values.Count(), 1);
            Assert.AreEqual(values.First(), 1.ToString());


        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.ServiceUnavailable)]  // 503
        [DataRow(429)] // 429
        public async Task ShouldDelayBasedOnRetryAfterHeader(HttpStatusCode statusCode)
        {
            var retryResponse = new HttpResponseMessage(statusCode);
            retryResponse.Headers.TryAddWithoutValidation(RETRY_AFTER, 4.ToString());
            await DelayTestWithMessage(retryResponse, 1, "Init");
            Assert.AreEqual(Message, "Init Work 1", "Delay doesn't work");
        }


        [DataTestMethod]
        [DataRow(HttpStatusCode.ServiceUnavailable)]  // 503
        [DataRow(429)] // 429
        public async Task ShouldDelayBasedOnExponentialBackOff(HttpStatusCode statusCode)
        {
            var retryResponse = new HttpResponseMessage(statusCode);
            String compareMessage = "Init Work ";
            
            for (int count = 0; count < 3; count++)
            {
                await DelayTestWithMessage(retryResponse, count, "Init");
                Assert.AreEqual(Message, compareMessage + count.ToString(), "Delay doesn't work");
            }

        }

        private async Task DelayTestWithMessage(HttpResponseMessage response, int count, string message)
        {
            Message = message;
            await Task.Run(async () =>
            {
                await this.retryHandler.Delay(response, count, new CancellationToken());
                Message += " Work " + count.ToString();
            });

        }

        public string Message { get; private set; }
    }
}
