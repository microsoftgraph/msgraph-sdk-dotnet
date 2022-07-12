using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PrinterCreateOperation : PrintOperation, IParsable {
        /// <summary>The signed certificate created during the registration process. Read-only.</summary>
        public string Certificate {
            get { return BackingStore?.Get<string>("certificate"); }
            set { BackingStore?.Set("certificate", value); }
        }
        /// <summary>The created printer entity. Read-only.</summary>
        public Microsoft.Graph.Models.Printer Printer {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Printer>("printer"); }
            set { BackingStore?.Set("printer", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new PrinterCreateOperation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PrinterCreateOperation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"certificate", n => { Certificate = n.GetStringValue(); } },
                {"printer", n => { Printer = n.GetObjectValue<Microsoft.Graph.Models.Printer>(Microsoft.Graph.Models.Printer.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("certificate", Certificate);
            writer.WriteObjectValue<Microsoft.Graph.Models.Printer>("printer", Printer);
        }
    }
}
