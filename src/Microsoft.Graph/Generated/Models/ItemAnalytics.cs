using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ItemAnalytics : Entity, IParsable {
        /// <summary>The allTime property</summary>
        public ItemActivityStat AllTime {
            get { return BackingStore?.Get<ItemActivityStat>("allTime"); }
            set { BackingStore?.Set("allTime", value); }
        }
        /// <summary>The itemActivityStats property</summary>
        public List<ItemActivityStat> ItemActivityStats {
            get { return BackingStore?.Get<List<ItemActivityStat>>("itemActivityStats"); }
            set { BackingStore?.Set("itemActivityStats", value); }
        }
        /// <summary>The lastSevenDays property</summary>
        public ItemActivityStat LastSevenDays {
            get { return BackingStore?.Get<ItemActivityStat>("lastSevenDays"); }
            set { BackingStore?.Set("lastSevenDays", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ItemAnalytics CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemAnalytics();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"allTime", n => { AllTime = n.GetObjectValue<ItemActivityStat>(ItemActivityStat.CreateFromDiscriminatorValue); } },
                {"itemActivityStats", n => { ItemActivityStats = n.GetCollectionOfObjectValues<ItemActivityStat>(ItemActivityStat.CreateFromDiscriminatorValue).ToList(); } },
                {"lastSevenDays", n => { LastSevenDays = n.GetObjectValue<ItemActivityStat>(ItemActivityStat.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ItemActivityStat>("allTime", AllTime);
            writer.WriteCollectionOfObjectValues<ItemActivityStat>("itemActivityStats", ItemActivityStats);
            writer.WriteObjectValue<ItemActivityStat>("lastSevenDays", LastSevenDays);
        }
    }
}
