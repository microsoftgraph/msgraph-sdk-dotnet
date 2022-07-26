using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class ConversationMember : Entity, IParsable {
        /// <summary>The display name of the user.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The roles for that user. This property only contains additional qualifiers when relevant - for example, if the member has owner privileges, the roles property contains owner as one of the values. Similarly, if the member is a guest, the roles property contains guest as one of the values. A basic member should not have any values specified in the roles property.</summary>
        public List<string> Roles {
            get { return BackingStore?.Get<List<string>>("roles"); }
            set { BackingStore?.Set("roles", value); }
        }
        /// <summary>The timestamp denoting how far back a conversation&apos;s history is shared with the conversation member. This property is settable only for members of a chat.</summary>
        public DateTimeOffset? VisibleHistoryStartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("visibleHistoryStartDateTime"); }
            set { BackingStore?.Set("visibleHistoryStartDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new conversationMember and sets the default values.
        /// </summary>
        public ConversationMember() : base() {
            OdataType = "#microsoft.graph.conversationMember";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ConversationMember CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.aadUserConversationMember" => new AadUserConversationMember(),
                _ => new ConversationMember(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"roles", n => { Roles = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
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
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfPrimitiveValues<string>("roles", Roles);
            writer.WriteDateTimeOffsetValue("visibleHistoryStartDateTime", VisibleHistoryStartDateTime);
        }
    }
}
