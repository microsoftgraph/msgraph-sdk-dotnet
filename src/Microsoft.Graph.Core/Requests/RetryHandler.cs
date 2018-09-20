// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Globalization;

namespace Microsoft.Graph
{ 
    /// <summary>
    /// An <see cref="DelegatingHandler"/> implementation using standard .NET libraries.
    /// </summary>
    public class RetryHandler : DelegatingHandler
    {

        private const string RETRY_AFTER = "Retry-After";
        private const string RETRY_ATTEMPT = "Retry-Attempt";
       
        
        private const int DELAY_MILLISECONDS = 60000;
        private const int MAX_RETRY = 10;
        private double m_pow = 1;
        

        /// <summary>
        /// Construct a new <see cref="RetryHandler"/>
        /// </summary>
        /// <param name="innerHandler">An HTTP message handler to pass to the <see cref="HttpMessageHandler"/> for sending requests.</param>
        public RetryHandler(HttpMessageHandler innerHandler)
        {
            InnerHandler = innerHandler;
        }

        /// <summary>
        /// Send a HTTP request 
        /// </summary>
        /// <param name="httpRequest">The HTTP request<see cref="HttpRequestMessage"/>needs to be sent.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns></returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequest, CancellationToken cancellationToken)
        {
            // Send request first time
            var response = await base.SendAsync(httpRequest, cancellationToken);

            if (IsRetry(response) && IsBuffered(httpRequest))
            {
                response = await SendRetryAsync(response, cancellationToken);
            }

            return response;
        }

        /// <summary>
        /// Retry sending the HTTP request 
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> needs to be retried.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the retry.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> SendRetryAsync(HttpResponseMessage response, CancellationToken cancellationToken)
        {


            int retryCount = 0;

          
            while (retryCount < MAX_RETRY)
            {

                // Call Delay method to get delay time from response's Retry-After header or by exponential backoff 
                Task delay = Delay(response, retryCount, cancellationToken);

                // Get the original request
                var request = response.RequestMessage;

                // Increase retryCount and then update Retry-Attempt in request header
                retryCount++;
                AddOrUpdateRetryAttempt(request, retryCount);

                // Delay time
                await delay;

                // Call base.SendAsync to send the request
                response = await base.SendAsync(request, cancellationToken);

                if (!IsRetry(response) || !IsBuffered(request))
                {
                    return response;
                }

            }
            throw new ServiceException(
                         new Error
                         {
                             Code = ErrorConstants.Codes.TooManyRetries,
                             Message = string.Format(ErrorConstants.Messages.TooManyRetriesFormatString, retryCount)
                         });

        }



        /// <summary>
        /// Check the HTTP response's status to determine whether it should be retried or not.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>returned.</param>
        /// <returns></returns>
        public bool IsRetry(HttpResponseMessage response)
        {
            if ((response.StatusCode == HttpStatusCode.ServiceUnavailable ||
                response.StatusCode == (HttpStatusCode)429))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check the HTTP request's content to determine whether it can be retried or not.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/>needs to be sent.</param>
        /// <returns></returns>
        private bool IsBuffered(HttpRequestMessage request)
        {
            HttpContent content = request.Content;

            if ((request.Method == HttpMethod.Put || request.Method == HttpMethod.Post || request.Method.Method.Equals("PATCH")) 
                && content != null && (content.Headers.ContentLength == null || (int)content.Headers.ContentLength == -1))
            {
                return false;
            }
            return true;
           
        }

        /// <summary>
        /// Update Retry-Attempt header in the HTTP request
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/>needs to be sent.</param>
        /// <param name="retry_count">Retry times</param>
        private void AddOrUpdateRetryAttempt(HttpRequestMessage request, int retry_count)
        {
            if (request.Headers.Contains(RETRY_ATTEMPT))
            {
                request.Headers.Remove(RETRY_ATTEMPT);
            }
            request.Headers.Add(RETRY_ATTEMPT, retry_count.ToString());
        }

        /// <summary>
        /// Delay task operation based on Retry-After header in the response or exponential backoff
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>returned.</param>
        /// <param name="retry_count">The retry counts</param>
        /// <param name="cancellationToken">The cancellationToken for the Http request</param>
        /// <returns>The <see cref="Task"/> for delay operation.</returns>
        public Task Delay(HttpResponseMessage response, int retry_count, CancellationToken cancellationToken)
        {
            
            TimeSpan delay = TimeSpan.FromMilliseconds(0);
            HttpHeaders headers = response.Headers;
            if (headers.TryGetValues(RETRY_AFTER, out IEnumerable<string> values))
            {
                string retry_after = values.First();    
                if (Int32.TryParse(retry_after, out int delay_seconds))
                {
                    delay = TimeSpan.FromSeconds(delay_seconds);
                }
            }
            else
            {

                m_pow = Math.Pow(2, retry_count); // m_pow = Pow(2, retry_count)

                double delay_time = m_pow * DELAY_MILLISECONDS;
              
                delay = TimeSpan.FromMilliseconds(delay_time);
            }
            return Task.Delay(delay, cancellationToken);

        }

    }
}
