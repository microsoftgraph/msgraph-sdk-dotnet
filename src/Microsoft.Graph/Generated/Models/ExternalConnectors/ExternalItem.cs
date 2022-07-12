using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.ExternalConnectors {
    /// <summary>Provides operations to manage the collection of externalConnection entities.</summary>
    public class ExternalItem : Entity, IParsable {
        /// <summary>An array of access control entries. Each entry specifies the access granted to a user or group. Required.</summary>
        public List<Microsoft.Graph.Models.ExternalConnectors.Acl> Acl {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ExternalConnectors.Acl>>("acl"); }
            set { BackingStore?.Set("acl", value); }
        }
        /// <summary>A plain-text  representation of the contents of the item. The text in this property is full-text indexed. Optional.</summary>
        public ExternalItemContent Content {
            get { return BackingStore?.Get<ExternalItemContent>("content"); }
            set { BackingStore?.Set("content", value); }
        }
        /// <summary>A property bag with the properties of the item. The properties MUST conform to the schema defined for the externalConnection. Required.</summary>
        public Microsoft.Graph.Models.ExternalConnectors.Properties Properties {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ExternalConnectors.Properties>("properties"); }
            set { BackingStore?.Set("properties", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ExternalItem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ExternalItem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"acl", n => { Acl = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.ExternalConnectors.Acl>(Microsoft.Graph.Models.ExternalConnectors.Acl.CreateFromDiscriminatorValue).ToList(); } },
                {"content", n => { Content = n.GetObjectValue<ExternalItemContent>(ExternalItemContent.CreateFromDiscriminatorValue); } },
                {"properties", n => { Properties = n.GetObjectValue<Microsoft.Graph.Models.ExternalConnectors.Properties>(Microsoft.Graph.Models.ExternalConnectors.Properties.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.ExternalConnectors.Acl>("acl", Acl);
            writer.WriteObjectValue<ExternalItemContent>("content", Content);
            writer.WriteObjectValue<Microsoft.Graph.Models.ExternalConnectors.Properties>("properties", Properties);
        }
    }
}
