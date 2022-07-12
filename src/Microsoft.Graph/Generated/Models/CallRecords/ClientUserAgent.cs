using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.CallRecords {
    public class ClientUserAgent : UserAgent, IParsable {
        /// <summary>The platform property</summary>
        public ClientPlatform? Platform {
            get { return BackingStore?.Get<ClientPlatform?>("platform"); }
            set { BackingStore?.Set("platform", value); }
        }
        /// <summary>The productFamily property</summary>
        public Microsoft.Graph.Models.CallRecords.ProductFamily? ProductFamily {
            get { return BackingStore?.Get<Microsoft.Graph.Models.CallRecords.ProductFamily?>("productFamily"); }
            set { BackingStore?.Set("productFamily", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ClientUserAgent CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ClientUserAgent();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"platform", n => { Platform = n.GetEnumValue<ClientPlatform>(); } },
                {"productFamily", n => { ProductFamily = n.GetEnumValue<ProductFamily>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<ClientPlatform>("platform", Platform);
            writer.WriteEnumValue<ProductFamily>("productFamily", ProductFamily);
        }
    }
}
