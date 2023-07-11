using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>
    /// This topic provides descriptions of the declared methods, properties and relationships exposed by the windowsPhone81GeneralConfiguration resource.
    /// </summary>
    public class WindowsPhone81GeneralConfiguration : DeviceConfiguration, IParsable {
        /// <summary>Value indicating whether this policy only applies to Windows Phone 8.1. This property is read-only.</summary>
        public bool? ApplyOnlyToWindowsPhone81 {
            get { return BackingStore?.Get<bool?>("applyOnlyToWindowsPhone81"); }
            set { BackingStore?.Set("applyOnlyToWindowsPhone81", value); }
        }
        /// <summary>Indicates whether or not to block copy paste.</summary>
        public bool? AppsBlockCopyPaste {
            get { return BackingStore?.Get<bool?>("appsBlockCopyPaste"); }
            set { BackingStore?.Set("appsBlockCopyPaste", value); }
        }
        /// <summary>Indicates whether or not to block bluetooth.</summary>
        public bool? BluetoothBlocked {
            get { return BackingStore?.Get<bool?>("bluetoothBlocked"); }
            set { BackingStore?.Set("bluetoothBlocked", value); }
        }
        /// <summary>Indicates whether or not to block camera.</summary>
        public bool? CameraBlocked {
            get { return BackingStore?.Get<bool?>("cameraBlocked"); }
            set { BackingStore?.Set("cameraBlocked", value); }
        }
        /// <summary>Indicates whether or not to block Wi-Fi tethering. Has no impact if Wi-Fi is blocked.</summary>
        public bool? CellularBlockWifiTethering {
            get { return BackingStore?.Get<bool?>("cellularBlockWifiTethering"); }
            set { BackingStore?.Set("cellularBlockWifiTethering", value); }
        }
        /// <summary>Possible values of the compliance app list.</summary>
        public AppListType? CompliantAppListType {
            get { return BackingStore?.Get<AppListType?>("compliantAppListType"); }
            set { BackingStore?.Set("compliantAppListType", value); }
        }
        /// <summary>List of apps in the compliance (either allow list or block list, controlled by CompliantAppListType). This collection can contain a maximum of 10000 elements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<AppListItem>? CompliantAppsList {
            get { return BackingStore?.Get<List<AppListItem>?>("compliantAppsList"); }
            set { BackingStore?.Set("compliantAppsList", value); }
        }
#nullable restore
#else
        public List<AppListItem> CompliantAppsList {
            get { return BackingStore?.Get<List<AppListItem>>("compliantAppsList"); }
            set { BackingStore?.Set("compliantAppsList", value); }
        }
