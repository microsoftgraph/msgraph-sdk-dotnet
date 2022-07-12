using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CallEndedEventMessageDetail : EventMessageDetail, IParsable {
        /// <summary>Duration of the call.</summary>
        public TimeSpan? CallDuration {
            get { return BackingStore?.Get<TimeSpan?>("callDuration"); }
            set { BackingStore?.Set("callDuration", value); }
        }
        /// <summary>Represents the call event type. Possible values are: call, meeting, screenShare, unknownFutureValue.</summary>
        public TeamworkCallEventType? CallEventType {
            get { return BackingStore?.Get<TeamworkCallEventType?>("callEventType"); }
            set { BackingStore?.Set("callEventType", value); }
        }
        /// <summary>Unique identifier of the call.</summary>
        public string CallId {
            get { return BackingStore?.Get<string>("callId"); }
            set { BackingStore?.Set("callId", value); }
        }
        /// <summary>List of call participants.</summary>
        public List<CallParticipantInfo> CallParticipants {
            get { return BackingStore?.Get<List<CallParticipantInfo>>("callParticipants"); }
            set { BackingStore?.Set("callParticipants", value); }
        }
        /// <summary>Initiator of the event.</summary>
        public IdentitySet Initiator {
            get { return BackingStore?.Get<IdentitySet>("initiator"); }
            set { BackingStore?.Set("initiator", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CallEndedEventMessageDetail CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CallEndedEventMessageDetail();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"callDuration", n => { CallDuration = n.GetTimeSpanValue(); } },
                {"callEventType", n => { CallEventType = n.GetEnumValue<TeamworkCallEventType>(); } },
                {"callId", n => { CallId = n.GetStringValue(); } },
                {"callParticipants", n => { CallParticipants = n.GetCollectionOfObjectValues<CallParticipantInfo>(CallParticipantInfo.CreateFromDiscriminatorValue).ToList(); } },
                {"initiator", n => { Initiator = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteTimeSpanValue("callDuration", CallDuration);
            writer.WriteEnumValue<TeamworkCallEventType>("callEventType", CallEventType);
            writer.WriteStringValue("callId", CallId);
            writer.WriteCollectionOfObjectValues<CallParticipantInfo>("callParticipants", CallParticipants);
            writer.WriteObjectValue<IdentitySet>("initiator", Initiator);
        }
    }
}
