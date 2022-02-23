using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class ManagedDevice : Entity, IParsable {
        /// <summary>Code that allows the Activation Lock on a device to be bypassed. This property is read-only.</summary>
        public string ActivationLockBypassCode { get; set; }
        /// <summary>Android security patch level. This property is read-only.</summary>
        public string AndroidSecurityPatchLevel { get; set; }
        /// <summary>The unique identifier for the Azure Active Directory device. Read only. This property is read-only.</summary>
        public string AzureADDeviceId { get; set; }
        /// <summary>Whether the device is Azure Active Directory registered. This property is read-only.</summary>
        public bool? AzureADRegistered { get; set; }
        /// <summary>The DateTime when device compliance grace period expires. This property is read-only.</summary>
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
        /// <summary>Compliance state of the device. This property is read-only. Possible values are: unknown, compliant, noncompliant, conflict, error, inGracePeriod, configManager.</summary>
        public ComplianceState? ComplianceState { get; set; }
        /// <summary>ConfigrMgr client enabled features. This property is read-only.</summary>
        public ConfigurationManagerClientEnabledFeatures ConfigurationManagerClientEnabledFeatures { get; set; }
        /// <summary>List of ComplexType deviceActionResult objects. This property is read-only.</summary>
        public List<DeviceActionResult> DeviceActionResults { get; set; }
        /// <summary>Device category</summary>
        public DeviceCategory DeviceCategory { get; set; }
        /// <summary>Device category display name. This property is read-only.</summary>
        public string DeviceCategoryDisplayName { get; set; }
        /// <summary>Device compliance policy states for this device.</summary>
        public List<DeviceCompliancePolicyState> DeviceCompliancePolicyStates { get; set; }
        /// <summary>Device configuration states for this device.</summary>
        public List<DeviceConfigurationState> DeviceConfigurationStates { get; set; }
        /// <summary>Enrollment type of the device. This property is read-only. Possible values are: unknown, userEnrollment, deviceEnrollmentManager, appleBulkWithUser, appleBulkWithoutUser, windowsAzureADJoin, windowsBulkUserless, windowsAutoEnrollment, windowsBulkAzureDomainJoin, windowsCoManagement, windowsAzureADJoinUsingDeviceAuth, appleUserEnrollment, appleUserEnrollmentWithServiceAccount.</summary>
        public DeviceEnrollmentType? DeviceEnrollmentType { get; set; }
        /// <summary>The device health attestation state. This property is read-only.</summary>
        public DeviceHealthAttestationState DeviceHealthAttestationState { get; set; }
        /// <summary>Name of the device. This property is read-only.</summary>
        public string DeviceName { get; set; }
        /// <summary>Device registration state. This property is read-only. Possible values are: notRegistered, registered, revoked, keyConflict, approvalPending, certificateReset, notRegisteredPendingEnrollment, unknown.</summary>
        public DeviceRegistrationState? DeviceRegistrationState { get; set; }
        /// <summary>Whether the device is Exchange ActiveSync activated. This property is read-only.</summary>
        public bool? EasActivated { get; set; }
        /// <summary>Exchange ActivationSync activation time of the device. This property is read-only.</summary>
        public DateTimeOffset? EasActivationDateTime { get; set; }
        /// <summary>Exchange ActiveSync Id of the device. This property is read-only.</summary>
        public string EasDeviceId { get; set; }
        /// <summary>Email(s) for the user associated with the device. This property is read-only.</summary>
        public string EmailAddress { get; set; }
        /// <summary>Enrollment time of the device. This property is read-only.</summary>
        public DateTimeOffset? EnrolledDateTime { get; set; }
        /// <summary>Ethernet MAC. This property is read-only.</summary>
        public string EthernetMacAddress { get; set; }
        /// <summary>The Access State of the device in Exchange. This property is read-only. Possible values are: none, unknown, allowed, blocked, quarantined.</summary>
        public DeviceManagementExchangeAccessState? ExchangeAccessState { get; set; }
        /// <summary>The reason for the device's access state in Exchange. This property is read-only. Possible values are: none, unknown, exchangeGlobalRule, exchangeIndividualRule, exchangeDeviceRule, exchangeUpgrade, exchangeMailboxPolicy, other, compliant, notCompliant, notEnrolled, unknownLocation, mfaRequired, azureADBlockDueToAccessPolicy, compromisedPassword, deviceNotKnownWithManagedApp.</summary>
        public DeviceManagementExchangeAccessStateReason? ExchangeAccessStateReason { get; set; }
        /// <summary>Last time the device contacted Exchange. This property is read-only.</summary>
        public DateTimeOffset? ExchangeLastSuccessfulSyncDateTime { get; set; }
        /// <summary>Free Storage in Bytes. This property is read-only.</summary>
        public long? FreeStorageSpaceInBytes { get; set; }
        /// <summary>Integrated Circuit Card Identifier, it is A SIM card's unique identification number. This property is read-only.</summary>
        public string Iccid { get; set; }
        /// <summary>IMEI. This property is read-only.</summary>
        public string Imei { get; set; }
        /// <summary>Device encryption status. This property is read-only.</summary>
        public bool? IsEncrypted { get; set; }
        /// <summary>Device supervised status. This property is read-only.</summary>
        public bool? IsSupervised { get; set; }
        /// <summary>whether the device is jail broken or rooted. This property is read-only.</summary>
        public string JailBroken { get; set; }
        /// <summary>The date and time that the device last completed a successful sync with Intune. This property is read-only.</summary>
        public DateTimeOffset? LastSyncDateTime { get; set; }
        /// <summary>Automatically generated name to identify a device. Can be overwritten to a user friendly name.</summary>
        public string ManagedDeviceName { get; set; }
        /// <summary>Ownership of the device. Can be 'company' or 'personal'. Possible values are: unknown, company, personal.</summary>
        public ManagedDeviceOwnerType? ManagedDeviceOwnerType { get; set; }
        /// <summary>Management channel of the device. Intune, EAS, etc. This property is read-only. Possible values are: eas, mdm, easMdm, intuneClient, easIntuneClient, configurationManagerClient, configurationManagerClientMdm, configurationManagerClientMdmEas, unknown, jamf, googleCloudDevicePolicyController.</summary>
        public ManagementAgentType? ManagementAgent { get; set; }
        /// <summary>Manufacturer of the device. This property is read-only.</summary>
        public string Manufacturer { get; set; }
        /// <summary>MEID. This property is read-only.</summary>
        public string Meid { get; set; }
        /// <summary>Model of the device. This property is read-only.</summary>
        public string Model { get; set; }
        /// <summary>Notes on the device created by IT Admin</summary>
        public string Notes { get; set; }
        /// <summary>Operating system of the device. Windows, iOS, etc. This property is read-only.</summary>
        public string OperatingSystem { get; set; }
        /// <summary>Operating system version of the device. This property is read-only.</summary>
        public string OsVersion { get; set; }
        /// <summary>Indicates the threat state of a device when a Mobile Threat Defense partner is in use by the account and device. Read Only. This property is read-only. Possible values are: unknown, activated, deactivated, secured, lowSeverity, mediumSeverity, highSeverity, unresponsive, compromised, misconfigured.</summary>
        public ManagedDevicePartnerReportedHealthState? PartnerReportedThreatState { get; set; }
        /// <summary>Phone number of the device. This property is read-only.</summary>
        public string PhoneNumber { get; set; }
        /// <summary>Total Memory in Bytes. This property is read-only.</summary>
        public long? PhysicalMemoryInBytes { get; set; }
        /// <summary>An error string that identifies issues when creating Remote Assistance session objects. This property is read-only.</summary>
        public string RemoteAssistanceSessionErrorDetails { get; set; }
        /// <summary>Url that allows a Remote Assistance session to be established with the device. This property is read-only.</summary>
        public string RemoteAssistanceSessionUrl { get; set; }
        /// <summary>SerialNumber. This property is read-only.</summary>
        public string SerialNumber { get; set; }
        /// <summary>Subscriber Carrier. This property is read-only.</summary>
        public string SubscriberCarrier { get; set; }
        /// <summary>Total Storage in Bytes. This property is read-only.</summary>
        public long? TotalStorageSpaceInBytes { get; set; }
        /// <summary>Unique Device Identifier for iOS and macOS devices. This property is read-only.</summary>
        public string Udid { get; set; }
        /// <summary>User display name. This property is read-only.</summary>
        public string UserDisplayName { get; set; }
        /// <summary>Unique Identifier for the user associated with the device. This property is read-only.</summary>
        public string UserId { get; set; }
        /// <summary>Device user principal name. This property is read-only.</summary>
        public string UserPrincipalName { get; set; }
        /// <summary>Wi-Fi MAC. This property is read-only.</summary>
        public string WiFiMacAddress { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"activationLockBypassCode", (o,n) => { (o as ManagedDevice).ActivationLockBypassCode = n.GetStringValue(); } },
                {"androidSecurityPatchLevel", (o,n) => { (o as ManagedDevice).AndroidSecurityPatchLevel = n.GetStringValue(); } },
                {"azureADDeviceId", (o,n) => { (o as ManagedDevice).AzureADDeviceId = n.GetStringValue(); } },
                {"azureADRegistered", (o,n) => { (o as ManagedDevice).AzureADRegistered = n.GetBoolValue(); } },
                {"complianceGracePeriodExpirationDateTime", (o,n) => { (o as ManagedDevice).ComplianceGracePeriodExpirationDateTime = n.GetDateTimeOffsetValue(); } },
                {"complianceState", (o,n) => { (o as ManagedDevice).ComplianceState = n.GetEnumValue<ComplianceState>(); } },
                {"configurationManagerClientEnabledFeatures", (o,n) => { (o as ManagedDevice).ConfigurationManagerClientEnabledFeatures = n.GetObjectValue<ConfigurationManagerClientEnabledFeatures>(); } },
                {"deviceActionResults", (o,n) => { (o as ManagedDevice).DeviceActionResults = n.GetCollectionOfObjectValues<DeviceActionResult>().ToList(); } },
                {"deviceCategory", (o,n) => { (o as ManagedDevice).DeviceCategory = n.GetObjectValue<DeviceCategory>(); } },
                {"deviceCategoryDisplayName", (o,n) => { (o as ManagedDevice).DeviceCategoryDisplayName = n.GetStringValue(); } },
                {"deviceCompliancePolicyStates", (o,n) => { (o as ManagedDevice).DeviceCompliancePolicyStates = n.GetCollectionOfObjectValues<DeviceCompliancePolicyState>().ToList(); } },
                {"deviceConfigurationStates", (o,n) => { (o as ManagedDevice).DeviceConfigurationStates = n.GetCollectionOfObjectValues<DeviceConfigurationState>().ToList(); } },
                {"deviceEnrollmentType", (o,n) => { (o as ManagedDevice).DeviceEnrollmentType = n.GetEnumValue<DeviceEnrollmentType>(); } },
                {"deviceHealthAttestationState", (o,n) => { (o as ManagedDevice).DeviceHealthAttestationState = n.GetObjectValue<DeviceHealthAttestationState>(); } },
                {"deviceName", (o,n) => { (o as ManagedDevice).DeviceName = n.GetStringValue(); } },
                {"deviceRegistrationState", (o,n) => { (o as ManagedDevice).DeviceRegistrationState = n.GetEnumValue<DeviceRegistrationState>(); } },
                {"easActivated", (o,n) => { (o as ManagedDevice).EasActivated = n.GetBoolValue(); } },
                {"easActivationDateTime", (o,n) => { (o as ManagedDevice).EasActivationDateTime = n.GetDateTimeOffsetValue(); } },
                {"easDeviceId", (o,n) => { (o as ManagedDevice).EasDeviceId = n.GetStringValue(); } },
                {"emailAddress", (o,n) => { (o as ManagedDevice).EmailAddress = n.GetStringValue(); } },
                {"enrolledDateTime", (o,n) => { (o as ManagedDevice).EnrolledDateTime = n.GetDateTimeOffsetValue(); } },
                {"ethernetMacAddress", (o,n) => { (o as ManagedDevice).EthernetMacAddress = n.GetStringValue(); } },
                {"exchangeAccessState", (o,n) => { (o as ManagedDevice).ExchangeAccessState = n.GetEnumValue<DeviceManagementExchangeAccessState>(); } },
                {"exchangeAccessStateReason", (o,n) => { (o as ManagedDevice).ExchangeAccessStateReason = n.GetEnumValue<DeviceManagementExchangeAccessStateReason>(); } },
                {"exchangeLastSuccessfulSyncDateTime", (o,n) => { (o as ManagedDevice).ExchangeLastSuccessfulSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"freeStorageSpaceInBytes", (o,n) => { (o as ManagedDevice).FreeStorageSpaceInBytes = n.GetLongValue(); } },
                {"iccid", (o,n) => { (o as ManagedDevice).Iccid = n.GetStringValue(); } },
                {"imei", (o,n) => { (o as ManagedDevice).Imei = n.GetStringValue(); } },
                {"isEncrypted", (o,n) => { (o as ManagedDevice).IsEncrypted = n.GetBoolValue(); } },
                {"isSupervised", (o,n) => { (o as ManagedDevice).IsSupervised = n.GetBoolValue(); } },
                {"jailBroken", (o,n) => { (o as ManagedDevice).JailBroken = n.GetStringValue(); } },
                {"lastSyncDateTime", (o,n) => { (o as ManagedDevice).LastSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"managedDeviceName", (o,n) => { (o as ManagedDevice).ManagedDeviceName = n.GetStringValue(); } },
                {"managedDeviceOwnerType", (o,n) => { (o as ManagedDevice).ManagedDeviceOwnerType = n.GetEnumValue<ManagedDeviceOwnerType>(); } },
                {"managementAgent", (o,n) => { (o as ManagedDevice).ManagementAgent = n.GetEnumValue<ManagementAgentType>(); } },
                {"manufacturer", (o,n) => { (o as ManagedDevice).Manufacturer = n.GetStringValue(); } },
                {"meid", (o,n) => { (o as ManagedDevice).Meid = n.GetStringValue(); } },
                {"model", (o,n) => { (o as ManagedDevice).Model = n.GetStringValue(); } },
                {"notes", (o,n) => { (o as ManagedDevice).Notes = n.GetStringValue(); } },
                {"operatingSystem", (o,n) => { (o as ManagedDevice).OperatingSystem = n.GetStringValue(); } },
                {"osVersion", (o,n) => { (o as ManagedDevice).OsVersion = n.GetStringValue(); } },
                {"partnerReportedThreatState", (o,n) => { (o as ManagedDevice).PartnerReportedThreatState = n.GetEnumValue<ManagedDevicePartnerReportedHealthState>(); } },
                {"phoneNumber", (o,n) => { (o as ManagedDevice).PhoneNumber = n.GetStringValue(); } },
                {"physicalMemoryInBytes", (o,n) => { (o as ManagedDevice).PhysicalMemoryInBytes = n.GetLongValue(); } },
                {"remoteAssistanceSessionErrorDetails", (o,n) => { (o as ManagedDevice).RemoteAssistanceSessionErrorDetails = n.GetStringValue(); } },
                {"remoteAssistanceSessionUrl", (o,n) => { (o as ManagedDevice).RemoteAssistanceSessionUrl = n.GetStringValue(); } },
                {"serialNumber", (o,n) => { (o as ManagedDevice).SerialNumber = n.GetStringValue(); } },
                {"subscriberCarrier", (o,n) => { (o as ManagedDevice).SubscriberCarrier = n.GetStringValue(); } },
                {"totalStorageSpaceInBytes", (o,n) => { (o as ManagedDevice).TotalStorageSpaceInBytes = n.GetLongValue(); } },
                {"udid", (o,n) => { (o as ManagedDevice).Udid = n.GetStringValue(); } },
                {"userDisplayName", (o,n) => { (o as ManagedDevice).UserDisplayName = n.GetStringValue(); } },
                {"userId", (o,n) => { (o as ManagedDevice).UserId = n.GetStringValue(); } },
                {"userPrincipalName", (o,n) => { (o as ManagedDevice).UserPrincipalName = n.GetStringValue(); } },
                {"wiFiMacAddress", (o,n) => { (o as ManagedDevice).WiFiMacAddress = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("activationLockBypassCode", ActivationLockBypassCode);
            writer.WriteStringValue("androidSecurityPatchLevel", AndroidSecurityPatchLevel);
            writer.WriteStringValue("azureADDeviceId", AzureADDeviceId);
            writer.WriteBoolValue("azureADRegistered", AzureADRegistered);
            writer.WriteDateTimeOffsetValue("complianceGracePeriodExpirationDateTime", ComplianceGracePeriodExpirationDateTime);
            writer.WriteEnumValue<ComplianceState>("complianceState", ComplianceState);
            writer.WriteObjectValue<ConfigurationManagerClientEnabledFeatures>("configurationManagerClientEnabledFeatures", ConfigurationManagerClientEnabledFeatures);
            writer.WriteCollectionOfObjectValues<DeviceActionResult>("deviceActionResults", DeviceActionResults);
            writer.WriteObjectValue<DeviceCategory>("deviceCategory", DeviceCategory);
            writer.WriteStringValue("deviceCategoryDisplayName", DeviceCategoryDisplayName);
            writer.WriteCollectionOfObjectValues<DeviceCompliancePolicyState>("deviceCompliancePolicyStates", DeviceCompliancePolicyStates);
            writer.WriteCollectionOfObjectValues<DeviceConfigurationState>("deviceConfigurationStates", DeviceConfigurationStates);
            writer.WriteEnumValue<DeviceEnrollmentType>("deviceEnrollmentType", DeviceEnrollmentType);
            writer.WriteObjectValue<DeviceHealthAttestationState>("deviceHealthAttestationState", DeviceHealthAttestationState);
            writer.WriteStringValue("deviceName", DeviceName);
            writer.WriteEnumValue<DeviceRegistrationState>("deviceRegistrationState", DeviceRegistrationState);
            writer.WriteBoolValue("easActivated", EasActivated);
            writer.WriteDateTimeOffsetValue("easActivationDateTime", EasActivationDateTime);
            writer.WriteStringValue("easDeviceId", EasDeviceId);
            writer.WriteStringValue("emailAddress", EmailAddress);
            writer.WriteDateTimeOffsetValue("enrolledDateTime", EnrolledDateTime);
            writer.WriteStringValue("ethernetMacAddress", EthernetMacAddress);
            writer.WriteEnumValue<DeviceManagementExchangeAccessState>("exchangeAccessState", ExchangeAccessState);
            writer.WriteEnumValue<DeviceManagementExchangeAccessStateReason>("exchangeAccessStateReason", ExchangeAccessStateReason);
            writer.WriteDateTimeOffsetValue("exchangeLastSuccessfulSyncDateTime", ExchangeLastSuccessfulSyncDateTime);
            writer.WriteLongValue("freeStorageSpaceInBytes", FreeStorageSpaceInBytes);
            writer.WriteStringValue("iccid", Iccid);
            writer.WriteStringValue("imei", Imei);
            writer.WriteBoolValue("isEncrypted", IsEncrypted);
            writer.WriteBoolValue("isSupervised", IsSupervised);
            writer.WriteStringValue("jailBroken", JailBroken);
            writer.WriteDateTimeOffsetValue("lastSyncDateTime", LastSyncDateTime);
            writer.WriteStringValue("managedDeviceName", ManagedDeviceName);
            writer.WriteEnumValue<ManagedDeviceOwnerType>("managedDeviceOwnerType", ManagedDeviceOwnerType);
            writer.WriteEnumValue<ManagementAgentType>("managementAgent", ManagementAgent);
            writer.WriteStringValue("manufacturer", Manufacturer);
            writer.WriteStringValue("meid", Meid);
            writer.WriteStringValue("model", Model);
            writer.WriteStringValue("notes", Notes);
            writer.WriteStringValue("operatingSystem", OperatingSystem);
            writer.WriteStringValue("osVersion", OsVersion);
            writer.WriteEnumValue<ManagedDevicePartnerReportedHealthState>("partnerReportedThreatState", PartnerReportedThreatState);
            writer.WriteStringValue("phoneNumber", PhoneNumber);
            writer.WriteLongValue("physicalMemoryInBytes", PhysicalMemoryInBytes);
            writer.WriteStringValue("remoteAssistanceSessionErrorDetails", RemoteAssistanceSessionErrorDetails);
            writer.WriteStringValue("remoteAssistanceSessionUrl", RemoteAssistanceSessionUrl);
            writer.WriteStringValue("serialNumber", SerialNumber);
            writer.WriteStringValue("subscriberCarrier", SubscriberCarrier);
            writer.WriteLongValue("totalStorageSpaceInBytes", TotalStorageSpaceInBytes);
            writer.WriteStringValue("udid", Udid);
            writer.WriteStringValue("userDisplayName", UserDisplayName);
            writer.WriteStringValue("userId", UserId);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
            writer.WriteStringValue("wiFiMacAddress", WiFiMacAddress);
        }
    }
}
