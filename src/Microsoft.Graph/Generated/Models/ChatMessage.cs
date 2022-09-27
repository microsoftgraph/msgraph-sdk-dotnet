using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of chat entities.</summary>
    public class ChatMessage : Entity, IParsable {
        /// <summary>References to attached objects like files, tabs, meetings etc.</summary>
        public List<ChatMessageAttachment> Attachments {
            get { return BackingStore?.Get<List<ChatMessageAttachment>>("attachments"); }
            set { BackingStore?.Set("attachments", value); }
        }
        /// <summary>The body property</summary>
        public ItemBody Body {
            get { return BackingStore?.Get<ItemBody>("body"); }
            set { BackingStore?.Set("body", value); }
        }
        /// <summary>If the message was sent in a channel, represents identity of the channel.</summary>
        public Microsoft.Graph.Models.ChannelIdentity ChannelIdentity {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ChannelIdentity>("channelIdentity"); }
            set { BackingStore?.Set("channelIdentity", value); }
        }
        /// <summary>If the message was sent in a chat, represents the identity of the chat.</summary>
        public string ChatId {
            get { return BackingStore?.Get<string>("chatId"); }
            set { BackingStore?.Set("chatId", value); }
        }
        /// <summary>Timestamp of when the chat message was created.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Read only. Timestamp at which the chat message was deleted, or null if not deleted.</summary>
        public DateTimeOffset? DeletedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("deletedDateTime"); }
            set { BackingStore?.Set("deletedDateTime", value); }
        }
        /// <summary>Read-only. Version number of the chat message.</summary>
        public string Etag {
            get { return BackingStore?.Get<string>("etag"); }
            set { BackingStore?.Set("etag", value); }
        }
        /// <summary>Read-only. If present, represents details of an event that happened in a chat, a channel, or a team, for example, adding new members. For event messages, the messageType property will be set to systemEventMessage.</summary>
        public EventMessageDetail EventDetail {
            get { return BackingStore?.Get<EventMessageDetail>("eventDetail"); }
            set { BackingStore?.Set("eventDetail", value); }
        }
        /// <summary>Details of the sender of the chat message. Can only be set during migration.</summary>
        public ChatMessageFromIdentitySet From {
            get { return BackingStore?.Get<ChatMessageFromIdentitySet>("from"); }
            set { BackingStore?.Set("from", value); }
        }
        /// <summary>Content in a message hosted by Microsoft Teams - for example, images or code snippets.</summary>
        public List<ChatMessageHostedContent> HostedContents {
            get { return BackingStore?.Get<List<ChatMessageHostedContent>>("hostedContents"); }
            set { BackingStore?.Set("hostedContents", value); }
        }
        /// <summary>The importance property</summary>
        public ChatMessageImportance? Importance {
            get { return BackingStore?.Get<ChatMessageImportance?>("importance"); }
            set { BackingStore?.Set("importance", value); }
        }
        /// <summary>Read only. Timestamp when edits to the chat message were made. Triggers an &apos;Edited&apos; flag in the Teams UI. If no edits are made the value is null.</summary>
        public DateTimeOffset? LastEditedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastEditedDateTime"); }
            set { BackingStore?.Set("lastEditedDateTime", value); }
        }
        /// <summary>Read only. Timestamp when the chat message is created (initial setting) or modified, including when a reaction is added or removed.</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>Locale of the chat message set by the client. Always set to en-us.</summary>
        public string Locale {
            get { return BackingStore?.Get<string>("locale"); }
            set { BackingStore?.Set("locale", value); }
        }
        /// <summary>List of entities mentioned in the chat message. Supported entities are: user, bot, team, and channel.</summary>
        public List<ChatMessageMention> Mentions {
            get { return BackingStore?.Get<List<ChatMessageMention>>("mentions"); }
            set { BackingStore?.Set("mentions", value); }
        }
        /// <summary>The messageType property</summary>
        public ChatMessageType? MessageType {
            get { return BackingStore?.Get<ChatMessageType?>("messageType"); }
            set { BackingStore?.Set("messageType", value); }
        }
        /// <summary>Defines the properties of a policy violation set by a data loss prevention (DLP) application.</summary>
        public ChatMessagePolicyViolation PolicyViolation {
            get { return BackingStore?.Get<ChatMessagePolicyViolation>("policyViolation"); }
            set { BackingStore?.Set("policyViolation", value); }
        }
        /// <summary>Reactions for this chat message (for example, Like).</summary>
        public List<ChatMessageReaction> Reactions {
            get { return BackingStore?.Get<List<ChatMessageReaction>>("reactions"); }
            set { BackingStore?.Set("reactions", value); }
        }
        /// <summary>Replies for a specified message. Supports $expand for channel messages.</summary>
        public List<ChatMessage> Replies {
            get { return BackingStore?.Get<List<ChatMessage>>("replies"); }
            set { BackingStore?.Set("replies", value); }
        }
        /// <summary>Read-only. ID of the parent chat message or root chat message of the thread. (Only applies to chat messages in channels, not chats.)</summary>
        public string ReplyToId {
            get { return BackingStore?.Get<string>("replyToId"); }
            set { BackingStore?.Set("replyToId", value); }
        }
        /// <summary>The subject of the chat message, in plaintext.</summary>
        public string Subject {
            get { return BackingStore?.Get<string>("subject"); }
            set { BackingStore?.Set("subject", value); }
        }
        /// <summary>Summary text of the chat message that could be used for push notifications and summary views or fall back views. Only applies to channel chat messages, not chat messages in a chat.</summary>
        public string Summary {
            get { return BackingStore?.Get<string>("summary"); }
            set { BackingStore?.Set("summary", value); }
        }
        /// <summary>Read-only. Link to the message in Microsoft Teams.</summary>
        public string WebUrl {
            get { return BackingStore?.Get<string>("webUrl"); }
            set { BackingStore?.Set("webUrl", value); }
        }
        /// <summary>
        /// Instantiates a new chatMessage and sets the default values.
        /// </summary>
        public ChatMessage() : base() {
            OdataType = "#microsoft.graph.chatMessage";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ChatMessage CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ChatMessage();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"attachments", n => { Attachments = n.GetCollectionOfObjectValues<ChatMessageAttachment>(ChatMessageAttachment.CreateFromDiscriminatorValue)?.ToList(); } },
                {"body", n => { Body = n.GetObjectValue<ItemBody>(ItemBody.CreateFromDiscriminatorValue); } },
                {"channelIdentity", n => { ChannelIdentity = n.GetObjectValue<Microsoft.Graph.Models.ChannelIdentity>(Microsoft.Graph.Models.ChannelIdentity.CreateFromDiscriminatorValue); } },
                {"chatId", n => { ChatId = n.GetStringValue(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"deletedDateTime", n => { DeletedDateTime = n.GetDateTimeOffsetValue(); } },
                {"etag", n => { Etag = n.GetStringValue(); } },
                {"eventDetail", n => { EventDetail = n.GetObjectValue<EventMessageDetail>(EventMessageDetail.CreateFromDiscriminatorValue); } },
                {"from", n => { From = n.GetObjectValue<ChatMessageFromIdentitySet>(ChatMessageFromIdentitySet.CreateFromDiscriminatorValue); } },
                {"hostedContents", n => { HostedContents = n.GetCollectionOfObjectValues<ChatMessageHostedContent>(ChatMessageHostedContent.CreateFromDiscriminatorValue)?.ToList(); } },
                {"importance", n => { Importance = n.GetEnumValue<ChatMessageImportance>(); } },
                {"lastEditedDateTime", n => { LastEditedDateTime = n.GetDateTimeOffsetValue(); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"locale", n => { Locale = n.GetStringValue(); } },
                {"mentions", n => { Mentions = n.GetCollectionOfObjectValues<ChatMessageMention>(ChatMessageMention.CreateFromDiscriminatorValue)?.ToList(); } },
                {"messageType", n => { MessageType = n.GetEnumValue<ChatMessageType>(); } },
                {"policyViolation", n => { PolicyViolation = n.GetObjectValue<ChatMessagePolicyViolation>(ChatMessagePolicyViolation.CreateFromDiscriminatorValue); } },
                {"reactions", n => { Reactions = n.GetCollectionOfObjectValues<ChatMessageReaction>(ChatMessageReaction.CreateFromDiscriminatorValue)?.ToList(); } },
                {"replies", n => { Replies = n.GetCollectionOfObjectValues<ChatMessage>(ChatMessage.CreateFromDiscriminatorValue)?.ToList(); } },
                {"replyToId", n => { ReplyToId = n.GetStringValue(); } },
                {"subject", n => { Subject = n.GetStringValue(); } },
                {"summary", n => { Summary = n.GetStringValue(); } },
                {"webUrl", n => { WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ChatMessageAttachment>("attachments", Attachments);
            writer.WriteObjectValue<ItemBody>("body", Body);
            writer.WriteObjectValue<Microsoft.Graph.Models.ChannelIdentity>("channelIdentity", ChannelIdentity);
            writer.WriteStringValue("chatId", ChatId);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteDateTimeOffsetValue("deletedDateTime", DeletedDateTime);
            writer.WriteStringValue("etag", Etag);
            writer.WriteObjectValue<EventMessageDetail>("eventDetail", EventDetail);
            writer.WriteObjectValue<ChatMessageFromIdentitySet>("from", From);
            writer.WriteCollectionOfObjectValues<ChatMessageHostedContent>("hostedContents", HostedContents);
            writer.WriteEnumValue<ChatMessageImportance>("importance", Importance);
            writer.WriteDateTimeOffsetValue("lastEditedDateTime", LastEditedDateTime);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteStringValue("locale", Locale);
            writer.WriteCollectionOfObjectValues<ChatMessageMention>("mentions", Mentions);
            writer.WriteEnumValue<ChatMessageType>("messageType", MessageType);
            writer.WriteObjectValue<ChatMessagePolicyViolation>("policyViolation", PolicyViolation);
            writer.WriteCollectionOfObjectValues<ChatMessageReaction>("reactions", Reactions);
            writer.WriteCollectionOfObjectValues<ChatMessage>("replies", Replies);
            writer.WriteStringValue("replyToId", ReplyToId);
            writer.WriteStringValue("subject", Subject);
            writer.WriteStringValue("summary", Summary);
            writer.WriteStringValue("webUrl", WebUrl);
        }
    }
}
