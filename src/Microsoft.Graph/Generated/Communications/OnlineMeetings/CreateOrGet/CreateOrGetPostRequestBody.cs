using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Communications.OnlineMeetings.CreateOrGet {
    /// <summary>Provides operations to call the createOrGet method.</summary>
    public class CreateOrGetPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The chatInfo property</summary>
        public Microsoft.Graph.Models.ChatInfo ChatInfo {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ChatInfo>("chatInfo"); }
            set { BackingStore?.Set("chatInfo", value); }
        }
        /// <summary>The endDateTime property</summary>
        public DateTimeOffset? EndDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
        /// <summary>The externalId property</summary>
        public string ExternalId {
            get { return BackingStore?.Get<string>("externalId"); }
            set { BackingStore?.Set("externalId", value); }
        }
        /// <summary>The participants property</summary>
        public MeetingParticipants Participants {
            get { return BackingStore?.Get<MeetingParticipants>("participants"); }
            set { BackingStore?.Set("participants", value); }
        }
        /// <summary>The startDateTime property</summary>
        public DateTimeOffset? StartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
        /// <summary>The subject property</summary>
        public string Subject {
            get { return BackingStore?.Get<string>("subject"); }
            set { BackingStore?.Set("subject", value); }
        }
        /// <summary>
        /// Instantiates a new createOrGetPostRequestBody and sets the default values.
        /// </summary>
        public CreateOrGetPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static CreateOrGetPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CreateOrGetPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"chatInfo", n => { ChatInfo = n.GetObjectValue<Microsoft.Graph.Models.ChatInfo>(Microsoft.Graph.Models.ChatInfo.CreateFromDiscriminatorValue); } },
                {"endDateTime", n => { EndDateTime = n.GetDateTimeOffsetValue(); } },
                {"externalId", n => { ExternalId = n.GetStringValue(); } },
                {"participants", n => { Participants = n.GetObjectValue<MeetingParticipants>(MeetingParticipants.CreateFromDiscriminatorValue); } },
                {"startDateTime", n => { StartDateTime = n.GetDateTimeOffsetValue(); } },
                {"subject", n => { Subject = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Microsoft.Graph.Models.ChatInfo>("chatInfo", ChatInfo);
            writer.WriteDateTimeOffsetValue("endDateTime", EndDateTime);
            writer.WriteStringValue("externalId", ExternalId);
            writer.WriteObjectValue<MeetingParticipants>("participants", Participants);
            writer.WriteDateTimeOffsetValue("startDateTime", StartDateTime);
            writer.WriteStringValue("subject", Subject);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
