using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ItemActionStat : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>The number of times the action took place. Read-only.</summary>
        public int? ActionCount {
            get { return BackingStore?.Get<int?>("actionCount"); }
            set { BackingStore?.Set("actionCount", value); }
        }
        /// <summary>The number of distinct actors that performed the action. Read-only.</summary>
        public int? ActorCount {
            get { return BackingStore?.Get<int?>("actorCount"); }
            set { BackingStore?.Set("actorCount", value); }
        }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>
        /// Instantiates a new itemActionStat and sets the default values.
        /// </summary>
        public ItemActionStat() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ItemActionStat CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemActionStat();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"actionCount", n => { ActionCount = n.GetIntValue(); } },
                {"actorCount", n => { ActorCount = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("actionCount", ActionCount);
            writer.WriteIntValue("actorCount", ActorCount);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
