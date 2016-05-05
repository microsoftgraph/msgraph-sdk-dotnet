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
        private const int maxRedirects = 5;

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
        internal HttpProvider(HttpMessageHandler httpMessageHandler, bool disposeHandler, ISerializer serializer)
        {
            this.disposeHandler = disposeHandler;
            this.httpMessageHandler = httpMessageHandler ?? new HttpClientHandler { AllowAutoRedirect = false };
            this.httpClient = new HttpClient(this.httpMessageHandler, this.disposeHandler);

            this.CacheControlHeader = new CacheControlHeaderValue { NoCache = true, NoStore = true };
            this.Serializer = serializer ?? new Serializer();
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
            var response = await this.SendRequestAsync(request, completionOption, cancellationToken);

            if (this.IsRedirect(response.StatusCode))
            {
                response = await this.HandleRedirect(response, completionOption, cancellationToken);

                if (response == null)
                {
                    throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.GeneralException,
                            Message = ErrorConstants.Messages.LocationHeaderNotSetOnRedirect,
                        });
                }
            }

            if (!response.IsSuccessStatusCode && !this.IsRedirect(response.StatusCode))
            {
                using (response)
                {
                    var errorResponse = await this.ConvertErrorResponseAsync(response);
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

                    throw new ServiceException(error);
                }
            }

            return response;
        }

        internal async Task<HttpResponseMessage> HandleRedirect(
            HttpResponseMessage initialResponse,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken,
            int redirectCount = 0)
        {
            if (initialResponse.Headers.Location == null)
            {
                return null;
            }

            using (initialResponse)
            using (var redirectRequest = new HttpRequestMessage(initialResponse.RequestMessage.Method, initialResponse.Headers.Location))
            {
                // Preserve headers for the next request
                foreach (var header in initialResponse.RequestMessage.Headers)
                {
                    redirectRequest.Headers.Add(header.Key, header.Value);
                }

                var response = await this.SendRequestAsync(redirectRequest, completionOption, cancellationToken);

                if (this.IsRedirect(response.StatusCode))
                {
                    if (++redirectCount > HttpProvider.maxRedirects)
                    {
                        throw new ServiceException(
                            new Error
                            {
                                Code = ErrorConstants.Codes.TooManyRedirects,
                                Message = string.Format(ErrorConstants.Messages.TooManyRedirectsFormatString, HttpProvider.maxRedirects)
                            });
                    }

                    return await this.HandleRedirect(response, completionOption, cancellationToken, redirectCount);
                }

                return response;
            }
        }

        internal async Task<HttpResponseMessage> SendRequestAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            try
            {
                return await this.httpClient.SendAsync(request, completionOption, cancellationToken);
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
        /// <param name="response">The <see cref="WebResponse"/> to convert.</param>
        /// <returns>The <see cref="ErrorResponse"/> object.</returns>
        private async Task<ErrorResponse> ConvertErrorResponseAsync(HttpResponseMessage response)
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
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

        private bool IsRedirect(HttpStatusCode statusCode)
        {
            return (int)statusCode >= 300 && (int)statusCode < 400 && statusCode != HttpStatusCode.NotModified;
        }
    }
}
