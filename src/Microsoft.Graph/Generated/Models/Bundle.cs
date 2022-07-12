using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Bundle : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>If the bundle is an [album][], then the album property is included</summary>
        public Microsoft.Graph.Models.Album Album {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Album>("album"); }
            set { BackingStore?.Set("album", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Number of children contained immediately within this container.</summary>
        public int? ChildCount {
            get { return BackingStore?.Get<int?>("childCount"); }
            set { BackingStore?.Set("childCount", value); }
        }
        /// <summary>
        /// Instantiates a new bundle and sets the default values.
        /// </summary>
        public Bundle() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Bundle CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Bundle();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"album", n => { Album = n.GetObjectValue<Microsoft.Graph.Models.Album>(Microsoft.Graph.Models.Album.CreateFromDiscriminatorValue); } },
                {"childCount", n => { ChildCount = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Microsoft.Graph.Models.Album>("album", Album);
            writer.WriteIntValue("childCount", ChildCount);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
