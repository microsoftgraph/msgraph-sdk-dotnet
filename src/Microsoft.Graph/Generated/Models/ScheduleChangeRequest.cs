using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ScheduleChangeRequest : ChangeTrackedEntity, IParsable {
        /// <summary>The assignedTo property</summary>
        public ScheduleChangeRequestActor? AssignedTo {
            get { return BackingStore?.Get<ScheduleChangeRequestActor?>("assignedTo"); }
            set { BackingStore?.Set("assignedTo", value); }
        }
        /// <summary>The managerActionDateTime property</summary>
        public DateTimeOffset? ManagerActionDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("managerActionDateTime"); }
            set { BackingStore?.Set("managerActionDateTime", value); }
        }
        /// <summary>The managerActionMessage property</summary>
        public string ManagerActionMessage {
            get { return BackingStore?.Get<string>("managerActionMessage"); }
            set { BackingStore?.Set("managerActionMessage", value); }
        }
        /// <summary>The managerUserId property</summary>
        public string ManagerUserId {
            get { return BackingStore?.Get<string>("managerUserId"); }
            set { BackingStore?.Set("managerUserId", value); }
        }
        /// <summary>The senderDateTime property</summary>
        public DateTimeOffset? SenderDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("senderDateTime"); }
            set { BackingStore?.Set("senderDateTime", value); }
        }
        /// <summary>The senderMessage property</summary>
        public string SenderMessage {
            get { return BackingStore?.Get<string>("senderMessage"); }
            set { BackingStore?.Set("senderMessage", value); }
        }
        /// <summary>The senderUserId property</summary>
        public string SenderUserId {
            get { return BackingStore?.Get<string>("senderUserId"); }
            set { BackingStore?.Set("senderUserId", value); }
        }
        /// <summary>The state property</summary>
        public ScheduleChangeState? State {
            get { return BackingStore?.Get<ScheduleChangeState?>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>
        /// Instantiates a new ScheduleChangeRequest and sets the default values.
        /// </summary>
        public ScheduleChangeRequest() : base() {
            Type = "#microsoft.graph.scheduleChangeRequest";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ScheduleChangeRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.offerShiftRequest" => new OfferShiftRequest(),
                "#microsoft.graph.openShiftChangeRequest" => new OpenShiftChangeRequest(),
                "#microsoft.graph.timeOffRequest" => new TimeOffRequest(),
                _ => new ScheduleChangeRequest(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assignedTo", n => { AssignedTo = n.GetEnumValue<ScheduleChangeRequestActor>(); } },
                {"managerActionDateTime", n => { ManagerActionDateTime = n.GetDateTimeOffsetValue(); } },
                {"managerActionMessage", n => { ManagerActionMessage = n.GetStringValue(); } },
                {"managerUserId", n => { ManagerUserId = n.GetStringValue(); } },
                {"senderDateTime", n => { SenderDateTime = n.GetDateTimeOffsetValue(); } },
                {"senderMessage", n => { SenderMessage = n.GetStringValue(); } },
                {"senderUserId", n => { SenderUserId = n.GetStringValue(); } },
                {"state", n => { State = n.GetEnumValue<ScheduleChangeState>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<ScheduleChangeRequestActor>("assignedTo", AssignedTo);
            writer.WriteDateTimeOffsetValue("managerActionDateTime", ManagerActionDateTime);
            writer.WriteStringValue("managerActionMessage", ManagerActionMessage);
            writer.WriteStringValue("managerUserId", ManagerUserId);
            writer.WriteDateTimeOffsetValue("senderDateTime", SenderDateTime);
            writer.WriteStringValue("senderMessage", SenderMessage);
            writer.WriteStringValue("senderUserId", SenderUserId);
            writer.WriteEnumValue<ScheduleChangeState>("state", State);
        }
    }
}
