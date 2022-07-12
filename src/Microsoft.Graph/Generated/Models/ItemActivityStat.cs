using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ItemActivityStat : Entity, IParsable {
        /// <summary>Statistics about the access actions in this interval. Read-only.</summary>
        public ItemActionStat Access {
            get { return BackingStore?.Get<ItemActionStat>("access"); }
            set { BackingStore?.Set("access", value); }
        }
        /// <summary>Exposes the itemActivities represented in this itemActivityStat resource.</summary>
        public List<ItemActivity> Activities {
            get { return BackingStore?.Get<List<ItemActivity>>("activities"); }
            set { BackingStore?.Set("activities", value); }
        }
        /// <summary>Statistics about the create actions in this interval. Read-only.</summary>
        public ItemActionStat Create {
            get { return BackingStore?.Get<ItemActionStat>("create"); }
            set { BackingStore?.Set("create", value); }
        }
        /// <summary>Statistics about the delete actions in this interval. Read-only.</summary>
        public ItemActionStat Delete {
            get { return BackingStore?.Get<ItemActionStat>("delete"); }
            set { BackingStore?.Set("delete", value); }
        }
        /// <summary>Statistics about the edit actions in this interval. Read-only.</summary>
        public ItemActionStat Edit {
            get { return BackingStore?.Get<ItemActionStat>("edit"); }
            set { BackingStore?.Set("edit", value); }
        }
        /// <summary>When the interval ends. Read-only.</summary>
        public DateTimeOffset? EndDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
        /// <summary>Indicates that the statistics in this interval are based on incomplete data. Read-only.</summary>
        public Microsoft.Graph.Models.IncompleteData IncompleteData {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IncompleteData>("incompleteData"); }
            set { BackingStore?.Set("incompleteData", value); }
        }
        /// <summary>Indicates whether the item is &apos;trending.&apos; Read-only.</summary>
        public bool? IsTrending {
            get { return BackingStore?.Get<bool?>("isTrending"); }
            set { BackingStore?.Set("isTrending", value); }
        }
        /// <summary>Statistics about the move actions in this interval. Read-only.</summary>
        public ItemActionStat Move {
            get { return BackingStore?.Get<ItemActionStat>("move"); }
            set { BackingStore?.Set("move", value); }
        }
        /// <summary>When the interval starts. Read-only.</summary>
        public DateTimeOffset? StartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ItemActivityStat CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemActivityStat();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"access", n => { Access = n.GetObjectValue<ItemActionStat>(ItemActionStat.CreateFromDiscriminatorValue); } },
                {"activities", n => { Activities = n.GetCollectionOfObjectValues<ItemActivity>(ItemActivity.CreateFromDiscriminatorValue).ToList(); } },
                {"create", n => { Create = n.GetObjectValue<ItemActionStat>(ItemActionStat.CreateFromDiscriminatorValue); } },
                {"delete", n => { Delete = n.GetObjectValue<ItemActionStat>(ItemActionStat.CreateFromDiscriminatorValue); } },
                {"edit", n => { Edit = n.GetObjectValue<ItemActionStat>(ItemActionStat.CreateFromDiscriminatorValue); } },
                {"endDateTime", n => { EndDateTime = n.GetDateTimeOffsetValue(); } },
                {"incompleteData", n => { IncompleteData = n.GetObjectValue<Microsoft.Graph.Models.IncompleteData>(Microsoft.Graph.Models.IncompleteData.CreateFromDiscriminatorValue); } },
                {"isTrending", n => { IsTrending = n.GetBoolValue(); } },
                {"move", n => { Move = n.GetObjectValue<ItemActionStat>(ItemActionStat.CreateFromDiscriminatorValue); } },
                {"startDateTime", n => { StartDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ItemActionStat>("access", Access);
            writer.WriteCollectionOfObjectValues<ItemActivity>("activities", Activities);
            writer.WriteObjectValue<ItemActionStat>("create", Create);
            writer.WriteObjectValue<ItemActionStat>("delete", Delete);
            writer.WriteObjectValue<ItemActionStat>("edit", Edit);
            writer.WriteDateTimeOffsetValue("endDateTime", EndDateTime);
            writer.WriteObjectValue<Microsoft.Graph.Models.IncompleteData>("incompleteData", IncompleteData);
            writer.WriteBoolValue("isTrending", IsTrending);
            writer.WriteObjectValue<ItemActionStat>("move", Move);
            writer.WriteDateTimeOffsetValue("startDateTime", StartDateTime);
        }
    }
}
