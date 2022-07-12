using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ManagedAppConfiguration : ManagedAppPolicy, IParsable {
        /// <summary>A set of string key and string value pairs to be sent to apps for users to whom the configuration is scoped, unalterned by this service</summary>
        public List<KeyValuePair> CustomSettings {
            get { return BackingStore?.Get<List<KeyValuePair>>("customSettings"); }
            set { BackingStore?.Set("customSettings", value); }
        }
        /// <summary>
        /// Instantiates a new ManagedAppConfiguration and sets the default values.
        /// </summary>
        public ManagedAppConfiguration() : base() {
            Type = "#microsoft.graph.managedAppConfiguration";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ManagedAppConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.targetedManagedAppConfiguration" => new TargetedManagedAppConfiguration(),
                _ => new ManagedAppConfiguration(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"customSettings", n => { CustomSettings = n.GetCollectionOfObjectValues<KeyValuePair>(KeyValuePair.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<KeyValuePair>("customSettings", CustomSettings);
        }
    }
}
