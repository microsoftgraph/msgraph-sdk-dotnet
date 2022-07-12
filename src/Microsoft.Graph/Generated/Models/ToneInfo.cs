using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ToneInfo : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>An incremental identifier used for ordering DTMF events.</summary>
        public long? SequenceId {
            get { return BackingStore?.Get<long?>("sequenceId"); }
            set { BackingStore?.Set("sequenceId", value); }
        }
        /// <summary>The tone property</summary>
        public Microsoft.Graph.Models.Tone? Tone {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Tone?>("tone"); }
            set { BackingStore?.Set("tone", value); }
        }
        /// <summary>
        /// Instantiates a new toneInfo and sets the default values.
        /// </summary>
        public ToneInfo() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ToneInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ToneInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"sequenceId", n => { SequenceId = n.GetLongValue(); } },
                {"tone", n => { Tone = n.GetEnumValue<Tone>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteLongValue("sequenceId", SequenceId);
            writer.WriteEnumValue<Tone>("tone", Tone);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
