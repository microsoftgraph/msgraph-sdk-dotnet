using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ChatMessageMention : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Index of an entity being mentioned in the specified chatMessage. Matches the {index} value in the corresponding &lt;at id=&apos;{index}&apos;&gt; tag in the message body.</summary>
        public int? Id {
            get { return BackingStore?.Get<int?>("id"); }
            set { BackingStore?.Set("id", value); }
        }
        /// <summary>The entity (user, application, team, or channel) that was @mentioned.</summary>
        public ChatMessageMentionedIdentitySet Mentioned {
            get { return BackingStore?.Get<ChatMessageMentionedIdentitySet>("mentioned"); }
            set { BackingStore?.Set("mentioned", value); }
        }
        /// <summary>String used to represent the mention. For example, a user&apos;s display name, a team name.</summary>
        public string MentionText {
            get { return BackingStore?.Get<string>("mentionText"); }
            set { BackingStore?.Set("mentionText", value); }
        }
        /// <summary>
        /// Instantiates a new chatMessageMention and sets the default values.
        /// </summary>
        public ChatMessageMention() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ChatMessageMention CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ChatMessageMention();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"id", n => { Id = n.GetIntValue(); } },
                {"mentioned", n => { Mentioned = n.GetObjectValue<ChatMessageMentionedIdentitySet>(ChatMessageMentionedIdentitySet.CreateFromDiscriminatorValue); } },
                {"mentionText", n => { MentionText = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("id", Id);
            writer.WriteObjectValue<ChatMessageMentionedIdentitySet>("mentioned", Mentioned);
            writer.WriteStringValue("mentionText", MentionText);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
