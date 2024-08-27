// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;
    using System.Net.Http;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Graph.Requests;
    using Microsoft.Graph.Core.Requests;
    using Microsoft.Kiota.Abstractions.Authentication;
    using Microsoft.Kiota.Abstractions;
    using Azure.Core;

    /// <summary>
    /// A default client implementation.
    /// </summary>
    public class GraphServiceClient : BaseGraphServiceClient, IBaseClient, IDisposable
    {
        private static readonly Version assemblyVersion = typeof(GraphServiceClient).GetTypeInfo().Assembly.GetName().Version;
        private static readonly GraphClientOptions graphClientOptions = new GraphClientOptions
        {
            GraphServiceLibraryClientVersion = $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}",
            GraphServiceTargetVersion = string.Empty,
        };

        /// <summary>
        /// Constructs a new <see cref="GraphServiceClient"/>.
        /// </summary>
        /// <param name="requestAdapter">The custom <see cref="IRequestAdapter"/> to be used for making requests</param>
        /// <param name="baseUrl">The base service URL. For example, "https://graph.microsoft.com/v1.0"</param>
        public GraphServiceClient(IRequestAdapter requestAdapter, string baseUrl = null): base(InitializeRequestAdapterWithBaseUrl(requestAdapter,baseUrl))
        {
            this.RequestAdapter = requestAdapter;
        }

        /// <summary>
        /// Constructs a new <see cref="GraphServiceClient"/>.
        /// </summary>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> for authenticating request messages.</param>
        /// <param name="scopes">List of scopes for the authentication context.</param>
        /// <param name="baseUrl">The base service URL. For example, "https://graph.microsoft.com/v1.0"</param>
        public GraphServiceClient(
            TokenCredential tokenCredential,
            IEnumerable<string> scopes = null,
            string baseUrl = null
            ):this(new Microsoft.Graph.Authentication.AzureIdentityAuthenticationProvider(tokenCredential, null, null,true,scopes?.ToArray() ?? []), baseUrl)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="GraphServiceClient"/>.
        /// </summary>
        /// <param name="httpClient">The customized <see cref="HttpClient"/> to be used for making requests</param>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> for authenticating request messages.</param>
        /// <param name="scopes">List of scopes for the authentication context.</param>
        /// <param name="baseUrl">The base service URL. For example, "https://graph.microsoft.com/v1.0"</param>
        public GraphServiceClient(
            HttpClient httpClient,
            TokenCredential tokenCredential,
            IEnumerable<string> scopes = null,
            string baseUrl = null
            ):this(httpClient, new Microsoft.Graph.Authentication.AzureIdentityAuthenticationProvider(tokenCredential, null, null,true, scopes?.ToArray() ?? []), baseUrl)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="GraphServiceClient"/>.
        /// </summary>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.</param>
        /// <param name="baseUrl">The base service URL. For example, "https://graph.microsoft.com/v1.0"</param>
        public GraphServiceClient(
            IAuthenticationProvider authenticationProvider,
            string baseUrl = null
            ): this(new BaseGraphRequestAdapter(authenticationProvider, graphClientOptions),baseUrl)
        {
        }

        /// <summary>
        /// Constructs a new <see cref="GraphServiceClient"/>.
        /// </summary>
        /// <param name="httpClient">The customized <see cref="HttpClient"/> to be used for making requests</param>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.
        /// Defaults to <see cref="AnonymousAuthenticationProvider"/> so that authentication is handled by custom middleware in the httpClient</param>
        /// <param name="baseUrl">The base service URL. For example, "https://graph.microsoft.com/v1.0"</param>
        public GraphServiceClient(
            HttpClient httpClient,
            IAuthenticationProvider authenticationProvider = null,
            string baseUrl = null):this(new BaseGraphRequestAdapter(authenticationProvider ?? new AnonymousAuthenticationProvider(), graphClientOptions, httpClient: httpClient),baseUrl)
        {
        }

        /// <summary>
        /// Gets the <see cref="IRequestAdapter"/> for sending requests.
        /// </summary>
        public new IRequestAdapter RequestAdapter { get; set; }

        /// <summary>
        /// Gets the <see cref="BatchRequestBuilder"/> for building batch Requests
        /// </summary>
        public BatchRequestBuilder Batch
        {
            get
            {
                return new CustomBatchRequestBuilder(this.RequestAdapter);
            }
        }
        
        /// <summary>
        /// Cleanup anything as needed
        /// </summary>
        public void Dispose()
        {
            if (this.RequestAdapter is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
        
        private static IRequestAdapter InitializeRequestAdapterWithBaseUrl(IRequestAdapter requestAdapter, string baseUrl)
        {
            if (!string.IsNullOrEmpty(baseUrl))
            {
                requestAdapter.BaseUrl = baseUrl;
            }

            return requestAdapter;
        }
    }
}
