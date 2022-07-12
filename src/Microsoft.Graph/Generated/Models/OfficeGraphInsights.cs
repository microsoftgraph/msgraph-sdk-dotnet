using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class OfficeGraphInsights : Entity, IParsable {
        /// <summary>Access this property from the derived type itemInsights.</summary>
        public List<SharedInsight> Shared {
            get { return BackingStore?.Get<List<SharedInsight>>("shared"); }
            set { BackingStore?.Set("shared", value); }
        }
        /// <summary>Access this property from the derived type itemInsights.</summary>
        public List<Microsoft.Graph.Models.Trending> Trending {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.Trending>>("trending"); }
            set { BackingStore?.Set("trending", value); }
        }
        /// <summary>Access this property from the derived type itemInsights.</summary>
        public List<UsedInsight> Used {
            get { return BackingStore?.Get<List<UsedInsight>>("used"); }
            set { BackingStore?.Set("used", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new OfficeGraphInsights CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OfficeGraphInsights();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"shared", n => { Shared = n.GetCollectionOfObjectValues<SharedInsight>(SharedInsight.CreateFromDiscriminatorValue).ToList(); } },
                {"trending", n => { Trending = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.Trending>(Microsoft.Graph.Models.Trending.CreateFromDiscriminatorValue).ToList(); } },
                {"used", n => { Used = n.GetCollectionOfObjectValues<UsedInsight>(UsedInsight.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<SharedInsight>("shared", Shared);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.Trending>("trending", Trending);
            writer.WriteCollectionOfObjectValues<UsedInsight>("used", Used);
        }
    }
}
