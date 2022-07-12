using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Device Compliance Policy State for a given device.</summary>
    public class DeviceCompliancePolicyState : Entity, IParsable {
        /// <summary>The name of the policy for this policyBase</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Supported platform types for policies.</summary>
        public PolicyPlatformType? PlatformType {
            get { return BackingStore?.Get<PolicyPlatformType?>("platformType"); }
            set { BackingStore?.Set("platformType", value); }
        }
        /// <summary>Count of how many setting a policy holds</summary>
        public int? SettingCount {
            get { return BackingStore?.Get<int?>("settingCount"); }
            set { BackingStore?.Set("settingCount", value); }
        }
        /// <summary>The settingStates property</summary>
        public List<DeviceCompliancePolicySettingState> SettingStates {
            get { return BackingStore?.Get<List<DeviceCompliancePolicySettingState>>("settingStates"); }
            set { BackingStore?.Set("settingStates", value); }
        }
        /// <summary>The state property</summary>
        public ComplianceStatus? State {
            get { return BackingStore?.Get<ComplianceStatus?>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>The version of the policy</summary>
        public int? Version {
            get { return BackingStore?.Get<int?>("version"); }
            set { BackingStore?.Set("version", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceCompliancePolicyState CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceCompliancePolicyState();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"platformType", n => { PlatformType = n.GetEnumValue<PolicyPlatformType>(); } },
                {"settingCount", n => { SettingCount = n.GetIntValue(); } },
                {"settingStates", n => { SettingStates = n.GetCollectionOfObjectValues<DeviceCompliancePolicySettingState>(DeviceCompliancePolicySettingState.CreateFromDiscriminatorValue).ToList(); } },
                {"state", n => { State = n.GetEnumValue<ComplianceStatus>(); } },
                {"version", n => { Version = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteEnumValue<PolicyPlatformType>("platformType", PlatformType);
            writer.WriteIntValue("settingCount", SettingCount);
            writer.WriteCollectionOfObjectValues<DeviceCompliancePolicySettingState>("settingStates", SettingStates);
            writer.WriteEnumValue<ComplianceStatus>("state", State);
            writer.WriteIntValue("version", Version);
        }
    }
}
