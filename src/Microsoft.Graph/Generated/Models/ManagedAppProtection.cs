using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ManagedAppProtection : ManagedAppPolicy, IParsable {
        /// <summary>Data storage locations where a user may store managed data.</summary>
        public List<string> AllowedDataStorageLocations {
            get { return BackingStore?.Get<List<string>>("allowedDataStorageLocations"); }
            set { BackingStore?.Set("allowedDataStorageLocations", value); }
        }
        /// <summary>Data can be transferred from/to these classes of apps</summary>
        public ManagedAppDataTransferLevel? AllowedInboundDataTransferSources {
            get { return BackingStore?.Get<ManagedAppDataTransferLevel?>("allowedInboundDataTransferSources"); }
            set { BackingStore?.Set("allowedInboundDataTransferSources", value); }
        }
        /// <summary>Represents the level to which the device&apos;s clipboard may be shared between apps</summary>
        public ManagedAppClipboardSharingLevel? AllowedOutboundClipboardSharingLevel {
            get { return BackingStore?.Get<ManagedAppClipboardSharingLevel?>("allowedOutboundClipboardSharingLevel"); }
            set { BackingStore?.Set("allowedOutboundClipboardSharingLevel", value); }
        }
        /// <summary>Data can be transferred from/to these classes of apps</summary>
        public ManagedAppDataTransferLevel? AllowedOutboundDataTransferDestinations {
            get { return BackingStore?.Get<ManagedAppDataTransferLevel?>("allowedOutboundDataTransferDestinations"); }
            set { BackingStore?.Set("allowedOutboundDataTransferDestinations", value); }
        }
        /// <summary>Indicates whether contacts can be synced to the user&apos;s device.</summary>
        public bool? ContactSyncBlocked {
            get { return BackingStore?.Get<bool?>("contactSyncBlocked"); }
            set { BackingStore?.Set("contactSyncBlocked", value); }
        }
        /// <summary>Indicates whether the backup of a managed app&apos;s data is blocked.</summary>
        public bool? DataBackupBlocked {
            get { return BackingStore?.Get<bool?>("dataBackupBlocked"); }
            set { BackingStore?.Set("dataBackupBlocked", value); }
        }
        /// <summary>Indicates whether device compliance is required.</summary>
        public bool? DeviceComplianceRequired {
            get { return BackingStore?.Get<bool?>("deviceComplianceRequired"); }
            set { BackingStore?.Set("deviceComplianceRequired", value); }
        }
        /// <summary>Indicates whether use of the app pin is required if the device pin is set.</summary>
        public bool? DisableAppPinIfDevicePinIsSet {
            get { return BackingStore?.Get<bool?>("disableAppPinIfDevicePinIsSet"); }
            set { BackingStore?.Set("disableAppPinIfDevicePinIsSet", value); }
        }
        /// <summary>Indicates whether use of the fingerprint reader is allowed in place of a pin if PinRequired is set to True.</summary>
        public bool? FingerprintBlocked {
            get { return BackingStore?.Get<bool?>("fingerprintBlocked"); }
            set { BackingStore?.Set("fingerprintBlocked", value); }
        }
        /// <summary>Type of managed browser</summary>
        public ManagedBrowserType? ManagedBrowser {
            get { return BackingStore?.Get<ManagedBrowserType?>("managedBrowser"); }
            set { BackingStore?.Set("managedBrowser", value); }
        }
        /// <summary>Indicates whether internet links should be opened in the managed browser app, or any custom browser specified by CustomBrowserProtocol (for iOS) or CustomBrowserPackageId/CustomBrowserDisplayName (for Android)</summary>
        public bool? ManagedBrowserToOpenLinksRequired {
            get { return BackingStore?.Get<bool?>("managedBrowserToOpenLinksRequired"); }
            set { BackingStore?.Set("managedBrowserToOpenLinksRequired", value); }
        }
        /// <summary>Maximum number of incorrect pin retry attempts before the managed app is either blocked or wiped.</summary>
        public int? MaximumPinRetries {
            get { return BackingStore?.Get<int?>("maximumPinRetries"); }
            set { BackingStore?.Set("maximumPinRetries", value); }
        }
        /// <summary>Minimum pin length required for an app-level pin if PinRequired is set to True</summary>
        public int? MinimumPinLength {
            get { return BackingStore?.Get<int?>("minimumPinLength"); }
            set { BackingStore?.Set("minimumPinLength", value); }
        }
        /// <summary>Versions less than the specified version will block the managed app from accessing company data.</summary>
        public string MinimumRequiredAppVersion {
            get { return BackingStore?.Get<string>("minimumRequiredAppVersion"); }
            set { BackingStore?.Set("minimumRequiredAppVersion", value); }
        }
        /// <summary>Versions less than the specified version will block the managed app from accessing company data.</summary>
        public string MinimumRequiredOsVersion {
            get { return BackingStore?.Get<string>("minimumRequiredOsVersion"); }
            set { BackingStore?.Set("minimumRequiredOsVersion", value); }
        }
        /// <summary>Versions less than the specified version will result in warning message on the managed app.</summary>
        public string MinimumWarningAppVersion {
            get { return BackingStore?.Get<string>("minimumWarningAppVersion"); }
            set { BackingStore?.Set("minimumWarningAppVersion", value); }
        }
        /// <summary>Versions less than the specified version will result in warning message on the managed app from accessing company data.</summary>
        public string MinimumWarningOsVersion {
            get { return BackingStore?.Get<string>("minimumWarningOsVersion"); }
            set { BackingStore?.Set("minimumWarningOsVersion", value); }
        }
        /// <summary>Indicates whether organizational credentials are required for app use.</summary>
        public bool? OrganizationalCredentialsRequired {
            get { return BackingStore?.Get<bool?>("organizationalCredentialsRequired"); }
            set { BackingStore?.Set("organizationalCredentialsRequired", value); }
        }
        /// <summary>TimePeriod before the all-level pin must be reset if PinRequired is set to True.</summary>
        public TimeSpan? PeriodBeforePinReset {
            get { return BackingStore?.Get<TimeSpan?>("periodBeforePinReset"); }
            set { BackingStore?.Set("periodBeforePinReset", value); }
        }
        /// <summary>The period after which access is checked when the device is not connected to the internet.</summary>
        public TimeSpan? PeriodOfflineBeforeAccessCheck {
            get { return BackingStore?.Get<TimeSpan?>("periodOfflineBeforeAccessCheck"); }
            set { BackingStore?.Set("periodOfflineBeforeAccessCheck", value); }
        }
        /// <summary>The amount of time an app is allowed to remain disconnected from the internet before all managed data it is wiped.</summary>
        public TimeSpan? PeriodOfflineBeforeWipeIsEnforced {
            get { return BackingStore?.Get<TimeSpan?>("periodOfflineBeforeWipeIsEnforced"); }
            set { BackingStore?.Set("periodOfflineBeforeWipeIsEnforced", value); }
        }
        /// <summary>The period after which access is checked when the device is connected to the internet.</summary>
        public TimeSpan? PeriodOnlineBeforeAccessCheck {
            get { return BackingStore?.Get<TimeSpan?>("periodOnlineBeforeAccessCheck"); }
            set { BackingStore?.Set("periodOnlineBeforeAccessCheck", value); }
        }
        /// <summary>Character set which is to be used for a user&apos;s app PIN</summary>
        public ManagedAppPinCharacterSet? PinCharacterSet {
            get { return BackingStore?.Get<ManagedAppPinCharacterSet?>("pinCharacterSet"); }
            set { BackingStore?.Set("pinCharacterSet", value); }
        }
        /// <summary>Indicates whether an app-level pin is required.</summary>
        public bool? PinRequired {
            get { return BackingStore?.Get<bool?>("pinRequired"); }
            set { BackingStore?.Set("pinRequired", value); }
        }
        /// <summary>Indicates whether printing is allowed from managed apps.</summary>
        public bool? PrintBlocked {
            get { return BackingStore?.Get<bool?>("printBlocked"); }
            set { BackingStore?.Set("printBlocked", value); }
        }
        /// <summary>Indicates whether users may use the &apos;Save As&apos; menu item to save a copy of protected files.</summary>
        public bool? SaveAsBlocked {
            get { return BackingStore?.Get<bool?>("saveAsBlocked"); }
            set { BackingStore?.Set("saveAsBlocked", value); }
        }
        /// <summary>Indicates whether simplePin is blocked.</summary>
        public bool? SimplePinBlocked {
            get { return BackingStore?.Get<bool?>("simplePinBlocked"); }
            set { BackingStore?.Set("simplePinBlocked", value); }
        }
        /// <summary>
        /// Instantiates a new ManagedAppProtection and sets the default values.
        /// </summary>
        public ManagedAppProtection() : base() {
            Type = "#microsoft.graph.managedAppProtection";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ManagedAppProtection CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.defaultManagedAppProtection" => new DefaultManagedAppProtection(),
                "#microsoft.graph.targetedManagedAppProtection" => new TargetedManagedAppProtection(),
                _ => new ManagedAppProtection(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"allowedDataStorageLocations", n => { AllowedDataStorageLocations = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"allowedInboundDataTransferSources", n => { AllowedInboundDataTransferSources = n.GetEnumValue<ManagedAppDataTransferLevel>(); } },
                {"allowedOutboundClipboardSharingLevel", n => { AllowedOutboundClipboardSharingLevel = n.GetEnumValue<ManagedAppClipboardSharingLevel>(); } },
                {"allowedOutboundDataTransferDestinations", n => { AllowedOutboundDataTransferDestinations = n.GetEnumValue<ManagedAppDataTransferLevel>(); } },
                {"contactSyncBlocked", n => { ContactSyncBlocked = n.GetBoolValue(); } },
                {"dataBackupBlocked", n => { DataBackupBlocked = n.GetBoolValue(); } },
                {"deviceComplianceRequired", n => { DeviceComplianceRequired = n.GetBoolValue(); } },
                {"disableAppPinIfDevicePinIsSet", n => { DisableAppPinIfDevicePinIsSet = n.GetBoolValue(); } },
                {"fingerprintBlocked", n => { FingerprintBlocked = n.GetBoolValue(); } },
                {"managedBrowser", n => { ManagedBrowser = n.GetEnumValue<ManagedBrowserType>(); } },
                {"managedBrowserToOpenLinksRequired", n => { ManagedBrowserToOpenLinksRequired = n.GetBoolValue(); } },
                {"maximumPinRetries", n => { MaximumPinRetries = n.GetIntValue(); } },
                {"minimumPinLength", n => { MinimumPinLength = n.GetIntValue(); } },
                {"minimumRequiredAppVersion", n => { MinimumRequiredAppVersion = n.GetStringValue(); } },
                {"minimumRequiredOsVersion", n => { MinimumRequiredOsVersion = n.GetStringValue(); } },
                {"minimumWarningAppVersion", n => { MinimumWarningAppVersion = n.GetStringValue(); } },
                {"minimumWarningOsVersion", n => { MinimumWarningOsVersion = n.GetStringValue(); } },
                {"organizationalCredentialsRequired", n => { OrganizationalCredentialsRequired = n.GetBoolValue(); } },
                {"periodBeforePinReset", n => { PeriodBeforePinReset = n.GetTimeSpanValue(); } },
                {"periodOfflineBeforeAccessCheck", n => { PeriodOfflineBeforeAccessCheck = n.GetTimeSpanValue(); } },
                {"periodOfflineBeforeWipeIsEnforced", n => { PeriodOfflineBeforeWipeIsEnforced = n.GetTimeSpanValue(); } },
                {"periodOnlineBeforeAccessCheck", n => { PeriodOnlineBeforeAccessCheck = n.GetTimeSpanValue(); } },
                {"pinCharacterSet", n => { PinCharacterSet = n.GetEnumValue<ManagedAppPinCharacterSet>(); } },
                {"pinRequired", n => { PinRequired = n.GetBoolValue(); } },
                {"printBlocked", n => { PrintBlocked = n.GetBoolValue(); } },
                {"saveAsBlocked", n => { SaveAsBlocked = n.GetBoolValue(); } },
                {"simplePinBlocked", n => { SimplePinBlocked = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfPrimitiveValues<string>("allowedDataStorageLocations", AllowedDataStorageLocations);
            writer.WriteEnumValue<ManagedAppDataTransferLevel>("allowedInboundDataTransferSources", AllowedInboundDataTransferSources);
            writer.WriteEnumValue<ManagedAppClipboardSharingLevel>("allowedOutboundClipboardSharingLevel", AllowedOutboundClipboardSharingLevel);
            writer.WriteEnumValue<ManagedAppDataTransferLevel>("allowedOutboundDataTransferDestinations", AllowedOutboundDataTransferDestinations);
            writer.WriteBoolValue("contactSyncBlocked", ContactSyncBlocked);
            writer.WriteBoolValue("dataBackupBlocked", DataBackupBlocked);
            writer.WriteBoolValue("deviceComplianceRequired", DeviceComplianceRequired);
            writer.WriteBoolValue("disableAppPinIfDevicePinIsSet", DisableAppPinIfDevicePinIsSet);
            writer.WriteBoolValue("fingerprintBlocked", FingerprintBlocked);
            writer.WriteEnumValue<ManagedBrowserType>("managedBrowser", ManagedBrowser);
            writer.WriteBoolValue("managedBrowserToOpenLinksRequired", ManagedBrowserToOpenLinksRequired);
            writer.WriteIntValue("maximumPinRetries", MaximumPinRetries);
            writer.WriteIntValue("minimumPinLength", MinimumPinLength);
            writer.WriteStringValue("minimumRequiredAppVersion", MinimumRequiredAppVersion);
            writer.WriteStringValue("minimumRequiredOsVersion", MinimumRequiredOsVersion);
            writer.WriteStringValue("minimumWarningAppVersion", MinimumWarningAppVersion);
            writer.WriteStringValue("minimumWarningOsVersion", MinimumWarningOsVersion);
            writer.WriteBoolValue("organizationalCredentialsRequired", OrganizationalCredentialsRequired);
            writer.WriteTimeSpanValue("periodBeforePinReset", PeriodBeforePinReset);
            writer.WriteTimeSpanValue("periodOfflineBeforeAccessCheck", PeriodOfflineBeforeAccessCheck);
            writer.WriteTimeSpanValue("periodOfflineBeforeWipeIsEnforced", PeriodOfflineBeforeWipeIsEnforced);
            writer.WriteTimeSpanValue("periodOnlineBeforeAccessCheck", PeriodOnlineBeforeAccessCheck);
            writer.WriteEnumValue<ManagedAppPinCharacterSet>("pinCharacterSet", PinCharacterSet);
            writer.WriteBoolValue("pinRequired", PinRequired);
            writer.WriteBoolValue("printBlocked", PrintBlocked);
            writer.WriteBoolValue("saveAsBlocked", SaveAsBlocked);
            writer.WriteBoolValue("simplePinBlocked", SimplePinBlocked);
        }
    }
}
