// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class ChatMessage : global::Microsoft.Graph.Models.Entity, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>References to attached objects like files, tabs, meetings etc.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.ChatMessageAttachment>? Attachments
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageAttachment>?>("attachments"); }
            set { BackingStore?.Set("attachments", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.ChatMessageAttachment> Attachments
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageAttachment>>("attachments"); }
            set { BackingStore?.Set("attachments", value); }
        }
#endif
        /// <summary>The body property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.ItemBody? Body
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ItemBody?>("body"); }
            set { BackingStore?.Set("body", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.ItemBody Body
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ItemBody>("body"); }
            set { BackingStore?.Set("body", value); }
        }
#endif
        /// <summary>If the message was sent in a channel, represents identity of the channel.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.ChannelIdentity? ChannelIdentity
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ChannelIdentity?>("channelIdentity"); }
            set { BackingStore?.Set("channelIdentity", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.ChannelIdentity ChannelIdentity
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ChannelIdentity>("channelIdentity"); }
            set { BackingStore?.Set("channelIdentity", value); }
        }
#endif
        /// <summary>If the message was sent in a chat, represents the identity of the chat.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ChatId
        {
            get { return BackingStore?.Get<string?>("chatId"); }
            set { BackingStore?.Set("chatId", value); }
        }
#nullable restore
#else
        public string ChatId
        {
            get { return BackingStore?.Get<string>("chatId"); }
            set { BackingStore?.Set("chatId", value); }
        }
#endif
        /// <summary>Timestamp of when the chat message was created.</summary>
        public DateTimeOffset? CreatedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Read only. Timestamp at which the chat message was deleted, or null if not deleted.</summary>
        public DateTimeOffset? DeletedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("deletedDateTime"); }
            set { BackingStore?.Set("deletedDateTime", value); }
        }
        /// <summary>Read-only. Version number of the chat message.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Etag
        {
            get { return BackingStore?.Get<string?>("etag"); }
            set { BackingStore?.Set("etag", value); }
        }
#nullable restore
#else
        public string Etag
        {
            get { return BackingStore?.Get<string>("etag"); }
            set { BackingStore?.Set("etag", value); }
        }
#endif
        /// <summary>Read-only. If present, represents details of an event that happened in a chat, a channel, or a team, for example, adding new members. For event messages, the messageType property will be set to systemEventMessage.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.EventMessageDetail? EventDetail
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.EventMessageDetail?>("eventDetail"); }
            set { BackingStore?.Set("eventDetail", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.EventMessageDetail EventDetail
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.EventMessageDetail>("eventDetail"); }
            set { BackingStore?.Set("eventDetail", value); }
        }
#endif
        /// <summary>Details of the sender of the chat message. Can only be set during migration.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.ChatMessageFromIdentitySet? From
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ChatMessageFromIdentitySet?>("from"); }
            set { BackingStore?.Set("from", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.ChatMessageFromIdentitySet From
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ChatMessageFromIdentitySet>("from"); }
            set { BackingStore?.Set("from", value); }
        }
#endif
        /// <summary>Content in a message hosted by Microsoft Teams - for example, images or code snippets.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.ChatMessageHostedContent>? HostedContents
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageHostedContent>?>("hostedContents"); }
            set { BackingStore?.Set("hostedContents", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.ChatMessageHostedContent> HostedContents
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageHostedContent>>("hostedContents"); }
            set { BackingStore?.Set("hostedContents", value); }
        }
#endif
        /// <summary>The importance property</summary>
        public global::Microsoft.Graph.Models.ChatMessageImportance? Importance
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ChatMessageImportance?>("importance"); }
            set { BackingStore?.Set("importance", value); }
        }
        /// <summary>Read only. Timestamp when edits to the chat message were made. Triggers an &apos;Edited&apos; flag in the Teams UI. If no edits are made the value is null.</summary>
        public DateTimeOffset? LastEditedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("lastEditedDateTime"); }
            set { BackingStore?.Set("lastEditedDateTime", value); }
        }
        /// <summary>Read only. Timestamp when the chat message is created (initial setting) or modified, including when a reaction is added or removed.</summary>
        public DateTimeOffset? LastModifiedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>Locale of the chat message set by the client. Always set to en-us.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Locale
        {
            get { return BackingStore?.Get<string?>("locale"); }
            set { BackingStore?.Set("locale", value); }
        }
