using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ProvisioningStatusInfo : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The errorInformation property</summary>
        public ProvisioningErrorInfo ErrorInformation {
            get { return BackingStore?.Get<ProvisioningErrorInfo>("errorInformation"); }
            set { BackingStore?.Set("errorInformation", value); }
        }
        /// <summary>Possible values are: success, warning, failure, skipped, unknownFutureValue.</summary>
        public ProvisioningResult? Status {
            get { return BackingStore?.Get<ProvisioningResult?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new provisioningStatusInfo and sets the default values.
        /// </summary>
        public ProvisioningStatusInfo() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ProvisioningStatusInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ProvisioningStatusInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"errorInformation", n => { ErrorInformation = n.GetObjectValue<ProvisioningErrorInfo>(ProvisioningErrorInfo.CreateFromDiscriminatorValue); } },
                {"status", n => { Status = n.GetEnumValue<ProvisioningResult>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ProvisioningErrorInfo>("errorInformation", ErrorInformation);
            writer.WriteEnumValue<ProvisioningResult>("status", Status);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
