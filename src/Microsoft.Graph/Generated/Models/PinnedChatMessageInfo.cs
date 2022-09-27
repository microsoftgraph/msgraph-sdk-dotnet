using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public class PinnedChatMessageInfo : Entity, IParsable {
        /// <summary>Represents details about the chat message that is pinned.</summary>
        public ChatMessage Message {
            get { return BackingStore?.Get<ChatMessage>("message"); }
            set { BackingStore?.Set("message", value); }
        }
        /// <summary>
        /// Instantiates a new pinnedChatMessageInfo and sets the default values.
        /// </summary>
        public PinnedChatMessageInfo() : base() {
            OdataType = "#microsoft.graph.pinnedChatMessageInfo";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new PinnedChatMessageInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PinnedChatMessageInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"message", n => { Message = n.GetObjectValue<ChatMessage>(ChatMessage.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ChatMessage>("message", Message);
        }
    }
}
