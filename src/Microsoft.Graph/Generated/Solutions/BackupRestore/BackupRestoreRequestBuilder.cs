// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models;
using Microsoft.Graph.Solutions.BackupRestore.DriveInclusionRules;
using Microsoft.Graph.Solutions.BackupRestore.DriveProtectionUnits;
using Microsoft.Graph.Solutions.BackupRestore.DriveProtectionUnitsBulkAdditionJobs;
using Microsoft.Graph.Solutions.BackupRestore.Enable;
using Microsoft.Graph.Solutions.BackupRestore.ExchangeProtectionPolicies;
using Microsoft.Graph.Solutions.BackupRestore.ExchangeRestoreSessions;
using Microsoft.Graph.Solutions.BackupRestore.MailboxInclusionRules;
using Microsoft.Graph.Solutions.BackupRestore.MailboxProtectionUnits;
using Microsoft.Graph.Solutions.BackupRestore.MailboxProtectionUnitsBulkAdditionJobs;
using Microsoft.Graph.Solutions.BackupRestore.OneDriveForBusinessProtectionPolicies;
using Microsoft.Graph.Solutions.BackupRestore.OneDriveForBusinessRestoreSessions;
using Microsoft.Graph.Solutions.BackupRestore.ProtectionPolicies;
using Microsoft.Graph.Solutions.BackupRestore.ProtectionUnits;
using Microsoft.Graph.Solutions.BackupRestore.RestorePoints;
using Microsoft.Graph.Solutions.BackupRestore.RestoreSessions;
using Microsoft.Graph.Solutions.BackupRestore.ServiceApps;
using Microsoft.Graph.Solutions.BackupRestore.SharePointProtectionPolicies;
using Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions;
using Microsoft.Graph.Solutions.BackupRestore.SiteInclusionRules;
using Microsoft.Graph.Solutions.BackupRestore.SiteProtectionUnits;
using Microsoft.Graph.Solutions.BackupRestore.SiteProtectionUnitsBulkAdditionJobs;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Microsoft.Graph.Solutions.BackupRestore
{
    /// <summary>
    /// Provides operations to manage the backupRestore property of the microsoft.graph.solutionsRoot entity.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class BackupRestoreRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Provides operations to manage the driveInclusionRules property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.DriveInclusionRules.DriveInclusionRulesRequestBuilder DriveInclusionRules
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.DriveInclusionRules.DriveInclusionRulesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the driveProtectionUnits property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.DriveProtectionUnits.DriveProtectionUnitsRequestBuilder DriveProtectionUnits
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.DriveProtectionUnits.DriveProtectionUnitsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the driveProtectionUnitsBulkAdditionJobs property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.DriveProtectionUnitsBulkAdditionJobs.DriveProtectionUnitsBulkAdditionJobsRequestBuilder DriveProtectionUnitsBulkAdditionJobs
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.DriveProtectionUnitsBulkAdditionJobs.DriveProtectionUnitsBulkAdditionJobsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the enable method.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.Enable.EnableRequestBuilder Enable
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.Enable.EnableRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the exchangeProtectionPolicies property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.ExchangeProtectionPolicies.ExchangeProtectionPoliciesRequestBuilder ExchangeProtectionPolicies
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.ExchangeProtectionPolicies.ExchangeProtectionPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the exchangeRestoreSessions property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.ExchangeRestoreSessions.ExchangeRestoreSessionsRequestBuilder ExchangeRestoreSessions
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.ExchangeRestoreSessions.ExchangeRestoreSessionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the mailboxInclusionRules property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.MailboxInclusionRules.MailboxInclusionRulesRequestBuilder MailboxInclusionRules
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.MailboxInclusionRules.MailboxInclusionRulesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the mailboxProtectionUnits property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.MailboxProtectionUnits.MailboxProtectionUnitsRequestBuilder MailboxProtectionUnits
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.MailboxProtectionUnits.MailboxProtectionUnitsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the mailboxProtectionUnitsBulkAdditionJobs property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.MailboxProtectionUnitsBulkAdditionJobs.MailboxProtectionUnitsBulkAdditionJobsRequestBuilder MailboxProtectionUnitsBulkAdditionJobs
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.MailboxProtectionUnitsBulkAdditionJobs.MailboxProtectionUnitsBulkAdditionJobsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the oneDriveForBusinessProtectionPolicies property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.OneDriveForBusinessProtectionPolicies.OneDriveForBusinessProtectionPoliciesRequestBuilder OneDriveForBusinessProtectionPolicies
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.OneDriveForBusinessProtectionPolicies.OneDriveForBusinessProtectionPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the oneDriveForBusinessRestoreSessions property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.OneDriveForBusinessRestoreSessions.OneDriveForBusinessRestoreSessionsRequestBuilder OneDriveForBusinessRestoreSessions
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.OneDriveForBusinessRestoreSessions.OneDriveForBusinessRestoreSessionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the protectionPolicies property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.ProtectionPolicies.ProtectionPoliciesRequestBuilder ProtectionPolicies
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.ProtectionPolicies.ProtectionPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the protectionUnits property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.ProtectionUnits.ProtectionUnitsRequestBuilder ProtectionUnits
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.ProtectionUnits.ProtectionUnitsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the restorePoints property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.RestorePoints.RestorePointsRequestBuilder RestorePoints
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.RestorePoints.RestorePointsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the restoreSessions property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.RestoreSessions.RestoreSessionsRequestBuilder RestoreSessions
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.RestoreSessions.RestoreSessionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the serviceApps property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.ServiceApps.ServiceAppsRequestBuilder ServiceApps
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.ServiceApps.ServiceAppsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the sharePointProtectionPolicies property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.SharePointProtectionPolicies.SharePointProtectionPoliciesRequestBuilder SharePointProtectionPolicies
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.SharePointProtectionPolicies.SharePointProtectionPoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the sharePointRestoreSessions property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.SharePointRestoreSessionsRequestBuilder SharePointRestoreSessions
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.SharePointRestoreSessions.SharePointRestoreSessionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the siteInclusionRules property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.SiteInclusionRules.SiteInclusionRulesRequestBuilder SiteInclusionRules
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.SiteInclusionRules.SiteInclusionRulesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the siteProtectionUnits property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.SiteProtectionUnits.SiteProtectionUnitsRequestBuilder SiteProtectionUnits
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.SiteProtectionUnits.SiteProtectionUnitsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to manage the siteProtectionUnitsBulkAdditionJobs property of the microsoft.graph.backupRestoreRoot entity.</summary>
        public global::Microsoft.Graph.Solutions.BackupRestore.SiteProtectionUnitsBulkAdditionJobs.SiteProtectionUnitsBulkAdditionJobsRequestBuilder SiteProtectionUnitsBulkAdditionJobs
        {
            get => new global::Microsoft.Graph.Solutions.BackupRestore.SiteProtectionUnitsBulkAdditionJobs.SiteProtectionUnitsBulkAdditionJobsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public BackupRestoreRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/solutions/backupRestore{?%24expand,%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public BackupRestoreRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/solutions/backupRestore{?%24expand,%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Delete navigation property backupRestore for solutions
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
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
        /// Get the serviceStatus of the Microsoft 365 Backup Storage service in a tenant.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/backuprestoreroot-get?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.BackupRestoreRoot"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.BackupRestoreRoot?> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder.BackupRestoreRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.BackupRestoreRoot> GetAsync(Action<RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder.BackupRestoreRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.BackupRestoreRoot>(requestInfo, global::Microsoft.Graph.Models.BackupRestoreRoot.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Update the navigation property backupRestore in solutions
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.BackupRestoreRoot"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Microsoft.Graph.Models.ODataErrors.ODataError">When receiving a 4XX or 5XX status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Microsoft.Graph.Models.BackupRestoreRoot?> PatchAsync(global::Microsoft.Graph.Models.BackupRestoreRoot body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Microsoft.Graph.Models.BackupRestoreRoot> PatchAsync(global::Microsoft.Graph.Models.BackupRestoreRoot body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "XXX", global::Microsoft.Graph.Models.ODataErrors.ODataError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Microsoft.Graph.Models.BackupRestoreRoot>(requestInfo, global::Microsoft.Graph.Models.BackupRestoreRoot.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Delete navigation property backupRestore for solutions
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
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
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Get the serviceStatus of the Microsoft 365 Backup Storage service in a tenant.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder.BackupRestoreRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder.BackupRestoreRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property backupRestore in solutions
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.BackupRestoreRoot body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(global::Microsoft.Graph.Models.BackupRestoreRoot body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class BackupRestoreRequestBuilderDeleteRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
        /// <summary>
        /// Get the serviceStatus of the Microsoft 365 Backup Storage service in a tenant.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class BackupRestoreRequestBuilderGetQueryParameters 
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
        public partial class BackupRestoreRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Microsoft.Graph.Solutions.BackupRestore.BackupRestoreRequestBuilder.BackupRestoreRequestBuilderGetQueryParameters>
        {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class BackupRestoreRequestBuilderPatchRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
