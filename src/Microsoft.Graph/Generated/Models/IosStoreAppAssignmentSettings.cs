using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class IosStoreAppAssignmentSettings : MobileAppAssignmentSettings, IParsable {
        /// <summary>The VPN Configuration Id to apply for this app.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? VpnConfigurationId {
            get { return BackingStore?.Get<string?>("vpnConfigurationId"); }
            set { BackingStore?.Set("vpnConfigurationId", value); }
        }
#nullable restore
#else
        public string VpnConfigurationId {
            get { return BackingStore?.Get<string>("vpnConfigurationId"); }
            set { BackingStore?.Set("vpnConfigurationId", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new IosStoreAppAssignmentSettings and sets the default values.
        /// </summary>
        public IosStoreAppAssignmentSettings() : base() {
            OdataType = "#microsoft.graph.iosStoreAppAssignmentSettings";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new IosStoreAppAssignmentSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IosStoreAppAssignmentSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"vpnConfigurationId", n => { VpnConfigurationId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("vpnConfigurationId", VpnConfigurationId);
        }
    }
}
