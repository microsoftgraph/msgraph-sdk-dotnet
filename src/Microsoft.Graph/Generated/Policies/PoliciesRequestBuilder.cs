using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models;
using Microsoft.Graph.Policies.ActivityBasedTimeoutPolicies;
using Microsoft.Graph.Policies.AdminConsentRequestPolicy;
using Microsoft.Graph.Policies.AppManagementPolicies;
using Microsoft.Graph.Policies.AuthenticationFlowsPolicy;
using Microsoft.Graph.Policies.AuthenticationMethodsPolicy;
using Microsoft.Graph.Policies.AuthenticationStrengthPolicies;
using Microsoft.Graph.Policies.AuthorizationPolicy;
using Microsoft.Graph.Policies.ClaimsMappingPolicies;
using Microsoft.Graph.Policies.ConditionalAccessPolicies;
using Microsoft.Graph.Policies.CrossTenantAccessPolicy;
using Microsoft.Graph.Policies.DefaultAppManagementPolicy;
using Microsoft.Graph.Policies.FeatureRolloutPolicies;
using Microsoft.Graph.Policies.HomeRealmDiscoveryPolicies;
using Microsoft.Graph.Policies.IdentitySecurityDefaultsEnforcementPolicy;
using Microsoft.Graph.Policies.PermissionGrantPolicies;
using Microsoft.Graph.Policies.RoleManagementPolicies;
using Microsoft.Graph.Policies.RoleManagementPolicyAssignments;
using Microsoft.Graph.Policies.TokenIssuancePolicies;
using Microsoft.Graph.Policies.TokenLifetimePolicies;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Microsoft.Graph.Policies {
    /// <summary>
    /// Provides operations to manage the policyRoot singleton.
    /// </summary>
    public class PoliciesRequestBuilder : BaseRequestBuilder {
        /// <summary>Provides operations to manage the activityBasedTimeoutPolicies property of the microsoft.graph.policyRoot entity.</summary>
        public ActivityBasedTimeoutPoliciesRequestBuilder ActivityBasedTimeoutPolicies { get =>
            new ActivityBasedTimeoutPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the adminConsentRequestPolicy property of the microsoft.graph.policyRoot entity.</summary>
        public AdminConsentRequestPolicyRequestBuilder AdminConsentRequestPolicy { get =>
            new AdminConsentRequestPolicyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the appManagementPolicies property of the microsoft.graph.policyRoot entity.</summary>
        public AppManagementPoliciesRequestBuilder AppManagementPolicies { get =>
            new AppManagementPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the authenticationFlowsPolicy property of the microsoft.graph.policyRoot entity.</summary>
        public AuthenticationFlowsPolicyRequestBuilder AuthenticationFlowsPolicy { get =>
            new AuthenticationFlowsPolicyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the authenticationMethodsPolicy property of the microsoft.graph.policyRoot entity.</summary>
        public AuthenticationMethodsPolicyRequestBuilder AuthenticationMethodsPolicy { get =>
            new AuthenticationMethodsPolicyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the authenticationStrengthPolicies property of the microsoft.graph.policyRoot entity.</summary>
        public AuthenticationStrengthPoliciesRequestBuilder AuthenticationStrengthPolicies { get =>
            new AuthenticationStrengthPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the authorizationPolicy property of the microsoft.graph.policyRoot entity.</summary>
        public AuthorizationPolicyRequestBuilder AuthorizationPolicy { get =>
            new AuthorizationPolicyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the claimsMappingPolicies property of the microsoft.graph.policyRoot entity.</summary>
        public ClaimsMappingPoliciesRequestBuilder ClaimsMappingPolicies { get =>
            new ClaimsMappingPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the conditionalAccessPolicies property of the microsoft.graph.policyRoot entity.</summary>
        public ConditionalAccessPoliciesRequestBuilder ConditionalAccessPolicies { get =>
            new ConditionalAccessPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the crossTenantAccessPolicy property of the microsoft.graph.policyRoot entity.</summary>
        public CrossTenantAccessPolicyRequestBuilder CrossTenantAccessPolicy { get =>
            new CrossTenantAccessPolicyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the defaultAppManagementPolicy property of the microsoft.graph.policyRoot entity.</summary>
        public DefaultAppManagementPolicyRequestBuilder DefaultAppManagementPolicy { get =>
            new DefaultAppManagementPolicyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the featureRolloutPolicies property of the microsoft.graph.policyRoot entity.</summary>
        public FeatureRolloutPoliciesRequestBuilder FeatureRolloutPolicies { get =>
            new FeatureRolloutPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the homeRealmDiscoveryPolicies property of the microsoft.graph.policyRoot entity.</summary>
        public HomeRealmDiscoveryPoliciesRequestBuilder HomeRealmDiscoveryPolicies { get =>
            new HomeRealmDiscoveryPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the identitySecurityDefaultsEnforcementPolicy property of the microsoft.graph.policyRoot entity.</summary>
        public IdentitySecurityDefaultsEnforcementPolicyRequestBuilder IdentitySecurityDefaultsEnforcementPolicy { get =>
            new IdentitySecurityDefaultsEnforcementPolicyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the permissionGrantPolicies property of the microsoft.graph.policyRoot entity.</summary>
        public PermissionGrantPoliciesRequestBuilder PermissionGrantPolicies { get =>
            new PermissionGrantPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the roleManagementPolicies property of the microsoft.graph.policyRoot entity.</summary>
        public RoleManagementPoliciesRequestBuilder RoleManagementPolicies { get =>
            new RoleManagementPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the roleManagementPolicyAssignments property of the microsoft.graph.policyRoot entity.</summary>
        public RoleManagementPolicyAssignmentsRequestBuilder RoleManagementPolicyAssignments { get =>
            new RoleManagementPolicyAssignmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the tokenIssuancePolicies property of the microsoft.graph.policyRoot entity.</summary>
        public TokenIssuancePoliciesRequestBuilder TokenIssuancePolicies { get =>
            new TokenIssuancePoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the tokenLifetimePolicies property of the microsoft.graph.policyRoot entity.</summary>
        public TokenLifetimePoliciesRequestBuilder TokenLifetimePolicies { get =>
            new TokenLifetimePoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new PoliciesRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public PoliciesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/policies{?%24select,%24expand}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new PoliciesRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public PoliciesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/policies{?%24select,%24expand}", rawUrl) {
        }
        /// <summary>
        /// Get policies
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<PolicyRoot?> GetAsync(Action<PoliciesRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<PolicyRoot> GetAsync(Action<PoliciesRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<PolicyRoot>(requestInfo, PolicyRoot.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Update policies
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<PolicyRoot?> PatchAsync(PolicyRoot body, Action<PoliciesRequestBuilderPatchRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<PolicyRoot> PatchAsync(PolicyRoot body, Action<PoliciesRequestBuilderPatchRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<PolicyRoot>(requestInfo, PolicyRoot.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Get policies
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<PoliciesRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<PoliciesRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new PoliciesRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update policies
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(PolicyRoot body, Action<PoliciesRequestBuilderPatchRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(PolicyRoot body, Action<PoliciesRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
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
                var requestConfig = new PoliciesRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Get policies
        /// </summary>
        public class PoliciesRequestBuilderGetQueryParameters {
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
        public class PoliciesRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public PoliciesRequestBuilderGetQueryParameters QueryParameters { get; set; } = new PoliciesRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new policiesRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public PoliciesRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class PoliciesRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new policiesRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public PoliciesRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
