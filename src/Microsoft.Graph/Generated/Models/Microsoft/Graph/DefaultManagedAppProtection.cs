using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class DefaultManagedAppProtection : ManagedAppProtection, IParsable {
        /// <summary>Type of encryption which should be used for data in a managed app. (iOS Only). Possible values are: useDeviceSettings, afterDeviceRestart, whenDeviceLockedExceptOpenFiles, whenDeviceLocked.</summary>
        public ManagedAppDataEncryptionType? AppDataEncryptionType { get; set; }
        /// <summary>List of apps to which the policy is deployed.</summary>
        public List<ManagedMobileApp> Apps { get; set; }
        /// <summary>A set of string key and string value pairs to be sent to the affected users, unalterned by this service</summary>
        public List<KeyValuePair> CustomSettings { get; set; }
        /// <summary>Count of apps to which the current policy is deployed.</summary>
        public int? DeployedAppCount { get; set; }
        /// <summary>Navigation property to deployment summary of the configuration.</summary>
        public ManagedAppPolicyDeploymentSummary DeploymentSummary { get; set; }
        /// <summary>When this setting is enabled, app level encryption is disabled if device level encryption is enabled. (Android only)</summary>
        public bool? DisableAppEncryptionIfDeviceEncryptionIsEnabled { get; set; }
        /// <summary>Indicates whether managed-app data should be encrypted. (Android only)</summary>
        public bool? EncryptAppData { get; set; }
        /// <summary>Indicates whether use of the FaceID is allowed in place of a pin if PinRequired is set to True. (iOS Only)</summary>
        public bool? FaceIdBlocked { get; set; }
        /// <summary>Define the oldest required Android security patch level a user can have to gain secure access to the app. (Android only)</summary>
        public string MinimumRequiredPatchVersion { get; set; }
        /// <summary>Versions less than the specified version will block the managed app from accessing company data. (iOS Only)</summary>
        public string MinimumRequiredSdkVersion { get; set; }
        /// <summary>Define the oldest recommended Android security patch level a user can have for secure access to the app. (Android only)</summary>
        public string MinimumWarningPatchVersion { get; set; }
        /// <summary>Indicates whether screen capture is blocked. (Android only)</summary>
        public bool? ScreenCaptureBlocked { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"appDataEncryptionType", (o,n) => { (o as DefaultManagedAppProtection).AppDataEncryptionType = n.GetEnumValue<ManagedAppDataEncryptionType>(); } },
                {"apps", (o,n) => { (o as DefaultManagedAppProtection).Apps = n.GetCollectionOfObjectValues<ManagedMobileApp>().ToList(); } },
                {"customSettings", (o,n) => { (o as DefaultManagedAppProtection).CustomSettings = n.GetCollectionOfObjectValues<KeyValuePair>().ToList(); } },
                {"deployedAppCount", (o,n) => { (o as DefaultManagedAppProtection).DeployedAppCount = n.GetIntValue(); } },
                {"deploymentSummary", (o,n) => { (o as DefaultManagedAppProtection).DeploymentSummary = n.GetObjectValue<ManagedAppPolicyDeploymentSummary>(); } },
                {"disableAppEncryptionIfDeviceEncryptionIsEnabled", (o,n) => { (o as DefaultManagedAppProtection).DisableAppEncryptionIfDeviceEncryptionIsEnabled = n.GetBoolValue(); } },
                {"encryptAppData", (o,n) => { (o as DefaultManagedAppProtection).EncryptAppData = n.GetBoolValue(); } },
                {"faceIdBlocked", (o,n) => { (o as DefaultManagedAppProtection).FaceIdBlocked = n.GetBoolValue(); } },
                {"minimumRequiredPatchVersion", (o,n) => { (o as DefaultManagedAppProtection).MinimumRequiredPatchVersion = n.GetStringValue(); } },
                {"minimumRequiredSdkVersion", (o,n) => { (o as DefaultManagedAppProtection).MinimumRequiredSdkVersion = n.GetStringValue(); } },
                {"minimumWarningPatchVersion", (o,n) => { (o as DefaultManagedAppProtection).MinimumWarningPatchVersion = n.GetStringValue(); } },
                {"screenCaptureBlocked", (o,n) => { (o as DefaultManagedAppProtection).ScreenCaptureBlocked = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<ManagedAppDataEncryptionType>("appDataEncryptionType", AppDataEncryptionType);
            writer.WriteCollectionOfObjectValues<ManagedMobileApp>("apps", Apps);
            writer.WriteCollectionOfObjectValues<KeyValuePair>("customSettings", CustomSettings);
            writer.WriteIntValue("deployedAppCount", DeployedAppCount);
            writer.WriteObjectValue<ManagedAppPolicyDeploymentSummary>("deploymentSummary", DeploymentSummary);
            writer.WriteBoolValue("disableAppEncryptionIfDeviceEncryptionIsEnabled", DisableAppEncryptionIfDeviceEncryptionIsEnabled);
            writer.WriteBoolValue("encryptAppData", EncryptAppData);
            writer.WriteBoolValue("faceIdBlocked", FaceIdBlocked);
            writer.WriteStringValue("minimumRequiredPatchVersion", MinimumRequiredPatchVersion);
            writer.WriteStringValue("minimumRequiredSdkVersion", MinimumRequiredSdkVersion);
            writer.WriteStringValue("minimumWarningPatchVersion", MinimumWarningPatchVersion);
            writer.WriteBoolValue("screenCaptureBlocked", ScreenCaptureBlocked);
        }
    }
}
