using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PlannerAssignedToTaskBoardTaskFormat : Entity, IParsable {
        /// <summary>Dictionary of hints used to order tasks on the AssignedTo view of the Task Board. The key of each entry is one of the users the task is assigned to and the value is the order hint. The format of each value is defined as outlined here.</summary>
        public PlannerOrderHintsByAssignee OrderHintsByAssignee {
            get { return BackingStore?.Get<PlannerOrderHintsByAssignee>("orderHintsByAssignee"); }
            set { BackingStore?.Set("orderHintsByAssignee", value); }
        }
        /// <summary>Hint value used to order the task on the AssignedTo view of the Task Board when the task is not assigned to anyone, or if the orderHintsByAssignee dictionary does not provide an order hint for the user the task is assigned to. The format is defined as outlined here.</summary>
        public string UnassignedOrderHint {
            get { return BackingStore?.Get<string>("unassignedOrderHint"); }
            set { BackingStore?.Set("unassignedOrderHint", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new PlannerAssignedToTaskBoardTaskFormat CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PlannerAssignedToTaskBoardTaskFormat();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"orderHintsByAssignee", n => { OrderHintsByAssignee = n.GetObjectValue<PlannerOrderHintsByAssignee>(PlannerOrderHintsByAssignee.CreateFromDiscriminatorValue); } },
                {"unassignedOrderHint", n => { UnassignedOrderHint = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<PlannerOrderHintsByAssignee>("orderHintsByAssignee", OrderHintsByAssignee);
            writer.WriteStringValue("unassignedOrderHint", UnassignedOrderHint);
        }
    }
}
