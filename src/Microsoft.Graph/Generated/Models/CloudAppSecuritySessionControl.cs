using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CloudAppSecuritySessionControl : ConditionalAccessSessionControl, IParsable {
        /// <summary>Possible values are: mcasConfigured, monitorOnly, blockDownloads. To learn more about these values, Deploy Conditional Access App Control for featured apps.</summary>
        public CloudAppSecuritySessionControlType? CloudAppSecurityType {
            get { return BackingStore?.Get<CloudAppSecuritySessionControlType?>("cloudAppSecurityType"); }
            set { BackingStore?.Set("cloudAppSecurityType", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CloudAppSecuritySessionControl CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CloudAppSecuritySessionControl();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"cloudAppSecurityType", n => { CloudAppSecurityType = n.GetEnumValue<CloudAppSecuritySessionControlType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<CloudAppSecuritySessionControlType>("cloudAppSecurityType", CloudAppSecurityType);
        }
    }
}
