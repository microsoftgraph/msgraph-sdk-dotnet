using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class DeviceManagement : Entity, IParsable {
        /// <summary>Apple push notification certificate.</summary>
        public Microsoft.Graph.Models.ApplePushNotificationCertificate ApplePushNotificationCertificate {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ApplePushNotificationCertificate>("applePushNotificationCertificate"); }
            set { BackingStore?.Set("applePushNotificationCertificate", value); }
        }
        /// <summary>The list of Compliance Management Partners configured by the tenant.</summary>
        public List<ComplianceManagementPartner> ComplianceManagementPartners {
            get { return BackingStore?.Get<List<ComplianceManagementPartner>>("complianceManagementPartners"); }
            set { BackingStore?.Set("complianceManagementPartners", value); }
        }
        /// <summary>The Exchange on premises conditional access settings. On premises conditional access will require devices to be both enrolled and compliant for mail access</summary>
        public OnPremisesConditionalAccessSettings ConditionalAccessSettings {
            get { return BackingStore?.Get<OnPremisesConditionalAccessSettings>("conditionalAccessSettings"); }
            set { BackingStore?.Set("conditionalAccessSettings", value); }
        }
        /// <summary>The list of detected apps associated with a device.</summary>
        public List<DetectedApp> DetectedApps {
            get { return BackingStore?.Get<List<DetectedApp>>("detectedApps"); }
            set { BackingStore?.Set("detectedApps", value); }
        }
        /// <summary>The list of device categories with the tenant.</summary>
        public List<DeviceCategory> DeviceCategories {
            get { return BackingStore?.Get<List<DeviceCategory>>("deviceCategories"); }
            set { BackingStore?.Set("deviceCategories", value); }
        }
        /// <summary>The device compliance policies.</summary>
        public List<DeviceCompliancePolicy> DeviceCompliancePolicies {
            get { return BackingStore?.Get<List<DeviceCompliancePolicy>>("deviceCompliancePolicies"); }
            set { BackingStore?.Set("deviceCompliancePolicies", value); }
        }
        /// <summary>The device compliance state summary for this account.</summary>
        public Microsoft.Graph.Models.DeviceCompliancePolicyDeviceStateSummary DeviceCompliancePolicyDeviceStateSummary {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DeviceCompliancePolicyDeviceStateSummary>("deviceCompliancePolicyDeviceStateSummary"); }
            set { BackingStore?.Set("deviceCompliancePolicyDeviceStateSummary", value); }
        }
        /// <summary>The summary states of compliance policy settings for this account.</summary>
        public List<DeviceCompliancePolicySettingStateSummary> DeviceCompliancePolicySettingStateSummaries {
            get { return BackingStore?.Get<List<DeviceCompliancePolicySettingStateSummary>>("deviceCompliancePolicySettingStateSummaries"); }
            set { BackingStore?.Set("deviceCompliancePolicySettingStateSummaries", value); }
        }
        /// <summary>The device configuration device state summary for this account.</summary>
        public DeviceConfigurationDeviceStateSummary DeviceConfigurationDeviceStateSummaries {
            get { return BackingStore?.Get<DeviceConfigurationDeviceStateSummary>("deviceConfigurationDeviceStateSummaries"); }
            set { BackingStore?.Set("deviceConfigurationDeviceStateSummaries", value); }
        }
        /// <summary>The device configurations.</summary>
        public List<DeviceConfiguration> DeviceConfigurations {
            get { return BackingStore?.Get<List<DeviceConfiguration>>("deviceConfigurations"); }
            set { BackingStore?.Set("deviceConfigurations", value); }
        }
        /// <summary>The list of device enrollment configurations</summary>
        public List<DeviceEnrollmentConfiguration> DeviceEnrollmentConfigurations {
            get { return BackingStore?.Get<List<DeviceEnrollmentConfiguration>>("deviceEnrollmentConfigurations"); }
            set { BackingStore?.Set("deviceEnrollmentConfigurations", value); }
        }
        /// <summary>The list of Device Management Partners configured by the tenant.</summary>
        public List<DeviceManagementPartner> DeviceManagementPartners {
            get { return BackingStore?.Get<List<DeviceManagementPartner>>("deviceManagementPartners"); }
            set { BackingStore?.Set("deviceManagementPartners", value); }
        }
        /// <summary>The list of Exchange Connectors configured by the tenant.</summary>
        public List<DeviceManagementExchangeConnector> ExchangeConnectors {
            get { return BackingStore?.Get<List<DeviceManagementExchangeConnector>>("exchangeConnectors"); }
            set { BackingStore?.Set("exchangeConnectors", value); }
        }
        /// <summary>Collection of imported Windows autopilot devices.</summary>
        public List<ImportedWindowsAutopilotDeviceIdentity> ImportedWindowsAutopilotDeviceIdentities {
            get { return BackingStore?.Get<List<ImportedWindowsAutopilotDeviceIdentity>>("importedWindowsAutopilotDeviceIdentities"); }
            set { BackingStore?.Set("importedWindowsAutopilotDeviceIdentities", value); }
        }
        /// <summary>Intune Account ID for given tenant</summary>
        public string IntuneAccountId {
            get { return BackingStore?.Get<string>("intuneAccountId"); }
            set { BackingStore?.Set("intuneAccountId", value); }
        }
        /// <summary>intuneBrand contains data which is used in customizing the appearance of the Company Portal applications as well as the end user web portal.</summary>
        public Microsoft.Graph.Models.IntuneBrand IntuneBrand {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IntuneBrand>("intuneBrand"); }
            set { BackingStore?.Set("intuneBrand", value); }
        }
        /// <summary>The IOS software update installation statuses for this account.</summary>
        public List<IosUpdateDeviceStatus> IosUpdateStatuses {
            get { return BackingStore?.Get<List<IosUpdateDeviceStatus>>("iosUpdateStatuses"); }
            set { BackingStore?.Set("iosUpdateStatuses", value); }
        }
        /// <summary>Device overview</summary>
        public Microsoft.Graph.Models.ManagedDeviceOverview ManagedDeviceOverview {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ManagedDeviceOverview>("managedDeviceOverview"); }
            set { BackingStore?.Set("managedDeviceOverview", value); }
        }
        /// <summary>The list of managed devices.</summary>
        public List<ManagedDevice> ManagedDevices {
            get { return BackingStore?.Get<List<ManagedDevice>>("managedDevices"); }
            set { BackingStore?.Set("managedDevices", value); }
        }
        /// <summary>The list of Mobile threat Defense connectors configured by the tenant.</summary>
        public List<MobileThreatDefenseConnector> MobileThreatDefenseConnectors {
            get { return BackingStore?.Get<List<MobileThreatDefenseConnector>>("mobileThreatDefenseConnectors"); }
            set { BackingStore?.Set("mobileThreatDefenseConnectors", value); }
        }
        /// <summary>The Notification Message Templates.</summary>
        public List<NotificationMessageTemplate> NotificationMessageTemplates {
            get { return BackingStore?.Get<List<NotificationMessageTemplate>>("notificationMessageTemplates"); }
            set { BackingStore?.Set("notificationMessageTemplates", value); }
        }
        /// <summary>The remote assist partners.</summary>
        public List<RemoteAssistancePartner> RemoteAssistancePartners {
            get { return BackingStore?.Get<List<RemoteAssistancePartner>>("remoteAssistancePartners"); }
            set { BackingStore?.Set("remoteAssistancePartners", value); }
        }
        /// <summary>Reports singleton</summary>
        public DeviceManagementReports Reports {
            get { return BackingStore?.Get<DeviceManagementReports>("reports"); }
            set { BackingStore?.Set("reports", value); }
        }
        /// <summary>The Resource Operations.</summary>
        public List<ResourceOperation> ResourceOperations {
            get { return BackingStore?.Get<List<ResourceOperation>>("resourceOperations"); }
            set { BackingStore?.Set("resourceOperations", value); }
        }
        /// <summary>The Role Assignments.</summary>
        public List<DeviceAndAppManagementRoleAssignment> RoleAssignments {
            get { return BackingStore?.Get<List<DeviceAndAppManagementRoleAssignment>>("roleAssignments"); }
            set { BackingStore?.Set("roleAssignments", value); }
        }
        /// <summary>The Role Definitions.</summary>
        public List<RoleDefinition> RoleDefinitions {
            get { return BackingStore?.Get<List<RoleDefinition>>("roleDefinitions"); }
            set { BackingStore?.Set("roleDefinitions", value); }
        }
        /// <summary>Account level settings.</summary>
        public DeviceManagementSettings Settings {
            get { return BackingStore?.Get<DeviceManagementSettings>("settings"); }
            set { BackingStore?.Set("settings", value); }
        }
        /// <summary>The software update status summary.</summary>
        public Microsoft.Graph.Models.SoftwareUpdateStatusSummary SoftwareUpdateStatusSummary {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SoftwareUpdateStatusSummary>("softwareUpdateStatusSummary"); }
            set { BackingStore?.Set("softwareUpdateStatusSummary", value); }
        }
        /// <summary>Tenant mobile device management subscription state.</summary>
        public DeviceManagementSubscriptionState? SubscriptionState {
            get { return BackingStore?.Get<DeviceManagementSubscriptionState?>("subscriptionState"); }
            set { BackingStore?.Set("subscriptionState", value); }
        }
        /// <summary>The telecom expense management partners.</summary>
        public List<TelecomExpenseManagementPartner> TelecomExpenseManagementPartners {
            get { return BackingStore?.Get<List<TelecomExpenseManagementPartner>>("telecomExpenseManagementPartners"); }
            set { BackingStore?.Set("telecomExpenseManagementPartners", value); }
        }
        /// <summary>The terms and conditions associated with device management of the company.</summary>
        public List<Microsoft.Graph.Models.TermsAndConditions> TermsAndConditions {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.TermsAndConditions>>("termsAndConditions"); }
            set { BackingStore?.Set("termsAndConditions", value); }
        }
        /// <summary>The list of troubleshooting events for the tenant.</summary>
        public List<DeviceManagementTroubleshootingEvent> TroubleshootingEvents {
            get { return BackingStore?.Get<List<DeviceManagementTroubleshootingEvent>>("troubleshootingEvents"); }
            set { BackingStore?.Set("troubleshootingEvents", value); }
        }
        /// <summary>The Windows autopilot device identities contained collection.</summary>
        public List<WindowsAutopilotDeviceIdentity> WindowsAutopilotDeviceIdentities {
            get { return BackingStore?.Get<List<WindowsAutopilotDeviceIdentity>>("windowsAutopilotDeviceIdentities"); }
            set { BackingStore?.Set("windowsAutopilotDeviceIdentities", value); }
        }
        /// <summary>The windows information protection app learning summaries.</summary>
        public List<WindowsInformationProtectionAppLearningSummary> WindowsInformationProtectionAppLearningSummaries {
            get { return BackingStore?.Get<List<WindowsInformationProtectionAppLearningSummary>>("windowsInformationProtectionAppLearningSummaries"); }
            set { BackingStore?.Set("windowsInformationProtectionAppLearningSummaries", value); }
        }
        /// <summary>The windows information protection network learning summaries.</summary>
        public List<WindowsInformationProtectionNetworkLearningSummary> WindowsInformationProtectionNetworkLearningSummaries {
            get { return BackingStore?.Get<List<WindowsInformationProtectionNetworkLearningSummary>>("windowsInformationProtectionNetworkLearningSummaries"); }
            set { BackingStore?.Set("windowsInformationProtectionNetworkLearningSummaries", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceManagement CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceManagement();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"applePushNotificationCertificate", n => { ApplePushNotificationCertificate = n.GetObjectValue<Microsoft.Graph.Models.ApplePushNotificationCertificate>(Microsoft.Graph.Models.ApplePushNotificationCertificate.CreateFromDiscriminatorValue); } },
                {"complianceManagementPartners", n => { ComplianceManagementPartners = n.GetCollectionOfObjectValues<ComplianceManagementPartner>(ComplianceManagementPartner.CreateFromDiscriminatorValue).ToList(); } },
                {"conditionalAccessSettings", n => { ConditionalAccessSettings = n.GetObjectValue<OnPremisesConditionalAccessSettings>(OnPremisesConditionalAccessSettings.CreateFromDiscriminatorValue); } },
                {"detectedApps", n => { DetectedApps = n.GetCollectionOfObjectValues<DetectedApp>(DetectedApp.CreateFromDiscriminatorValue).ToList(); } },
                {"deviceCategories", n => { DeviceCategories = n.GetCollectionOfObjectValues<DeviceCategory>(DeviceCategory.CreateFromDiscriminatorValue).ToList(); } },
                {"deviceCompliancePolicies", n => { DeviceCompliancePolicies = n.GetCollectionOfObjectValues<DeviceCompliancePolicy>(DeviceCompliancePolicy.CreateFromDiscriminatorValue).ToList(); } },
                {"deviceCompliancePolicyDeviceStateSummary", n => { DeviceCompliancePolicyDeviceStateSummary = n.GetObjectValue<Microsoft.Graph.Models.DeviceCompliancePolicyDeviceStateSummary>(Microsoft.Graph.Models.DeviceCompliancePolicyDeviceStateSummary.CreateFromDiscriminatorValue); } },
                {"deviceCompliancePolicySettingStateSummaries", n => { DeviceCompliancePolicySettingStateSummaries = n.GetCollectionOfObjectValues<DeviceCompliancePolicySettingStateSummary>(DeviceCompliancePolicySettingStateSummary.CreateFromDiscriminatorValue).ToList(); } },
                {"deviceConfigurationDeviceStateSummaries", n => { DeviceConfigurationDeviceStateSummaries = n.GetObjectValue<DeviceConfigurationDeviceStateSummary>(DeviceConfigurationDeviceStateSummary.CreateFromDiscriminatorValue); } },
                {"deviceConfigurations", n => { DeviceConfigurations = n.GetCollectionOfObjectValues<DeviceConfiguration>(DeviceConfiguration.CreateFromDiscriminatorValue).ToList(); } },
                {"deviceEnrollmentConfigurations", n => { DeviceEnrollmentConfigurations = n.GetCollectionOfObjectValues<DeviceEnrollmentConfiguration>(DeviceEnrollmentConfiguration.CreateFromDiscriminatorValue).ToList(); } },
                {"deviceManagementPartners", n => { DeviceManagementPartners = n.GetCollectionOfObjectValues<DeviceManagementPartner>(DeviceManagementPartner.CreateFromDiscriminatorValue).ToList(); } },
                {"exchangeConnectors", n => { ExchangeConnectors = n.GetCollectionOfObjectValues<DeviceManagementExchangeConnector>(DeviceManagementExchangeConnector.CreateFromDiscriminatorValue).ToList(); } },
                {"importedWindowsAutopilotDeviceIdentities", n => { ImportedWindowsAutopilotDeviceIdentities = n.GetCollectionOfObjectValues<ImportedWindowsAutopilotDeviceIdentity>(ImportedWindowsAutopilotDeviceIdentity.CreateFromDiscriminatorValue).ToList(); } },
                {"intuneAccountId", n => { IntuneAccountId = n.GetStringValue(); } },
                {"intuneBrand", n => { IntuneBrand = n.GetObjectValue<Microsoft.Graph.Models.IntuneBrand>(Microsoft.Graph.Models.IntuneBrand.CreateFromDiscriminatorValue); } },
                {"iosUpdateStatuses", n => { IosUpdateStatuses = n.GetCollectionOfObjectValues<IosUpdateDeviceStatus>(IosUpdateDeviceStatus.CreateFromDiscriminatorValue).ToList(); } },
                {"managedDeviceOverview", n => { ManagedDeviceOverview = n.GetObjectValue<Microsoft.Graph.Models.ManagedDeviceOverview>(Microsoft.Graph.Models.ManagedDeviceOverview.CreateFromDiscriminatorValue); } },
                {"managedDevices", n => { ManagedDevices = n.GetCollectionOfObjectValues<ManagedDevice>(ManagedDevice.CreateFromDiscriminatorValue).ToList(); } },
                {"mobileThreatDefenseConnectors", n => { MobileThreatDefenseConnectors = n.GetCollectionOfObjectValues<MobileThreatDefenseConnector>(MobileThreatDefenseConnector.CreateFromDiscriminatorValue).ToList(); } },
                {"notificationMessageTemplates", n => { NotificationMessageTemplates = n.GetCollectionOfObjectValues<NotificationMessageTemplate>(NotificationMessageTemplate.CreateFromDiscriminatorValue).ToList(); } },
                {"remoteAssistancePartners", n => { RemoteAssistancePartners = n.GetCollectionOfObjectValues<RemoteAssistancePartner>(RemoteAssistancePartner.CreateFromDiscriminatorValue).ToList(); } },
                {"reports", n => { Reports = n.GetObjectValue<DeviceManagementReports>(DeviceManagementReports.CreateFromDiscriminatorValue); } },
                {"resourceOperations", n => { ResourceOperations = n.GetCollectionOfObjectValues<ResourceOperation>(ResourceOperation.CreateFromDiscriminatorValue).ToList(); } },
                {"roleAssignments", n => { RoleAssignments = n.GetCollectionOfObjectValues<DeviceAndAppManagementRoleAssignment>(DeviceAndAppManagementRoleAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"roleDefinitions", n => { RoleDefinitions = n.GetCollectionOfObjectValues<RoleDefinition>(RoleDefinition.CreateFromDiscriminatorValue).ToList(); } },
                {"settings", n => { Settings = n.GetObjectValue<DeviceManagementSettings>(DeviceManagementSettings.CreateFromDiscriminatorValue); } },
                {"softwareUpdateStatusSummary", n => { SoftwareUpdateStatusSummary = n.GetObjectValue<Microsoft.Graph.Models.SoftwareUpdateStatusSummary>(Microsoft.Graph.Models.SoftwareUpdateStatusSummary.CreateFromDiscriminatorValue); } },
                {"subscriptionState", n => { SubscriptionState = n.GetEnumValue<DeviceManagementSubscriptionState>(); } },
                {"telecomExpenseManagementPartners", n => { TelecomExpenseManagementPartners = n.GetCollectionOfObjectValues<TelecomExpenseManagementPartner>(TelecomExpenseManagementPartner.CreateFromDiscriminatorValue).ToList(); } },
                {"termsAndConditions", n => { TermsAndConditions = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.TermsAndConditions>(Microsoft.Graph.Models.TermsAndConditions.CreateFromDiscriminatorValue).ToList(); } },
                {"troubleshootingEvents", n => { TroubleshootingEvents = n.GetCollectionOfObjectValues<DeviceManagementTroubleshootingEvent>(DeviceManagementTroubleshootingEvent.CreateFromDiscriminatorValue).ToList(); } },
                {"windowsAutopilotDeviceIdentities", n => { WindowsAutopilotDeviceIdentities = n.GetCollectionOfObjectValues<WindowsAutopilotDeviceIdentity>(WindowsAutopilotDeviceIdentity.CreateFromDiscriminatorValue).ToList(); } },
                {"windowsInformationProtectionAppLearningSummaries", n => { WindowsInformationProtectionAppLearningSummaries = n.GetCollectionOfObjectValues<WindowsInformationProtectionAppLearningSummary>(WindowsInformationProtectionAppLearningSummary.CreateFromDiscriminatorValue).ToList(); } },
                {"windowsInformationProtectionNetworkLearningSummaries", n => { WindowsInformationProtectionNetworkLearningSummaries = n.GetCollectionOfObjectValues<WindowsInformationProtectionNetworkLearningSummary>(WindowsInformationProtectionNetworkLearningSummary.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.ApplePushNotificationCertificate>("applePushNotificationCertificate", ApplePushNotificationCertificate);
            writer.WriteCollectionOfObjectValues<ComplianceManagementPartner>("complianceManagementPartners", ComplianceManagementPartners);
            writer.WriteObjectValue<OnPremisesConditionalAccessSettings>("conditionalAccessSettings", ConditionalAccessSettings);
            writer.WriteCollectionOfObjectValues<DetectedApp>("detectedApps", DetectedApps);
            writer.WriteCollectionOfObjectValues<DeviceCategory>("deviceCategories", DeviceCategories);
            writer.WriteCollectionOfObjectValues<DeviceCompliancePolicy>("deviceCompliancePolicies", DeviceCompliancePolicies);
            writer.WriteObjectValue<Microsoft.Graph.Models.DeviceCompliancePolicyDeviceStateSummary>("deviceCompliancePolicyDeviceStateSummary", DeviceCompliancePolicyDeviceStateSummary);
            writer.WriteCollectionOfObjectValues<DeviceCompliancePolicySettingStateSummary>("deviceCompliancePolicySettingStateSummaries", DeviceCompliancePolicySettingStateSummaries);
            writer.WriteObjectValue<DeviceConfigurationDeviceStateSummary>("deviceConfigurationDeviceStateSummaries", DeviceConfigurationDeviceStateSummaries);
            writer.WriteCollectionOfObjectValues<DeviceConfiguration>("deviceConfigurations", DeviceConfigurations);
            writer.WriteCollectionOfObjectValues<DeviceEnrollmentConfiguration>("deviceEnrollmentConfigurations", DeviceEnrollmentConfigurations);
            writer.WriteCollectionOfObjectValues<DeviceManagementPartner>("deviceManagementPartners", DeviceManagementPartners);
            writer.WriteCollectionOfObjectValues<DeviceManagementExchangeConnector>("exchangeConnectors", ExchangeConnectors);
            writer.WriteCollectionOfObjectValues<ImportedWindowsAutopilotDeviceIdentity>("importedWindowsAutopilotDeviceIdentities", ImportedWindowsAutopilotDeviceIdentities);
            writer.WriteStringValue("intuneAccountId", IntuneAccountId);
            writer.WriteObjectValue<Microsoft.Graph.Models.IntuneBrand>("intuneBrand", IntuneBrand);
            writer.WriteCollectionOfObjectValues<IosUpdateDeviceStatus>("iosUpdateStatuses", IosUpdateStatuses);
            writer.WriteObjectValue<Microsoft.Graph.Models.ManagedDeviceOverview>("managedDeviceOverview", ManagedDeviceOverview);
            writer.WriteCollectionOfObjectValues<ManagedDevice>("managedDevices", ManagedDevices);
            writer.WriteCollectionOfObjectValues<MobileThreatDefenseConnector>("mobileThreatDefenseConnectors", MobileThreatDefenseConnectors);
            writer.WriteCollectionOfObjectValues<NotificationMessageTemplate>("notificationMessageTemplates", NotificationMessageTemplates);
            writer.WriteCollectionOfObjectValues<RemoteAssistancePartner>("remoteAssistancePartners", RemoteAssistancePartners);
            writer.WriteObjectValue<DeviceManagementReports>("reports", Reports);
            writer.WriteCollectionOfObjectValues<ResourceOperation>("resourceOperations", ResourceOperations);
            writer.WriteCollectionOfObjectValues<DeviceAndAppManagementRoleAssignment>("roleAssignments", RoleAssignments);
            writer.WriteCollectionOfObjectValues<RoleDefinition>("roleDefinitions", RoleDefinitions);
            writer.WriteObjectValue<DeviceManagementSettings>("settings", Settings);
            writer.WriteObjectValue<Microsoft.Graph.Models.SoftwareUpdateStatusSummary>("softwareUpdateStatusSummary", SoftwareUpdateStatusSummary);
            writer.WriteEnumValue<DeviceManagementSubscriptionState>("subscriptionState", SubscriptionState);
            writer.WriteCollectionOfObjectValues<TelecomExpenseManagementPartner>("telecomExpenseManagementPartners", TelecomExpenseManagementPartners);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.TermsAndConditions>("termsAndConditions", TermsAndConditions);
            writer.WriteCollectionOfObjectValues<DeviceManagementTroubleshootingEvent>("troubleshootingEvents", TroubleshootingEvents);
            writer.WriteCollectionOfObjectValues<WindowsAutopilotDeviceIdentity>("windowsAutopilotDeviceIdentities", WindowsAutopilotDeviceIdentities);
            writer.WriteCollectionOfObjectValues<WindowsInformationProtectionAppLearningSummary>("windowsInformationProtectionAppLearningSummaries", WindowsInformationProtectionAppLearningSummaries);
            writer.WriteCollectionOfObjectValues<WindowsInformationProtectionNetworkLearningSummary>("windowsInformationProtectionNetworkLearningSummaries", WindowsInformationProtectionNetworkLearningSummaries);
        }
    }
}
