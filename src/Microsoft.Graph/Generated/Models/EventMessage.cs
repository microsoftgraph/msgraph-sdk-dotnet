// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class EventMessage : global::Microsoft.Graph.Models.Message, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The endDateTime property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.DateTimeTimeZone? EndDateTime
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DateTimeTimeZone?>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.DateTimeTimeZone EndDateTime
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DateTimeTimeZone>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
#endif
        /// <summary>The event associated with the event message. The assumption for attendees or room resources is that the Calendar Attendant is set to automatically update the calendar with an event when meeting request event messages arrive. Navigation property. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.Event? Event
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.Event?>("event"); }
            set { BackingStore?.Set("event", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.Event Event
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.Event>("event"); }
            set { BackingStore?.Set("event", value); }
        }
#endif
        /// <summary>The isAllDay property</summary>
        public bool? IsAllDay
        {
            get { return BackingStore?.Get<bool?>("isAllDay"); }
            set { BackingStore?.Set("isAllDay", value); }
        }
        /// <summary>True if this meeting request is accessible to a delegate, false otherwise. The default is false.</summary>
        public bool? IsDelegated
        {
            get { return BackingStore?.Get<bool?>("isDelegated"); }
            set { BackingStore?.Set("isDelegated", value); }
        }
        /// <summary>The isOutOfDate property</summary>
        public bool? IsOutOfDate
        {
            get { return BackingStore?.Get<bool?>("isOutOfDate"); }
            set { BackingStore?.Set("isOutOfDate", value); }
        }
        /// <summary>The location property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.Location? Location
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.Location?>("location"); }
            set { BackingStore?.Set("location", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.Location Location
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.Location>("location"); }
            set { BackingStore?.Set("location", value); }
        }
#endif
        /// <summary>The type of event message: none, meetingRequest, meetingCancelled, meetingAccepted, meetingTenativelyAccepted, meetingDeclined.</summary>
        public global::Microsoft.Graph.Models.MeetingMessageType? MeetingMessageType
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.MeetingMessageType?>("meetingMessageType"); }
            set { BackingStore?.Set("meetingMessageType", value); }
        }
        /// <summary>The recurrence property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.PatternedRecurrence? Recurrence
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.PatternedRecurrence?>("recurrence"); }
            set { BackingStore?.Set("recurrence", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.PatternedRecurrence Recurrence
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.PatternedRecurrence>("recurrence"); }
            set { BackingStore?.Set("recurrence", value); }
        }
#endif
        /// <summary>The startDateTime property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.DateTimeTimeZone? StartDateTime
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DateTimeTimeZone?>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.DateTimeTimeZone StartDateTime
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DateTimeTimeZone>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
#endif
        /// <summary>The type property</summary>
        public global::Microsoft.Graph.Models.EventType? Type
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.EventType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Models.EventMessage"/> and sets the default values.
        /// </summary>
        public EventMessage() : base()
        {
            OdataType = "#microsoft.graph.eventMessage";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.EventMessage"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.EventMessage CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch
            {
                "#microsoft.graph.eventMessageRequest" => new global::Microsoft.Graph.Models.EventMessageRequest(),
                "#microsoft.graph.eventMessageResponse" => new global::Microsoft.Graph.Models.EventMessageResponse(),
                _ => new global::Microsoft.Graph.Models.EventMessage(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "endDateTime", n => { EndDateTime = n.GetObjectValue<global::Microsoft.Graph.Models.DateTimeTimeZone>(global::Microsoft.Graph.Models.DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                { "event", n => { Event = n.GetObjectValue<global::Microsoft.Graph.Models.Event>(global::Microsoft.Graph.Models.Event.CreateFromDiscriminatorValue); } },
                { "isAllDay", n => { IsAllDay = n.GetBoolValue(); } },
                { "isDelegated", n => { IsDelegated = n.GetBoolValue(); } },
                { "isOutOfDate", n => { IsOutOfDate = n.GetBoolValue(); } },
                { "location", n => { Location = n.GetObjectValue<global::Microsoft.Graph.Models.Location>(global::Microsoft.Graph.Models.Location.CreateFromDiscriminatorValue); } },
                { "meetingMessageType", n => { MeetingMessageType = n.GetEnumValue<global::Microsoft.Graph.Models.MeetingMessageType>(); } },
                { "recurrence", n => { Recurrence = n.GetObjectValue<global::Microsoft.Graph.Models.PatternedRecurrence>(global::Microsoft.Graph.Models.PatternedRecurrence.CreateFromDiscriminatorValue); } },
                { "startDateTime", n => { StartDateTime = n.GetObjectValue<global::Microsoft.Graph.Models.DateTimeTimeZone>(global::Microsoft.Graph.Models.DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                { "type", n => { Type = n.GetEnumValue<global::Microsoft.Graph.Models.EventType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.DateTimeTimeZone>("endDateTime", EndDateTime);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.Event>("event", Event);
            writer.WriteBoolValue("isAllDay", IsAllDay);
            writer.WriteBoolValue("isDelegated", IsDelegated);
            writer.WriteBoolValue("isOutOfDate", IsOutOfDate);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.Location>("location", Location);
            writer.WriteEnumValue<global::Microsoft.Graph.Models.MeetingMessageType>("meetingMessageType", MeetingMessageType);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.PatternedRecurrence>("recurrence", Recurrence);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.DateTimeTimeZone>("startDateTime", StartDateTime);
            writer.WriteEnumValue<global::Microsoft.Graph.Models.EventType>("type", Type);
        }
    }
}
#pragma warning restore CS0618
