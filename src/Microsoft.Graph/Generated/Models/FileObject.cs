using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class FileObject : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Hashes of the file&apos;s binary content, if available. Read-only.</summary>
        public Microsoft.Graph.Models.Hashes Hashes {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Hashes>("hashes"); }
            set { BackingStore?.Set("hashes", value); }
        }
        /// <summary>The MIME type for the file. This is determined by logic on the server and might not be the value provided when the file was uploaded. Read-only.</summary>
        public string MimeType {
            get { return BackingStore?.Get<string>("mimeType"); }
            set { BackingStore?.Set("mimeType", value); }
        }
        /// <summary>The processingMetadata property</summary>
        public bool? ProcessingMetadata {
            get { return BackingStore?.Get<bool?>("processingMetadata"); }
            set { BackingStore?.Set("processingMetadata", value); }
        }
        /// <summary>
        /// Instantiates a new fileObject and sets the default values.
        /// </summary>
        public FileObject() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static FileObject CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new FileObject();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"hashes", n => { Hashes = n.GetObjectValue<Microsoft.Graph.Models.Hashes>(Microsoft.Graph.Models.Hashes.CreateFromDiscriminatorValue); } },
                {"mimeType", n => { MimeType = n.GetStringValue(); } },
                {"processingMetadata", n => { ProcessingMetadata = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Microsoft.Graph.Models.Hashes>("hashes", Hashes);
            writer.WriteStringValue("mimeType", MimeType);
            writer.WriteBoolValue("processingMetadata", ProcessingMetadata);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
