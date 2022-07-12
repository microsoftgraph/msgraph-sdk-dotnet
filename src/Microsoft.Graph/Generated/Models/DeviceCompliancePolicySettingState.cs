using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Device Compilance Policy Setting State for a given device.</summary>
    public class DeviceCompliancePolicySettingState : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Current value of setting on device</summary>
        public string CurrentValue {
            get { return BackingStore?.Get<string>("currentValue"); }
            set { BackingStore?.Set("currentValue", value); }
        }
        /// <summary>Error code for the setting</summary>
        public long? ErrorCode {
            get { return BackingStore?.Get<long?>("errorCode"); }
            set { BackingStore?.Set("errorCode", value); }
        }
        /// <summary>Error description</summary>
        public string ErrorDescription {
            get { return BackingStore?.Get<string>("errorDescription"); }
            set { BackingStore?.Set("errorDescription", value); }
        }
        /// <summary>Name of setting instance that is being reported.</summary>
        public string InstanceDisplayName {
            get { return BackingStore?.Get<string>("instanceDisplayName"); }
            set { BackingStore?.Set("instanceDisplayName", value); }
        }
        /// <summary>The setting that is being reported</summary>
        public string Setting {
            get { return BackingStore?.Get<string>("setting"); }
            set { BackingStore?.Set("setting", value); }
        }
        /// <summary>Localized/user friendly setting name that is being reported</summary>
        public string SettingName {
            get { return BackingStore?.Get<string>("settingName"); }
            set { BackingStore?.Set("settingName", value); }
        }
        /// <summary>Contributing policies</summary>
        public List<SettingSource> Sources {
            get { return BackingStore?.Get<List<SettingSource>>("sources"); }
            set { BackingStore?.Set("sources", value); }
        }
        /// <summary>The state property</summary>
        public ComplianceStatus? State {
            get { return BackingStore?.Get<ComplianceStatus?>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>UserEmail</summary>
        public string UserEmail {
            get { return BackingStore?.Get<string>("userEmail"); }
            set { BackingStore?.Set("userEmail", value); }
        }
        /// <summary>UserId</summary>
        public string UserId {
            get { return BackingStore?.Get<string>("userId"); }
            set { BackingStore?.Set("userId", value); }
        }
        /// <summary>UserName</summary>
        public string UserName {
            get { return BackingStore?.Get<string>("userName"); }
            set { BackingStore?.Set("userName", value); }
        }
        /// <summary>UserPrincipalName.</summary>
        public string UserPrincipalName {
            get { return BackingStore?.Get<string>("userPrincipalName"); }
            set { BackingStore?.Set("userPrincipalName", value); }
        }
        /// <summary>
        /// Instantiates a new deviceCompliancePolicySettingState and sets the default values.
        /// </summary>
        public DeviceCompliancePolicySettingState() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static DeviceCompliancePolicySettingState CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceCompliancePolicySettingState();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"currentValue", n => { CurrentValue = n.GetStringValue(); } },
                {"errorCode", n => { ErrorCode = n.GetLongValue(); } },
                {"errorDescription", n => { ErrorDescription = n.GetStringValue(); } },
                {"instanceDisplayName", n => { InstanceDisplayName = n.GetStringValue(); } },
                {"setting", n => { Setting = n.GetStringValue(); } },
                {"settingName", n => { SettingName = n.GetStringValue(); } },
                {"sources", n => { Sources = n.GetCollectionOfObjectValues<SettingSource>(SettingSource.CreateFromDiscriminatorValue).ToList(); } },
                {"state", n => { State = n.GetEnumValue<ComplianceStatus>(); } },
                {"userEmail", n => { UserEmail = n.GetStringValue(); } },
                {"userId", n => { UserId = n.GetStringValue(); } },
                {"userName", n => { UserName = n.GetStringValue(); } },
                {"userPrincipalName", n => { UserPrincipalName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("currentValue", CurrentValue);
            writer.WriteLongValue("errorCode", ErrorCode);
            writer.WriteStringValue("errorDescription", ErrorDescription);
            writer.WriteStringValue("instanceDisplayName", InstanceDisplayName);
            writer.WriteStringValue("setting", Setting);
            writer.WriteStringValue("settingName", SettingName);
            writer.WriteCollectionOfObjectValues<SettingSource>("sources", Sources);
            writer.WriteEnumValue<ComplianceStatus>("state", State);
            writer.WriteStringValue("userEmail", UserEmail);
            writer.WriteStringValue("userId", UserId);
            writer.WriteStringValue("userName", UserName);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
