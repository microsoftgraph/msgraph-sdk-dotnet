using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SizeRange : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The maximum size (in kilobytes) that an incoming message must have in order for a condition or exception to apply.</summary>
        public int? MaximumSize {
            get { return BackingStore?.Get<int?>("maximumSize"); }
            set { BackingStore?.Set("maximumSize", value); }
        }
        /// <summary>The minimum size (in kilobytes) that an incoming message must have in order for a condition or exception to apply.</summary>
        public int? MinimumSize {
            get { return BackingStore?.Get<int?>("minimumSize"); }
            set { BackingStore?.Set("minimumSize", value); }
        }
        /// <summary>
        /// Instantiates a new sizeRange and sets the default values.
        /// </summary>
        public SizeRange() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SizeRange CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SizeRange();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"maximumSize", n => { MaximumSize = n.GetIntValue(); } },
                {"minimumSize", n => { MinimumSize = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("maximumSize", MaximumSize);
            writer.WriteIntValue("minimumSize", MinimumSize);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
