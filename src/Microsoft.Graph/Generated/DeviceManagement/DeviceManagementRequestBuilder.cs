using Microsoft.Graph.DeviceManagement.ApplePushNotificationCertificate;
using Microsoft.Graph.DeviceManagement.ComplianceManagementPartners;
using Microsoft.Graph.DeviceManagement.ConditionalAccessSettings;
using Microsoft.Graph.DeviceManagement.DetectedApps;
using Microsoft.Graph.DeviceManagement.DeviceCategories;
using Microsoft.Graph.DeviceManagement.DeviceCompliancePolicies;
using Microsoft.Graph.DeviceManagement.DeviceCompliancePolicyDeviceStateSummary;
using Microsoft.Graph.DeviceManagement.DeviceCompliancePolicySettingStateSummaries;
using Microsoft.Graph.DeviceManagement.DeviceConfigurationDeviceStateSummaries;
using Microsoft.Graph.DeviceManagement.DeviceConfigurations;
using Microsoft.Graph.DeviceManagement.DeviceEnrollmentConfigurations;
using Microsoft.Graph.DeviceManagement.DeviceManagementPartners;
using Microsoft.Graph.DeviceManagement.ExchangeConnectors;
using Microsoft.Graph.DeviceManagement.GetEffectivePermissionsWithScope;
using Microsoft.Graph.DeviceManagement.ImportedWindowsAutopilotDeviceIdentities;
using Microsoft.Graph.DeviceManagement.IosUpdateStatuses;
using Microsoft.Graph.DeviceManagement.ManagedDeviceOverview;
using Microsoft.Graph.DeviceManagement.ManagedDevices;
using Microsoft.Graph.DeviceManagement.MobileThreatDefenseConnectors;
using Microsoft.Graph.DeviceManagement.NotificationMessageTemplates;
using Microsoft.Graph.DeviceManagement.RemoteAssistancePartners;
using Microsoft.Graph.DeviceManagement.Reports;
using Microsoft.Graph.DeviceManagement.ResourceOperations;
using Microsoft.Graph.DeviceManagement.RoleAssignments;
using Microsoft.Graph.DeviceManagement.RoleDefinitions;
using Microsoft.Graph.DeviceManagement.SoftwareUpdateStatusSummary;
using Microsoft.Graph.DeviceManagement.TelecomExpenseManagementPartners;
using Microsoft.Graph.DeviceManagement.TermsAndConditions;
using Microsoft.Graph.DeviceManagement.TroubleshootingEvents;
using Microsoft.Graph.DeviceManagement.VerifyWindowsEnrollmentAutoDiscoveryWithDomainName;
using Microsoft.Graph.DeviceManagement.WindowsAutopilotDeviceIdentities;
using Microsoft.Graph.DeviceManagement.WindowsInformationProtectionAppLearningSummaries;
using Microsoft.Graph.DeviceManagement.WindowsInformationProtectionNetworkLearningSummaries;
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
namespace Microsoft.Graph.DeviceManagement {
    /// <summary>Provides operations to manage the deviceManagement singleton.</summary>
    public class DeviceManagementRequestBuilder {
        /// <summary>The applePushNotificationCertificate property</summary>
        public ApplePushNotificationCertificateRequestBuilder ApplePushNotificationCertificate { get =>
            new ApplePushNotificationCertificateRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The complianceManagementPartners property</summary>
        public ComplianceManagementPartnersRequestBuilder ComplianceManagementPartners { get =>
            new ComplianceManagementPartnersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The conditionalAccessSettings property</summary>
        public ConditionalAccessSettingsRequestBuilder ConditionalAccessSettings { get =>
            new ConditionalAccessSettingsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The detectedApps property</summary>
        public DetectedAppsRequestBuilder DetectedApps { get =>
            new DetectedAppsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deviceCategories property</summary>
        public DeviceCategoriesRequestBuilder DeviceCategories { get =>
            new DeviceCategoriesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deviceCompliancePolicies property</summary>
        public DeviceCompliancePoliciesRequestBuilder DeviceCompliancePolicies { get =>
            new DeviceCompliancePoliciesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deviceCompliancePolicyDeviceStateSummary property</summary>
        public DeviceCompliancePolicyDeviceStateSummaryRequestBuilder DeviceCompliancePolicyDeviceStateSummary { get =>
            new DeviceCompliancePolicyDeviceStateSummaryRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deviceCompliancePolicySettingStateSummaries property</summary>
        public DeviceCompliancePolicySettingStateSummariesRequestBuilder DeviceCompliancePolicySettingStateSummaries { get =>
            new DeviceCompliancePolicySettingStateSummariesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deviceConfigurationDeviceStateSummaries property</summary>
        public DeviceConfigurationDeviceStateSummariesRequestBuilder DeviceConfigurationDeviceStateSummaries { get =>
            new DeviceConfigurationDeviceStateSummariesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deviceConfigurations property</summary>
        public DeviceConfigurationsRequestBuilder DeviceConfigurations { get =>
            new DeviceConfigurationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deviceEnrollmentConfigurations property</summary>
        public DeviceEnrollmentConfigurationsRequestBuilder DeviceEnrollmentConfigurations { get =>
            new DeviceEnrollmentConfigurationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deviceManagementPartners property</summary>
        public DeviceManagementPartnersRequestBuilder DeviceManagementPartners { get =>
            new DeviceManagementPartnersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The exchangeConnectors property</summary>
        public ExchangeConnectorsRequestBuilder ExchangeConnectors { get =>
            new ExchangeConnectorsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The importedWindowsAutopilotDeviceIdentities property</summary>
        public ImportedWindowsAutopilotDeviceIdentitiesRequestBuilder ImportedWindowsAutopilotDeviceIdentities { get =>
            new ImportedWindowsAutopilotDeviceIdentitiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The iosUpdateStatuses property</summary>
        public IosUpdateStatusesRequestBuilder IosUpdateStatuses { get =>
            new IosUpdateStatusesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The managedDeviceOverview property</summary>
        public ManagedDeviceOverviewRequestBuilder ManagedDeviceOverview { get =>
            new ManagedDeviceOverviewRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The managedDevices property</summary>
        public ManagedDevicesRequestBuilder ManagedDevices { get =>
            new ManagedDevicesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The mobileThreatDefenseConnectors property</summary>
        public MobileThreatDefenseConnectorsRequestBuilder MobileThreatDefenseConnectors { get =>
            new MobileThreatDefenseConnectorsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The notificationMessageTemplates property</summary>
        public NotificationMessageTemplatesRequestBuilder NotificationMessageTemplates { get =>
            new NotificationMessageTemplatesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The remoteAssistancePartners property</summary>
        public RemoteAssistancePartnersRequestBuilder RemoteAssistancePartners { get =>
            new RemoteAssistancePartnersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The reports property</summary>
        public ReportsRequestBuilder Reports { get =>
            new ReportsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>The resourceOperations property</summary>
        public ResourceOperationsRequestBuilder ResourceOperations { get =>
            new ResourceOperationsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The roleAssignments property</summary>
        public RoleAssignmentsRequestBuilder RoleAssignments { get =>
            new RoleAssignmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The roleDefinitions property</summary>
        public RoleDefinitionsRequestBuilder RoleDefinitions { get =>
            new RoleDefinitionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The softwareUpdateStatusSummary property</summary>
        public SoftwareUpdateStatusSummaryRequestBuilder SoftwareUpdateStatusSummary { get =>
            new SoftwareUpdateStatusSummaryRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The telecomExpenseManagementPartners property</summary>
        public TelecomExpenseManagementPartnersRequestBuilder TelecomExpenseManagementPartners { get =>
            new TelecomExpenseManagementPartnersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The termsAndConditions property</summary>
        public TermsAndConditionsRequestBuilder TermsAndConditions { get =>
            new TermsAndConditionsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The troubleshootingEvents property</summary>
        public TroubleshootingEventsRequestBuilder TroubleshootingEvents { get =>
            new TroubleshootingEventsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>The windowsAutopilotDeviceIdentities property</summary>
        public WindowsAutopilotDeviceIdentitiesRequestBuilder WindowsAutopilotDeviceIdentities { get =>
            new WindowsAutopilotDeviceIdentitiesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The windowsInformationProtectionAppLearningSummaries property</summary>
        public WindowsInformationProtectionAppLearningSummariesRequestBuilder WindowsInformationProtectionAppLearningSummaries { get =>
            new WindowsInformationProtectionAppLearningSummariesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The windowsInformationProtectionNetworkLearningSummaries property</summary>
        public WindowsInformationProtectionNetworkLearningSummariesRequestBuilder WindowsInformationProtectionNetworkLearningSummaries { get =>
            new WindowsInformationProtectionNetworkLearningSummariesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new DeviceManagementRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public DeviceManagementRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/deviceManagement{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new DeviceManagementRequestBuilder and sets the default values.
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public DeviceManagementRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/deviceManagement{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>();
            urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Get deviceManagement
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<DeviceManagementRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new DeviceManagementRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update deviceManagement
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(Microsoft.Graph.Models.DeviceManagement body, Action<DeviceManagementRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new DeviceManagementRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Get deviceManagement
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<Microsoft.Graph.Models.DeviceManagement> GetAsync(Action<DeviceManagementRequestBuilderGetRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Microsoft.Graph.Models.DeviceManagement>(requestInfo, Microsoft.Graph.Models.DeviceManagement.CreateFromDiscriminatorValue, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Provides operations to call the getEffectivePermissions method.
        /// <param name="scope">Usage: scope=&apos;{scope}&apos;</param>
        /// </summary>
        public GetEffectivePermissionsWithScopeRequestBuilder GetEffectivePermissionsWithScope(string scope) {
            if(string.IsNullOrEmpty(scope)) throw new ArgumentNullException(nameof(scope));
            return new GetEffectivePermissionsWithScopeRequestBuilder(PathParameters, RequestAdapter, scope);
        }
        /// <summary>
        /// Update deviceManagement
        /// <param name="body"></param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<Microsoft.Graph.Models.DeviceManagement> PatchAsync(Microsoft.Graph.Models.DeviceManagement body, Action<DeviceManagementRequestBuilderPatchRequestConfiguration> requestConfiguration = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = CreatePatchRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"4XX", ODataError.CreateFromDiscriminatorValue},
                {"5XX", ODataError.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<Microsoft.Graph.Models.DeviceManagement>(requestInfo, Microsoft.Graph.Models.DeviceManagement.CreateFromDiscriminatorValue, responseHandler, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Provides operations to call the verifyWindowsEnrollmentAutoDiscovery method.
        /// <param name="domainName">Usage: domainName=&apos;{domainName}&apos;</param>
        /// </summary>
        public VerifyWindowsEnrollmentAutoDiscoveryWithDomainNameRequestBuilder VerifyWindowsEnrollmentAutoDiscoveryWithDomainName(string domainName) {
            if(string.IsNullOrEmpty(domainName)) throw new ArgumentNullException(nameof(domainName));
            return new VerifyWindowsEnrollmentAutoDiscoveryWithDomainNameRequestBuilder(PathParameters, RequestAdapter, domainName);
        }
        /// <summary>Get deviceManagement</summary>
        public class DeviceManagementRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class DeviceManagementRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public DeviceManagementRequestBuilderGetQueryParameters QueryParameters { get; set; } = new DeviceManagementRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new deviceManagementRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public DeviceManagementRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class DeviceManagementRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new deviceManagementRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public DeviceManagementRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
