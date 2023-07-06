using Microsoft.Graph.DeviceManagement.Reports.ExportJobs;
using Microsoft.Graph.DeviceManagement.Reports.GetCachedReport;
using Microsoft.Graph.DeviceManagement.Reports.GetCompliancePolicyNonComplianceReport;
using Microsoft.Graph.DeviceManagement.Reports.GetCompliancePolicyNonComplianceSummaryReport;
using Microsoft.Graph.DeviceManagement.Reports.GetComplianceSettingNonComplianceReport;
using Microsoft.Graph.DeviceManagement.Reports.GetConfigurationPolicyNonComplianceReport;
using Microsoft.Graph.DeviceManagement.Reports.GetConfigurationPolicyNonComplianceSummaryReport;
using Microsoft.Graph.DeviceManagement.Reports.GetConfigurationSettingNonComplianceReport;
using Microsoft.Graph.DeviceManagement.Reports.GetDeviceManagementIntentPerSettingContributingProfiles;
using Microsoft.Graph.DeviceManagement.Reports.GetDeviceManagementIntentSettingsReport;
using Microsoft.Graph.DeviceManagement.Reports.GetDeviceNonComplianceReport;
using Microsoft.Graph.DeviceManagement.Reports.GetDevicesWithoutCompliancePolicyReport;
using Microsoft.Graph.DeviceManagement.Reports.GetHistoricalReport;
using Microsoft.Graph.DeviceManagement.Reports.GetNoncompliantDevicesAndSettingsReport;
using Microsoft.Graph.DeviceManagement.Reports.GetPolicyNonComplianceMetadata;
using Microsoft.Graph.DeviceManagement.Reports.GetPolicyNonComplianceReport;
using Microsoft.Graph.DeviceManagement.Reports.GetPolicyNonComplianceSummaryReport;
using Microsoft.Graph.DeviceManagement.Reports.GetReportFilters;
using Microsoft.Graph.DeviceManagement.Reports.GetSettingNonComplianceReport;
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Microsoft.Graph.DeviceManagement.Reports {
    /// <summary>
    /// Provides operations to manage the reports property of the microsoft.graph.deviceManagement entity.
    /// </summary>
    public class ReportsRequestBuilder : BaseRequestBuilder {
        /// <summary>Provides operations to manage the exportJobs property of the microsoft.graph.deviceManagementReports entity.</summary>
        public ExportJobsRequestBuilder ExportJobs { get =>
            new ExportJobsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getCachedReport method.</summary>
        public GetCachedReportRequestBuilder GetCachedReport { get =>
            new GetCachedReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getCompliancePolicyNonComplianceReport method.</summary>
        public GetCompliancePolicyNonComplianceReportRequestBuilder GetCompliancePolicyNonComplianceReport { get =>
            new GetCompliancePolicyNonComplianceReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getCompliancePolicyNonComplianceSummaryReport method.</summary>
        public GetCompliancePolicyNonComplianceSummaryReportRequestBuilder GetCompliancePolicyNonComplianceSummaryReport { get =>
            new GetCompliancePolicyNonComplianceSummaryReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getComplianceSettingNonComplianceReport method.</summary>
        public GetComplianceSettingNonComplianceReportRequestBuilder GetComplianceSettingNonComplianceReport { get =>
            new GetComplianceSettingNonComplianceReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getConfigurationPolicyNonComplianceReport method.</summary>
        public GetConfigurationPolicyNonComplianceReportRequestBuilder GetConfigurationPolicyNonComplianceReport { get =>
            new GetConfigurationPolicyNonComplianceReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getConfigurationPolicyNonComplianceSummaryReport method.</summary>
        public GetConfigurationPolicyNonComplianceSummaryReportRequestBuilder GetConfigurationPolicyNonComplianceSummaryReport { get =>
            new GetConfigurationPolicyNonComplianceSummaryReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getConfigurationSettingNonComplianceReport method.</summary>
        public GetConfigurationSettingNonComplianceReportRequestBuilder GetConfigurationSettingNonComplianceReport { get =>
            new GetConfigurationSettingNonComplianceReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getDeviceManagementIntentPerSettingContributingProfiles method.</summary>
        public GetDeviceManagementIntentPerSettingContributingProfilesRequestBuilder GetDeviceManagementIntentPerSettingContributingProfiles { get =>
            new GetDeviceManagementIntentPerSettingContributingProfilesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getDeviceManagementIntentSettingsReport method.</summary>
        public GetDeviceManagementIntentSettingsReportRequestBuilder GetDeviceManagementIntentSettingsReport { get =>
            new GetDeviceManagementIntentSettingsReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getDeviceNonComplianceReport method.</summary>
        public GetDeviceNonComplianceReportRequestBuilder GetDeviceNonComplianceReport { get =>
            new GetDeviceNonComplianceReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getDevicesWithoutCompliancePolicyReport method.</summary>
        public GetDevicesWithoutCompliancePolicyReportRequestBuilder GetDevicesWithoutCompliancePolicyReport { get =>
            new GetDevicesWithoutCompliancePolicyReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getHistoricalReport method.</summary>
        public GetHistoricalReportRequestBuilder GetHistoricalReport { get =>
            new GetHistoricalReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getNoncompliantDevicesAndSettingsReport method.</summary>
        public GetNoncompliantDevicesAndSettingsReportRequestBuilder GetNoncompliantDevicesAndSettingsReport { get =>
            new GetNoncompliantDevicesAndSettingsReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getPolicyNonComplianceMetadata method.</summary>
        public GetPolicyNonComplianceMetadataRequestBuilder GetPolicyNonComplianceMetadata { get =>
            new GetPolicyNonComplianceMetadataRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getPolicyNonComplianceReport method.</summary>
        public GetPolicyNonComplianceReportRequestBuilder GetPolicyNonComplianceReport { get =>
            new GetPolicyNonComplianceReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getPolicyNonComplianceSummaryReport method.</summary>
        public GetPolicyNonComplianceSummaryReportRequestBuilder GetPolicyNonComplianceSummaryReport { get =>
            new GetPolicyNonComplianceSummaryReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getReportFilters method.</summary>
        public GetReportFiltersRequestBuilder GetReportFilters { get =>
            new GetReportFiltersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Provides operations to call the getSettingNonComplianceReport method.</summary>
        public GetSettingNonComplianceReportRequestBuilder GetSettingNonComplianceReport { get =>
            new GetSettingNonComplianceReportRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new ReportsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ReportsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/deviceManagement/reports{?%24select,%24expand}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new ReportsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ReportsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/deviceManagement/reports{?%24select,%24expand}", rawUrl) {
        }
        /// <summary>
        /// Delete navigation property reports for deviceManagement
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task DeleteAsync(Action<ReportsRequestBuilderDeleteRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task DeleteAsync(Action<ReportsRequestBuilderDeleteRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Reports singleton
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<DeviceManagementReports?> GetAsync(Action<ReportsRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<DeviceManagementReports> GetAsync(Action<ReportsRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<DeviceManagementReports>(requestInfo, DeviceManagementReports.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Update the navigation property reports in deviceManagement
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<DeviceManagementReports?> PatchAsync(DeviceManagementReports body, Action<ReportsRequestBuilderPatchRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<DeviceManagementReports> PatchAsync(DeviceManagementReports body, Action<ReportsRequestBuilderPatchRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<DeviceManagementReports>(requestInfo, DeviceManagementReports.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Delete navigation property reports for deviceManagement
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<ReportsRequestBuilderDeleteRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<ReportsRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new ReportsRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Reports singleton
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<ReportsRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<ReportsRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new ReportsRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property reports in deviceManagement
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(DeviceManagementReports body, Action<ReportsRequestBuilderPatchRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(DeviceManagementReports body, Action<ReportsRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
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
                var requestConfig = new ReportsRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class ReportsRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new reportsRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public ReportsRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Reports singleton
        /// </summary>
        public class ReportsRequestBuilderGetQueryParameters {
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
        public class ReportsRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public ReportsRequestBuilderGetQueryParameters QueryParameters { get; set; } = new ReportsRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new reportsRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public ReportsRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class ReportsRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new reportsRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public ReportsRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
