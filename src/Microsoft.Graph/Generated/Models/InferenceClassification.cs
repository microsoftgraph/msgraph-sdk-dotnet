using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class InferenceClassification : Entity, IParsable {
        /// <summary>A set of overrides for a user to always classify messages from specific senders in certain ways: focused, or other. Read-only. Nullable.</summary>
        public List<InferenceClassificationOverride> Overrides {
            get { return BackingStore?.Get<List<InferenceClassificationOverride>>("overrides"); }
            set { BackingStore?.Set("overrides", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new InferenceClassification CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new InferenceClassification();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"overrides", n => { Overrides = n.GetCollectionOfObjectValues<InferenceClassificationOverride>(InferenceClassificationOverride.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<InferenceClassificationOverride>("overrides", Overrides);
        }
    }
}