#nullable restore
#else
        public string Locale
        {
            get { return BackingStore?.Get<string>("locale"); }
            set { BackingStore?.Set("locale", value); }
        }
#endif
        /// <summary>List of entities mentioned in the chat message. Supported entities are: user, bot, team, channel, chat, and tag.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.ChatMessageMention>? Mentions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageMention>?>("mentions"); }
            set { BackingStore?.Set("mentions", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.ChatMessageMention> Mentions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageMention>>("mentions"); }
            set { BackingStore?.Set("mentions", value); }
        }
#endif
        /// <summary>List of activity history of a message item, including modification time and actions, such as reactionAdded, reactionRemoved, or reaction changes, on the message.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.ChatMessageHistoryItem>? MessageHistory
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageHistoryItem>?>("messageHistory"); }
            set { BackingStore?.Set("messageHistory", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.ChatMessageHistoryItem> MessageHistory
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageHistoryItem>>("messageHistory"); }
            set { BackingStore?.Set("messageHistory", value); }
        }
#endif
        /// <summary>The messageType property</summary>
        public global::Microsoft.Graph.Models.ChatMessageType? MessageType
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ChatMessageType?>("messageType"); }
            set { BackingStore?.Set("messageType", value); }
        }
        /// <summary>Defines the properties of a policy violation set by a data loss prevention (DLP) application.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.ChatMessagePolicyViolation? PolicyViolation
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ChatMessagePolicyViolation?>("policyViolation"); }
            set { BackingStore?.Set("policyViolation", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.ChatMessagePolicyViolation PolicyViolation
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ChatMessagePolicyViolation>("policyViolation"); }
            set { BackingStore?.Set("policyViolation", value); }
        }
#endif
        /// <summary>Reactions for this chat message (for example, Like).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.ChatMessageReaction>? Reactions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageReaction>?>("reactions"); }
            set { BackingStore?.Set("reactions", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.ChatMessageReaction> Reactions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessageReaction>>("reactions"); }
            set { BackingStore?.Set("reactions", value); }
        }
#endif
        /// <summary>Replies for a specified message. Supports $expand for channel messages.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.ChatMessage>? Replies
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessage>?>("replies"); }
            set { BackingStore?.Set("replies", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.ChatMessage> Replies
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ChatMessage>>("replies"); }
            set { BackingStore?.Set("replies", value); }
        }
#endif
        /// <summary>Read-only. ID of the parent chat message or root chat message of the thread. (Only applies to chat messages in channels, not chats.)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ReplyToId
        {
            get { return BackingStore?.Get<string?>("replyToId"); }
            set { BackingStore?.Set("replyToId", value); }
        }
#nullable restore
#else
        public string ReplyToId
        {
            get { return BackingStore?.Get<string>("replyToId"); }
            set { BackingStore?.Set("replyToId", value); }
        }
#endif
        /// <summary>The subject of the chat message, in plaintext.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Subject
        {
            get { return BackingStore?.Get<string?>("subject"); }
            set { BackingStore?.Set("subject", value); }
        }
#nullable restore
#else
        public string Subject
        {
            get { return BackingStore?.Get<string>("subject"); }
            set { BackingStore?.Set("subject", value); }
        }
#endif
        /// <summary>Summary text of the chat message that could be used for push notifications and summary views or fall back views. Only applies to channel chat messages, not chat messages in a chat.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Summary
        {
            get { return BackingStore?.Get<string?>("summary"); }
            set { BackingStore?.Set("summary", value); }
        }
#nullable restore
#else
        public string Summary
        {
            get { return BackingStore?.Get<string>("summary"); }
            set { BackingStore?.Set("summary", value); }
        }
#endif
        /// <summary>Read-only. Link to the message in Microsoft Teams.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? WebUrl
        {
            get { return BackingStore?.Get<string?>("webUrl"); }
            set { BackingStore?.Set("webUrl", value); }
        }
