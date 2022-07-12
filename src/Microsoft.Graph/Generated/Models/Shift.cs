using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Shift : ChangeTrackedEntity, IParsable {
        /// <summary>The draft version of this shift that is viewable by managers. Required.</summary>
        public ShiftItem DraftShift {
            get { return BackingStore?.Get<ShiftItem>("draftShift"); }
            set { BackingStore?.Set("draftShift", value); }
        }
        /// <summary>ID of the scheduling group the shift is part of. Required.</summary>
        public string SchedulingGroupId {
            get { return BackingStore?.Get<string>("schedulingGroupId"); }
            set { BackingStore?.Set("schedulingGroupId", value); }
        }
        /// <summary>The shared version of this shift that is viewable by both employees and managers. Required.</summary>
        public ShiftItem SharedShift {
            get { return BackingStore?.Get<ShiftItem>("sharedShift"); }
            set { BackingStore?.Set("sharedShift", value); }
        }
        /// <summary>ID of the user assigned to the shift. Required.</summary>
        public string UserId {
            get { return BackingStore?.Get<string>("userId"); }
            set { BackingStore?.Set("userId", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Shift CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Shift();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"draftShift", n => { DraftShift = n.GetObjectValue<ShiftItem>(ShiftItem.CreateFromDiscriminatorValue); } },
                {"schedulingGroupId", n => { SchedulingGroupId = n.GetStringValue(); } },
                {"sharedShift", n => { SharedShift = n.GetObjectValue<ShiftItem>(ShiftItem.CreateFromDiscriminatorValue); } },
                {"userId", n => { UserId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ShiftItem>("draftShift", DraftShift);
            writer.WriteStringValue("schedulingGroupId", SchedulingGroupId);
            writer.WriteObjectValue<ShiftItem>("sharedShift", SharedShift);
            writer.WriteStringValue("userId", UserId);
        }
    }
}
