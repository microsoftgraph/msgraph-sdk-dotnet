// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models;
using Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Approvers;
using Microsoft.Graph.Privacy.SubjectRightsRequests.Item.ApproversWithUserPrincipalName;
using Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Collaborators;
using Microsoft.Graph.Privacy.SubjectRightsRequests.Item.CollaboratorsWithUserPrincipalName;
using Microsoft.Graph.Privacy.SubjectRightsRequests.Item.GetFinalAttachment;
using Microsoft.Graph.Privacy.SubjectRightsRequests.Item.GetFinalReport;
using Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Notes;
using Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Team;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Microsoft.Graph.Privacy.SubjectRightsRequests.Item
{
    /// <summary>
    /// Provides operations to manage the subjectRightsRequests property of the microsoft.graph.privacy entity.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class SubjectRightsRequestItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Provides operations to manage the approvers property of the microsoft.graph.subjectRightsRequest entity.</summary>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
        public global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Approvers.ApproversRequestBuilder Approvers
        {
            get => new global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Approvers.ApproversRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the collaborators property of the microsoft.graph.subjectRightsRequest entity.</summary>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
        public global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Collaborators.CollaboratorsRequestBuilder Collaborators
        {
            get => new global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Collaborators.CollaboratorsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getFinalAttachment method.</summary>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
        public global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.GetFinalAttachment.GetFinalAttachmentRequestBuilder GetFinalAttachment
        {
            get => new global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.GetFinalAttachment.GetFinalAttachmentRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getFinalReport method.</summary>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
        public global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.GetFinalReport.GetFinalReportRequestBuilder GetFinalReport
        {
            get => new global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.GetFinalReport.GetFinalReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the notes property of the microsoft.graph.subjectRightsRequest entity.</summary>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
        public global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Notes.NotesRequestBuilder Notes
        {
            get => new global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Notes.NotesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the team property of the microsoft.graph.subjectRightsRequest entity.</summary>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
        public global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Team.TeamRequestBuilder Team
        {
            get => new global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.Team.TeamRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Provides operations to manage the approvers property of the microsoft.graph.subjectRightsRequest entity.
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.ApproversWithUserPrincipalName.ApproversWithUserPrincipalNameRequestBuilder"/></returns>
        /// <param name="userPrincipalName">Alternate key of user</param>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
        public global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.ApproversWithUserPrincipalName.ApproversWithUserPrincipalNameRequestBuilder ApproversWithUserPrincipalName(string userPrincipalName)
        {
            if(string.IsNullOrEmpty(userPrincipalName)) throw new ArgumentNullException(nameof(userPrincipalName));
            return new global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.ApproversWithUserPrincipalName.ApproversWithUserPrincipalNameRequestBuilder(PathParameters, RequestAdapter, userPrincipalName);
        }
        /// <summary>
        /// Provides operations to manage the collaborators property of the microsoft.graph.subjectRightsRequest entity.
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.CollaboratorsWithUserPrincipalName.CollaboratorsWithUserPrincipalNameRequestBuilder"/></returns>
        /// <param name="userPrincipalName">Alternate key of user</param>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
        public global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.CollaboratorsWithUserPrincipalName.CollaboratorsWithUserPrincipalNameRequestBuilder CollaboratorsWithUserPrincipalName(string userPrincipalName)
        {
            if(string.IsNullOrEmpty(userPrincipalName)) throw new ArgumentNullException(nameof(userPrincipalName));
            return new global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.CollaboratorsWithUserPrincipalName.CollaboratorsWithUserPrincipalNameRequestBuilder(PathParameters, RequestAdapter, userPrincipalName);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SubjectRightsRequestItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/privacy/subjectRightsRequests/{subjectRightsRequest%2Did}{?%24expand,%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SubjectRightsRequestItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/privacy/subjectRightsRequests/{subjectRightsRequest%2Did}{?%24expand,%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Delete navigation property subjectRightsRequests for privacy
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task DeleteAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task DeleteAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Read the properties and relationships of a subjectRightsRequest object.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/subjectrightsrequest-get?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.SubjectRightsRequest"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.SubjectRightsRequest?> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder.SubjectRightsRequestItemRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.SubjectRightsRequest> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder.SubjectRightsRequestItemRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.SubjectRightsRequest>(requestInfo, global::Microsoft.Graph.Models.SubjectRightsRequest.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Update the properties of a subjectRightsRequest object.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/subjectrightsrequest-update?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.SubjectRightsRequest"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.SubjectRightsRequest?> PatchAsync(global::Microsoft.Graph.Models.SubjectRightsRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.SubjectRightsRequest> PatchAsync(global::Microsoft.Graph.Models.SubjectRightsRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.SubjectRightsRequest>(requestInfo, global::Microsoft.Graph.Models.SubjectRightsRequest.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Delete navigation property subjectRightsRequests for privacy
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.DELETE, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            return requestInfo;
        }
        /// <summary>
        /// Read the properties and relationships of a subjectRightsRequest object.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder.SubjectRightsRequestItemRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder.SubjectRightsRequestItemRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Update the properties of a subjectRightsRequest object.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.SubjectRightsRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.SubjectRightsRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.PATCH, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        [Obsolete("The subject rights request API under Privacy is deprecated and will stop working on  March 22, 2025. Please use the new API under Security. as of 2022-02/PrivacyDeprecate on 2022-03-22 and will be removed 2025-03-20")]
        public global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class SubjectRightsRequestItemRequestBuilderDeleteRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
        /// <summary>
        /// Read the properties and relationships of a subjectRightsRequest object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class SubjectRightsRequestItemRequestBuilderGetQueryParameters 
        {
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
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class SubjectRightsRequestItemRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Microsoft.Graph.Privacy.SubjectRightsRequests.Item.SubjectRightsRequestItemRequestBuilder.SubjectRightsRequestItemRequestBuilderGetQueryParameters>
        {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class SubjectRightsRequestItemRequestBuilderPatchRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
