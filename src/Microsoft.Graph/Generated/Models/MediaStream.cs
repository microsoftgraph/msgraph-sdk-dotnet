using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class MediaStream : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The direction property</summary>
        public MediaDirection? Direction {
            get { return BackingStore?.Get<MediaDirection?>("direction"); }
            set { BackingStore?.Set("direction", value); }
        }
        /// <summary>The media stream label.</summary>
        public string Label {
            get { return BackingStore?.Get<string>("label"); }
            set { BackingStore?.Set("label", value); }
        }
        /// <summary>The mediaType property</summary>
        public Modality? MediaType {
            get { return BackingStore?.Get<Modality?>("mediaType"); }
            set { BackingStore?.Set("mediaType", value); }
        }
        /// <summary>Indicates whether the media is muted by the server.</summary>
        public bool? ServerMuted {
            get { return BackingStore?.Get<bool?>("serverMuted"); }
            set { BackingStore?.Set("serverMuted", value); }
        }
        /// <summary>The source ID.</summary>
        public string SourceId {
            get { return BackingStore?.Get<string>("sourceId"); }
            set { BackingStore?.Set("sourceId", value); }
        }
        /// <summary>
        /// Instantiates a new mediaStream and sets the default values.
        /// </summary>
        public MediaStream() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static MediaStream CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MediaStream();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"direction", n => { Direction = n.GetEnumValue<MediaDirection>(); } },
                {"label", n => { Label = n.GetStringValue(); } },
                {"mediaType", n => { MediaType = n.GetEnumValue<Modality>(); } },
                {"serverMuted", n => { ServerMuted = n.GetBoolValue(); } },
                {"sourceId", n => { SourceId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<MediaDirection>("direction", Direction);
            writer.WriteStringValue("label", Label);
            writer.WriteEnumValue<Modality>("mediaType", MediaType);
            writer.WriteBoolValue("serverMuted", ServerMuted);
            writer.WriteStringValue("sourceId", SourceId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
