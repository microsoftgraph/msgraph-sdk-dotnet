using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Event : OutlookItem, IParsable {
        /// <summary>true if the meeting organizer allows invitees to propose a new time when responding; otherwise false. Optional. Default is true.</summary>
        public bool? AllowNewTimeProposals {
            get { return BackingStore?.Get<bool?>("allowNewTimeProposals"); }
            set { BackingStore?.Set("allowNewTimeProposals", value); }
        }
        /// <summary>The collection of FileAttachment, ItemAttachment, and referenceAttachment attachments for the event. Navigation property. Read-only. Nullable.</summary>
        public List<Attachment> Attachments {
            get { return BackingStore?.Get<List<Attachment>>("attachments"); }
            set { BackingStore?.Set("attachments", value); }
        }
        /// <summary>The collection of attendees for the event.</summary>
        public List<Attendee> Attendees {
            get { return BackingStore?.Get<List<Attendee>>("attendees"); }
            set { BackingStore?.Set("attendees", value); }
        }
        /// <summary>The body of the message associated with the event. It can be in HTML or text format.</summary>
        public ItemBody Body {
            get { return BackingStore?.Get<ItemBody>("body"); }
            set { BackingStore?.Set("body", value); }
        }
        /// <summary>The preview of the message associated with the event. It is in text format.</summary>
        public string BodyPreview {
            get { return BackingStore?.Get<string>("bodyPreview"); }
            set { BackingStore?.Set("bodyPreview", value); }
        }
        /// <summary>The calendar that contains the event. Navigation property. Read-only.</summary>
        public Microsoft.Graph.Models.Calendar Calendar {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Calendar>("calendar"); }
            set { BackingStore?.Set("calendar", value); }
        }
        /// <summary>The date, time, and time zone that the event ends. By default, the end time is in UTC.</summary>
        public DateTimeTimeZone End {
            get { return BackingStore?.Get<DateTimeTimeZone>("end"); }
            set { BackingStore?.Set("end", value); }
        }
        /// <summary>The collection of open extensions defined for the event. Nullable.</summary>
        public List<Extension> Extensions {
            get { return BackingStore?.Get<List<Extension>>("extensions"); }
            set { BackingStore?.Set("extensions", value); }
        }
        /// <summary>Set to true if the event has attachments.</summary>
        public bool? HasAttachments {
            get { return BackingStore?.Get<bool?>("hasAttachments"); }
            set { BackingStore?.Set("hasAttachments", value); }
        }
        /// <summary>When set to true, each attendee only sees themselves in the meeting request and meeting Tracking list. Default is false.</summary>
        public bool? HideAttendees {
            get { return BackingStore?.Get<bool?>("hideAttendees"); }
            set { BackingStore?.Set("hideAttendees", value); }
        }
        /// <summary>A unique identifier for an event across calendars. This ID is different for each occurrence in a recurring series. Read-only.</summary>
        public string ICalUId {
            get { return BackingStore?.Get<string>("iCalUId"); }
            set { BackingStore?.Set("iCalUId", value); }
        }
        /// <summary>The importance property</summary>
        public Microsoft.Graph.Models.Importance? Importance {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Importance?>("importance"); }
            set { BackingStore?.Set("importance", value); }
        }
        /// <summary>The occurrences of a recurring series, if the event is a series master. This property includes occurrences that are part of the recurrence pattern, and exceptions that have been modified, but does not include occurrences that have been cancelled from the series. Navigation property. Read-only. Nullable.</summary>
        public List<Event> Instances {
            get { return BackingStore?.Get<List<Event>>("instances"); }
            set { BackingStore?.Set("instances", value); }
        }
        /// <summary>The isAllDay property</summary>
        public bool? IsAllDay {
            get { return BackingStore?.Get<bool?>("isAllDay"); }
            set { BackingStore?.Set("isAllDay", value); }
        }
        /// <summary>The isCancelled property</summary>
        public bool? IsCancelled {
            get { return BackingStore?.Get<bool?>("isCancelled"); }
            set { BackingStore?.Set("isCancelled", value); }
        }
        /// <summary>The isDraft property</summary>
        public bool? IsDraft {
            get { return BackingStore?.Get<bool?>("isDraft"); }
            set { BackingStore?.Set("isDraft", value); }
        }
        /// <summary>The isOnlineMeeting property</summary>
        public bool? IsOnlineMeeting {
            get { return BackingStore?.Get<bool?>("isOnlineMeeting"); }
            set { BackingStore?.Set("isOnlineMeeting", value); }
        }
        /// <summary>The isOrganizer property</summary>
        public bool? IsOrganizer {
            get { return BackingStore?.Get<bool?>("isOrganizer"); }
            set { BackingStore?.Set("isOrganizer", value); }
        }
        /// <summary>The isReminderOn property</summary>
        public bool? IsReminderOn {
            get { return BackingStore?.Get<bool?>("isReminderOn"); }
            set { BackingStore?.Set("isReminderOn", value); }
        }
        /// <summary>The location property</summary>
        public Microsoft.Graph.Models.Location Location {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Location>("location"); }
            set { BackingStore?.Set("location", value); }
        }
        /// <summary>The locations property</summary>
        public List<Microsoft.Graph.Models.Location> Locations {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.Location>>("locations"); }
            set { BackingStore?.Set("locations", value); }
        }
        /// <summary>The collection of multi-value extended properties defined for the event. Read-only. Nullable.</summary>
        public List<MultiValueLegacyExtendedProperty> MultiValueExtendedProperties {
            get { return BackingStore?.Get<List<MultiValueLegacyExtendedProperty>>("multiValueExtendedProperties"); }
            set { BackingStore?.Set("multiValueExtendedProperties", value); }
        }
        /// <summary>The onlineMeeting property</summary>
        public OnlineMeetingInfo OnlineMeeting {
            get { return BackingStore?.Get<OnlineMeetingInfo>("onlineMeeting"); }
            set { BackingStore?.Set("onlineMeeting", value); }
        }
        /// <summary>The onlineMeetingProvider property</summary>
        public OnlineMeetingProviderType? OnlineMeetingProvider {
            get { return BackingStore?.Get<OnlineMeetingProviderType?>("onlineMeetingProvider"); }
            set { BackingStore?.Set("onlineMeetingProvider", value); }
        }
        /// <summary>The onlineMeetingUrl property</summary>
        public string OnlineMeetingUrl {
            get { return BackingStore?.Get<string>("onlineMeetingUrl"); }
            set { BackingStore?.Set("onlineMeetingUrl", value); }
        }
        /// <summary>The organizer property</summary>
        public Recipient Organizer {
            get { return BackingStore?.Get<Recipient>("organizer"); }
            set { BackingStore?.Set("organizer", value); }
        }
        /// <summary>The originalEndTimeZone property</summary>
        public string OriginalEndTimeZone {
            get { return BackingStore?.Get<string>("originalEndTimeZone"); }
            set { BackingStore?.Set("originalEndTimeZone", value); }
        }
        /// <summary>The originalStart property</summary>
        public DateTimeOffset? OriginalStart {
            get { return BackingStore?.Get<DateTimeOffset?>("originalStart"); }
            set { BackingStore?.Set("originalStart", value); }
        }
        /// <summary>The originalStartTimeZone property</summary>
        public string OriginalStartTimeZone {
            get { return BackingStore?.Get<string>("originalStartTimeZone"); }
            set { BackingStore?.Set("originalStartTimeZone", value); }
        }
        /// <summary>The recurrence property</summary>
        public PatternedRecurrence Recurrence {
            get { return BackingStore?.Get<PatternedRecurrence>("recurrence"); }
            set { BackingStore?.Set("recurrence", value); }
        }
        /// <summary>The reminderMinutesBeforeStart property</summary>
        public int? ReminderMinutesBeforeStart {
            get { return BackingStore?.Get<int?>("reminderMinutesBeforeStart"); }
            set { BackingStore?.Set("reminderMinutesBeforeStart", value); }
        }
        /// <summary>The responseRequested property</summary>
        public bool? ResponseRequested {
            get { return BackingStore?.Get<bool?>("responseRequested"); }
            set { BackingStore?.Set("responseRequested", value); }
        }
        /// <summary>The responseStatus property</summary>
        public Microsoft.Graph.Models.ResponseStatus ResponseStatus {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ResponseStatus>("responseStatus"); }
            set { BackingStore?.Set("responseStatus", value); }
        }
        /// <summary>The sensitivity property</summary>
        public Microsoft.Graph.Models.Sensitivity? Sensitivity {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Sensitivity?>("sensitivity"); }
            set { BackingStore?.Set("sensitivity", value); }
        }
        /// <summary>The seriesMasterId property</summary>
        public string SeriesMasterId {
            get { return BackingStore?.Get<string>("seriesMasterId"); }
            set { BackingStore?.Set("seriesMasterId", value); }
        }
        /// <summary>The showAs property</summary>
        public FreeBusyStatus? ShowAs {
            get { return BackingStore?.Get<FreeBusyStatus?>("showAs"); }
            set { BackingStore?.Set("showAs", value); }
        }
        /// <summary>The collection of single-value extended properties defined for the event. Read-only. Nullable.</summary>
        public List<SingleValueLegacyExtendedProperty> SingleValueExtendedProperties {
            get { return BackingStore?.Get<List<SingleValueLegacyExtendedProperty>>("singleValueExtendedProperties"); }
            set { BackingStore?.Set("singleValueExtendedProperties", value); }
        }
        /// <summary>The start property</summary>
        public DateTimeTimeZone Start {
            get { return BackingStore?.Get<DateTimeTimeZone>("start"); }
            set { BackingStore?.Set("start", value); }
        }
        /// <summary>The subject property</summary>
        public string Subject {
            get { return BackingStore?.Get<string>("subject"); }
            set { BackingStore?.Set("subject", value); }
        }
        /// <summary>The transactionId property</summary>
        public string TransactionId {
            get { return BackingStore?.Get<string>("transactionId"); }
            set { BackingStore?.Set("transactionId", value); }
        }
        /// <summary>The webLink property</summary>
        public string WebLink {
            get { return BackingStore?.Get<string>("webLink"); }
            set { BackingStore?.Set("webLink", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Event CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Event();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"allowNewTimeProposals", n => { AllowNewTimeProposals = n.GetBoolValue(); } },
                {"attachments", n => { Attachments = n.GetCollectionOfObjectValues<Attachment>(Attachment.CreateFromDiscriminatorValue).ToList(); } },
                {"attendees", n => { Attendees = n.GetCollectionOfObjectValues<Attendee>(Attendee.CreateFromDiscriminatorValue).ToList(); } },
                {"body", n => { Body = n.GetObjectValue<ItemBody>(ItemBody.CreateFromDiscriminatorValue); } },
                {"bodyPreview", n => { BodyPreview = n.GetStringValue(); } },
                {"calendar", n => { Calendar = n.GetObjectValue<Microsoft.Graph.Models.Calendar>(Microsoft.Graph.Models.Calendar.CreateFromDiscriminatorValue); } },
                {"end", n => { End = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"extensions", n => { Extensions = n.GetCollectionOfObjectValues<Extension>(Extension.CreateFromDiscriminatorValue).ToList(); } },
                {"hasAttachments", n => { HasAttachments = n.GetBoolValue(); } },
                {"hideAttendees", n => { HideAttendees = n.GetBoolValue(); } },
                {"iCalUId", n => { ICalUId = n.GetStringValue(); } },
                {"importance", n => { Importance = n.GetEnumValue<Importance>(); } },
                {"instances", n => { Instances = n.GetCollectionOfObjectValues<Event>(Event.CreateFromDiscriminatorValue).ToList(); } },
                {"isAllDay", n => { IsAllDay = n.GetBoolValue(); } },
                {"isCancelled", n => { IsCancelled = n.GetBoolValue(); } },
                {"isDraft", n => { IsDraft = n.GetBoolValue(); } },
                {"isOnlineMeeting", n => { IsOnlineMeeting = n.GetBoolValue(); } },
                {"isOrganizer", n => { IsOrganizer = n.GetBoolValue(); } },
                {"isReminderOn", n => { IsReminderOn = n.GetBoolValue(); } },
                {"location", n => { Location = n.GetObjectValue<Microsoft.Graph.Models.Location>(Microsoft.Graph.Models.Location.CreateFromDiscriminatorValue); } },
                {"locations", n => { Locations = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.Location>(Microsoft.Graph.Models.Location.CreateFromDiscriminatorValue).ToList(); } },
                {"multiValueExtendedProperties", n => { MultiValueExtendedProperties = n.GetCollectionOfObjectValues<MultiValueLegacyExtendedProperty>(MultiValueLegacyExtendedProperty.CreateFromDiscriminatorValue).ToList(); } },
                {"onlineMeeting", n => { OnlineMeeting = n.GetObjectValue<OnlineMeetingInfo>(OnlineMeetingInfo.CreateFromDiscriminatorValue); } },
                {"onlineMeetingProvider", n => { OnlineMeetingProvider = n.GetEnumValue<OnlineMeetingProviderType>(); } },
                {"onlineMeetingUrl", n => { OnlineMeetingUrl = n.GetStringValue(); } },
                {"organizer", n => { Organizer = n.GetObjectValue<Recipient>(Recipient.CreateFromDiscriminatorValue); } },
                {"originalEndTimeZone", n => { OriginalEndTimeZone = n.GetStringValue(); } },
                {"originalStart", n => { OriginalStart = n.GetDateTimeOffsetValue(); } },
                {"originalStartTimeZone", n => { OriginalStartTimeZone = n.GetStringValue(); } },
                {"recurrence", n => { Recurrence = n.GetObjectValue<PatternedRecurrence>(PatternedRecurrence.CreateFromDiscriminatorValue); } },
                {"reminderMinutesBeforeStart", n => { ReminderMinutesBeforeStart = n.GetIntValue(); } },
                {"responseRequested", n => { ResponseRequested = n.GetBoolValue(); } },
                {"responseStatus", n => { ResponseStatus = n.GetObjectValue<Microsoft.Graph.Models.ResponseStatus>(Microsoft.Graph.Models.ResponseStatus.CreateFromDiscriminatorValue); } },
                {"sensitivity", n => { Sensitivity = n.GetEnumValue<Sensitivity>(); } },
                {"seriesMasterId", n => { SeriesMasterId = n.GetStringValue(); } },
                {"showAs", n => { ShowAs = n.GetEnumValue<FreeBusyStatus>(); } },
                {"singleValueExtendedProperties", n => { SingleValueExtendedProperties = n.GetCollectionOfObjectValues<SingleValueLegacyExtendedProperty>(SingleValueLegacyExtendedProperty.CreateFromDiscriminatorValue).ToList(); } },
                {"start", n => { Start = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"subject", n => { Subject = n.GetStringValue(); } },
                {"transactionId", n => { TransactionId = n.GetStringValue(); } },
                {"webLink", n => { WebLink = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("allowNewTimeProposals", AllowNewTimeProposals);
            writer.WriteCollectionOfObjectValues<Attachment>("attachments", Attachments);
            writer.WriteCollectionOfObjectValues<Attendee>("attendees", Attendees);
            writer.WriteObjectValue<ItemBody>("body", Body);
            writer.WriteStringValue("bodyPreview", BodyPreview);
            writer.WriteObjectValue<Microsoft.Graph.Models.Calendar>("calendar", Calendar);
            writer.WriteObjectValue<DateTimeTimeZone>("end", End);
            writer.WriteCollectionOfObjectValues<Extension>("extensions", Extensions);
            writer.WriteBoolValue("hasAttachments", HasAttachments);
            writer.WriteBoolValue("hideAttendees", HideAttendees);
            writer.WriteStringValue("iCalUId", ICalUId);
            writer.WriteEnumValue<Importance>("importance", Importance);
            writer.WriteCollectionOfObjectValues<Event>("instances", Instances);
            writer.WriteBoolValue("isAllDay", IsAllDay);
            writer.WriteBoolValue("isCancelled", IsCancelled);
            writer.WriteBoolValue("isDraft", IsDraft);
            writer.WriteBoolValue("isOnlineMeeting", IsOnlineMeeting);
            writer.WriteBoolValue("isOrganizer", IsOrganizer);
            writer.WriteBoolValue("isReminderOn", IsReminderOn);
            writer.WriteObjectValue<Microsoft.Graph.Models.Location>("location", Location);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.Location>("locations", Locations);
            writer.WriteCollectionOfObjectValues<MultiValueLegacyExtendedProperty>("multiValueExtendedProperties", MultiValueExtendedProperties);
            writer.WriteObjectValue<OnlineMeetingInfo>("onlineMeeting", OnlineMeeting);
            writer.WriteEnumValue<OnlineMeetingProviderType>("onlineMeetingProvider", OnlineMeetingProvider);
            writer.WriteStringValue("onlineMeetingUrl", OnlineMeetingUrl);
            writer.WriteObjectValue<Recipient>("organizer", Organizer);
            writer.WriteStringValue("originalEndTimeZone", OriginalEndTimeZone);
            writer.WriteDateTimeOffsetValue("originalStart", OriginalStart);
            writer.WriteStringValue("originalStartTimeZone", OriginalStartTimeZone);
            writer.WriteObjectValue<PatternedRecurrence>("recurrence", Recurrence);
            writer.WriteIntValue("reminderMinutesBeforeStart", ReminderMinutesBeforeStart);
            writer.WriteBoolValue("responseRequested", ResponseRequested);
            writer.WriteObjectValue<Microsoft.Graph.Models.ResponseStatus>("responseStatus", ResponseStatus);
            writer.WriteEnumValue<Sensitivity>("sensitivity", Sensitivity);
            writer.WriteStringValue("seriesMasterId", SeriesMasterId);
            writer.WriteEnumValue<FreeBusyStatus>("showAs", ShowAs);
            writer.WriteCollectionOfObjectValues<SingleValueLegacyExtendedProperty>("singleValueExtendedProperties", SingleValueExtendedProperties);
            writer.WriteObjectValue<DateTimeTimeZone>("start", Start);
            writer.WriteStringValue("subject", Subject);
            writer.WriteStringValue("transactionId", TransactionId);
            writer.WriteStringValue("webLink", WebLink);
        }
    }
}
