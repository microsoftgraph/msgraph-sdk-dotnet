using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Devices that are managed or pre-enrolled through Intune</summary>
    public class ManagedDevice : Entity, IParsable {
        /// <summary>Code that allows the Activation Lock on a device to be bypassed. This property is read-only.</summary>
        public string ActivationLockBypassCode {
            get { return BackingStore?.Get<string>("activationLockBypassCode"); }
            set { BackingStore?.Set("activationLockBypassCode", value); }
        }
        /// <summary>Android security patch level. This property is read-only.</summary>
        public string AndroidSecurityPatchLevel {
            get { return BackingStore?.Get<string>("androidSecurityPatchLevel"); }
            set { BackingStore?.Set("androidSecurityPatchLevel", value); }
        }
        /// <summary>The unique identifier for the Azure Active Directory device. Read only. This property is read-only.</summary>
        public string AzureADDeviceId {
            get { return BackingStore?.Get<string>("azureADDeviceId"); }
            set { BackingStore?.Set("azureADDeviceId", value); }
        }
        /// <summary>Whether the device is Azure Active Directory registered. This property is read-only.</summary>
        public bool? AzureADRegistered {
            get { return BackingStore?.Get<bool?>("azureADRegistered"); }
            set { BackingStore?.Set("azureADRegistered", value); }
        }
        /// <summary>The DateTime when device compliance grace period expires. This property is read-only.</summary>
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("complianceGracePeriodExpirationDateTime"); }
            set { BackingStore?.Set("complianceGracePeriodExpirationDateTime", value); }
        }
        /// <summary>Compliance state.</summary>
        public Microsoft.Graph.Models.ComplianceState? ComplianceState {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ComplianceState?>("complianceState"); }
            set { BackingStore?.Set("complianceState", value); }
        }
        /// <summary>ConfigrMgr client enabled features. This property is read-only.</summary>
        public Microsoft.Graph.Models.ConfigurationManagerClientEnabledFeatures ConfigurationManagerClientEnabledFeatures {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ConfigurationManagerClientEnabledFeatures>("configurationManagerClientEnabledFeatures"); }
            set { BackingStore?.Set("configurationManagerClientEnabledFeatures", value); }
        }
        /// <summary>List of ComplexType deviceActionResult objects. This property is read-only.</summary>
        public List<DeviceActionResult> DeviceActionResults {
            get { return BackingStore?.Get<List<DeviceActionResult>>("deviceActionResults"); }
            set { BackingStore?.Set("deviceActionResults", value); }
        }
        /// <summary>Device category</summary>
        public Microsoft.Graph.Models.DeviceCategory DeviceCategory {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DeviceCategory>("deviceCategory"); }
            set { BackingStore?.Set("deviceCategory", value); }
        }
        /// <summary>Device category display name. This property is read-only.</summary>
        public string DeviceCategoryDisplayName {
            get { return BackingStore?.Get<string>("deviceCategoryDisplayName"); }
            set { BackingStore?.Set("deviceCategoryDisplayName", value); }
        }
        /// <summary>Device compliance policy states for this device.</summary>
        public List<DeviceCompliancePolicyState> DeviceCompliancePolicyStates {
            get { return BackingStore?.Get<List<DeviceCompliancePolicyState>>("deviceCompliancePolicyStates"); }
            set { BackingStore?.Set("deviceCompliancePolicyStates", value); }
        }
        /// <summary>Device configuration states for this device.</summary>
        public List<DeviceConfigurationState> DeviceConfigurationStates {
            get { return BackingStore?.Get<List<DeviceConfigurationState>>("deviceConfigurationStates"); }
            set { BackingStore?.Set("deviceConfigurationStates", value); }
        }
        /// <summary>Possible ways of adding a mobile device to management.</summary>
        public Microsoft.Graph.Models.DeviceEnrollmentType? DeviceEnrollmentType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DeviceEnrollmentType?>("deviceEnrollmentType"); }
            set { BackingStore?.Set("deviceEnrollmentType", value); }
        }
        /// <summary>The device health attestation state. This property is read-only.</summary>
        public Microsoft.Graph.Models.DeviceHealthAttestationState DeviceHealthAttestationState {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DeviceHealthAttestationState>("deviceHealthAttestationState"); }
            set { BackingStore?.Set("deviceHealthAttestationState", value); }
        }
        /// <summary>Name of the device. This property is read-only.</summary>
        public string DeviceName {
            get { return BackingStore?.Get<string>("deviceName"); }
            set { BackingStore?.Set("deviceName", value); }
        }
        /// <summary>Device registration status.</summary>
        public Microsoft.Graph.Models.DeviceRegistrationState? DeviceRegistrationState {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DeviceRegistrationState?>("deviceRegistrationState"); }
            set { BackingStore?.Set("deviceRegistrationState", value); }
        }
        /// <summary>Whether the device is Exchange ActiveSync activated. This property is read-only.</summary>
        public bool? EasActivated {
            get { return BackingStore?.Get<bool?>("easActivated"); }
            set { BackingStore?.Set("easActivated", value); }
        }
        /// <summary>Exchange ActivationSync activation time of the device. This property is read-only.</summary>
        public DateTimeOffset? EasActivationDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("easActivationDateTime"); }
            set { BackingStore?.Set("easActivationDateTime", value); }
        }
        /// <summary>Exchange ActiveSync Id of the device. This property is read-only.</summary>
        public string EasDeviceId {
            get { return BackingStore?.Get<string>("easDeviceId"); }
            set { BackingStore?.Set("easDeviceId", value); }
        }
        /// <summary>Email(s) for the user associated with the device. This property is read-only.</summary>
        public string EmailAddress {
            get { return BackingStore?.Get<string>("emailAddress"); }
            set { BackingStore?.Set("emailAddress", value); }
        }
        /// <summary>Enrollment time of the device. This property is read-only.</summary>
        public DateTimeOffset? EnrolledDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("enrolledDateTime"); }
            set { BackingStore?.Set("enrolledDateTime", value); }
        }
        /// <summary>Ethernet MAC. This property is read-only.</summary>
        public string EthernetMacAddress {
            get { return BackingStore?.Get<string>("ethernetMacAddress"); }
            set { BackingStore?.Set("ethernetMacAddress", value); }
        }
        /// <summary>Device Exchange Access State.</summary>
        public DeviceManagementExchangeAccessState? ExchangeAccessState {
            get { return BackingStore?.Get<DeviceManagementExchangeAccessState?>("exchangeAccessState"); }
            set { BackingStore?.Set("exchangeAccessState", value); }
        }
        /// <summary>Device Exchange Access State Reason.</summary>
        public DeviceManagementExchangeAccessStateReason? ExchangeAccessStateReason {
            get { return BackingStore?.Get<DeviceManagementExchangeAccessStateReason?>("exchangeAccessStateReason"); }
            set { BackingStore?.Set("exchangeAccessStateReason", value); }
        }
        /// <summary>Last time the device contacted Exchange. This property is read-only.</summary>
        public DateTimeOffset? ExchangeLastSuccessfulSyncDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("exchangeLastSuccessfulSyncDateTime"); }
            set { BackingStore?.Set("exchangeLastSuccessfulSyncDateTime", value); }
        }
        /// <summary>Free Storage in Bytes. This property is read-only.</summary>
        public long? FreeStorageSpaceInBytes {
            get { return BackingStore?.Get<long?>("freeStorageSpaceInBytes"); }
            set { BackingStore?.Set("freeStorageSpaceInBytes", value); }
        }
        /// <summary>Integrated Circuit Card Identifier, it is A SIM card&apos;s unique identification number. This property is read-only.</summary>
        public string Iccid {
            get { return BackingStore?.Get<string>("iccid"); }
            set { BackingStore?.Set("iccid", value); }
        }
        /// <summary>IMEI. This property is read-only.</summary>
        public string Imei {
            get { return BackingStore?.Get<string>("imei"); }
            set { BackingStore?.Set("imei", value); }
        }
        /// <summary>Device encryption status. This property is read-only.</summary>
        public bool? IsEncrypted {
            get { return BackingStore?.Get<bool?>("isEncrypted"); }
            set { BackingStore?.Set("isEncrypted", value); }
        }
        /// <summary>Device supervised status. This property is read-only.</summary>
        public bool? IsSupervised {
            get { return BackingStore?.Get<bool?>("isSupervised"); }
            set { BackingStore?.Set("isSupervised", value); }
        }
        /// <summary>whether the device is jail broken or rooted. This property is read-only.</summary>
        public string JailBroken {
            get { return BackingStore?.Get<string>("jailBroken"); }
            set { BackingStore?.Set("jailBroken", value); }
        }
        /// <summary>The date and time that the device last completed a successful sync with Intune. This property is read-only.</summary>
        public DateTimeOffset? LastSyncDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastSyncDateTime"); }
            set { BackingStore?.Set("lastSyncDateTime", value); }
        }
        /// <summary>Automatically generated name to identify a device. Can be overwritten to a user friendly name.</summary>
        public string ManagedDeviceName {
            get { return BackingStore?.Get<string>("managedDeviceName"); }
            set { BackingStore?.Set("managedDeviceName", value); }
        }
        /// <summary>Owner type of device.</summary>
        public Microsoft.Graph.Models.ManagedDeviceOwnerType? ManagedDeviceOwnerType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ManagedDeviceOwnerType?>("managedDeviceOwnerType"); }
            set { BackingStore?.Set("managedDeviceOwnerType", value); }
        }
        /// <summary>The managementAgent property</summary>
        public ManagementAgentType? ManagementAgent {
            get { return BackingStore?.Get<ManagementAgentType?>("managementAgent"); }
            set { BackingStore?.Set("managementAgent", value); }
        }
        /// <summary>Reports device management certificate expiration date. This property is read-only.</summary>
        public DateTimeOffset? ManagementCertificateExpirationDate {
            get { return BackingStore?.Get<DateTimeOffset?>("managementCertificateExpirationDate"); }
            set { BackingStore?.Set("managementCertificateExpirationDate", value); }
        }
        /// <summary>Manufacturer of the device. This property is read-only.</summary>
        public string Manufacturer {
            get { return BackingStore?.Get<string>("manufacturer"); }
            set { BackingStore?.Set("manufacturer", value); }
        }
        /// <summary>MEID. This property is read-only.</summary>
        public string Meid {
            get { return BackingStore?.Get<string>("meid"); }
            set { BackingStore?.Set("meid", value); }
        }
        /// <summary>Model of the device. This property is read-only.</summary>
        public string Model {
            get { return BackingStore?.Get<string>("model"); }
            set { BackingStore?.Set("model", value); }
        }
        /// <summary>Notes on the device created by IT Admin</summary>
        public string Notes {
            get { return BackingStore?.Get<string>("notes"); }
            set { BackingStore?.Set("notes", value); }
        }
        /// <summary>Operating system of the device. Windows, iOS, etc. This property is read-only.</summary>
        public string OperatingSystem {
            get { return BackingStore?.Get<string>("operatingSystem"); }
            set { BackingStore?.Set("operatingSystem", value); }
        }
        /// <summary>Operating system version of the device. This property is read-only.</summary>
        public string OsVersion {
            get { return BackingStore?.Get<string>("osVersion"); }
            set { BackingStore?.Set("osVersion", value); }
        }
        /// <summary>Available health states for the Device Health API</summary>
        public ManagedDevicePartnerReportedHealthState? PartnerReportedThreatState {
            get { return BackingStore?.Get<ManagedDevicePartnerReportedHealthState?>("partnerReportedThreatState"); }
            set { BackingStore?.Set("partnerReportedThreatState", value); }
        }
        /// <summary>Phone number of the device. This property is read-only.</summary>
        public string PhoneNumber {
            get { return BackingStore?.Get<string>("phoneNumber"); }
            set { BackingStore?.Set("phoneNumber", value); }
        }
        /// <summary>Total Memory in Bytes. This property is read-only.</summary>
        public long? PhysicalMemoryInBytes {
            get { return BackingStore?.Get<long?>("physicalMemoryInBytes"); }
            set { BackingStore?.Set("physicalMemoryInBytes", value); }
        }
        /// <summary>An error string that identifies issues when creating Remote Assistance session objects. This property is read-only.</summary>
        public string RemoteAssistanceSessionErrorDetails {
            get { return BackingStore?.Get<string>("remoteAssistanceSessionErrorDetails"); }
            set { BackingStore?.Set("remoteAssistanceSessionErrorDetails", value); }
        }
        /// <summary>Url that allows a Remote Assistance session to be established with the device. This property is read-only.</summary>
        public string RemoteAssistanceSessionUrl {
            get { return BackingStore?.Get<string>("remoteAssistanceSessionUrl"); }
            set { BackingStore?.Set("remoteAssistanceSessionUrl", value); }
        }
        /// <summary>Reports if the managed iOS device is user approval enrollment. This property is read-only.</summary>
        public bool? RequireUserEnrollmentApproval {
            get { return BackingStore?.Get<bool?>("requireUserEnrollmentApproval"); }
            set { BackingStore?.Set("requireUserEnrollmentApproval", value); }
        }
        /// <summary>SerialNumber. This property is read-only.</summary>
        public string SerialNumber {
            get { return BackingStore?.Get<string>("serialNumber"); }
            set { BackingStore?.Set("serialNumber", value); }
        }
        /// <summary>Subscriber Carrier. This property is read-only.</summary>
        public string SubscriberCarrier {
            get { return BackingStore?.Get<string>("subscriberCarrier"); }
            set { BackingStore?.Set("subscriberCarrier", value); }
        }
        /// <summary>Total Storage in Bytes. This property is read-only.</summary>
        public long? TotalStorageSpaceInBytes {
            get { return BackingStore?.Get<long?>("totalStorageSpaceInBytes"); }
            set { BackingStore?.Set("totalStorageSpaceInBytes", value); }
        }
        /// <summary>Unique Device Identifier for iOS and macOS devices. This property is read-only.</summary>
        public string Udid {
            get { return BackingStore?.Get<string>("udid"); }
            set { BackingStore?.Set("udid", value); }
        }
        /// <summary>User display name. This property is read-only.</summary>
        public string UserDisplayName {
            get { return BackingStore?.Get<string>("userDisplayName"); }
            set { BackingStore?.Set("userDisplayName", value); }
        }
        /// <summary>Unique Identifier for the user associated with the device. This property is read-only.</summary>
        public string UserId {
            get { return BackingStore?.Get<string>("userId"); }
            set { BackingStore?.Set("userId", value); }
        }
        /// <summary>Device user principal name. This property is read-only.</summary>
        public string UserPrincipalName {
            get { return BackingStore?.Get<string>("userPrincipalName"); }
            set { BackingStore?.Set("userPrincipalName", value); }
        }
        /// <summary>The primary users associated with the managed device.</summary>
        public List<User> Users {
            get { return BackingStore?.Get<List<User>>("users"); }
            set { BackingStore?.Set("users", value); }
        }
        /// <summary>Wi-Fi MAC. This property is read-only.</summary>
        public string WiFiMacAddress {
            get { return BackingStore?.Get<string>("wiFiMacAddress"); }
            set { BackingStore?.Set("wiFiMacAddress", value); }
        }
        /// <summary>
        /// Instantiates a new managedDevice and sets the default values.
        /// </summary>
        public ManagedDevice() : base() {
            OdataType = "#microsoft.graph.managedDevice";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ManagedDevice CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ManagedDevice();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"activationLockBypassCode", n => { ActivationLockBypassCode = n.GetStringValue(); } },
                {"androidSecurityPatchLevel", n => { AndroidSecurityPatchLevel = n.GetStringValue(); } },
                {"azureADDeviceId", n => { AzureADDeviceId = n.GetStringValue(); } },
                {"azureADRegistered", n => { AzureADRegistered = n.GetBoolValue(); } },
                {"complianceGracePeriodExpirationDateTime", n => { ComplianceGracePeriodExpirationDateTime = n.GetDateTimeOffsetValue(); } },
                {"complianceState", n => { ComplianceState = n.GetEnumValue<ComplianceState>(); } },
                {"configurationManagerClientEnabledFeatures", n => { ConfigurationManagerClientEnabledFeatures = n.GetObjectValue<Microsoft.Graph.Models.ConfigurationManagerClientEnabledFeatures>(Microsoft.Graph.Models.ConfigurationManagerClientEnabledFeatures.CreateFromDiscriminatorValue); } },
                {"deviceActionResults", n => { DeviceActionResults = n.GetCollectionOfObjectValues<DeviceActionResult>(DeviceActionResult.CreateFromDiscriminatorValue)?.ToList(); } },
                {"deviceCategory", n => { DeviceCategory = n.GetObjectValue<Microsoft.Graph.Models.DeviceCategory>(Microsoft.Graph.Models.DeviceCategory.CreateFromDiscriminatorValue); } },
                {"deviceCategoryDisplayName", n => { DeviceCategoryDisplayName = n.GetStringValue(); } },
                {"deviceCompliancePolicyStates", n => { DeviceCompliancePolicyStates = n.GetCollectionOfObjectValues<DeviceCompliancePolicyState>(DeviceCompliancePolicyState.CreateFromDiscriminatorValue)?.ToList(); } },
                {"deviceConfigurationStates", n => { DeviceConfigurationStates = n.GetCollectionOfObjectValues<DeviceConfigurationState>(DeviceConfigurationState.CreateFromDiscriminatorValue)?.ToList(); } },
                {"deviceEnrollmentType", n => { DeviceEnrollmentType = n.GetEnumValue<DeviceEnrollmentType>(); } },
                {"deviceHealthAttestationState", n => { DeviceHealthAttestationState = n.GetObjectValue<Microsoft.Graph.Models.DeviceHealthAttestationState>(Microsoft.Graph.Models.DeviceHealthAttestationState.CreateFromDiscriminatorValue); } },
                {"deviceName", n => { DeviceName = n.GetStringValue(); } },
                {"deviceRegistrationState", n => { DeviceRegistrationState = n.GetEnumValue<DeviceRegistrationState>(); } },
                {"easActivated", n => { EasActivated = n.GetBoolValue(); } },
                {"easActivationDateTime", n => { EasActivationDateTime = n.GetDateTimeOffsetValue(); } },
                {"easDeviceId", n => { EasDeviceId = n.GetStringValue(); } },
                {"emailAddress", n => { EmailAddress = n.GetStringValue(); } },
                {"enrolledDateTime", n => { EnrolledDateTime = n.GetDateTimeOffsetValue(); } },
                {"ethernetMacAddress", n => { EthernetMacAddress = n.GetStringValue(); } },
                {"exchangeAccessState", n => { ExchangeAccessState = n.GetEnumValue<DeviceManagementExchangeAccessState>(); } },
                {"exchangeAccessStateReason", n => { ExchangeAccessStateReason = n.GetEnumValue<DeviceManagementExchangeAccessStateReason>(); } },
                {"exchangeLastSuccessfulSyncDateTime", n => { ExchangeLastSuccessfulSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"freeStorageSpaceInBytes", n => { FreeStorageSpaceInBytes = n.GetLongValue(); } },
                {"iccid", n => { Iccid = n.GetStringValue(); } },
                {"imei", n => { Imei = n.GetStringValue(); } },
                {"isEncrypted", n => { IsEncrypted = n.GetBoolValue(); } },
                {"isSupervised", n => { IsSupervised = n.GetBoolValue(); } },
                {"jailBroken", n => { JailBroken = n.GetStringValue(); } },
                {"lastSyncDateTime", n => { LastSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"managedDeviceName", n => { ManagedDeviceName = n.GetStringValue(); } },
                {"managedDeviceOwnerType", n => { ManagedDeviceOwnerType = n.GetEnumValue<ManagedDeviceOwnerType>(); } },
                {"managementAgent", n => { ManagementAgent = n.GetEnumValue<ManagementAgentType>(); } },
                {"managementCertificateExpirationDate", n => { ManagementCertificateExpirationDate = n.GetDateTimeOffsetValue(); } },
                {"manufacturer", n => { Manufacturer = n.GetStringValue(); } },
                {"meid", n => { Meid = n.GetStringValue(); } },
                {"model", n => { Model = n.GetStringValue(); } },
                {"notes", n => { Notes = n.GetStringValue(); } },
                {"operatingSystem", n => { OperatingSystem = n.GetStringValue(); } },
                {"osVersion", n => { OsVersion = n.GetStringValue(); } },
                {"partnerReportedThreatState", n => { PartnerReportedThreatState = n.GetEnumValue<ManagedDevicePartnerReportedHealthState>(); } },
                {"phoneNumber", n => { PhoneNumber = n.GetStringValue(); } },
                {"physicalMemoryInBytes", n => { PhysicalMemoryInBytes = n.GetLongValue(); } },
                {"remoteAssistanceSessionErrorDetails", n => { RemoteAssistanceSessionErrorDetails = n.GetStringValue(); } },
                {"remoteAssistanceSessionUrl", n => { RemoteAssistanceSessionUrl = n.GetStringValue(); } },
                {"requireUserEnrollmentApproval", n => { RequireUserEnrollmentApproval = n.GetBoolValue(); } },
                {"serialNumber", n => { SerialNumber = n.GetStringValue(); } },
                {"subscriberCarrier", n => { SubscriberCarrier = n.GetStringValue(); } },
                {"totalStorageSpaceInBytes", n => { TotalStorageSpaceInBytes = n.GetLongValue(); } },
                {"udid", n => { Udid = n.GetStringValue(); } },
                {"userDisplayName", n => { UserDisplayName = n.GetStringValue(); } },
                {"userId", n => { UserId = n.GetStringValue(); } },
                {"userPrincipalName", n => { UserPrincipalName = n.GetStringValue(); } },
                {"users", n => { Users = n.GetCollectionOfObjectValues<User>(User.CreateFromDiscriminatorValue)?.ToList(); } },
                {"wiFiMacAddress", n => { WiFiMacAddress = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<ComplianceState>("complianceState", ComplianceState);
            writer.WriteObjectValue<Microsoft.Graph.Models.DeviceCategory>("deviceCategory", DeviceCategory);
            writer.WriteCollectionOfObjectValues<DeviceCompliancePolicyState>("deviceCompliancePolicyStates", DeviceCompliancePolicyStates);
            writer.WriteCollectionOfObjectValues<DeviceConfigurationState>("deviceConfigurationStates", DeviceConfigurationStates);
            writer.WriteEnumValue<DeviceEnrollmentType>("deviceEnrollmentType", DeviceEnrollmentType);
            writer.WriteEnumValue<DeviceRegistrationState>("deviceRegistrationState", DeviceRegistrationState);
            writer.WriteEnumValue<DeviceManagementExchangeAccessState>("exchangeAccessState", ExchangeAccessState);
            writer.WriteEnumValue<DeviceManagementExchangeAccessStateReason>("exchangeAccessStateReason", ExchangeAccessStateReason);
            writer.WriteStringValue("managedDeviceName", ManagedDeviceName);
            writer.WriteEnumValue<ManagedDeviceOwnerType>("managedDeviceOwnerType", ManagedDeviceOwnerType);
            writer.WriteEnumValue<ManagementAgentType>("managementAgent", ManagementAgent);
            writer.WriteStringValue("notes", Notes);
            writer.WriteEnumValue<ManagedDevicePartnerReportedHealthState>("partnerReportedThreatState", PartnerReportedThreatState);
            writer.WriteCollectionOfObjectValues<User>("users", Users);
        }
    }
}
