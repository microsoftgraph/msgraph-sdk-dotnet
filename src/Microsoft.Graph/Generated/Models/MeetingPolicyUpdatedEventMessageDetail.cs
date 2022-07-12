using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class MeetingPolicyUpdatedEventMessageDetail : EventMessageDetail, IParsable {
        /// <summary>Initiator of the event.</summary>
        public IdentitySet Initiator {
            get { return BackingStore?.Get<IdentitySet>("initiator"); }
            set { BackingStore?.Set("initiator", value); }
        }
        /// <summary>Represents whether the meeting chat is enabled or not.</summary>
        public bool? MeetingChatEnabled {
            get { return BackingStore?.Get<bool?>("meetingChatEnabled"); }
            set { BackingStore?.Set("meetingChatEnabled", value); }
        }
        /// <summary>Unique identifier of the meeting chat.</summary>
        public string MeetingChatId {
            get { return BackingStore?.Get<string>("meetingChatId"); }
            set { BackingStore?.Set("meetingChatId", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new MeetingPolicyUpdatedEventMessageDetail CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MeetingPolicyUpdatedEventMessageDetail();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"initiator", n => { Initiator = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"meetingChatEnabled", n => { MeetingChatEnabled = n.GetBoolValue(); } },
                {"meetingChatId", n => { MeetingChatId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<IdentitySet>("initiator", Initiator);
            writer.WriteBoolValue("meetingChatEnabled", MeetingChatEnabled);
            writer.WriteStringValue("meetingChatId", MeetingChatId);
        }
    }
}
