using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>
    /// Color in RGB.
    /// </summary>
    public class RgbColor : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Blue value</summary>
        public byte? B {
            get { return BackingStore?.Get<byte?>("b"); }
            set { BackingStore?.Set("b", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Green value</summary>
        public byte? G {
            get { return BackingStore?.Get<byte?>("g"); }
            set { BackingStore?.Set("g", value); }
        }
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>Red value</summary>
        public byte? R {
            get { return BackingStore?.Get<byte?>("r"); }
            set { BackingStore?.Set("r", value); }
        }
        /// <summary>
        /// Instantiates a new rgbColor and sets the default values.
        /// </summary>
        public RgbColor() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static RgbColor CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RgbColor();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"b", n => { B = n.GetByteValue(); } },
                {"g", n => { G = n.GetByteValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"r", n => { R = n.GetByteValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteByteValue("b", B);
            writer.WriteByteValue("g", G);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteByteValue("r", R);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
