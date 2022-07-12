using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessPackageAssignmentRequestRequirements : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Indicates whether the requestor is allowed to set a custom schedule.</summary>
        public bool? AllowCustomAssignmentSchedule {
            get { return BackingStore?.Get<bool?>("allowCustomAssignmentSchedule"); }
            set { BackingStore?.Set("allowCustomAssignmentSchedule", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Indicates whether a request to add must be approved by an approver.</summary>
        public bool? IsApprovalRequiredForAdd {
            get { return BackingStore?.Get<bool?>("isApprovalRequiredForAdd"); }
            set { BackingStore?.Set("isApprovalRequiredForAdd", value); }
        }
        /// <summary>Indicates whether a request to update must be approved by an approver.</summary>
        public bool? IsApprovalRequiredForUpdate {
            get { return BackingStore?.Get<bool?>("isApprovalRequiredForUpdate"); }
            set { BackingStore?.Set("isApprovalRequiredForUpdate", value); }
        }
        /// <summary>The description of the policy that the user is trying to request access using.</summary>
        public string PolicyDescription {
            get { return BackingStore?.Get<string>("policyDescription"); }
            set { BackingStore?.Set("policyDescription", value); }
        }
        /// <summary>The display name of the policy that the user is trying to request access using.</summary>
        public string PolicyDisplayName {
            get { return BackingStore?.Get<string>("policyDisplayName"); }
            set { BackingStore?.Set("policyDisplayName", value); }
        }
        /// <summary>The identifier of the policy that these requirements are associated with. This identifier can be used when creating a new assignment request.</summary>
        public string PolicyId {
            get { return BackingStore?.Get<string>("policyId"); }
            set { BackingStore?.Set("policyId", value); }
        }
        /// <summary>Schedule restrictions enforced, if any.</summary>
        public EntitlementManagementSchedule Schedule {
            get { return BackingStore?.Get<EntitlementManagementSchedule>("schedule"); }
            set { BackingStore?.Set("schedule", value); }
        }
        /// <summary>
        /// Instantiates a new accessPackageAssignmentRequestRequirements and sets the default values.
        /// </summary>
        public AccessPackageAssignmentRequestRequirements() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AccessPackageAssignmentRequestRequirements CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessPackageAssignmentRequestRequirements();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allowCustomAssignmentSchedule", n => { AllowCustomAssignmentSchedule = n.GetBoolValue(); } },
                {"isApprovalRequiredForAdd", n => { IsApprovalRequiredForAdd = n.GetBoolValue(); } },
                {"isApprovalRequiredForUpdate", n => { IsApprovalRequiredForUpdate = n.GetBoolValue(); } },
                {"policyDescription", n => { PolicyDescription = n.GetStringValue(); } },
                {"policyDisplayName", n => { PolicyDisplayName = n.GetStringValue(); } },
                {"policyId", n => { PolicyId = n.GetStringValue(); } },
                {"schedule", n => { Schedule = n.GetObjectValue<EntitlementManagementSchedule>(EntitlementManagementSchedule.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("allowCustomAssignmentSchedule", AllowCustomAssignmentSchedule);
            writer.WriteBoolValue("isApprovalRequiredForAdd", IsApprovalRequiredForAdd);
            writer.WriteBoolValue("isApprovalRequiredForUpdate", IsApprovalRequiredForUpdate);
            writer.WriteStringValue("policyDescription", PolicyDescription);
            writer.WriteStringValue("policyDisplayName", PolicyDisplayName);
            writer.WriteStringValue("policyId", PolicyId);
            writer.WriteObjectValue<EntitlementManagementSchedule>("schedule", Schedule);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
