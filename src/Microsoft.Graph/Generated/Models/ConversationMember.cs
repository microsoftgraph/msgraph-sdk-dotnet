using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class ConversationMember : Entity, IParsable {
        /// <summary>The display name of the user.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DisplayName {
            get { return BackingStore?.Get<string?>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#nullable restore
#else
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#endif
        /// <summary>The roles for that user. This property contains additional qualifiers only when relevant - for example, if the member has owner privileges, the roles property contains owner as one of the values. Similarly, if the member is an in-tenant guest, the roles property contains guest as one of the values. A basic member should not have any values specified in the roles property. An Out-of-tenant external member is assigned the owner role.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Roles {
            get { return BackingStore?.Get<List<string>?>("roles"); }
            set { BackingStore?.Set("roles", value); }
        }
#nullable restore
#else
        public List<string> Roles {
            get { return BackingStore?.Get<List<string>>("roles"); }
            set { BackingStore?.Set("roles", value); }
        }
#endif
        /// <summary>The timestamp denoting how far back a conversation&apos;s history is shared with the conversation member. This property is settable only for members of a chat.</summary>
        public DateTimeOffset? VisibleHistoryStartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("visibleHistoryStartDateTime"); }
            set { BackingStore?.Set("visibleHistoryStartDateTime", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new ConversationMember CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.aadUserConversationMember" => new AadUserConversationMember(),
                "#microsoft.graph.anonymousGuestConversationMember" => new AnonymousGuestConversationMember(),
                "#microsoft.graph.azureCommunicationServicesUserConversationMember" => new AzureCommunicationServicesUserConversationMember(),
                "#microsoft.graph.microsoftAccountUserConversationMember" => new MicrosoftAccountUserConversationMember(),
                "#microsoft.graph.skypeForBusinessUserConversationMember" => new SkypeForBusinessUserConversationMember(),
                "#microsoft.graph.skypeUserConversationMember" => new SkypeUserConversationMember(),
                _ => new ConversationMember(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"roles", n => { Roles = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"visibleHistoryStartDateTime", n => { VisibleHistoryStartDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfPrimitiveValues<string>("roles", Roles);
            writer.WriteDateTimeOffsetValue("visibleHistoryStartDateTime", VisibleHistoryStartDateTime);
        }
    }
}
