using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class DefaultManagedAppProtection : ManagedAppProtection, IParsable {
        /// <summary>Represents the level to which app data is encrypted for managed apps</summary>
        public ManagedAppDataEncryptionType? AppDataEncryptionType {
            get { return BackingStore?.Get<ManagedAppDataEncryptionType?>("appDataEncryptionType"); }
            set { BackingStore?.Set("appDataEncryptionType", value); }
        }
        /// <summary>List of apps to which the policy is deployed.</summary>
        public List<ManagedMobileApp> Apps {
            get { return BackingStore?.Get<List<ManagedMobileApp>>("apps"); }
            set { BackingStore?.Set("apps", value); }
        }
        /// <summary>A set of string key and string value pairs to be sent to the affected users, unalterned by this service</summary>
        public List<KeyValuePair> CustomSettings {
            get { return BackingStore?.Get<List<KeyValuePair>>("customSettings"); }
            set { BackingStore?.Set("customSettings", value); }
        }
        /// <summary>Count of apps to which the current policy is deployed.</summary>
        public int? DeployedAppCount {
            get { return BackingStore?.Get<int?>("deployedAppCount"); }
            set { BackingStore?.Set("deployedAppCount", value); }
        }
        /// <summary>Navigation property to deployment summary of the configuration.</summary>
        public ManagedAppPolicyDeploymentSummary DeploymentSummary {
            get { return BackingStore?.Get<ManagedAppPolicyDeploymentSummary>("deploymentSummary"); }
            set { BackingStore?.Set("deploymentSummary", value); }
        }
        /// <summary>When this setting is enabled, app level encryption is disabled if device level encryption is enabled. (Android only)</summary>
        public bool? DisableAppEncryptionIfDeviceEncryptionIsEnabled {
            get { return BackingStore?.Get<bool?>("disableAppEncryptionIfDeviceEncryptionIsEnabled"); }
            set { BackingStore?.Set("disableAppEncryptionIfDeviceEncryptionIsEnabled", value); }
        }
        /// <summary>Indicates whether managed-app data should be encrypted. (Android only)</summary>
        public bool? EncryptAppData {
            get { return BackingStore?.Get<bool?>("encryptAppData"); }
            set { BackingStore?.Set("encryptAppData", value); }
        }
        /// <summary>Indicates whether use of the FaceID is allowed in place of a pin if PinRequired is set to True. (iOS Only)</summary>
        public bool? FaceIdBlocked {
            get { return BackingStore?.Get<bool?>("faceIdBlocked"); }
            set { BackingStore?.Set("faceIdBlocked", value); }
        }
        /// <summary>Define the oldest required Android security patch level a user can have to gain secure access to the app. (Android only)</summary>
        public string MinimumRequiredPatchVersion {
            get { return BackingStore?.Get<string>("minimumRequiredPatchVersion"); }
            set { BackingStore?.Set("minimumRequiredPatchVersion", value); }
        }
        /// <summary>Versions less than the specified version will block the managed app from accessing company data. (iOS Only)</summary>
        public string MinimumRequiredSdkVersion {
            get { return BackingStore?.Get<string>("minimumRequiredSdkVersion"); }
            set { BackingStore?.Set("minimumRequiredSdkVersion", value); }
        }
        /// <summary>Define the oldest recommended Android security patch level a user can have for secure access to the app. (Android only)</summary>
        public string MinimumWarningPatchVersion {
            get { return BackingStore?.Get<string>("minimumWarningPatchVersion"); }
            set { BackingStore?.Set("minimumWarningPatchVersion", value); }
        }
        /// <summary>Indicates whether screen capture is blocked. (Android only)</summary>
        public bool? ScreenCaptureBlocked {
            get { return BackingStore?.Get<bool?>("screenCaptureBlocked"); }
            set { BackingStore?.Set("screenCaptureBlocked", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DefaultManagedAppProtection CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DefaultManagedAppProtection();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appDataEncryptionType", n => { AppDataEncryptionType = n.GetEnumValue<ManagedAppDataEncryptionType>(); } },
                {"apps", n => { Apps = n.GetCollectionOfObjectValues<ManagedMobileApp>(ManagedMobileApp.CreateFromDiscriminatorValue).ToList(); } },
                {"customSettings", n => { CustomSettings = n.GetCollectionOfObjectValues<KeyValuePair>(KeyValuePair.CreateFromDiscriminatorValue).ToList(); } },
                {"deployedAppCount", n => { DeployedAppCount = n.GetIntValue(); } },
                {"deploymentSummary", n => { DeploymentSummary = n.GetObjectValue<ManagedAppPolicyDeploymentSummary>(ManagedAppPolicyDeploymentSummary.CreateFromDiscriminatorValue); } },
                {"disableAppEncryptionIfDeviceEncryptionIsEnabled", n => { DisableAppEncryptionIfDeviceEncryptionIsEnabled = n.GetBoolValue(); } },
                {"encryptAppData", n => { EncryptAppData = n.GetBoolValue(); } },
                {"faceIdBlocked", n => { FaceIdBlocked = n.GetBoolValue(); } },
                {"minimumRequiredPatchVersion", n => { MinimumRequiredPatchVersion = n.GetStringValue(); } },
                {"minimumRequiredSdkVersion", n => { MinimumRequiredSdkVersion = n.GetStringValue(); } },
                {"minimumWarningPatchVersion", n => { MinimumWarningPatchVersion = n.GetStringValue(); } },
                {"screenCaptureBlocked", n => { ScreenCaptureBlocked = n.GetBoolValue(); } },
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
