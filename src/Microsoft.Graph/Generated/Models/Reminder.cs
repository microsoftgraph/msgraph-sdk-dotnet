using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Reminder : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Identifies the version of the reminder. Every time the reminder is changed, changeKey changes as well. This allows Exchange to apply changes to the correct version of the object.</summary>
        public string ChangeKey {
            get { return BackingStore?.Get<string>("changeKey"); }
            set { BackingStore?.Set("changeKey", value); }
        }
        /// <summary>The date, time and time zone that the event ends.</summary>
        public DateTimeTimeZone EventEndTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("eventEndTime"); }
            set { BackingStore?.Set("eventEndTime", value); }
        }
        /// <summary>The unique ID of the event. Read only.</summary>
        public string EventId {
            get { return BackingStore?.Get<string>("eventId"); }
            set { BackingStore?.Set("eventId", value); }
        }
        /// <summary>The location of the event.</summary>
        public Location EventLocation {
            get { return BackingStore?.Get<Location>("eventLocation"); }
            set { BackingStore?.Set("eventLocation", value); }
        }
        /// <summary>The date, time, and time zone that the event starts.</summary>
        public DateTimeTimeZone EventStartTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("eventStartTime"); }
            set { BackingStore?.Set("eventStartTime", value); }
        }
        /// <summary>The text of the event&apos;s subject line.</summary>
        public string EventSubject {
            get { return BackingStore?.Get<string>("eventSubject"); }
            set { BackingStore?.Set("eventSubject", value); }
        }
        /// <summary>The URL to open the event in Outlook on the web.The event will open in the browser if you are logged in to your mailbox via Outlook on the web. You will be prompted to login if you are not already logged in with the browser.This URL cannot be accessed from within an iFrame.</summary>
        public string EventWebLink {
            get { return BackingStore?.Get<string>("eventWebLink"); }
            set { BackingStore?.Set("eventWebLink", value); }
        }
        /// <summary>The date, time, and time zone that the reminder is set to occur.</summary>
        public DateTimeTimeZone ReminderFireTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("reminderFireTime"); }
            set { BackingStore?.Set("reminderFireTime", value); }
        }
        /// <summary>
        /// Instantiates a new reminder and sets the default values.
        /// </summary>
        public Reminder() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Reminder CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Reminder();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"changeKey", n => { ChangeKey = n.GetStringValue(); } },
                {"eventEndTime", n => { EventEndTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"eventId", n => { EventId = n.GetStringValue(); } },
                {"eventLocation", n => { EventLocation = n.GetObjectValue<Location>(Location.CreateFromDiscriminatorValue); } },
                {"eventStartTime", n => { EventStartTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"eventSubject", n => { EventSubject = n.GetStringValue(); } },
                {"eventWebLink", n => { EventWebLink = n.GetStringValue(); } },
                {"reminderFireTime", n => { ReminderFireTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("changeKey", ChangeKey);
            writer.WriteObjectValue<DateTimeTimeZone>("eventEndTime", EventEndTime);
            writer.WriteStringValue("eventId", EventId);
            writer.WriteObjectValue<Location>("eventLocation", EventLocation);
            writer.WriteObjectValue<DateTimeTimeZone>("eventStartTime", EventStartTime);
            writer.WriteStringValue("eventSubject", EventSubject);
            writer.WriteStringValue("eventWebLink", EventWebLink);
            writer.WriteObjectValue<DateTimeTimeZone>("reminderFireTime", ReminderFireTime);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
