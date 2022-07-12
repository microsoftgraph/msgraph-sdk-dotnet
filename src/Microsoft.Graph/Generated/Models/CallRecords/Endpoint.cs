using Microsoft.Graph.Models.CallRecords;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.CallRecords {
    public class Endpoint : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The type property</summary>
        public string Type {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>User-agent reported by this endpoint.</summary>
        public Microsoft.Graph.Models.CallRecords.UserAgent UserAgent {
            get { return BackingStore?.Get<Microsoft.Graph.Models.CallRecords.UserAgent>("userAgent"); }
            set { BackingStore?.Set("userAgent", value); }
        }
        /// <summary>
        /// Instantiates a new endpoint and sets the default values.
        /// </summary>
        public Endpoint() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
            Type = "#microsoft.graph.callRecords.endpoint";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Endpoint CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.callRecords.participantEndpoint" => new ParticipantEndpoint(),
                "#microsoft.graph.callRecords.serviceEndpoint" => new ServiceEndpoint(),
                _ => new Endpoint(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"@odata.type", n => { Type = n.GetStringValue(); } },
                {"userAgent", n => { UserAgent = n.GetObjectValue<Microsoft.Graph.Models.CallRecords.UserAgent>(Microsoft.Graph.Models.CallRecords.UserAgent.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("@odata.type", Type);
            writer.WriteObjectValue<Microsoft.Graph.Models.CallRecords.UserAgent>("userAgent", UserAgent);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
