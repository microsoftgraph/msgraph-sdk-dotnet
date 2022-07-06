using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class DeviceHealthAttestationState : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>TWhen an Attestation Identity Key (AIK) is present on a device, it indicates that the device has an endorsement key (EK) certificate.</summary>
        public string AttestationIdentityKey {
            get { return BackingStore?.Get<string>("attestationIdentityKey"); }
            set { BackingStore?.Set("attestationIdentityKey", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>On or Off of BitLocker Drive Encryption</summary>
        public string BitLockerStatus {
            get { return BackingStore?.Get<string>("bitLockerStatus"); }
            set { BackingStore?.Set("bitLockerStatus", value); }
        }
        /// <summary>The security version number of the Boot Application</summary>
        public string BootAppSecurityVersion {
            get { return BackingStore?.Get<string>("bootAppSecurityVersion"); }
            set { BackingStore?.Set("bootAppSecurityVersion", value); }
        }
        /// <summary>When bootDebugging is enabled, the device is used in development and testing</summary>
        public string BootDebugging {
            get { return BackingStore?.Get<string>("bootDebugging"); }
            set { BackingStore?.Set("bootDebugging", value); }
        }
        /// <summary>The security version number of the Boot Application</summary>
        public string BootManagerSecurityVersion {
            get { return BackingStore?.Get<string>("bootManagerSecurityVersion"); }
            set { BackingStore?.Set("bootManagerSecurityVersion", value); }
        }
        /// <summary>The version of the Boot Manager</summary>
        public string BootManagerVersion {
            get { return BackingStore?.Get<string>("bootManagerVersion"); }
            set { BackingStore?.Set("bootManagerVersion", value); }
        }
        /// <summary>The Boot Revision List that was loaded during initial boot on the attested device</summary>
        public string BootRevisionListInfo {
            get { return BackingStore?.Get<string>("bootRevisionListInfo"); }
            set { BackingStore?.Set("bootRevisionListInfo", value); }
        }
        /// <summary>When code integrity is enabled, code execution is restricted to integrity verified code</summary>
        public string CodeIntegrity {
            get { return BackingStore?.Get<string>("codeIntegrity"); }
            set { BackingStore?.Set("codeIntegrity", value); }
        }
        /// <summary>The version of the Boot Manager</summary>
        public string CodeIntegrityCheckVersion {
            get { return BackingStore?.Get<string>("codeIntegrityCheckVersion"); }
            set { BackingStore?.Set("codeIntegrityCheckVersion", value); }
        }
        /// <summary>The Code Integrity policy that is controlling the security of the boot environment</summary>
        public string CodeIntegrityPolicy {
            get { return BackingStore?.Get<string>("codeIntegrityPolicy"); }
            set { BackingStore?.Set("codeIntegrityPolicy", value); }
        }
        /// <summary>The DHA report version. (Namespace version)</summary>
        public string ContentNamespaceUrl {
            get { return BackingStore?.Get<string>("contentNamespaceUrl"); }
            set { BackingStore?.Set("contentNamespaceUrl", value); }
        }
        /// <summary>The HealthAttestation state schema version</summary>
        public string ContentVersion {
            get { return BackingStore?.Get<string>("contentVersion"); }
            set { BackingStore?.Set("contentVersion", value); }
        }
        /// <summary>DEP Policy defines a set of hardware and software technologies that perform additional checks on memory</summary>
        public string DataExcutionPolicy {
            get { return BackingStore?.Get<string>("dataExcutionPolicy"); }
            set { BackingStore?.Set("dataExcutionPolicy", value); }
        }
        /// <summary>The DHA report version. (Namespace version)</summary>
        public string DeviceHealthAttestationStatus {
            get { return BackingStore?.Get<string>("deviceHealthAttestationStatus"); }
            set { BackingStore?.Set("deviceHealthAttestationStatus", value); }
        }
        /// <summary>ELAM provides protection for the computers in your network when they start up</summary>
        public string EarlyLaunchAntiMalwareDriverProtection {
            get { return BackingStore?.Get<string>("earlyLaunchAntiMalwareDriverProtection"); }
            set { BackingStore?.Set("earlyLaunchAntiMalwareDriverProtection", value); }
        }
        /// <summary>This attribute indicates if DHA is supported for the device</summary>
        public string HealthAttestationSupportedStatus {
            get { return BackingStore?.Get<string>("healthAttestationSupportedStatus"); }
            set { BackingStore?.Set("healthAttestationSupportedStatus", value); }
        }
        /// <summary>This attribute appears if DHA-Service detects an integrity issue</summary>
        public string HealthStatusMismatchInfo {
            get { return BackingStore?.Get<string>("healthStatusMismatchInfo"); }
            set { BackingStore?.Set("healthStatusMismatchInfo", value); }
        }
        /// <summary>The DateTime when device was evaluated or issued to MDM</summary>
        public DateTimeOffset? IssuedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("issuedDateTime"); }
            set { BackingStore?.Set("issuedDateTime", value); }
        }
        /// <summary>The Timestamp of the last update.</summary>
        public string LastUpdateDateTime {
            get { return BackingStore?.Get<string>("lastUpdateDateTime"); }
            set { BackingStore?.Set("lastUpdateDateTime", value); }
        }
        /// <summary>When operatingSystemKernelDebugging is enabled, the device is used in development and testing</summary>
        public string OperatingSystemKernelDebugging {
            get { return BackingStore?.Get<string>("operatingSystemKernelDebugging"); }
            set { BackingStore?.Set("operatingSystemKernelDebugging", value); }
        }
        /// <summary>The Operating System Revision List that was loaded during initial boot on the attested device</summary>
        public string OperatingSystemRevListInfo {
            get { return BackingStore?.Get<string>("operatingSystemRevListInfo"); }
            set { BackingStore?.Set("operatingSystemRevListInfo", value); }
        }
        /// <summary>The measurement that is captured in PCR[0]</summary>
        public string Pcr0 {
            get { return BackingStore?.Get<string>("pcr0"); }
            set { BackingStore?.Set("pcr0", value); }
        }
        /// <summary>Informational attribute that identifies the HASH algorithm that was used by TPM</summary>
        public string PcrHashAlgorithm {
            get { return BackingStore?.Get<string>("pcrHashAlgorithm"); }
            set { BackingStore?.Set("pcrHashAlgorithm", value); }
        }
        /// <summary>The number of times a PC device has hibernated or resumed</summary>
        public long? ResetCount {
            get { return BackingStore?.Get<long?>("resetCount"); }
            set { BackingStore?.Set("resetCount", value); }
        }
        /// <summary>The number of times a PC device has rebooted</summary>
        public long? RestartCount {
            get { return BackingStore?.Get<long?>("restartCount"); }
            set { BackingStore?.Set("restartCount", value); }
        }
        /// <summary>Safe mode is a troubleshooting option for Windows that starts your computer in a limited state</summary>
        public string SafeMode {
            get { return BackingStore?.Get<string>("safeMode"); }
            set { BackingStore?.Set("safeMode", value); }
        }
        /// <summary>When Secure Boot is enabled, the core components must have the correct cryptographic signatures</summary>
        public string SecureBoot {
            get { return BackingStore?.Get<string>("secureBoot"); }
            set { BackingStore?.Set("secureBoot", value); }
        }
        /// <summary>Fingerprint of the Custom Secure Boot Configuration Policy</summary>
        public string SecureBootConfigurationPolicyFingerPrint {
            get { return BackingStore?.Get<string>("secureBootConfigurationPolicyFingerPrint"); }
            set { BackingStore?.Set("secureBootConfigurationPolicyFingerPrint", value); }
        }
        /// <summary>When test signing is allowed, the device does not enforce signature validation during boot</summary>
        public string TestSigning {
            get { return BackingStore?.Get<string>("testSigning"); }
            set { BackingStore?.Set("testSigning", value); }
        }
        /// <summary>The security version number of the Boot Application</summary>
        public string TpmVersion {
            get { return BackingStore?.Get<string>("tpmVersion"); }
            set { BackingStore?.Set("tpmVersion", value); }
        }
        /// <summary>VSM is a container that protects high value assets from a compromised kernel</summary>
        public string VirtualSecureMode {
            get { return BackingStore?.Get<string>("virtualSecureMode"); }
            set { BackingStore?.Set("virtualSecureMode", value); }
        }
        /// <summary>Operating system running with limited services that is used to prepare a computer for Windows</summary>
        public string WindowsPE {
            get { return BackingStore?.Get<string>("windowsPE"); }
            set { BackingStore?.Set("windowsPE", value); }
        }
        /// <summary>
        /// Instantiates a new deviceHealthAttestationState and sets the default values.
        /// </summary>
        public DeviceHealthAttestationState() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static DeviceHealthAttestationState CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceHealthAttestationState();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"attestationIdentityKey", n => { AttestationIdentityKey = n.GetStringValue(); } },
                {"bitLockerStatus", n => { BitLockerStatus = n.GetStringValue(); } },
                {"bootAppSecurityVersion", n => { BootAppSecurityVersion = n.GetStringValue(); } },
                {"bootDebugging", n => { BootDebugging = n.GetStringValue(); } },
                {"bootManagerSecurityVersion", n => { BootManagerSecurityVersion = n.GetStringValue(); } },
                {"bootManagerVersion", n => { BootManagerVersion = n.GetStringValue(); } },
                {"bootRevisionListInfo", n => { BootRevisionListInfo = n.GetStringValue(); } },
                {"codeIntegrity", n => { CodeIntegrity = n.GetStringValue(); } },
                {"codeIntegrityCheckVersion", n => { CodeIntegrityCheckVersion = n.GetStringValue(); } },
                {"codeIntegrityPolicy", n => { CodeIntegrityPolicy = n.GetStringValue(); } },
                {"contentNamespaceUrl", n => { ContentNamespaceUrl = n.GetStringValue(); } },
                {"contentVersion", n => { ContentVersion = n.GetStringValue(); } },
                {"dataExcutionPolicy", n => { DataExcutionPolicy = n.GetStringValue(); } },
                {"deviceHealthAttestationStatus", n => { DeviceHealthAttestationStatus = n.GetStringValue(); } },
                {"earlyLaunchAntiMalwareDriverProtection", n => { EarlyLaunchAntiMalwareDriverProtection = n.GetStringValue(); } },
                {"healthAttestationSupportedStatus", n => { HealthAttestationSupportedStatus = n.GetStringValue(); } },
                {"healthStatusMismatchInfo", n => { HealthStatusMismatchInfo = n.GetStringValue(); } },
                {"issuedDateTime", n => { IssuedDateTime = n.GetDateTimeOffsetValue(); } },
                {"lastUpdateDateTime", n => { LastUpdateDateTime = n.GetStringValue(); } },
                {"operatingSystemKernelDebugging", n => { OperatingSystemKernelDebugging = n.GetStringValue(); } },
                {"operatingSystemRevListInfo", n => { OperatingSystemRevListInfo = n.GetStringValue(); } },
                {"pcr0", n => { Pcr0 = n.GetStringValue(); } },
                {"pcrHashAlgorithm", n => { PcrHashAlgorithm = n.GetStringValue(); } },
                {"resetCount", n => { ResetCount = n.GetLongValue(); } },
                {"restartCount", n => { RestartCount = n.GetLongValue(); } },
                {"safeMode", n => { SafeMode = n.GetStringValue(); } },
                {"secureBoot", n => { SecureBoot = n.GetStringValue(); } },
                {"secureBootConfigurationPolicyFingerPrint", n => { SecureBootConfigurationPolicyFingerPrint = n.GetStringValue(); } },
                {"testSigning", n => { TestSigning = n.GetStringValue(); } },
                {"tpmVersion", n => { TpmVersion = n.GetStringValue(); } },
                {"virtualSecureMode", n => { VirtualSecureMode = n.GetStringValue(); } },
                {"windowsPE", n => { WindowsPE = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("attestationIdentityKey", AttestationIdentityKey);
            writer.WriteStringValue("bitLockerStatus", BitLockerStatus);
            writer.WriteStringValue("bootAppSecurityVersion", BootAppSecurityVersion);
            writer.WriteStringValue("bootDebugging", BootDebugging);
            writer.WriteStringValue("bootManagerSecurityVersion", BootManagerSecurityVersion);
            writer.WriteStringValue("bootManagerVersion", BootManagerVersion);
            writer.WriteStringValue("bootRevisionListInfo", BootRevisionListInfo);
            writer.WriteStringValue("codeIntegrity", CodeIntegrity);
            writer.WriteStringValue("codeIntegrityCheckVersion", CodeIntegrityCheckVersion);
            writer.WriteStringValue("codeIntegrityPolicy", CodeIntegrityPolicy);
            writer.WriteStringValue("contentNamespaceUrl", ContentNamespaceUrl);
            writer.WriteStringValue("contentVersion", ContentVersion);
            writer.WriteStringValue("dataExcutionPolicy", DataExcutionPolicy);
            writer.WriteStringValue("deviceHealthAttestationStatus", DeviceHealthAttestationStatus);
            writer.WriteStringValue("earlyLaunchAntiMalwareDriverProtection", EarlyLaunchAntiMalwareDriverProtection);
            writer.WriteStringValue("healthAttestationSupportedStatus", HealthAttestationSupportedStatus);
            writer.WriteStringValue("healthStatusMismatchInfo", HealthStatusMismatchInfo);
            writer.WriteDateTimeOffsetValue("issuedDateTime", IssuedDateTime);
            writer.WriteStringValue("lastUpdateDateTime", LastUpdateDateTime);
            writer.WriteStringValue("operatingSystemKernelDebugging", OperatingSystemKernelDebugging);
            writer.WriteStringValue("operatingSystemRevListInfo", OperatingSystemRevListInfo);
            writer.WriteStringValue("pcr0", Pcr0);
            writer.WriteStringValue("pcrHashAlgorithm", PcrHashAlgorithm);
            writer.WriteLongValue("resetCount", ResetCount);
            writer.WriteLongValue("restartCount", RestartCount);
            writer.WriteStringValue("safeMode", SafeMode);
            writer.WriteStringValue("secureBoot", SecureBoot);
            writer.WriteStringValue("secureBootConfigurationPolicyFingerPrint", SecureBootConfigurationPolicyFingerPrint);
            writer.WriteStringValue("testSigning", TestSigning);
            writer.WriteStringValue("tpmVersion", TpmVersion);
            writer.WriteStringValue("virtualSecureMode", VirtualSecureMode);
            writer.WriteStringValue("windowsPE", WindowsPE);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
