using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class OnenotePagePreview : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The links property</summary>
        public OnenotePagePreviewLinks Links {
            get { return BackingStore?.Get<OnenotePagePreviewLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
        /// <summary>The previewText property</summary>
        public string PreviewText {
            get { return BackingStore?.Get<string>("previewText"); }
            set { BackingStore?.Set("previewText", value); }
        }
        /// <summary>
        /// Instantiates a new onenotePagePreview and sets the default values.
        /// </summary>
        public OnenotePagePreview() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static OnenotePagePreview CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OnenotePagePreview();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"links", n => { Links = n.GetObjectValue<OnenotePagePreviewLinks>(OnenotePagePreviewLinks.CreateFromDiscriminatorValue); } },
                {"previewText", n => { PreviewText = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<OnenotePagePreviewLinks>("links", Links);
            writer.WriteStringValue("previewText", PreviewText);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