#nullable restore
#else
        public string WebUrl
        {
            get { return BackingStore?.Get<string>("webUrl"); }
            set { BackingStore?.Set("webUrl", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.ChatMessage"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.ChatMessage CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Microsoft.Graph.Models.ChatMessage();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "attachments", n => { Attachments = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageAttachment>(global::Microsoft.Graph.Models.ChatMessageAttachment.CreateFromDiscriminatorValue)?.AsList(); } },
                { "body", n => { Body = n.GetObjectValue<global::Microsoft.Graph.Models.ItemBody>(global::Microsoft.Graph.Models.ItemBody.CreateFromDiscriminatorValue); } },
                { "channelIdentity", n => { ChannelIdentity = n.GetObjectValue<global::Microsoft.Graph.Models.ChannelIdentity>(global::Microsoft.Graph.Models.ChannelIdentity.CreateFromDiscriminatorValue); } },
                { "chatId", n => { ChatId = n.GetStringValue(); } },
                { "createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                { "deletedDateTime", n => { DeletedDateTime = n.GetDateTimeOffsetValue(); } },
                { "etag", n => { Etag = n.GetStringValue(); } },
                { "eventDetail", n => { EventDetail = n.GetObjectValue<global::Microsoft.Graph.Models.EventMessageDetail>(global::Microsoft.Graph.Models.EventMessageDetail.CreateFromDiscriminatorValue); } },
                { "from", n => { From = n.GetObjectValue<global::Microsoft.Graph.Models.ChatMessageFromIdentitySet>(global::Microsoft.Graph.Models.ChatMessageFromIdentitySet.CreateFromDiscriminatorValue); } },
                { "hostedContents", n => { HostedContents = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageHostedContent>(global::Microsoft.Graph.Models.ChatMessageHostedContent.CreateFromDiscriminatorValue)?.AsList(); } },
                { "importance", n => { Importance = n.GetEnumValue<global::Microsoft.Graph.Models.ChatMessageImportance>(); } },
                { "lastEditedDateTime", n => { LastEditedDateTime = n.GetDateTimeOffsetValue(); } },
                { "lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                { "locale", n => { Locale = n.GetStringValue(); } },
                { "mentions", n => { Mentions = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageMention>(global::Microsoft.Graph.Models.ChatMessageMention.CreateFromDiscriminatorValue)?.AsList(); } },
                { "messageHistory", n => { MessageHistory = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageHistoryItem>(global::Microsoft.Graph.Models.ChatMessageHistoryItem.CreateFromDiscriminatorValue)?.AsList(); } },
                { "messageType", n => { MessageType = n.GetEnumValue<global::Microsoft.Graph.Models.ChatMessageType>(); } },
                { "policyViolation", n => { PolicyViolation = n.GetObjectValue<global::Microsoft.Graph.Models.ChatMessagePolicyViolation>(global::Microsoft.Graph.Models.ChatMessagePolicyViolation.CreateFromDiscriminatorValue); } },
                { "reactions", n => { Reactions = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageReaction>(global::Microsoft.Graph.Models.ChatMessageReaction.CreateFromDiscriminatorValue)?.AsList(); } },
                { "replies", n => { Replies = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessage>(global::Microsoft.Graph.Models.ChatMessage.CreateFromDiscriminatorValue)?.AsList(); } },
                { "replyToId", n => { ReplyToId = n.GetStringValue(); } },
                { "subject", n => { Subject = n.GetStringValue(); } },
                { "summary", n => { Summary = n.GetStringValue(); } },
                { "webUrl", n => { WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageAttachment>("attachments", Attachments);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.ItemBody>("body", Body);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.ChannelIdentity>("channelIdentity", ChannelIdentity);
            writer.WriteStringValue("chatId", ChatId);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteDateTimeOffsetValue("deletedDateTime", DeletedDateTime);
            writer.WriteStringValue("etag", Etag);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.EventMessageDetail>("eventDetail", EventDetail);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.ChatMessageFromIdentitySet>("from", From);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageHostedContent>("hostedContents", HostedContents);
            writer.WriteEnumValue<global::Microsoft.Graph.Models.ChatMessageImportance>("importance", Importance);
            writer.WriteDateTimeOffsetValue("lastEditedDateTime", LastEditedDateTime);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteStringValue("locale", Locale);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageMention>("mentions", Mentions);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageHistoryItem>("messageHistory", MessageHistory);
            writer.WriteEnumValue<global::Microsoft.Graph.Models.ChatMessageType>("messageType", MessageType);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.ChatMessagePolicyViolation>("policyViolation", PolicyViolation);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessageReaction>("reactions", Reactions);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.ChatMessage>("replies", Replies);
            writer.WriteStringValue("replyToId", ReplyToId);
            writer.WriteStringValue("subject", Subject);
            writer.WriteStringValue("summary", Summary);
            writer.WriteStringValue("webUrl", WebUrl);
        }
    }
}
#pragma warning restore CS0618
