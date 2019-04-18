// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An <see cref="IHttpProvider"/> implementation using standard .NET libraries.
    /// </summary>
    public class HttpProvider : IHttpProvider
    {
        internal bool disposeHandler;

        internal HttpClient httpClient;

        internal HttpMessageHandler httpMessageHandler;

        /// <summary>
        /// Constructs a new <see cref="HttpProvider"/>.
        /// </summary>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        public HttpProvider(ISerializer serializer = null)
            : this((HttpMessageHandler)null, true, serializer)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="HttpProvider"/>.
        /// </summary>
        /// <param name="httpClientHandler">An HTTP client handler to pass to the <see cref="HttpClient"/> for sending requests.</param>
        /// <param name="disposeHandler">Whether or not to dispose the client handler on Dispose().</param>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        /// <remarks>
        ///     By default, HttpProvider disables automatic redirects and handles redirects to preserve authentication headers. If providing
        ///     an <see cref="HttpClientHandler"/> to the constructor and enabling automatic redirects this could cause issues with authentication
        ///     over the redirect.
        /// </remarks>
        public HttpProvider(HttpClientHandler httpClientHandler, bool disposeHandler, ISerializer serializer = null)
            : this((HttpMessageHandler)httpClientHandler, disposeHandler, serializer)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="HttpProvider"/>.
        /// </summary>
        /// <param name="httpMessageHandler">An HTTP message handler to pass to the <see cref="HttpClient"/> for sending requests.</param>
        /// <param name="disposeHandler">Whether or not to dispose the client handler on Dispose().</param>
        /// <param name="serializer">A serializer for serializing and deserializing JSON objects.</param>
        public HttpProvider(HttpMessageHandler httpMessageHandler, bool disposeHandler, ISerializer serializer)
        {
            this.disposeHandler = disposeHandler;
            this.httpMessageHandler = httpMessageHandler ?? new HttpClientHandler { AllowAutoRedirect = false };
            this.Serializer = serializer ?? new Serializer();

            // Always ensure RedirectHandler is the last handler in your pipeline.
            // The recommended DelegatingHandler order is : 1. AuthenticationHandler, 2. RetryHandler, 3.RedirectHandler.
            DelegatingHandler[] handlers = new DelegatingHandler[]
            {
                new AuthenticationHandler(null),
                new CompressionHandler(),
                new RetryHandler(),
                new RedirectHandler()
            };

            GraphClientFactory.DefaultHttpHandler = () => this.httpMessageHandler;
            this.httpClient = GraphClientFactory.Create("v1.0", GraphClientFactory.Global_Cloud, handlers);
            this.httpClient.SetFeatureFlags(FeatureFlag.AuthHandler | FeatureFlag.CompressionHandler | FeatureFlag.RetryHandler | FeatureFlag.RedirectHandler | FeatureFlag.DefaultHttpProvider);
        }

        /// <summary>
        /// Gets or sets the cache control header for requests;
        /// </summary>
        public CacheControlHeaderValue CacheControlHeader
        {
            get
            {
                return this.httpClient.DefaultRequestHeaders.CacheControl;
            }

            set
            {
                this.httpClient.DefaultRequestHeaders.CacheControl = value;
            }
        }

        /// <summary>
        /// Gets or sets the overall request timeout.
        /// </summary>
        public TimeSpan OverallTimeout
        {
            get
            {
                return this.httpClient.Timeout;
            }

            set
            {
                try
                {
                    this.httpClient.Timeout = value;
                }
                catch (InvalidOperationException exception)
                {
                    throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.NotAllowed,
                            Message = ErrorConstants.Messages.OverallTimeoutCannotBeSet,
                        },
                        exception);
                }
            }
        }

        /// <summary>
        /// Gets a serializer for serializing and deserializing JSON objects.
        /// </summary>
        public ISerializer Serializer { get; private set; }

        /// <summary>
        /// Disposes the HttpClient and HttpClientHandler instances.
        /// </summary>
        public void Dispose()
        {
            if (this.httpClient != null)
            {
                this.httpClient.Dispose();
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        public async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            var response = await this.SendRequestAsync(request, completionOption, cancellationToken).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                using (response)
                {
                    var errorResponse = await this.ConvertErrorResponseAsync(response).ConfigureAwait(false);
                    Error error = null;

                    if (errorResponse == null || errorResponse.Error == null)
                    {
                        if (response != null && response.StatusCode == HttpStatusCode.NotFound)
                        {
                            error = new Error { Code = ErrorConstants.Codes.ItemNotFound };
                        }
                        else
                        {
                            error = new Error
                            {
                                Code = ErrorConstants.Codes.GeneralException,
                                Message = ErrorConstants.Messages.UnexpectedExceptionResponse,
                            };
                        }
                    }
                    else
                    {
                        error = errorResponse.Error;
                    }

                    if (string.IsNullOrEmpty(error.ThrowSite))
                    {
                        IEnumerable<string> throwsiteValues;

                        if (response.Headers.TryGetValues(CoreConstants.Headers.ThrowSiteHeaderName, out throwsiteValues))
                        {
                            error.ThrowSite = throwsiteValues.FirstOrDefault();
                        }
                    }

                    // Pass through the response headers and status code to the ServiceException.
                    // System.Net.HttpStatusCode does not support RFC 6585, Additional HTTP Status Codes.
                    // Throttling status code 429 is in RFC 6586. The status code 429 will be passed through.
                    throw new ServiceException(error, response.Headers, response.StatusCode);
                }
            }

            return response;
        }

        internal async Task<HttpResponseMessage> SendRequestAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            try
            {
                return await this.httpClient.SendAsync(request, completionOption, cancellationToken).ConfigureAwait(false);
            }
            catch (TaskCanceledException exception)
            {
                throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.Timeout,
                            Message = ErrorConstants.Messages.RequestTimedOut,
                        },
                        exception);
            }
            catch(ServiceException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.GeneralException,
                            Message = ErrorConstants.Messages.UnexpectedExceptionOnSend,
                        },
                        exception);
            }
        }

        /// <summary>
        /// Converts the <see cref="HttpRequestException"/> into an <see cref="ErrorResponse"/> object;
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> to convert.</param>
        /// <returns>The <see cref="ErrorResponse"/> object.</returns>
        private async Task<ErrorResponse> ConvertErrorResponseAsync(HttpResponseMessage response)
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return this.Serializer.DeserializeObject<ErrorResponse>(responseStream);
                }
            }
            catch (Exception)
            {
                // If there's an exception deserializing the error response return null and throw a generic
                // ServiceException later.
                return null;
            }
        }

    }
}
