using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class OnenoteEntityBaseModel : Entity, IParsable {
        /// <summary>The endpoint where you can get details about the page. Read-only.</summary>
        public string Self {
            get { return BackingStore?.Get<string>("self"); }
            set { BackingStore?.Set("self", value); }
        }
        /// <summary>
        /// Instantiates a new onenoteEntityBaseModel and sets the default values.
        /// </summary>
        public OnenoteEntityBaseModel() : base() {
            Type = "#microsoft.graph.onenoteEntityBaseModel";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new OnenoteEntityBaseModel CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.onenoteEntitySchemaObjectModel" => new OnenoteEntitySchemaObjectModel(),
                "#microsoft.graph.onenoteResource" => new OnenoteResource(),
                _ => new OnenoteEntityBaseModel(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"self", n => { Self = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("self", Self);
        }
    }
}
