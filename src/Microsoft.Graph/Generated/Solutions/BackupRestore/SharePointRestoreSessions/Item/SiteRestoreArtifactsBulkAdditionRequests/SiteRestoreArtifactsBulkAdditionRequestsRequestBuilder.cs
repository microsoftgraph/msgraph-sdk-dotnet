// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models;
using Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.Count;
using Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests
{
    /// <summary>
    /// Provides operations to manage the siteRestoreArtifactsBulkAdditionRequests property of the microsoft.graph.sharePointRestoreSession entity.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Provides operations to count the resources in the collection.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.Count.CountRequestBuilder Count
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.Count.CountRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the siteRestoreArtifactsBulkAdditionRequests property of the microsoft.graph.sharePointRestoreSession entity.</summary>
        /// <param name="position">The unique identifier of siteRestoreArtifactsBulkAdditionRequest</param>
        /// <returns>A <see cref="global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.Item.SiteRestoreArtifactsBulkAdditionRequestItemRequestBuilder"/></returns>
        public global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.Item.SiteRestoreArtifactsBulkAdditionRequestItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("siteRestoreArtifactsBulkAdditionRequest%2Did", position);
                return new global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.Item.SiteRestoreArtifactsBulkAdditionRequestItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/solutions/backupRestore/sharePointRestoreSessions/{sharePointRestoreSession%2Did}/siteRestoreArtifactsBulkAdditionRequests{?%24count,%24expand,%24filter,%24orderby,%24search,%24select,%24skip,%24top}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/solutions/backupRestore/sharePointRestoreSessions/{sharePointRestoreSession%2Did}/siteRestoreArtifactsBulkAdditionRequests{?%24count,%24expand,%24filter,%24orderby,%24search,%24select,%24skip,%24top}", rawUrl)
        {
        }
        /// <summary>
        /// Get a list of the siteRestoreArtifactsBulkAdditionRequest objects associated with a sharePointRestoreSession. The siteWebUrls property is deliberately omitted from the response body in order to limit the response size.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/sharepointrestoresession-list-siterestoreartifactsbulkadditionrequests?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequestCollectionResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequestCollectionResponse?> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequestCollectionResponse> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequestCollectionResponse>(requestInfo, global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequestCollectionResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Create a new siteRestoreArtifactsBulkAdditionRequest object associated with a sharePointRestoreSession. The following steps describe how to create and manage a sharePointRestoreSession with bulk artifact additions:
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/sharepointrestoresession-post-siterestoreartifactsbulkadditionrequests?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequest"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequest?> PostAsync(global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequest> PostAsync(global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequest>(requestInfo, global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequest.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Get a list of the siteRestoreArtifactsBulkAdditionRequest objects associated with a sharePointRestoreSession. The siteWebUrls property is deliberately omitted from the response body in order to limit the response size.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Create a new siteRestoreArtifactsBulkAdditionRequest object associated with a sharePointRestoreSession. The following steps describe how to create and manage a sharePointRestoreSession with bulk artifact additions:
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(global::Microsoft.Graph.Models.SiteRestoreArtifactsBulkAdditionRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Get a list of the siteRestoreArtifactsBulkAdditionRequest objects associated with a sharePointRestoreSession. The siteWebUrls property is deliberately omitted from the response body in order to limit the response size.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class SiteRestoreArtifactsBulkAdditionRequestsRequestBuilderGetQueryParameters 
        {
            /// <summary>Include count of items</summary>
            [QueryParameter("%24count")]
            public bool? Count { get; set; }
            /// <summary>Expand related entities</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24expand")]
            public string[]? Expand { get; set; }
#nullable restore
#else
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
#endif
            /// <summary>Filter items by property values</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24filter")]
            public string? Filter { get; set; }
#nullable restore
#else
            [QueryParameter("%24filter")]
            public string Filter { get; set; }
#endif
            /// <summary>Order items by property values</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24orderby")]
            public string[]? Orderby { get; set; }
#nullable restore
#else
            [QueryParameter("%24orderby")]
            public string[] Orderby { get; set; }
#endif
            /// <summary>Search items by search phrases</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24search")]
            public string? Search { get; set; }
#nullable restore
#else
            [QueryParameter("%24search")]
            public string Search { get; set; }
#endif
            /// <summary>Select properties to be returned</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24select")]
            public string[]? Select { get; set; }
#nullable restore
#else
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
#endif
            /// <summary>Skip the first n items</summary>
            [QueryParameter("%24skip")]
            public int? Skip { get; set; }
            /// <summary>Show only the first n items</summary>
            [QueryParameter("%24top")]
            public int? Top { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class SiteRestoreArtifactsBulkAdditionRequestsRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.Item.SiteRestoreArtifactsBulkAdditionRequests.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilder.SiteRestoreArtifactsBulkAdditionRequestsRequestBuilderGetQueryParameters>
        {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class SiteRestoreArtifactsBulkAdditionRequestsRequestBuilderPostRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
