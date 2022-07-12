using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>This type represents when and to whom to send an e-mail reminder.</summary>
    public class BookingReminder : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The message in the reminder.</summary>
        public string Message {
            get { return BackingStore?.Get<string>("message"); }
            set { BackingStore?.Set("message", value); }
        }
        /// <summary>The amount of time before the start of an appointment that the reminder should be sent. It&apos;s denoted in ISO 8601 format.</summary>
        public TimeSpan? Offset {
            get { return BackingStore?.Get<TimeSpan?>("offset"); }
            set { BackingStore?.Set("offset", value); }
        }
        /// <summary>The recipients property</summary>
        public BookingReminderRecipients? Recipients {
            get { return BackingStore?.Get<BookingReminderRecipients?>("recipients"); }
            set { BackingStore?.Set("recipients", value); }
        }
        /// <summary>
        /// Instantiates a new bookingReminder and sets the default values.
        /// </summary>
        public BookingReminder() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static BookingReminder CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BookingReminder();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"message", n => { Message = n.GetStringValue(); } },
                {"offset", n => { Offset = n.GetTimeSpanValue(); } },
                {"recipients", n => { Recipients = n.GetEnumValue<BookingReminderRecipients>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("message", Message);
            writer.WriteTimeSpanValue("offset", Offset);
            writer.WriteEnumValue<BookingReminderRecipients>("recipients", Recipients);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
