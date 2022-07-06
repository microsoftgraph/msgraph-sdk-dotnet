using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AutomaticRepliesSetting : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The set of audience external to the signed-in user&apos;s organization who will receive the ExternalReplyMessage, if Status is AlwaysEnabled or Scheduled. Possible values are: none, contactsOnly, all.</summary>
        public ExternalAudienceScope? ExternalAudience {
            get { return BackingStore?.Get<ExternalAudienceScope?>("externalAudience"); }
            set { BackingStore?.Set("externalAudience", value); }
        }
        /// <summary>The automatic reply to send to the specified external audience, if Status is AlwaysEnabled or Scheduled.</summary>
        public string ExternalReplyMessage {
            get { return BackingStore?.Get<string>("externalReplyMessage"); }
            set { BackingStore?.Set("externalReplyMessage", value); }
        }
        /// <summary>The automatic reply to send to the audience internal to the signed-in user&apos;s organization, if Status is AlwaysEnabled or Scheduled.</summary>
        public string InternalReplyMessage {
            get { return BackingStore?.Get<string>("internalReplyMessage"); }
            set { BackingStore?.Set("internalReplyMessage", value); }
        }
        /// <summary>The date and time that automatic replies are set to end, if Status is set to Scheduled.</summary>
        public DateTimeTimeZone ScheduledEndDateTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("scheduledEndDateTime"); }
            set { BackingStore?.Set("scheduledEndDateTime", value); }
        }
        /// <summary>The date and time that automatic replies are set to begin, if Status is set to Scheduled.</summary>
        public DateTimeTimeZone ScheduledStartDateTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("scheduledStartDateTime"); }
            set { BackingStore?.Set("scheduledStartDateTime", value); }
        }
        /// <summary>Configurations status for automatic replies. Possible values are: disabled, alwaysEnabled, scheduled.</summary>
        public AutomaticRepliesStatus? Status {
            get { return BackingStore?.Get<AutomaticRepliesStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new automaticRepliesSetting and sets the default values.
        /// </summary>
        public AutomaticRepliesSetting() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AutomaticRepliesSetting CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AutomaticRepliesSetting();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"externalAudience", n => { ExternalAudience = n.GetEnumValue<ExternalAudienceScope>(); } },
                {"externalReplyMessage", n => { ExternalReplyMessage = n.GetStringValue(); } },
                {"internalReplyMessage", n => { InternalReplyMessage = n.GetStringValue(); } },
                {"scheduledEndDateTime", n => { ScheduledEndDateTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"scheduledStartDateTime", n => { ScheduledStartDateTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"status", n => { Status = n.GetEnumValue<AutomaticRepliesStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<ExternalAudienceScope>("externalAudience", ExternalAudience);
            writer.WriteStringValue("externalReplyMessage", ExternalReplyMessage);
            writer.WriteStringValue("internalReplyMessage", InternalReplyMessage);
            writer.WriteObjectValue<DateTimeTimeZone>("scheduledEndDateTime", ScheduledEndDateTime);
            writer.WriteObjectValue<DateTimeTimeZone>("scheduledStartDateTime", ScheduledStartDateTime);
            writer.WriteEnumValue<AutomaticRepliesStatus>("status", Status);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
