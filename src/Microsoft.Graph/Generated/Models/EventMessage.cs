using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class EventMessage : Message, IParsable {
        /// <summary>The endDateTime property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public DateTimeTimeZone? EndDateTime {
            get { return BackingStore?.Get<DateTimeTimeZone?>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
#nullable restore
#else
        public DateTimeTimeZone EndDateTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
#endif
        /// <summary>The event associated with the event message. The assumption for attendees or room resources is that the Calendar Attendant is set to automatically update the calendar with an event when meeting request event messages arrive. Navigation property.  Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.Event? Event {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Event?>("event"); }
            set { BackingStore?.Set("event", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.Event Event {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Event>("event"); }
            set { BackingStore?.Set("event", value); }
        }
#endif
        /// <summary>The isAllDay property</summary>
        public bool? IsAllDay {
            get { return BackingStore?.Get<bool?>("isAllDay"); }
            set { BackingStore?.Set("isAllDay", value); }
        }
        /// <summary>The isDelegated property</summary>
        public bool? IsDelegated {
            get { return BackingStore?.Get<bool?>("isDelegated"); }
            set { BackingStore?.Set("isDelegated", value); }
        }
        /// <summary>The isOutOfDate property</summary>
        public bool? IsOutOfDate {
            get { return BackingStore?.Get<bool?>("isOutOfDate"); }
            set { BackingStore?.Set("isOutOfDate", value); }
        }
        /// <summary>The location property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.Location? Location {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Location?>("location"); }
            set { BackingStore?.Set("location", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.Location Location {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Location>("location"); }
            set { BackingStore?.Set("location", value); }
        }
#endif
        /// <summary>The meetingMessageType property</summary>
        public Microsoft.Graph.Models.MeetingMessageType? MeetingMessageType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.MeetingMessageType?>("meetingMessageType"); }
            set { BackingStore?.Set("meetingMessageType", value); }
        }
        /// <summary>The recurrence property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public PatternedRecurrence? Recurrence {
            get { return BackingStore?.Get<PatternedRecurrence?>("recurrence"); }
            set { BackingStore?.Set("recurrence", value); }
        }
#nullable restore
#else
        public PatternedRecurrence Recurrence {
            get { return BackingStore?.Get<PatternedRecurrence>("recurrence"); }
            set { BackingStore?.Set("recurrence", value); }
        }
#endif
        /// <summary>The startDateTime property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public DateTimeTimeZone? StartDateTime {
            get { return BackingStore?.Get<DateTimeTimeZone?>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
#nullable restore
#else
        public DateTimeTimeZone StartDateTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
#endif
        /// <summary>The type property</summary>
        public EventType? Type {
            get { return BackingStore?.Get<EventType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new EventMessage and sets the default values.
        /// </summary>
        public EventMessage() : base() {
            OdataType = "#microsoft.graph.eventMessage";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new EventMessage CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.eventMessageRequest" => new EventMessageRequest(),
                "#microsoft.graph.eventMessageResponse" => new EventMessageResponse(),
                _ => new EventMessage(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"endDateTime", n => { EndDateTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"event", n => { Event = n.GetObjectValue<Microsoft.Graph.Models.Event>(Microsoft.Graph.Models.Event.CreateFromDiscriminatorValue); } },
                {"isAllDay", n => { IsAllDay = n.GetBoolValue(); } },
                {"isDelegated", n => { IsDelegated = n.GetBoolValue(); } },
                {"isOutOfDate", n => { IsOutOfDate = n.GetBoolValue(); } },
                {"location", n => { Location = n.GetObjectValue<Microsoft.Graph.Models.Location>(Microsoft.Graph.Models.Location.CreateFromDiscriminatorValue); } },
                {"meetingMessageType", n => { MeetingMessageType = n.GetEnumValue<MeetingMessageType>(); } },
                {"recurrence", n => { Recurrence = n.GetObjectValue<PatternedRecurrence>(PatternedRecurrence.CreateFromDiscriminatorValue); } },
                {"startDateTime", n => { StartDateTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"type", n => { Type = n.GetEnumValue<EventType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<DateTimeTimeZone>("endDateTime", EndDateTime);
            writer.WriteObjectValue<Microsoft.Graph.Models.Event>("event", Event);
            writer.WriteBoolValue("isAllDay", IsAllDay);
            writer.WriteBoolValue("isDelegated", IsDelegated);
            writer.WriteBoolValue("isOutOfDate", IsOutOfDate);
            writer.WriteObjectValue<Microsoft.Graph.Models.Location>("location", Location);
            writer.WriteEnumValue<MeetingMessageType>("meetingMessageType", MeetingMessageType);
            writer.WriteObjectValue<PatternedRecurrence>("recurrence", Recurrence);
            writer.WriteObjectValue<DateTimeTimeZone>("startDateTime", StartDateTime);
            writer.WriteEnumValue<EventType>("type", Type);
        }
    }
}
