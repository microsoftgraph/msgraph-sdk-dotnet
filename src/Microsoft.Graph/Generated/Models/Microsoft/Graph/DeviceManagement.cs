using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class DeviceManagement : Entity, IParsable {
        /// <summary>Apple push notification certificate.</summary>
        public ApplePushNotificationCertificate ApplePushNotificationCertificate { get; set; }
        /// <summary>The list of Compliance Management Partners configured by the tenant.</summary>
        public List<ComplianceManagementPartner> ComplianceManagementPartners { get; set; }
        /// <summary>The Exchange on premises conditional access settings. On premises conditional access will require devices to be both enrolled and compliant for mail access</summary>
        public OnPremisesConditionalAccessSettings ConditionalAccessSettings { get; set; }
        /// <summary>The list of detected apps associated with a device.</summary>
        public List<DetectedApp> DetectedApps { get; set; }
        /// <summary>The list of device categories with the tenant.</summary>
        public List<DeviceCategory> DeviceCategories { get; set; }
        /// <summary>The device compliance policies.</summary>
        public List<DeviceCompliancePolicy> DeviceCompliancePolicies { get; set; }
        /// <summary>The device compliance state summary for this account.</summary>
        public DeviceCompliancePolicyDeviceStateSummary DeviceCompliancePolicyDeviceStateSummary { get; set; }
        /// <summary>The summary states of compliance policy settings for this account.</summary>
        public List<DeviceCompliancePolicySettingStateSummary> DeviceCompliancePolicySettingStateSummaries { get; set; }
        /// <summary>The device configuration device state summary for this account.</summary>
        public DeviceConfigurationDeviceStateSummary DeviceConfigurationDeviceStateSummaries { get; set; }
        /// <summary>The device configurations.</summary>
        public List<DeviceConfiguration> DeviceConfigurations { get; set; }
        /// <summary>The list of device enrollment configurations</summary>
        public List<DeviceEnrollmentConfiguration> DeviceEnrollmentConfigurations { get; set; }
        /// <summary>The list of Device Management Partners configured by the tenant.</summary>
        public List<DeviceManagementPartner> DeviceManagementPartners { get; set; }
        /// <summary>The list of Exchange Connectors configured by the tenant.</summary>
        public List<DeviceManagementExchangeConnector> ExchangeConnectors { get; set; }
        /// <summary>Collection of imported Windows autopilot devices.</summary>
        public List<ImportedWindowsAutopilotDeviceIdentity> ImportedWindowsAutopilotDeviceIdentities { get; set; }
        /// <summary>Intune Account Id for given tenant</summary>
        public string IntuneAccountId { get; set; }
        /// <summary>intuneBrand contains data which is used in customizing the appearance of the Company Portal applications as well as the end user web portal.</summary>
        public IntuneBrand IntuneBrand { get; set; }
        /// <summary>The IOS software update installation statuses for this account.</summary>
        public List<IosUpdateDeviceStatus> IosUpdateStatuses { get; set; }
        /// <summary>Device overview</summary>
        public ManagedDeviceOverview ManagedDeviceOverview { get; set; }
        /// <summary>The list of managed devices.</summary>
        public List<ManagedDevice> ManagedDevices { get; set; }
        /// <summary>The list of Mobile threat Defense connectors configured by the tenant.</summary>
        public List<MobileThreatDefenseConnector> MobileThreatDefenseConnectors { get; set; }
        /// <summary>The Notification Message Templates.</summary>
        public List<NotificationMessageTemplate> NotificationMessageTemplates { get; set; }
        /// <summary>The remote assist partners.</summary>
        public List<RemoteAssistancePartner> RemoteAssistancePartners { get; set; }
        /// <summary>Reports singleton</summary>
        public DeviceManagementReports Reports { get; set; }
        /// <summary>The Resource Operations.</summary>
        public List<ResourceOperation> ResourceOperations { get; set; }
        /// <summary>The Role Assignments.</summary>
        public List<DeviceAndAppManagementRoleAssignment> RoleAssignments { get; set; }
        /// <summary>The Role Definitions.</summary>
        public List<RoleDefinition> RoleDefinitions { get; set; }
        /// <summary>Account level settings.</summary>
        public DeviceManagementSettings Settings { get; set; }
        /// <summary>The software update status summary.</summary>
        public SoftwareUpdateStatusSummary SoftwareUpdateStatusSummary { get; set; }
        /// <summary>Tenant mobile device management subscription state. Possible values are: pending, active, warning, disabled, deleted, blocked, lockedOut.</summary>
        public DeviceManagementSubscriptionState? SubscriptionState { get; set; }
        /// <summary>The telecom expense management partners.</summary>
        public List<TelecomExpenseManagementPartner> TelecomExpenseManagementPartners { get; set; }
        /// <summary>The terms and conditions associated with device management of the company.</summary>
        public List<TermsAndConditions> TermsAndConditions { get; set; }
        /// <summary>The list of troubleshooting events for the tenant.</summary>
        public List<DeviceManagementTroubleshootingEvent> TroubleshootingEvents { get; set; }
        /// <summary>The Windows autopilot device identities contained collection.</summary>
        public List<WindowsAutopilotDeviceIdentity> WindowsAutopilotDeviceIdentities { get; set; }
        /// <summary>The windows information protection app learning summaries.</summary>
        public List<WindowsInformationProtectionAppLearningSummary> WindowsInformationProtectionAppLearningSummaries { get; set; }
        /// <summary>The windows information protection network learning summaries.</summary>
        public List<WindowsInformationProtectionNetworkLearningSummary> WindowsInformationProtectionNetworkLearningSummaries { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"applePushNotificationCertificate", (o,n) => { (o as DeviceManagement).ApplePushNotificationCertificate = n.GetObjectValue<ApplePushNotificationCertificate>(); } },
                {"complianceManagementPartners", (o,n) => { (o as DeviceManagement).ComplianceManagementPartners = n.GetCollectionOfObjectValues<ComplianceManagementPartner>().ToList(); } },
                {"conditionalAccessSettings", (o,n) => { (o as DeviceManagement).ConditionalAccessSettings = n.GetObjectValue<OnPremisesConditionalAccessSettings>(); } },
                {"detectedApps", (o,n) => { (o as DeviceManagement).DetectedApps = n.GetCollectionOfObjectValues<DetectedApp>().ToList(); } },
                {"deviceCategories", (o,n) => { (o as DeviceManagement).DeviceCategories = n.GetCollectionOfObjectValues<DeviceCategory>().ToList(); } },
                {"deviceCompliancePolicies", (o,n) => { (o as DeviceManagement).DeviceCompliancePolicies = n.GetCollectionOfObjectValues<DeviceCompliancePolicy>().ToList(); } },
                {"deviceCompliancePolicyDeviceStateSummary", (o,n) => { (o as DeviceManagement).DeviceCompliancePolicyDeviceStateSummary = n.GetObjectValue<DeviceCompliancePolicyDeviceStateSummary>(); } },
                {"deviceCompliancePolicySettingStateSummaries", (o,n) => { (o as DeviceManagement).DeviceCompliancePolicySettingStateSummaries = n.GetCollectionOfObjectValues<DeviceCompliancePolicySettingStateSummary>().ToList(); } },
                {"deviceConfigurationDeviceStateSummaries", (o,n) => { (o as DeviceManagement).DeviceConfigurationDeviceStateSummaries = n.GetObjectValue<DeviceConfigurationDeviceStateSummary>(); } },
                {"deviceConfigurations", (o,n) => { (o as DeviceManagement).DeviceConfigurations = n.GetCollectionOfObjectValues<DeviceConfiguration>().ToList(); } },
                {"deviceEnrollmentConfigurations", (o,n) => { (o as DeviceManagement).DeviceEnrollmentConfigurations = n.GetCollectionOfObjectValues<DeviceEnrollmentConfiguration>().ToList(); } },
                {"deviceManagementPartners", (o,n) => { (o as DeviceManagement).DeviceManagementPartners = n.GetCollectionOfObjectValues<DeviceManagementPartner>().ToList(); } },
                {"exchangeConnectors", (o,n) => { (o as DeviceManagement).ExchangeConnectors = n.GetCollectionOfObjectValues<DeviceManagementExchangeConnector>().ToList(); } },
                {"importedWindowsAutopilotDeviceIdentities", (o,n) => { (o as DeviceManagement).ImportedWindowsAutopilotDeviceIdentities = n.GetCollectionOfObjectValues<ImportedWindowsAutopilotDeviceIdentity>().ToList(); } },
                {"intuneAccountId", (o,n) => { (o as DeviceManagement).IntuneAccountId = n.GetStringValue(); } },
                {"intuneBrand", (o,n) => { (o as DeviceManagement).IntuneBrand = n.GetObjectValue<IntuneBrand>(); } },
                {"iosUpdateStatuses", (o,n) => { (o as DeviceManagement).IosUpdateStatuses = n.GetCollectionOfObjectValues<IosUpdateDeviceStatus>().ToList(); } },
                {"managedDeviceOverview", (o,n) => { (o as DeviceManagement).ManagedDeviceOverview = n.GetObjectValue<ManagedDeviceOverview>(); } },
                {"managedDevices", (o,n) => { (o as DeviceManagement).ManagedDevices = n.GetCollectionOfObjectValues<ManagedDevice>().ToList(); } },
                {"mobileThreatDefenseConnectors", (o,n) => { (o as DeviceManagement).MobileThreatDefenseConnectors = n.GetCollectionOfObjectValues<MobileThreatDefenseConnector>().ToList(); } },
                {"notificationMessageTemplates", (o,n) => { (o as DeviceManagement).NotificationMessageTemplates = n.GetCollectionOfObjectValues<NotificationMessageTemplate>().ToList(); } },
                {"remoteAssistancePartners", (o,n) => { (o as DeviceManagement).RemoteAssistancePartners = n.GetCollectionOfObjectValues<RemoteAssistancePartner>().ToList(); } },
                {"reports", (o,n) => { (o as DeviceManagement).Reports = n.GetObjectValue<DeviceManagementReports>(); } },
                {"resourceOperations", (o,n) => { (o as DeviceManagement).ResourceOperations = n.GetCollectionOfObjectValues<ResourceOperation>().ToList(); } },
                {"roleAssignments", (o,n) => { (o as DeviceManagement).RoleAssignments = n.GetCollectionOfObjectValues<DeviceAndAppManagementRoleAssignment>().ToList(); } },
                {"roleDefinitions", (o,n) => { (o as DeviceManagement).RoleDefinitions = n.GetCollectionOfObjectValues<RoleDefinition>().ToList(); } },
                {"settings", (o,n) => { (o as DeviceManagement).Settings = n.GetObjectValue<DeviceManagementSettings>(); } },
                {"softwareUpdateStatusSummary", (o,n) => { (o as DeviceManagement).SoftwareUpdateStatusSummary = n.GetObjectValue<SoftwareUpdateStatusSummary>(); } },
                {"subscriptionState", (o,n) => { (o as DeviceManagement).SubscriptionState = n.GetEnumValue<DeviceManagementSubscriptionState>(); } },
                {"telecomExpenseManagementPartners", (o,n) => { (o as DeviceManagement).TelecomExpenseManagementPartners = n.GetCollectionOfObjectValues<TelecomExpenseManagementPartner>().ToList(); } },
                {"termsAndConditions", (o,n) => { (o as DeviceManagement).TermsAndConditions = n.GetCollectionOfObjectValues<TermsAndConditions>().ToList(); } },
                {"troubleshootingEvents", (o,n) => { (o as DeviceManagement).TroubleshootingEvents = n.GetCollectionOfObjectValues<DeviceManagementTroubleshootingEvent>().ToList(); } },
                {"windowsAutopilotDeviceIdentities", (o,n) => { (o as DeviceManagement).WindowsAutopilotDeviceIdentities = n.GetCollectionOfObjectValues<WindowsAutopilotDeviceIdentity>().ToList(); } },
                {"windowsInformationProtectionAppLearningSummaries", (o,n) => { (o as DeviceManagement).WindowsInformationProtectionAppLearningSummaries = n.GetCollectionOfObjectValues<WindowsInformationProtectionAppLearningSummary>().ToList(); } },
                {"windowsInformationProtectionNetworkLearningSummaries", (o,n) => { (o as DeviceManagement).WindowsInformationProtectionNetworkLearningSummaries = n.GetCollectionOfObjectValues<WindowsInformationProtectionNetworkLearningSummary>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ApplePushNotificationCertificate>("applePushNotificationCertificate", ApplePushNotificationCertificate);
            writer.WriteCollectionOfObjectValues<ComplianceManagementPartner>("complianceManagementPartners", ComplianceManagementPartners);
            writer.WriteObjectValue<OnPremisesConditionalAccessSettings>("conditionalAccessSettings", ConditionalAccessSettings);
            writer.WriteCollectionOfObjectValues<DetectedApp>("detectedApps", DetectedApps);
            writer.WriteCollectionOfObjectValues<DeviceCategory>("deviceCategories", DeviceCategories);
            writer.WriteCollectionOfObjectValues<DeviceCompliancePolicy>("deviceCompliancePolicies", DeviceCompliancePolicies);
            writer.WriteObjectValue<DeviceCompliancePolicyDeviceStateSummary>("deviceCompliancePolicyDeviceStateSummary", DeviceCompliancePolicyDeviceStateSummary);
            writer.WriteCollectionOfObjectValues<DeviceCompliancePolicySettingStateSummary>("deviceCompliancePolicySettingStateSummaries", DeviceCompliancePolicySettingStateSummaries);
            writer.WriteObjectValue<DeviceConfigurationDeviceStateSummary>("deviceConfigurationDeviceStateSummaries", DeviceConfigurationDeviceStateSummaries);
            writer.WriteCollectionOfObjectValues<DeviceConfiguration>("deviceConfigurations", DeviceConfigurations);
            writer.WriteCollectionOfObjectValues<DeviceEnrollmentConfiguration>("deviceEnrollmentConfigurations", DeviceEnrollmentConfigurations);
            writer.WriteCollectionOfObjectValues<DeviceManagementPartner>("deviceManagementPartners", DeviceManagementPartners);
            writer.WriteCollectionOfObjectValues<DeviceManagementExchangeConnector>("exchangeConnectors", ExchangeConnectors);
            writer.WriteCollectionOfObjectValues<ImportedWindowsAutopilotDeviceIdentity>("importedWindowsAutopilotDeviceIdentities", ImportedWindowsAutopilotDeviceIdentities);
            writer.WriteStringValue("intuneAccountId", IntuneAccountId);
            writer.WriteObjectValue<IntuneBrand>("intuneBrand", IntuneBrand);
            writer.WriteCollectionOfObjectValues<IosUpdateDeviceStatus>("iosUpdateStatuses", IosUpdateStatuses);
            writer.WriteObjectValue<ManagedDeviceOverview>("managedDeviceOverview", ManagedDeviceOverview);
            writer.WriteCollectionOfObjectValues<ManagedDevice>("managedDevices", ManagedDevices);
            writer.WriteCollectionOfObjectValues<MobileThreatDefenseConnector>("mobileThreatDefenseConnectors", MobileThreatDefenseConnectors);
            writer.WriteCollectionOfObjectValues<NotificationMessageTemplate>("notificationMessageTemplates", NotificationMessageTemplates);
            writer.WriteCollectionOfObjectValues<RemoteAssistancePartner>("remoteAssistancePartners", RemoteAssistancePartners);
            writer.WriteObjectValue<DeviceManagementReports>("reports", Reports);
            writer.WriteCollectionOfObjectValues<ResourceOperation>("resourceOperations", ResourceOperations);
            writer.WriteCollectionOfObjectValues<DeviceAndAppManagementRoleAssignment>("roleAssignments", RoleAssignments);
            writer.WriteCollectionOfObjectValues<RoleDefinition>("roleDefinitions", RoleDefinitions);
            writer.WriteObjectValue<DeviceManagementSettings>("settings", Settings);
            writer.WriteObjectValue<SoftwareUpdateStatusSummary>("softwareUpdateStatusSummary", SoftwareUpdateStatusSummary);
            writer.WriteEnumValue<DeviceManagementSubscriptionState>("subscriptionState", SubscriptionState);
            writer.WriteCollectionOfObjectValues<TelecomExpenseManagementPartner>("telecomExpenseManagementPartners", TelecomExpenseManagementPartners);
            writer.WriteCollectionOfObjectValues<TermsAndConditions>("termsAndConditions", TermsAndConditions);
            writer.WriteCollectionOfObjectValues<DeviceManagementTroubleshootingEvent>("troubleshootingEvents", TroubleshootingEvents);
            writer.WriteCollectionOfObjectValues<WindowsAutopilotDeviceIdentity>("windowsAutopilotDeviceIdentities", WindowsAutopilotDeviceIdentities);
            writer.WriteCollectionOfObjectValues<WindowsInformationProtectionAppLearningSummary>("windowsInformationProtectionAppLearningSummaries", WindowsInformationProtectionAppLearningSummaries);
            writer.WriteCollectionOfObjectValues<WindowsInformationProtectionNetworkLearningSummary>("windowsInformationProtectionNetworkLearningSummaries", WindowsInformationProtectionNetworkLearningSummaries);
        }
    }
}
