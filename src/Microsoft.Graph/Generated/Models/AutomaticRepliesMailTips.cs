using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AutomaticRepliesMailTips : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The automatic reply message.</summary>
        public string Message {
            get { return BackingStore?.Get<string>("message"); }
            set { BackingStore?.Set("message", value); }
        }
        /// <summary>The language that the automatic reply message is in.</summary>
        public LocaleInfo MessageLanguage {
            get { return BackingStore?.Get<LocaleInfo>("messageLanguage"); }
            set { BackingStore?.Set("messageLanguage", value); }
        }
        /// <summary>The date and time that automatic replies are set to end.</summary>
        public DateTimeTimeZone ScheduledEndTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("scheduledEndTime"); }
            set { BackingStore?.Set("scheduledEndTime", value); }
        }
        /// <summary>The date and time that automatic replies are set to begin.</summary>
        public DateTimeTimeZone ScheduledStartTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("scheduledStartTime"); }
            set { BackingStore?.Set("scheduledStartTime", value); }
        }
        /// <summary>
        /// Instantiates a new automaticRepliesMailTips and sets the default values.
        /// </summary>
        public AutomaticRepliesMailTips() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AutomaticRepliesMailTips CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AutomaticRepliesMailTips();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"message", n => { Message = n.GetStringValue(); } },
                {"messageLanguage", n => { MessageLanguage = n.GetObjectValue<LocaleInfo>(LocaleInfo.CreateFromDiscriminatorValue); } },
                {"scheduledEndTime", n => { ScheduledEndTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"scheduledStartTime", n => { ScheduledStartTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("message", Message);
            writer.WriteObjectValue<LocaleInfo>("messageLanguage", MessageLanguage);
            writer.WriteObjectValue<DateTimeTimeZone>("scheduledEndTime", ScheduledEndTime);
            writer.WriteObjectValue<DateTimeTimeZone>("scheduledStartTime", ScheduledStartTime);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
