using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ChatMessageAttachment : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The content of the attachment. If the attachment is a rich card, set the property to the rich card object. This property and contentUrl are mutually exclusive.</summary>
        public string Content {
            get { return BackingStore?.Get<string>("content"); }
            set { BackingStore?.Set("content", value); }
        }
        /// <summary>The media type of the content attachment. It can have the following values: reference: Attachment is a link to another file. Populate the contentURL with the link to the object.Any contentTypes supported by the Bot Framework&apos;s Attachment objectapplication/vnd.microsoft.card.codesnippet: A code snippet. application/vnd.microsoft.card.announcement: An announcement header.</summary>
        public string ContentType {
            get { return BackingStore?.Get<string>("contentType"); }
            set { BackingStore?.Set("contentType", value); }
        }
        /// <summary>URL for the content of the attachment. Supported protocols: http, https, file and data.</summary>
        public string ContentUrl {
            get { return BackingStore?.Get<string>("contentUrl"); }
            set { BackingStore?.Set("contentUrl", value); }
        }
        /// <summary>Read-only. Unique id of the attachment.</summary>
        public string Id {
            get { return BackingStore?.Get<string>("id"); }
            set { BackingStore?.Set("id", value); }
        }
        /// <summary>Name of the attachment.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>URL to a thumbnail image that the channel can use if it supports using an alternative, smaller form of content or contentUrl. For example, if you set contentType to application/word and set contentUrl to the location of the Word document, you might include a thumbnail image that represents the document. The channel could display the thumbnail image instead of the document. When the user clicks the image, the channel would open the document.</summary>
        public string ThumbnailUrl {
            get { return BackingStore?.Get<string>("thumbnailUrl"); }
            set { BackingStore?.Set("thumbnailUrl", value); }
        }
        /// <summary>
        /// Instantiates a new chatMessageAttachment and sets the default values.
        /// </summary>
        public ChatMessageAttachment() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ChatMessageAttachment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ChatMessageAttachment();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"content", n => { Content = n.GetStringValue(); } },
                {"contentType", n => { ContentType = n.GetStringValue(); } },
                {"contentUrl", n => { ContentUrl = n.GetStringValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"thumbnailUrl", n => { ThumbnailUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("content", Content);
            writer.WriteStringValue("contentType", ContentType);
            writer.WriteStringValue("contentUrl", ContentUrl);
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("name", Name);
            writer.WriteStringValue("thumbnailUrl", ThumbnailUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
