// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Requests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Graph.Core.Test.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TestModels;

    [TestClass]
    public class BaseRequestTests : RequestTestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void BaseRequest_InitializeWithEmptyBaseUrl()
        {
            try
            {
                var baseRequest = new BaseRequest(null, this.baseClient);
            }
            catch (ServiceException exception)
            {
                Assert.AreEqual(ErrorConstants.Codes.InvalidRequest, exception.Error.Code, "Unexpected error code.");
                Assert.AreEqual(ErrorConstants.Messages.BaseUrlMissing, exception.Error.Message, "Unexpected error message.");
                throw;
            }
        }

        [TestMethod]
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

            Assert.AreEqual(new Uri(baseUrl), new Uri(baseRequest.RequestUrl), "Unexpected request URL.");
            Assert.AreEqual(3, baseRequest.QueryOptions.Count, "Unexpected number of query options.");
            Assert.IsTrue(baseRequest.QueryOptions[0].Name.Equals("key") && baseRequest.QueryOptions[0].Value.Equals("value"), "Unexpected first query option.");
            Assert.IsTrue(baseRequest.QueryOptions[1].Name.Equals("key2") && string.IsNullOrEmpty(baseRequest.QueryOptions[1].Value), "Unexpected second query option.");
            Assert.IsTrue(baseRequest.QueryOptions[2].Name.Equals("key3") && baseRequest.QueryOptions[2].Value.Equals("value3"), "Unexpected third query option.");
            Assert.AreEqual(1, baseRequest.Headers.Count, "Unexpected number of header options.");
            Assert.IsTrue(baseRequest.Headers[0].Name.Equals("header") && baseRequest.Headers[0].Value.Equals("value"), "Unexpected header option.");
            Assert.IsNotNull(baseRequest.Client.AuthenticationProvider, "Authentication provider not set.");
            Assert.IsNotNull(baseRequest.GetHttpRequestMessage().GetRequestContext().ClientRequestId, "Client request id not set.");
            Assert.AreEqual(baseRequest.GetHttpRequestMessage().GetMiddlewareOption<AuthenticationHandlerOption>().AuthenticationProvider,
                baseRequest.Client.AuthenticationProvider, "Unexpected authentication provider set.");
        }

        [TestMethod]
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
            Assert.AreEqual(HttpMethod.Put, httpRequestMessage.Method, "Unexpected HTTP method in request.");
            Assert.AreEqual(requestUrl + "?query1=value1&query2=value2",
                httpRequestMessage.RequestUri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.Unescaped),
                "Unexpected base URL in request.");
            Assert.AreEqual("value1", httpRequestMessage.Headers.GetValues("header1").First(), "Unexpected first header in request.");
            Assert.AreEqual("value2", httpRequestMessage.Headers.GetValues("header2").First(), "Unexpected second header in request.");

            Assert.IsNotNull(httpRequestMessage.GetRequestContext().ClientRequestId, "Client request id not set.");
        }

        [TestMethod]
        public void GetRequestContextWithClientRequestIdHeader()
        {
            string requestUrl = string.Concat(this.baseUrl, "foo/bar");
            string clientRequestId = Guid.NewGuid().ToString();
            var headers = new List<HeaderOption>
            {
                new HeaderOption(CoreConstants.Headers.ClientRequestId, clientRequestId)
            };

            var baseRequest = new BaseRequest(requestUrl, this.baseClient, headers) { Method = "PUT" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.AreEqual(HttpMethod.Put, httpRequestMessage.Method, "Unexpected HTTP method in request");
            Assert.AreSame(clientRequestId, httpRequestMessage.GetRequestContext().ClientRequestId, "Unexpected client request id");

            Assert.IsNotNull(httpRequestMessage.GetRequestContext().ClientRequestId, "Client request id not set.");
        }

        [TestMethod]
        public void GetRequestContextWithClientRequestId()
        {
            string requestUrl = string.Concat(this.baseUrl, "foo/bar");
            string clientRequestId = Guid.NewGuid().ToString();

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { Method = "PUT" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.AreEqual(HttpMethod.Put, httpRequestMessage.Method, "Unexpected HTTP method in request");
            Assert.IsNotNull(httpRequestMessage.GetRequestContext().ClientRequestId, "Unexpected client request id");
        }

        [TestMethod]
        public void GetRequestNoAuthProvider()
        {
            string requestUrl = string.Concat(this.baseUrl, "foo/bar");
            string clientRequestId = Guid.NewGuid().ToString();

            var client = new BaseClient("http://localhost.foo", null);
            var baseRequest = new BaseRequest(requestUrl, client) { Method = "PUT" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.AreEqual(HttpMethod.Put, httpRequestMessage.Method, "Unexpected HTTP method in request");
            Assert.IsNotNull(httpRequestMessage.GetRequestContext().ClientRequestId, "Unexpected client request id");
            Assert.IsNull(httpRequestMessage.GetMiddlewareOption<AuthenticationHandlerOption>().AuthenticationProvider, "Unexpected authentication provider set.");
        }

        [TestMethod]
        public void GetWebRequestNoOptions()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { Method = "DELETE" };

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();
            Assert.AreEqual(HttpMethod.Delete, httpRequestMessage.Method, "Unexpected HTTP method in request.");
            Assert.AreEqual(requestUrl,
                httpRequestMessage.RequestUri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.Unescaped),
                "Unexpected base URL in request.");
            Assert.AreEqual(0, httpRequestMessage.Headers.Count(), "Unexpected headers in request.");
        }

        [TestMethod]
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
                Assert.IsNotNull(baseRequest.Client.AuthenticationProvider, "Authentication provider not set.");
                Assert.IsNotNull(baseRequest.GetHttpRequestMessage().GetRequestContext().ClientRequestId, "Client request id not set.");
                Assert.IsNotNull(responseItem, "DerivedTypeClass not returned.");
                Assert.AreEqual(expectedResponseItem.Id, responseItem.Id, "Unexpected ID.");
            }
        }

        [TestMethod]
        public async Task SendAsync_ResponseHeaders()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new BaseRequest(requestUrl, this.baseClient) { ContentType = "application/json" };

            var data = "{\"data\"}";

            using (var httpResponseMessage = new HttpResponseMessage())
            using (var responseStream = new MemoryStream(Encoding.ASCII.GetBytes(data)))
            using (var streamContent = new StreamContent(responseStream))
            {
                httpResponseMessage.Content = streamContent;
                httpResponseMessage.StatusCode = System.Net.HttpStatusCode.OK;

                this.httpProvider.Setup(
                    provider => provider.SendAsync(
                        It.Is<HttpRequestMessage>(
                            request =>
                                string.Equals(request.Content.Headers.ContentType.ToString(), "application/json")
                               && request.RequestUri.ToString().Equals(requestUrl)),
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None))
                        .Returns(Task.FromResult(httpResponseMessage));

                Dictionary<string, object> additionalData = new Dictionary<string, object>();
                additionalData["responseHeaders"] = new Dictionary<string, List<string>>() { { "key", new List<string>() { "value" } } };

                var expectedResponseItem = new DerivedTypeClass { Id = "id", AdditionalData = additionalData };

                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DerivedTypeClass>(It.IsAny<string>()))
                    .Returns(expectedResponseItem);
                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DerivedTypeClass>(It.IsAny<string>()))
                    .Returns(expectedResponseItem);

                var responseItem = await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);
                Assert.IsNotNull(responseItem.AdditionalData["responseHeaders"], "No response headers available");
                Assert.IsNotNull(baseRequest.Client.AuthenticationProvider, "Authentication provider not set.");
                Assert.IsNotNull(baseRequest.GetHttpRequestMessage().GetRequestContext().ClientRequestId, "Client request id not set.");
                Assert.AreEqual(expectedResponseItem.AdditionalData["responseHeaders"], responseItem.AdditionalData["responseHeaders"], "Unexpected response headers");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public async Task SendAsync_AuthenticationProviderNotSet()
        {
            var client = new BaseClient("https://localhost", null);

            var baseRequest = new BaseRequest("https://localhost", client);

            try
            {
                await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);
            }
            catch (ServiceException exception)
            {
                Assert.AreEqual(ErrorConstants.Codes.InvalidRequest, exception.Error.Code, "Unexpected error code.");
                Assert.AreEqual(ErrorConstants.Messages.AuthenticationProviderMissing, exception.Error.Message, "Unexpected error message.");
                throw;
            }
        }

        [TestMethod]
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

                Assert.IsNotNull(baseRequest.Client.AuthenticationProvider, "Authentication provider not set.");
            }
        }

        [TestMethod]
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

                Assert.IsNull(instance, "Unexpected object returned.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public async Task SendAsync_RequestUrlNotSet()
        {
            var baseRequest = new BaseRequest("https://localhost", this.baseClient);

            baseRequest.RequestUrl = null;

            try
            {
                await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);
            }
            catch (ServiceException exception)
            {
                Assert.AreEqual(ErrorConstants.Codes.InvalidRequest, exception.Error.Code, "Unexpected error code.");
                Assert.AreEqual(ErrorConstants.Messages.RequestUrlMissing, exception.Error.Message, "Unexpected error message.");
                throw;
            }
        }

        [TestMethod]
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
                    Assert.AreEqual(await httpResponseMessage.Content.ReadAsStreamAsync(), returnedResponseStream, "Unexpected stream returned.");
                }
            }
        }

        [TestMethod]
        public async Task SendAsync_WithCustomHttpProvider()
        {
            using (var httpResponseMessage = new HttpResponseMessage())
            using (TestHttpMessageHandler testHttpMessageHandler = new TestHttpMessageHandler())
            {
                string requestUrl = "https://localhost/";
                testHttpMessageHandler.AddResponseMapping(requestUrl, httpResponseMessage);
                MockCustomHttpProvider customHttpProvider = new MockCustomHttpProvider(testHttpMessageHandler);

                BaseClient client = new BaseClient(requestUrl, authenticationProvider.Object, customHttpProvider);
                BaseRequest baseRequest = new BaseRequest(requestUrl, client);

                HttpResponseMessage returnedResponse = await baseRequest.SendRequestAsync("string", CancellationToken.None);

                Assert.AreEqual(httpResponseMessage, returnedResponse, "Unexpected response message returned.");
                Assert.IsNotNull(returnedResponse.RequestMessage.Headers, "Headers cannot be null.");
                Assert.AreEqual(returnedResponse.RequestMessage.Headers.Authorization.Parameter, "Default-Token", "Unexpected authorization header set.");
            }
        }

        [TestMethod]
        public void BuildQueryString_NullQueryOptions()
        {
            var baseRequest = new BaseRequest("https://localhost", this.baseClient);

            baseRequest.QueryOptions = null;

            var queryString = baseRequest.BuildQueryString();

            Assert.IsNull(queryString, "Unexpected query string returned.");
        }
    }
}
