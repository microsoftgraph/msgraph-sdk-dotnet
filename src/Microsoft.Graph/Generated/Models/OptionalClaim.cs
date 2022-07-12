using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class OptionalClaim : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Additional properties of the claim. If a property exists in this collection, it modifies the behavior of the optional claim specified in the name property.</summary>
        public List<string> AdditionalProperties {
            get { return BackingStore?.Get<List<string>>("additionalProperties"); }
            set { BackingStore?.Set("additionalProperties", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>If the value is true, the claim specified by the client is necessary to ensure a smooth authorization experience for the specific task requested by the end user. The default value is false.</summary>
        public bool? Essential {
            get { return BackingStore?.Get<bool?>("essential"); }
            set { BackingStore?.Set("essential", value); }
        }
        /// <summary>The name of the optional claim.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>The source (directory object) of the claim. There are predefined claims and user-defined claims from extension properties. If the source value is null, the claim is a predefined optional claim. If the source value is user, the value in the name property is the extension property from the user object.</summary>
        public string Source {
            get { return BackingStore?.Get<string>("source"); }
            set { BackingStore?.Set("source", value); }
        }
        /// <summary>
        /// Instantiates a new optionalClaim and sets the default values.
        /// </summary>
        public OptionalClaim() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static OptionalClaim CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OptionalClaim();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"additionalProperties", n => { AdditionalProperties = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"essential", n => { Essential = n.GetBoolValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"source", n => { Source = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("additionalProperties", AdditionalProperties);
            writer.WriteBoolValue("essential", Essential);
            writer.WriteStringValue("name", Name);
            writer.WriteStringValue("source", Source);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
