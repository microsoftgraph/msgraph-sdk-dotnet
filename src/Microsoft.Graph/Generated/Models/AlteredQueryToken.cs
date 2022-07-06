using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AlteredQueryToken : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Defines the length of a changed segment.</summary>
        public int? Length {
            get { return BackingStore?.Get<int?>("length"); }
            set { BackingStore?.Set("length", value); }
        }
        /// <summary>Defines the offset of a changed segment.</summary>
        public int? Offset {
            get { return BackingStore?.Get<int?>("offset"); }
            set { BackingStore?.Set("offset", value); }
        }
        /// <summary>Represents the corrected segment string.</summary>
        public string Suggestion {
            get { return BackingStore?.Get<string>("suggestion"); }
            set { BackingStore?.Set("suggestion", value); }
        }
        /// <summary>
        /// Instantiates a new alteredQueryToken and sets the default values.
        /// </summary>
        public AlteredQueryToken() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AlteredQueryToken CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AlteredQueryToken();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"length", n => { Length = n.GetIntValue(); } },
                {"offset", n => { Offset = n.GetIntValue(); } },
                {"suggestion", n => { Suggestion = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("length", Length);
            writer.WriteIntValue("offset", Offset);
            writer.WriteStringValue("suggestion", Suggestion);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
