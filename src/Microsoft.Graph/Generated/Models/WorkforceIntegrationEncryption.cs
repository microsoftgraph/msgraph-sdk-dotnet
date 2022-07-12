using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkforceIntegrationEncryption : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Possible values are: sharedSecret, unknownFutureValue.</summary>
        public WorkforceIntegrationEncryptionProtocol? Protocol {
            get { return BackingStore?.Get<WorkforceIntegrationEncryptionProtocol?>("protocol"); }
            set { BackingStore?.Set("protocol", value); }
        }
        /// <summary>Encryption shared secret.</summary>
        public string Secret {
            get { return BackingStore?.Get<string>("secret"); }
            set { BackingStore?.Set("secret", value); }
        }
        /// <summary>
        /// Instantiates a new workforceIntegrationEncryption and sets the default values.
        /// </summary>
        public WorkforceIntegrationEncryption() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static WorkforceIntegrationEncryption CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkforceIntegrationEncryption();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"protocol", n => { Protocol = n.GetEnumValue<WorkforceIntegrationEncryptionProtocol>(); } },
                {"secret", n => { Secret = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<WorkforceIntegrationEncryptionProtocol>("protocol", Protocol);
            writer.WriteStringValue("secret", Secret);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
