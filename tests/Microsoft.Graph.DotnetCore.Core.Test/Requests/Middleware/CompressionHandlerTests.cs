// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests.Middleware
{
    using System;
    using Microsoft.Graph.DotnetCore.Core.Test.Mocks;
    using System.Net.Http;
    using Xunit;
    using System.Net;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Net.Http.Headers;

    public class CompressionHandlerTests : IDisposable
    {
        private MockRedirectHandler testHttpMessageHandler;
        private CompressionHandler compressionHandler;
        private HttpMessageInvoker invoker;

        public CompressionHandlerTests()
        {
            this.testHttpMessageHandler = new MockRedirectHandler();
            this.compressionHandler = new CompressionHandler(this.testHttpMessageHandler);
            this.invoker = new HttpMessageInvoker(this.compressionHandler);
        }

        public void Dispose()
        {
            this.invoker.Dispose();
        }

        [Fact]
        public void CompressionHandler_should_construct_handler()
        {
            Assert.NotNull(this.compressionHandler.InnerHandler);
        }

        [Fact]
        public async Task CompressionHandler_should_add_accept_encoding_gzip_header_when_non_is_present()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");

            HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.OK);

            this.testHttpMessageHandler.SetHttpResponse(httpResponse);
            HttpResponseMessage response = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());

            Assert.Same(httpRequestMessage, response.RequestMessage);
            Assert.True(response.RequestMessage.Headers.AcceptEncoding.Contains(new StringWithQualityHeaderValue(CoreConstants.Encoding.GZip)));
        }

        [Fact]
        public async Task CompressionHandler_should_decompress_response_with_content_encoding_gzip_header()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
            httpRequestMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue(CoreConstants.Encoding.GZip));
            string stringToCompress = "sample string content";

            // Compress response
            HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new MockCompressedContent(new StringContent(stringToCompress))
            };
            httpResponse.Content.Headers.ContentEncoding.Add(CoreConstants.Encoding.GZip);

            this.testHttpMessageHandler.SetHttpResponse(httpResponse);

            HttpResponseMessage decompressedResponse = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());
            string responseContentString = await decompressedResponse.Content.ReadAsStringAsync();

            Assert.Same(httpResponse, decompressedResponse);
            Assert.Same(httpRequestMessage, decompressedResponse.RequestMessage);
            Assert.Equal(stringToCompress, responseContentString);
        }

        [Fact]
        public async Task CompressionHandler_should_not_decompress_response_without_content_encoding_gzip_header()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://example.org/foo");
            string stringToCompress = "Microsoft Graph";

            HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new MockCompressedContent(new StringContent(stringToCompress))
            };
            this.testHttpMessageHandler.SetHttpResponse(httpResponse);

            HttpResponseMessage compressedResponse = await this.invoker.SendAsync(httpRequestMessage, new CancellationToken());
            string responseContentString = await compressedResponse.Content.ReadAsStringAsync();

            Assert.Same(httpResponse, compressedResponse);
            Assert.Same(httpRequestMessage, compressedResponse.RequestMessage);
            Assert.NotEqual(stringToCompress, responseContentString);
        }
    }
}
