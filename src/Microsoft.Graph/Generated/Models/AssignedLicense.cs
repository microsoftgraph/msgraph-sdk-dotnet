using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AssignedLicense : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>A collection of the unique identifiers for plans that have been disabled.</summary>
        public List<string> DisabledPlans {
            get { return BackingStore?.Get<List<string>>("disabledPlans"); }
            set { BackingStore?.Set("disabledPlans", value); }
        }
        /// <summary>The unique identifier for the SKU.</summary>
        public string SkuId {
            get { return BackingStore?.Get<string>("skuId"); }
            set { BackingStore?.Set("skuId", value); }
        }
        /// <summary>
        /// Instantiates a new assignedLicense and sets the default values.
        /// </summary>
        public AssignedLicense() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AssignedLicense CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AssignedLicense();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"disabledPlans", n => { DisabledPlans = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"skuId", n => { SkuId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("disabledPlans", DisabledPlans);
            writer.WriteStringValue("skuId", SkuId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
