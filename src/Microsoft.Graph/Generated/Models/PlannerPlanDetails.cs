using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PlannerPlanDetails : Entity, IParsable {
        /// <summary>An object that specifies the descriptions of the 25 categories that can be associated with tasks in the plan</summary>
        public PlannerCategoryDescriptions CategoryDescriptions {
            get { return BackingStore?.Get<PlannerCategoryDescriptions>("categoryDescriptions"); }
            set { BackingStore?.Set("categoryDescriptions", value); }
        }
        /// <summary>The set of user IDs that this plan is shared with. If you are using Microsoft 365 groups, use the groups API to manage group membership to share the group&apos;s plan. You can also add existing members of the group to this collection, although it is not required in order for them to access the plan owned by the group.</summary>
        public PlannerUserIds SharedWith {
            get { return BackingStore?.Get<PlannerUserIds>("sharedWith"); }
            set { BackingStore?.Set("sharedWith", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new PlannerPlanDetails CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PlannerPlanDetails();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"categoryDescriptions", n => { CategoryDescriptions = n.GetObjectValue<PlannerCategoryDescriptions>(PlannerCategoryDescriptions.CreateFromDiscriminatorValue); } },
                {"sharedWith", n => { SharedWith = n.GetObjectValue<PlannerUserIds>(PlannerUserIds.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<PlannerCategoryDescriptions>("categoryDescriptions", CategoryDescriptions);
            writer.WriteObjectValue<PlannerUserIds>("sharedWith", SharedWith);
        }
    }
}
