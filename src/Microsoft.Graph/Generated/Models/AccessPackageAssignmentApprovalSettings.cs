using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessPackageAssignmentApprovalSettings : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>If false, then approval is not required for new requests in this policy.</summary>
        public bool? IsApprovalRequiredForAdd {
            get { return BackingStore?.Get<bool?>("isApprovalRequiredForAdd"); }
            set { BackingStore?.Set("isApprovalRequiredForAdd", value); }
        }
        /// <summary>If false, then approval is not required for updates to requests in this policy.</summary>
        public bool? IsApprovalRequiredForUpdate {
            get { return BackingStore?.Get<bool?>("isApprovalRequiredForUpdate"); }
            set { BackingStore?.Set("isApprovalRequiredForUpdate", value); }
        }
        /// <summary>If approval is required, the one, two or three elements of this collection define each of the stages of approval. An empty array is present if no approval is required.</summary>
        public List<AccessPackageApprovalStage> Stages {
            get { return BackingStore?.Get<List<AccessPackageApprovalStage>>("stages"); }
            set { BackingStore?.Set("stages", value); }
        }
        /// <summary>
        /// Instantiates a new accessPackageAssignmentApprovalSettings and sets the default values.
        /// </summary>
        public AccessPackageAssignmentApprovalSettings() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AccessPackageAssignmentApprovalSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessPackageAssignmentApprovalSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"isApprovalRequiredForAdd", n => { IsApprovalRequiredForAdd = n.GetBoolValue(); } },
                {"isApprovalRequiredForUpdate", n => { IsApprovalRequiredForUpdate = n.GetBoolValue(); } },
                {"stages", n => { Stages = n.GetCollectionOfObjectValues<AccessPackageApprovalStage>(AccessPackageApprovalStage.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("isApprovalRequiredForAdd", IsApprovalRequiredForAdd);
            writer.WriteBoolValue("isApprovalRequiredForUpdate", IsApprovalRequiredForUpdate);
            writer.WriteCollectionOfObjectValues<AccessPackageApprovalStage>("stages", Stages);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
