using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class ConversationThread : Entity, IParsable {
        /// <summary>The Cc: recipients for the thread. Returned only on $select.</summary>
        public List<Recipient> CcRecipients {
            get { return BackingStore?.Get<List<Recipient>>("ccRecipients"); }
            set { BackingStore?.Set("ccRecipients", value); }
        }
        /// <summary>Indicates whether any of the posts within this thread has at least one attachment. Returned by default.</summary>
        public bool? HasAttachments {
            get { return BackingStore?.Get<bool?>("hasAttachments"); }
            set { BackingStore?.Set("hasAttachments", value); }
        }
        /// <summary>Indicates if the thread is locked. Returned by default.</summary>
        public bool? IsLocked {
            get { return BackingStore?.Get<bool?>("isLocked"); }
            set { BackingStore?.Set("isLocked", value); }
        }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Returned by default.</summary>
        public DateTimeOffset? LastDeliveredDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastDeliveredDateTime"); }
            set { BackingStore?.Set("lastDeliveredDateTime", value); }
        }
        /// <summary>The posts property</summary>
        public List<Post> Posts {
            get { return BackingStore?.Get<List<Post>>("posts"); }
            set { BackingStore?.Set("posts", value); }
        }
        /// <summary>A short summary from the body of the latest post in this conversation. Returned by default.</summary>
        public string Preview {
            get { return BackingStore?.Get<string>("preview"); }
            set { BackingStore?.Set("preview", value); }
        }
        /// <summary>The topic of the conversation. This property can be set when the conversation is created, but it cannot be updated. Returned by default.</summary>
        public string Topic {
            get { return BackingStore?.Get<string>("topic"); }
            set { BackingStore?.Set("topic", value); }
        }
        /// <summary>The To: recipients for the thread. Returned only on $select.</summary>
        public List<Recipient> ToRecipients {
            get { return BackingStore?.Get<List<Recipient>>("toRecipients"); }
            set { BackingStore?.Set("toRecipients", value); }
        }
        /// <summary>All the users that sent a message to this thread. Returned by default.</summary>
        public List<string> UniqueSenders {
            get { return BackingStore?.Get<List<string>>("uniqueSenders"); }
            set { BackingStore?.Set("uniqueSenders", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ConversationThread CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ConversationThread();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"ccRecipients", n => { CcRecipients = n.GetCollectionOfObjectValues<Recipient>(Recipient.CreateFromDiscriminatorValue).ToList(); } },
                {"hasAttachments", n => { HasAttachments = n.GetBoolValue(); } },
                {"isLocked", n => { IsLocked = n.GetBoolValue(); } },
                {"lastDeliveredDateTime", n => { LastDeliveredDateTime = n.GetDateTimeOffsetValue(); } },
                {"posts", n => { Posts = n.GetCollectionOfObjectValues<Post>(Post.CreateFromDiscriminatorValue).ToList(); } },
                {"preview", n => { Preview = n.GetStringValue(); } },
                {"topic", n => { Topic = n.GetStringValue(); } },
                {"toRecipients", n => { ToRecipients = n.GetCollectionOfObjectValues<Recipient>(Recipient.CreateFromDiscriminatorValue).ToList(); } },
                {"uniqueSenders", n => { UniqueSenders = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Recipient>("ccRecipients", CcRecipients);
            writer.WriteBoolValue("hasAttachments", HasAttachments);
            writer.WriteBoolValue("isLocked", IsLocked);
            writer.WriteDateTimeOffsetValue("lastDeliveredDateTime", LastDeliveredDateTime);
            writer.WriteCollectionOfObjectValues<Post>("posts", Posts);
            writer.WriteStringValue("preview", Preview);
            writer.WriteStringValue("topic", Topic);
            writer.WriteCollectionOfObjectValues<Recipient>("toRecipients", ToRecipients);
            writer.WriteCollectionOfPrimitiveValues<string>("uniqueSenders", UniqueSenders);
        }
    }
}
