using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PrintMargin : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The margin in microns from the bottom edge.</summary>
        public int? Bottom {
            get { return BackingStore?.Get<int?>("bottom"); }
            set { BackingStore?.Set("bottom", value); }
        }
        /// <summary>The margin in microns from the left edge.</summary>
        public int? Left {
            get { return BackingStore?.Get<int?>("left"); }
            set { BackingStore?.Set("left", value); }
        }
        /// <summary>The margin in microns from the right edge.</summary>
        public int? Right {
            get { return BackingStore?.Get<int?>("right"); }
            set { BackingStore?.Set("right", value); }
        }
        /// <summary>The margin in microns from the top edge.</summary>
        public int? Top {
            get { return BackingStore?.Get<int?>("top"); }
            set { BackingStore?.Set("top", value); }
        }
        /// <summary>
        /// Instantiates a new printMargin and sets the default values.
        /// </summary>
        public PrintMargin() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static PrintMargin CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PrintMargin();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"bottom", n => { Bottom = n.GetIntValue(); } },
                {"left", n => { Left = n.GetIntValue(); } },
                {"right", n => { Right = n.GetIntValue(); } },
                {"top", n => { Top = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("bottom", Bottom);
            writer.WriteIntValue("left", Left);
            writer.WriteIntValue("right", Right);
            writer.WriteIntValue("top", Top);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
