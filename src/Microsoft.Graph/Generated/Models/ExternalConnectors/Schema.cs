using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.ExternalConnectors {
    public class Schema : Entity, IParsable {
        /// <summary>Must be set to microsoft.graph.externalItem. Required.</summary>
        public string BaseType {
            get { return BackingStore?.Get<string>("baseType"); }
            set { BackingStore?.Set("baseType", value); }
        }
        /// <summary>The properties defined for the items in the connection. The minimum number of properties is one, the maximum is 128.</summary>
        public List<Property> Properties {
            get { return BackingStore?.Get<List<Property>>("properties"); }
            set { BackingStore?.Set("properties", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Schema CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Schema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"baseType", n => { BaseType = n.GetStringValue(); } },
                {"properties", n => { Properties = n.GetCollectionOfObjectValues<Property>(Property.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("baseType", BaseType);
            writer.WriteCollectionOfObjectValues<Property>("properties", Properties);
        }
    }
}
