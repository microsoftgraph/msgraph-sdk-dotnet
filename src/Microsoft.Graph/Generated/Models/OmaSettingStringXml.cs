using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class OmaSettingStringXml : OmaSetting, IParsable {
        /// <summary>File name associated with the Value property (.xml).</summary>
        public string FileName {
            get { return BackingStore?.Get<string>("fileName"); }
            set { BackingStore?.Set("fileName", value); }
        }
        /// <summary>Value. (UTF8 encoded byte array)</summary>
        public byte[] Value {
            get { return BackingStore?.Get<byte[]>("value"); }
            set { BackingStore?.Set("value", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new OmaSettingStringXml CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OmaSettingStringXml();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"fileName", n => { FileName = n.GetStringValue(); } },
                {"value", n => { Value = n.GetByteArrayValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("fileName", FileName);
            writer.WriteByteArrayValue("value", Value);
        }
    }
}
