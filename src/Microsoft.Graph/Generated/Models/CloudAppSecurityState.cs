using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CloudAppSecurityState : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Destination IP Address of the connection to the cloud application/service.</summary>
        public string DestinationServiceIp {
            get { return BackingStore?.Get<string>("destinationServiceIp"); }
            set { BackingStore?.Set("destinationServiceIp", value); }
        }
        /// <summary>Cloud application/service name (for example &apos;Salesforce&apos;, &apos;DropBox&apos;, etc.).</summary>
        public string DestinationServiceName {
            get { return BackingStore?.Get<string>("destinationServiceName"); }
            set { BackingStore?.Set("destinationServiceName", value); }
        }
        /// <summary>Provider-generated/calculated risk score of the Cloud Application/Service. Recommended value range of 0-1, which equates to a percentage.</summary>
        public string RiskScore {
            get { return BackingStore?.Get<string>("riskScore"); }
            set { BackingStore?.Set("riskScore", value); }
        }
        /// <summary>
        /// Instantiates a new cloudAppSecurityState and sets the default values.
        /// </summary>
        public CloudAppSecurityState() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static CloudAppSecurityState CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CloudAppSecurityState();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"destinationServiceIp", n => { DestinationServiceIp = n.GetStringValue(); } },
                {"destinationServiceName", n => { DestinationServiceName = n.GetStringValue(); } },
                {"riskScore", n => { RiskScore = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("destinationServiceIp", DestinationServiceIp);
            writer.WriteStringValue("destinationServiceName", DestinationServiceName);
            writer.WriteStringValue("riskScore", RiskScore);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