#endif
        /// <summary>Indicates whether or not to block diagnostic data submission.</summary>
        public bool? DiagnosticDataBlockSubmission {
            get { return BackingStore?.Get<bool?>("diagnosticDataBlockSubmission"); }
            set { BackingStore?.Set("diagnosticDataBlockSubmission", value); }
        }
        /// <summary>Indicates whether or not to block custom email accounts.</summary>
        public bool? EmailBlockAddingAccounts {
            get { return BackingStore?.Get<bool?>("emailBlockAddingAccounts"); }
            set { BackingStore?.Set("emailBlockAddingAccounts", value); }
        }
        /// <summary>Indicates whether or not to block location services.</summary>
        public bool? LocationServicesBlocked {
            get { return BackingStore?.Get<bool?>("locationServicesBlocked"); }
            set { BackingStore?.Set("locationServicesBlocked", value); }
        }
        /// <summary>Indicates whether or not to block using a Microsoft Account.</summary>
        public bool? MicrosoftAccountBlocked {
            get { return BackingStore?.Get<bool?>("microsoftAccountBlocked"); }
            set { BackingStore?.Set("microsoftAccountBlocked", value); }
        }
        /// <summary>Indicates whether or not to block Near-Field Communication.</summary>
        public bool? NfcBlocked {
            get { return BackingStore?.Get<bool?>("nfcBlocked"); }
            set { BackingStore?.Set("nfcBlocked", value); }
        }
        /// <summary>Indicates whether or not to block syncing the calendar.</summary>
        public bool? PasswordBlockSimple {
            get { return BackingStore?.Get<bool?>("passwordBlockSimple"); }
            set { BackingStore?.Set("passwordBlockSimple", value); }
        }
        /// <summary>Number of days before the password expires.</summary>
        public int? PasswordExpirationDays {
            get { return BackingStore?.Get<int?>("passwordExpirationDays"); }
            set { BackingStore?.Set("passwordExpirationDays", value); }
        }
        /// <summary>Number of character sets a password must contain.</summary>
        public int? PasswordMinimumCharacterSetCount {
            get { return BackingStore?.Get<int?>("passwordMinimumCharacterSetCount"); }
            set { BackingStore?.Set("passwordMinimumCharacterSetCount", value); }
        }
        /// <summary>Minimum length of passwords.</summary>
        public int? PasswordMinimumLength {
            get { return BackingStore?.Get<int?>("passwordMinimumLength"); }
            set { BackingStore?.Set("passwordMinimumLength", value); }
        }
        /// <summary>Minutes of inactivity before screen timeout.</summary>
        public int? PasswordMinutesOfInactivityBeforeScreenTimeout {
            get { return BackingStore?.Get<int?>("passwordMinutesOfInactivityBeforeScreenTimeout"); }
            set { BackingStore?.Set("passwordMinutesOfInactivityBeforeScreenTimeout", value); }
        }
        /// <summary>Number of previous passwords to block. Valid values 0 to 24</summary>
        public int? PasswordPreviousPasswordBlockCount {
            get { return BackingStore?.Get<int?>("passwordPreviousPasswordBlockCount"); }
            set { BackingStore?.Set("passwordPreviousPasswordBlockCount", value); }
        }
        /// <summary>Indicates whether or not to require a password.</summary>
        public bool? PasswordRequired {
            get { return BackingStore?.Get<bool?>("passwordRequired"); }
            set { BackingStore?.Set("passwordRequired", value); }
        }
        /// <summary>Possible values of required passwords.</summary>
        public RequiredPasswordType? PasswordRequiredType {
            get { return BackingStore?.Get<RequiredPasswordType?>("passwordRequiredType"); }
            set { BackingStore?.Set("passwordRequiredType", value); }
        }
        /// <summary>Number of sign in failures allowed before factory reset.</summary>
        public int? PasswordSignInFailureCountBeforeFactoryReset {
            get { return BackingStore?.Get<int?>("passwordSignInFailureCountBeforeFactoryReset"); }
            set { BackingStore?.Set("passwordSignInFailureCountBeforeFactoryReset", value); }
        }
        /// <summary>Indicates whether or not to block screenshots.</summary>
        public bool? ScreenCaptureBlocked {
            get { return BackingStore?.Get<bool?>("screenCaptureBlocked"); }
            set { BackingStore?.Set("screenCaptureBlocked", value); }
        }
        /// <summary>Indicates whether or not to block removable storage.</summary>
        public bool? StorageBlockRemovableStorage {
            get { return BackingStore?.Get<bool?>("storageBlockRemovableStorage"); }
            set { BackingStore?.Set("storageBlockRemovableStorage", value); }
        }
        /// <summary>Indicates whether or not to require encryption.</summary>
        public bool? StorageRequireEncryption {
            get { return BackingStore?.Get<bool?>("storageRequireEncryption"); }
            set { BackingStore?.Set("storageRequireEncryption", value); }
        }
        /// <summary>Indicates whether or not to block the web browser.</summary>
        public bool? WebBrowserBlocked {
            get { return BackingStore?.Get<bool?>("webBrowserBlocked"); }
            set { BackingStore?.Set("webBrowserBlocked", value); }
        }
        /// <summary>Indicates whether or not to block automatically connecting to Wi-Fi hotspots. Has no impact if Wi-Fi is blocked.</summary>
        public bool? WifiBlockAutomaticConnectHotspots {
            get { return BackingStore?.Get<bool?>("wifiBlockAutomaticConnectHotspots"); }
            set { BackingStore?.Set("wifiBlockAutomaticConnectHotspots", value); }
        }
        /// <summary>Indicates whether or not to block Wi-Fi.</summary>
        public bool? WifiBlocked {
            get { return BackingStore?.Get<bool?>("wifiBlocked"); }
            set { BackingStore?.Set("wifiBlocked", value); }
        }
        /// <summary>Indicates whether or not to block Wi-Fi hotspot reporting. Has no impact if Wi-Fi is blocked.</summary>
        public bool? WifiBlockHotspotReporting {
            get { return BackingStore?.Get<bool?>("wifiBlockHotspotReporting"); }
            set { BackingStore?.Set("wifiBlockHotspotReporting", value); }
        }
        /// <summary>Indicates whether or not to block the Windows Store.</summary>
        public bool? WindowsStoreBlocked {
            get { return BackingStore?.Get<bool?>("windowsStoreBlocked"); }
            set { BackingStore?.Set("windowsStoreBlocked", value); }
        }
        /// <summary>
        /// Instantiates a new windowsPhone81GeneralConfiguration and sets the default values.
        /// </summary>
        public WindowsPhone81GeneralConfiguration() : base() {
            OdataType = "#microsoft.graph.windowsPhone81GeneralConfiguration";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new WindowsPhone81GeneralConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WindowsPhone81GeneralConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"applyOnlyToWindowsPhone81", n => { ApplyOnlyToWindowsPhone81 = n.GetBoolValue(); } },
                {"appsBlockCopyPaste", n => { AppsBlockCopyPaste = n.GetBoolValue(); } },
                {"bluetoothBlocked", n => { BluetoothBlocked = n.GetBoolValue(); } },
                {"cameraBlocked", n => { CameraBlocked = n.GetBoolValue(); } },
                {"cellularBlockWifiTethering", n => { CellularBlockWifiTethering = n.GetBoolValue(); } },
                {"compliantAppListType", n => { CompliantAppListType = n.GetEnumValue<AppListType>(); } },
                {"compliantAppsList", n => { CompliantAppsList = n.GetCollectionOfObjectValues<AppListItem>(AppListItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"diagnosticDataBlockSubmission", n => { DiagnosticDataBlockSubmission = n.GetBoolValue(); } },
                {"emailBlockAddingAccounts", n => { EmailBlockAddingAccounts = n.GetBoolValue(); } },
                {"locationServicesBlocked", n => { LocationServicesBlocked = n.GetBoolValue(); } },
                {"microsoftAccountBlocked", n => { MicrosoftAccountBlocked = n.GetBoolValue(); } },
                {"nfcBlocked", n => { NfcBlocked = n.GetBoolValue(); } },
                {"passwordBlockSimple", n => { PasswordBlockSimple = n.GetBoolValue(); } },
                {"passwordExpirationDays", n => { PasswordExpirationDays = n.GetIntValue(); } },
                {"passwordMinimumCharacterSetCount", n => { PasswordMinimumCharacterSetCount = n.GetIntValue(); } },
                {"passwordMinimumLength", n => { PasswordMinimumLength = n.GetIntValue(); } },
                {"passwordMinutesOfInactivityBeforeScreenTimeout", n => { PasswordMinutesOfInactivityBeforeScreenTimeout = n.GetIntValue(); } },
                {"passwordPreviousPasswordBlockCount", n => { PasswordPreviousPasswordBlockCount = n.GetIntValue(); } },
                {"passwordRequired", n => { PasswordRequired = n.GetBoolValue(); } },
                {"passwordRequiredType", n => { PasswordRequiredType = n.GetEnumValue<RequiredPasswordType>(); } },
                {"passwordSignInFailureCountBeforeFactoryReset", n => { PasswordSignInFailureCountBeforeFactoryReset = n.GetIntValue(); } },
                {"screenCaptureBlocked", n => { ScreenCaptureBlocked = n.GetBoolValue(); } },
                {"storageBlockRemovableStorage", n => { StorageBlockRemovableStorage = n.GetBoolValue(); } },
                {"storageRequireEncryption", n => { StorageRequireEncryption = n.GetBoolValue(); } },
                {"webBrowserBlocked", n => { WebBrowserBlocked = n.GetBoolValue(); } },
                {"wifiBlockAutomaticConnectHotspots", n => { WifiBlockAutomaticConnectHotspots = n.GetBoolValue(); } },
                {"wifiBlocked", n => { WifiBlocked = n.GetBoolValue(); } },
                {"wifiBlockHotspotReporting", n => { WifiBlockHotspotReporting = n.GetBoolValue(); } },
                {"windowsStoreBlocked", n => { WindowsStoreBlocked = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("appsBlockCopyPaste", AppsBlockCopyPaste);
            writer.WriteBoolValue("bluetoothBlocked", BluetoothBlocked);
            writer.WriteBoolValue("cameraBlocked", CameraBlocked);
            writer.WriteBoolValue("cellularBlockWifiTethering", CellularBlockWifiTethering);
            writer.WriteEnumValue<AppListType>("compliantAppListType", CompliantAppListType);
            writer.WriteCollectionOfObjectValues<AppListItem>("compliantAppsList", CompliantAppsList);
            writer.WriteBoolValue("diagnosticDataBlockSubmission", DiagnosticDataBlockSubmission);
            writer.WriteBoolValue("emailBlockAddingAccounts", EmailBlockAddingAccounts);
            writer.WriteBoolValue("locationServicesBlocked", LocationServicesBlocked);
            writer.WriteBoolValue("microsoftAccountBlocked", MicrosoftAccountBlocked);
            writer.WriteBoolValue("nfcBlocked", NfcBlocked);
            writer.WriteBoolValue("passwordBlockSimple", PasswordBlockSimple);
            writer.WriteIntValue("passwordExpirationDays", PasswordExpirationDays);
            writer.WriteIntValue("passwordMinimumCharacterSetCount", PasswordMinimumCharacterSetCount);
            writer.WriteIntValue("passwordMinimumLength", PasswordMinimumLength);
            writer.WriteIntValue("passwordMinutesOfInactivityBeforeScreenTimeout", PasswordMinutesOfInactivityBeforeScreenTimeout);
            writer.WriteIntValue("passwordPreviousPasswordBlockCount", PasswordPreviousPasswordBlockCount);
            writer.WriteBoolValue("passwordRequired", PasswordRequired);
            writer.WriteEnumValue<RequiredPasswordType>("passwordRequiredType", PasswordRequiredType);
            writer.WriteIntValue("passwordSignInFailureCountBeforeFactoryReset", PasswordSignInFailureCountBeforeFactoryReset);
            writer.WriteBoolValue("screenCaptureBlocked", ScreenCaptureBlocked);
            writer.WriteBoolValue("storageBlockRemovableStorage", StorageBlockRemovableStorage);
            writer.WriteBoolValue("storageRequireEncryption", StorageRequireEncryption);
            writer.WriteBoolValue("webBrowserBlocked", WebBrowserBlocked);
            writer.WriteBoolValue("wifiBlockAutomaticConnectHotspots", WifiBlockAutomaticConnectHotspots);
            writer.WriteBoolValue("wifiBlocked", WifiBlocked);
            writer.WriteBoolValue("wifiBlockHotspotReporting", WifiBlockHotspotReporting);
            writer.WriteBoolValue("windowsStoreBlocked", WindowsStoreBlocked);
        }
    }
}
