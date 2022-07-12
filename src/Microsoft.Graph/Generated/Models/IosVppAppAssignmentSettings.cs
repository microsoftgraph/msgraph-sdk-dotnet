using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IosVppAppAssignmentSettings : MobileAppAssignmentSettings, IParsable {
        /// <summary>Whether or not to use device licensing.</summary>
        public bool? UseDeviceLicensing {
            get { return BackingStore?.Get<bool?>("useDeviceLicensing"); }
            set { BackingStore?.Set("useDeviceLicensing", value); }
        }
        /// <summary>The VPN Configuration Id to apply for this app.</summary>
        public string VpnConfigurationId {
            get { return BackingStore?.Get<string>("vpnConfigurationId"); }
            set { BackingStore?.Set("vpnConfigurationId", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new IosVppAppAssignmentSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IosVppAppAssignmentSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"useDeviceLicensing", n => { UseDeviceLicensing = n.GetBoolValue(); } },
                {"vpnConfigurationId", n => { VpnConfigurationId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("useDeviceLicensing", UseDeviceLicensing);
            writer.WriteStringValue("vpnConfigurationId", VpnConfigurationId);
        }
    }
}
