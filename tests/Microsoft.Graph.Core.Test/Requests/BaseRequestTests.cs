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
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Graph.Core;
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
                Assert.AreEqual("invalidRequest", exception.Error.Code, "Unexpected error code.");
                Assert.AreEqual("Base URL is not initialized for the request.", exception.Error.Message, "Unexpected error message.");
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

            var expectedVersion = typeof(BaseRequest).GetTypeInfo().Assembly.GetName().Version;
            Assert.AreEqual(
                string.Format(CoreConstants.Headers.SdkVersionHeaderValueFormatString, "dotnet", expectedVersion.Major, expectedVersion.Minor, expectedVersion.Build),
                httpRequestMessage.Headers.GetValues(CoreConstants.Headers.SdkVersionHeaderName).First(), "Unexpected request stats header.");
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
            Assert.AreEqual(1, httpRequestMessage.Headers.Count(), "Unexpected headers in request.");

            var expectedVersion = typeof(BaseRequest).GetTypeInfo().Assembly.GetName().Version;
            Assert.AreEqual(
                string.Format(CoreConstants.Headers.SdkVersionHeaderValueFormatString, "dotnet", expectedVersion.Major, expectedVersion.Minor, expectedVersion.Build),
                httpRequestMessage.Headers.GetValues(CoreConstants.Headers.SdkVersionHeaderName).First(), "Unexpected request stats header.");
        }

        [TestMethod]
        public void GetWebRequest_OverrideCustomTelemetryHeader()
        {
            var requestUrl = string.Concat(this.baseUrl, "/me/drive/items/id");

            var baseRequest = new CustomRequest(requestUrl, this.baseClient);

            var httpRequestMessage = baseRequest.GetHttpRequestMessage();

            Assert.AreEqual(
                CustomRequest.SdkHeaderValue,
                httpRequestMessage.Headers.GetValues(CustomRequest.SdkHeaderName).First(), "Unexpected request stats header.");

            Assert.IsFalse(
                httpRequestMessage.Headers.Contains(CoreConstants.Headers.SdkVersionHeaderName), "Unexpected request stats header present.");
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
                               && request.RequestUri.ToString().Equals(requestUrl))))
                        .Returns(Task.FromResult(httpResponseMessage));

                var expectedResponseItem = new DerivedTypeClass { Id = "id" };
                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<string>()))
                    .Returns(string.Empty);
                this.serializer.Setup(
                    serializer => serializer.DeserializeObject<DerivedTypeClass>(It.IsAny<string>()))
                    .Returns(expectedResponseItem);

                var responseItem = await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);

                Assert.IsNotNull(responseItem, "DerivedTypeClass not returned.");
                Assert.AreEqual(expectedResponseItem.Id, responseItem.Id, "Unexpected ID.");

                this.authenticationProvider.Verify(provider => provider.AuthenticateRequestAsync(It.IsAny<HttpRequestMessage>()), Times.Once);
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
                Assert.AreEqual("invalidRequest", exception.Error.Code, "Unexpected error code.");
                Assert.AreEqual("Authentication provider is required before sending a request.", exception.Error.Message, "Unexpected error message.");
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
                               && request.RequestUri.ToString().Equals(requestUrl))))
                        .Returns(Task.FromResult(httpResponseMessage));
                
                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<string>()))
                    .Returns(string.Empty);

                await baseRequest.SendAsync("string", CancellationToken.None);

                this.authenticationProvider.Verify(provider => provider.AuthenticateRequestAsync(It.IsAny<HttpRequestMessage>()), Times.Once);
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
                               && request.RequestUri.ToString().Equals(requestUrl))))
                        .Returns(Task.FromResult(httpResponseMessage));

                this.serializer.Setup(
                    serializer => serializer.SerializeObject(It.IsAny<string>()))
                    .Returns(string.Empty);

                var instance = await baseRequest.SendAsync<DerivedTypeClass>("string", CancellationToken.None);

                Assert.IsNull(instance, "Unexpected object returned.");

                this.authenticationProvider.Verify(provider => provider.AuthenticateRequestAsync(It.IsAny<HttpRequestMessage>()), Times.Once);
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
                Assert.AreEqual("invalidRequest", exception.Error.Code, "Unexpected error code.");
                Assert.AreEqual("Request URL is required to send a request.", exception.Error.Message, "Unexpected error message.");
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
                                && request.Method == HttpMethod.Put)))
                    .Returns(Task.FromResult(httpResponseMessage));

                using (var returnedResponseStream = await baseRequest.SendStreamRequestAsync(requestStream, CancellationToken.None))
                {
                    Assert.AreEqual(await httpResponseMessage.Content.ReadAsStreamAsync(), returnedResponseStream, "Unexpected stream returned.");
                }
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
