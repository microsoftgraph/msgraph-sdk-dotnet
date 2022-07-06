using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ImageInfo : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Optional; parameter used to indicate the server is able to render image dynamically in response to parameterization. For example – a high contrast image</summary>
        public bool? AddImageQuery {
            get { return BackingStore?.Get<bool?>("addImageQuery"); }
            set { BackingStore?.Set("addImageQuery", value); }
        }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Optional; alt-text accessible content for the image</summary>
        public string AlternateText {
            get { return BackingStore?.Get<string>("alternateText"); }
            set { BackingStore?.Set("alternateText", value); }
        }
        /// <summary>The alternativeText property</summary>
        public string AlternativeText {
            get { return BackingStore?.Get<string>("alternativeText"); }
            set { BackingStore?.Set("alternativeText", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Optional; URI that points to an icon which represents the application used to generate the activity</summary>
        public string IconUrl {
            get { return BackingStore?.Get<string>("iconUrl"); }
            set { BackingStore?.Set("iconUrl", value); }
        }
        /// <summary>
        /// Instantiates a new imageInfo and sets the default values.
        /// </summary>
        public ImageInfo() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ImageInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ImageInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"addImageQuery", n => { AddImageQuery = n.GetBoolValue(); } },
                {"alternateText", n => { AlternateText = n.GetStringValue(); } },
                {"alternativeText", n => { AlternativeText = n.GetStringValue(); } },
                {"iconUrl", n => { IconUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("addImageQuery", AddImageQuery);
            writer.WriteStringValue("alternateText", AlternateText);
            writer.WriteStringValue("alternativeText", AlternativeText);
            writer.WriteStringValue("iconUrl", IconUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
