using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Thumbnail : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The content stream for the thumbnail.</summary>
        public byte[] Content {
            get { return BackingStore?.Get<byte[]>("content"); }
            set { BackingStore?.Set("content", value); }
        }
        /// <summary>The height of the thumbnail, in pixels.</summary>
        public int? Height {
            get { return BackingStore?.Get<int?>("height"); }
            set { BackingStore?.Set("height", value); }
        }
        /// <summary>The unique identifier of the item that provided the thumbnail. This is only available when a folder thumbnail is requested.</summary>
        public string SourceItemId {
            get { return BackingStore?.Get<string>("sourceItemId"); }
            set { BackingStore?.Set("sourceItemId", value); }
        }
        /// <summary>The URL used to fetch the thumbnail content.</summary>
        public string Url {
            get { return BackingStore?.Get<string>("url"); }
            set { BackingStore?.Set("url", value); }
        }
        /// <summary>The width of the thumbnail, in pixels.</summary>
        public int? Width {
            get { return BackingStore?.Get<int?>("width"); }
            set { BackingStore?.Set("width", value); }
        }
        /// <summary>
        /// Instantiates a new thumbnail and sets the default values.
        /// </summary>
        public Thumbnail() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Thumbnail CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Thumbnail();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"content", n => { Content = n.GetByteArrayValue(); } },
                {"height", n => { Height = n.GetIntValue(); } },
                {"sourceItemId", n => { SourceItemId = n.GetStringValue(); } },
                {"url", n => { Url = n.GetStringValue(); } },
                {"width", n => { Width = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteByteArrayValue("content", Content);
            writer.WriteIntValue("height", Height);
            writer.WriteStringValue("sourceItemId", SourceItemId);
            writer.WriteStringValue("url", Url);
            writer.WriteIntValue("width", Width);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
