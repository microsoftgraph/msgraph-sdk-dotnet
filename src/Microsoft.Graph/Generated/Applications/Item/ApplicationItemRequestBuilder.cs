using Microsoft.Graph.Applications.Item.AppManagementPolicies;
using Microsoft.Graph.Applications.Item.CreatedOnBehalfOf;
using Microsoft.Graph.Applications.Item.ExtensionProperties;
using Microsoft.Graph.Applications.Item.FederatedIdentityCredentials;
using Microsoft.Graph.Applications.Item.HomeRealmDiscoveryPolicies;
using Microsoft.Graph.Applications.Item.Logo;
using Microsoft.Graph.Applications.Item.MicrosoftGraphAddKey;
using Microsoft.Graph.Applications.Item.MicrosoftGraphAddPassword;
using Microsoft.Graph.Applications.Item.MicrosoftGraphCheckMemberGroups;
using Microsoft.Graph.Applications.Item.MicrosoftGraphCheckMemberObjects;
using Microsoft.Graph.Applications.Item.MicrosoftGraphGetMemberGroups;
using Microsoft.Graph.Applications.Item.MicrosoftGraphGetMemberObjects;
using Microsoft.Graph.Applications.Item.MicrosoftGraphRemoveKey;
using Microsoft.Graph.Applications.Item.MicrosoftGraphRemovePassword;
using Microsoft.Graph.Applications.Item.MicrosoftGraphRestore;
using Microsoft.Graph.Applications.Item.MicrosoftGraphSetVerifiedPublisher;
using Microsoft.Graph.Applications.Item.MicrosoftGraphUnsetVerifiedPublisher;
using Microsoft.Graph.Applications.Item.Owners;
using Microsoft.Graph.Applications.Item.TokenIssuancePolicies;
using Microsoft.Graph.Applications.Item.TokenLifetimePolicies;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Microsoft.Graph.Applications.Item {
    /// <summary>
    /// Provides operations to manage the collection of application entities.
    /// </summary>
    public class ApplicationItemRequestBuilder {
        /// <summary>Provides operations to manage the appManagementPolicies property of the microsoft.graph.application entity.</summary>
        public AppManagementPoliciesRequestBuilder AppManagementPolicies { get =>
            new AppManagementPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the createdOnBehalfOf property of the microsoft.graph.application entity.</summary>
        public CreatedOnBehalfOfRequestBuilder CreatedOnBehalfOf { get =>
            new CreatedOnBehalfOfRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the extensionProperties property of the microsoft.graph.application entity.</summary>
        public ExtensionPropertiesRequestBuilder ExtensionProperties { get =>
            new ExtensionPropertiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the federatedIdentityCredentials property of the microsoft.graph.application entity.</summary>
        public FederatedIdentityCredentialsRequestBuilder FederatedIdentityCredentials { get =>
            new FederatedIdentityCredentialsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the homeRealmDiscoveryPolicies property of the microsoft.graph.application entity.</summary>
        public HomeRealmDiscoveryPoliciesRequestBuilder HomeRealmDiscoveryPolicies { get =>
            new HomeRealmDiscoveryPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the media for the application entity.</summary>
        public LogoRequestBuilder Logo { get =>
            new LogoRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the addKey method.</summary>
        public MicrosoftGraphAddKeyRequestBuilder MicrosoftGraphAddKey { get =>
            new MicrosoftGraphAddKeyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the addPassword method.</summary>
        public MicrosoftGraphAddPasswordRequestBuilder MicrosoftGraphAddPassword { get =>
            new MicrosoftGraphAddPasswordRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the checkMemberGroups method.</summary>
        public MicrosoftGraphCheckMemberGroupsRequestBuilder MicrosoftGraphCheckMemberGroups { get =>
            new MicrosoftGraphCheckMemberGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the checkMemberObjects method.</summary>
        public MicrosoftGraphCheckMemberObjectsRequestBuilder MicrosoftGraphCheckMemberObjects { get =>
            new MicrosoftGraphCheckMemberObjectsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getMemberGroups method.</summary>
        public MicrosoftGraphGetMemberGroupsRequestBuilder MicrosoftGraphGetMemberGroups { get =>
            new MicrosoftGraphGetMemberGroupsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getMemberObjects method.</summary>
        public MicrosoftGraphGetMemberObjectsRequestBuilder MicrosoftGraphGetMemberObjects { get =>
            new MicrosoftGraphGetMemberObjectsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the removeKey method.</summary>
        public MicrosoftGraphRemoveKeyRequestBuilder MicrosoftGraphRemoveKey { get =>
            new MicrosoftGraphRemoveKeyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the removePassword method.</summary>
        public MicrosoftGraphRemovePasswordRequestBuilder MicrosoftGraphRemovePassword { get =>
            new MicrosoftGraphRemovePasswordRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the restore method.</summary>
        public MicrosoftGraphRestoreRequestBuilder MicrosoftGraphRestore { get =>
            new MicrosoftGraphRestoreRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the setVerifiedPublisher method.</summary>
        public MicrosoftGraphSetVerifiedPublisherRequestBuilder MicrosoftGraphSetVerifiedPublisher { get =>
            new MicrosoftGraphSetVerifiedPublisherRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the unsetVerifiedPublisher method.</summary>
        public MicrosoftGraphUnsetVerifiedPublisherRequestBuilder MicrosoftGraphUnsetVerifiedPublisher { get =>
            new MicrosoftGraphUnsetVerifiedPublisherRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the owners property of the microsoft.graph.application entity.</summary>
        public OwnersRequestBuilder Owners { get =>
            new OwnersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Provides operations to manage the tokenIssuancePolicies property of the microsoft.graph.application entity.</summary>
        public TokenIssuancePoliciesRequestBuilder TokenIssuancePolicies { get =>
            new TokenIssuancePoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the tokenLifetimePolicies property of the microsoft.graph.application entity.</summary>
        public TokenLifetimePoliciesRequestBuilder TokenLifetimePolicies { get =>
            new TokenLifetimePoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new ApplicationItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApplicationItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/applications/{application%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new ApplicationItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApplicationItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/applications/{application%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(rawUrl)) urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete an application object. When deleted, apps are moved to a temporary container and can be restored within 30 days. After that time, they are permanently deleted.
        /// Find more info here <see href="https://docs.microsoft.com/graph/api/application-delete?view=graph-rest-1.0" />
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task DeleteAsync(Action<ApplicationItemRequestBuilderDeleteRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task DeleteAsync(Action<ApplicationItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Get the properties and relationships of an application object.
        /// Find more info here <see href="https://docs.microsoft.com/graph/api/application-get?view=graph-rest-1.0" />
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<Microsoft.Graph.Models.Application?> GetAsync(Action<ApplicationItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<Microsoft.Graph.Models.Application> GetAsync(Action<ApplicationItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Microsoft.Graph.Models.Application>(requestInfo, Microsoft.Graph.Models.Application.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Update the properties of an application object.
        /// Find more info here <see href="https://docs.microsoft.com/graph/api/application-update?view=graph-rest-1.0" />
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<Microsoft.Graph.Models.Application?> PatchAsync(Microsoft.Graph.Models.Application body, Action<ApplicationItemRequestBuilderPatchRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<Microsoft.Graph.Models.Application> PatchAsync(Microsoft.Graph.Models.Application body, Action<ApplicationItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Microsoft.Graph.Models.Application>(requestInfo, Microsoft.Graph.Models.Application.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Delete an application object. When deleted, apps are moved to a temporary container and can be restored within 30 days. After that time, they are permanently deleted.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<ApplicationItemRequestBuilderDeleteRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<ApplicationItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new ApplicationItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Get the properties and relationships of an application object.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<ApplicationItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<ApplicationItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new ApplicationItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the properties of an application object.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(Microsoft.Graph.Models.Application body, Action<ApplicationItemRequestBuilderPatchRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(Microsoft.Graph.Models.Application body, Action<ApplicationItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new ApplicationItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class ApplicationItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new ApplicationItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public ApplicationItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Get the properties and relationships of an application object.
        /// </summary>
        public class ApplicationItemRequestBuilderGetQueryParameters {
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
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class ApplicationItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public ApplicationItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new ApplicationItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new ApplicationItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public ApplicationItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class ApplicationItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new ApplicationItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public ApplicationItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
