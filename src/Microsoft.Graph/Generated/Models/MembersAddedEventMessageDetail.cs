using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class MembersAddedEventMessageDetail : EventMessageDetail, IParsable {
        /// <summary>Initiator of the event.</summary>
        public IdentitySet Initiator {
            get { return BackingStore?.Get<IdentitySet>("initiator"); }
            set { BackingStore?.Set("initiator", value); }
        }
        /// <summary>List of members added.</summary>
        public List<TeamworkUserIdentity> Members {
            get { return BackingStore?.Get<List<TeamworkUserIdentity>>("members"); }
            set { BackingStore?.Set("members", value); }
        }
        /// <summary>The timestamp denoting how far back a conversation&apos;s history is shared with the conversation members.</summary>
        public DateTimeOffset? VisibleHistoryStartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("visibleHistoryStartDateTime"); }
            set { BackingStore?.Set("visibleHistoryStartDateTime", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new MembersAddedEventMessageDetail CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MembersAddedEventMessageDetail();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"initiator", n => { Initiator = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"members", n => { Members = n.GetCollectionOfObjectValues<TeamworkUserIdentity>(TeamworkUserIdentity.CreateFromDiscriminatorValue).ToList(); } },
                {"visibleHistoryStartDateTime", n => { VisibleHistoryStartDateTime = n.GetDateTimeOffsetValue(); } },
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
            writer.WriteCollectionOfObjectValues<TeamworkUserIdentity>("members", Members);
            writer.WriteDateTimeOffsetValue("visibleHistoryStartDateTime", VisibleHistoryStartDateTime);
        }
    }
}
