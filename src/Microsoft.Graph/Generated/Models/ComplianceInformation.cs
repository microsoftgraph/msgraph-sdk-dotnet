using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ComplianceInformation : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Collection of the certification controls associated with certification</summary>
        public List<CertificationControl> CertificationControls {
            get { return BackingStore?.Get<List<CertificationControl>>("certificationControls"); }
            set { BackingStore?.Set("certificationControls", value); }
        }
        /// <summary>Compliance certification name (for example, ISO 27018:2014, GDPR, FedRAMP, NIST 800-171)</summary>
        public string CertificationName {
            get { return BackingStore?.Get<string>("certificationName"); }
            set { BackingStore?.Set("certificationName", value); }
        }
        /// <summary>
        /// Instantiates a new complianceInformation and sets the default values.
        /// </summary>
        public ComplianceInformation() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ComplianceInformation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ComplianceInformation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"certificationControls", n => { CertificationControls = n.GetCollectionOfObjectValues<CertificationControl>(CertificationControl.CreateFromDiscriminatorValue).ToList(); } },
                {"certificationName", n => { CertificationName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<CertificationControl>("certificationControls", CertificationControls);
            writer.WriteStringValue("certificationName", CertificationName);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
