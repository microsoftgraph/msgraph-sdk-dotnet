using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AttachmentItem : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The type of attachment. Possible values are: file, item, reference. Required.</summary>
        public Microsoft.Graph.Models.AttachmentType? AttachmentType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.AttachmentType?>("attachmentType"); }
            set { BackingStore?.Set("attachmentType", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The CID or Content-Id of the attachment for referencing in case of in-line attachments using &lt;img src=&apos;cid:contentId&apos;&gt; tag in HTML messages. Optional.</summary>
        public string ContentId {
            get { return BackingStore?.Get<string>("contentId"); }
            set { BackingStore?.Set("contentId", value); }
        }
        /// <summary>The nature of the data in the attachment. Optional.</summary>
        public string ContentType {
            get { return BackingStore?.Get<string>("contentType"); }
            set { BackingStore?.Set("contentType", value); }
        }
        /// <summary>true if the attachment is an inline attachment; otherwise, false. Optional.</summary>
        public bool? IsInline {
            get { return BackingStore?.Get<bool?>("isInline"); }
            set { BackingStore?.Set("isInline", value); }
        }
        /// <summary>The display name of the attachment. This can be a descriptive string and does not have to be the actual file name. Required.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>The length of the attachment in bytes. Required.</summary>
        public long? Size {
            get { return BackingStore?.Get<long?>("size"); }
            set { BackingStore?.Set("size", value); }
        }
        /// <summary>
        /// Instantiates a new attachmentItem and sets the default values.
        /// </summary>
        public AttachmentItem() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AttachmentItem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AttachmentItem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"attachmentType", n => { AttachmentType = n.GetEnumValue<AttachmentType>(); } },
                {"contentId", n => { ContentId = n.GetStringValue(); } },
                {"contentType", n => { ContentType = n.GetStringValue(); } },
                {"isInline", n => { IsInline = n.GetBoolValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"size", n => { Size = n.GetLongValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<AttachmentType>("attachmentType", AttachmentType);
            writer.WriteStringValue("contentId", ContentId);
            writer.WriteStringValue("contentType", ContentType);
            writer.WriteBoolValue("isInline", IsInline);
            writer.WriteStringValue("name", Name);
            writer.WriteLongValue("size", Size);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
