using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ConditionalAccessRoot : Entity, IParsable {
        /// <summary>Read-only. Nullable. Returns a collection of the specified named locations.</summary>
        public List<NamedLocation> NamedLocations {
            get { return BackingStore?.Get<List<NamedLocation>>("namedLocations"); }
            set { BackingStore?.Set("namedLocations", value); }
        }
        /// <summary>Read-only. Nullable. Returns a collection of the specified Conditional Access policies.</summary>
        public List<ConditionalAccessPolicy> Policies {
            get { return BackingStore?.Get<List<ConditionalAccessPolicy>>("policies"); }
            set { BackingStore?.Set("policies", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ConditionalAccessRoot CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ConditionalAccessRoot();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"namedLocations", n => { NamedLocations = n.GetCollectionOfObjectValues<NamedLocation>(NamedLocation.CreateFromDiscriminatorValue).ToList(); } },
                {"policies", n => { Policies = n.GetCollectionOfObjectValues<ConditionalAccessPolicy>(ConditionalAccessPolicy.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<NamedLocation>("namedLocations", NamedLocations);
            writer.WriteCollectionOfObjectValues<ConditionalAccessPolicy>("policies", Policies);
        }
    }
}
