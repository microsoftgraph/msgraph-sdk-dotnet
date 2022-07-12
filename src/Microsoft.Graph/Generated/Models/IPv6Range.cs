using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IPv6Range : IpRange, IParsable {
        /// <summary>Lower address.</summary>
        public string LowerAddress {
            get { return BackingStore?.Get<string>("lowerAddress"); }
            set { BackingStore?.Set("lowerAddress", value); }
        }
        /// <summary>Upper address.</summary>
        public string UpperAddress {
            get { return BackingStore?.Get<string>("upperAddress"); }
            set { BackingStore?.Set("upperAddress", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new IPv6Range CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IPv6Range();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"lowerAddress", n => { LowerAddress = n.GetStringValue(); } },
                {"upperAddress", n => { UpperAddress = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("lowerAddress", LowerAddress);
            writer.WriteStringValue("upperAddress", UpperAddress);
        }
    }
}
