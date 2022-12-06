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
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new OnenoteEntityBaseModel CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.notebook" => new Notebook(),
                "#microsoft.graph.onenoteEntityHierarchyModel" => new OnenoteEntityHierarchyModel(),
                "#microsoft.graph.onenoteEntitySchemaObjectModel" => new OnenoteEntitySchemaObjectModel(),
                "#microsoft.graph.onenotePage" => new OnenotePage(),
                "#microsoft.graph.onenoteResource" => new OnenoteResource(),
                "#microsoft.graph.onenoteSection" => new OnenoteSection(),
                "#microsoft.graph.sectionGroup" => new SectionGroup(),
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
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("self", Self);
        }
    }
}
