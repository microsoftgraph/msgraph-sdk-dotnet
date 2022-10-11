using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class ProvisioningObjectSummary : Entity, IParsable {
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? ActivityDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("activityDateTime"); }
            set { BackingStore?.Set("activityDateTime", value); }
        }
        /// <summary>Unique ID of this change in this cycle.</summary>
        public string ChangeId {
            get { return BackingStore?.Get<string>("changeId"); }
            set { BackingStore?.Set("changeId", value); }
        }
        /// <summary>Unique ID per job iteration.</summary>
        public string CycleId {
            get { return BackingStore?.Get<string>("cycleId"); }
            set { BackingStore?.Set("cycleId", value); }
        }
        /// <summary>Indicates how long this provisioning action took to finish. Measured in milliseconds.</summary>
        public int? DurationInMilliseconds {
            get { return BackingStore?.Get<int?>("durationInMilliseconds"); }
            set { BackingStore?.Set("durationInMilliseconds", value); }
        }
        /// <summary>Details of who initiated this provisioning.</summary>
        public Initiator InitiatedBy {
            get { return BackingStore?.Get<Initiator>("initiatedBy"); }
            set { BackingStore?.Set("initiatedBy", value); }
        }
        /// <summary>The unique ID for the whole provisioning job.</summary>
        public string JobId {
            get { return BackingStore?.Get<string>("jobId"); }
            set { BackingStore?.Set("jobId", value); }
        }
        /// <summary>Details of each property that was modified in this provisioning action on this object.</summary>
        public List<ModifiedProperty> ModifiedProperties {
            get { return BackingStore?.Get<List<ModifiedProperty>>("modifiedProperties"); }
            set { BackingStore?.Set("modifiedProperties", value); }
        }
        /// <summary>Indicates the activity name or the operation name. Possible values are: create, update, delete, stageddelete, disable, other and unknownFutureValue. For a list of activities logged, refer to Azure AD activity list.</summary>
        public Microsoft.Graph.Models.ProvisioningAction? ProvisioningAction {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningAction?>("provisioningAction"); }
            set { BackingStore?.Set("provisioningAction", value); }
        }
        /// <summary>Details of provisioning status.</summary>
        public Microsoft.Graph.Models.ProvisioningStatusInfo ProvisioningStatusInfo {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningStatusInfo>("provisioningStatusInfo"); }
            set { BackingStore?.Set("provisioningStatusInfo", value); }
        }
        /// <summary>Details of each step in provisioning.</summary>
        public List<ProvisioningStep> ProvisioningSteps {
            get { return BackingStore?.Get<List<ProvisioningStep>>("provisioningSteps"); }
            set { BackingStore?.Set("provisioningSteps", value); }
        }
        /// <summary>Represents the service principal used for provisioning.</summary>
        public ProvisioningServicePrincipal ServicePrincipal {
            get { return BackingStore?.Get<ProvisioningServicePrincipal>("servicePrincipal"); }
            set { BackingStore?.Set("servicePrincipal", value); }
        }
        /// <summary>Details of source object being provisioned.</summary>
        public ProvisionedIdentity SourceIdentity {
            get { return BackingStore?.Get<ProvisionedIdentity>("sourceIdentity"); }
            set { BackingStore?.Set("sourceIdentity", value); }
        }
        /// <summary>Details of source system of the object being provisioned.</summary>
        public ProvisioningSystem SourceSystem {
            get { return BackingStore?.Get<ProvisioningSystem>("sourceSystem"); }
            set { BackingStore?.Set("sourceSystem", value); }
        }
        /// <summary>Details of target object being provisioned.</summary>
        public ProvisionedIdentity TargetIdentity {
            get { return BackingStore?.Get<ProvisionedIdentity>("targetIdentity"); }
            set { BackingStore?.Set("targetIdentity", value); }
        }
        /// <summary>Details of target system of the object being provisioned.</summary>
        public ProvisioningSystem TargetSystem {
            get { return BackingStore?.Get<ProvisioningSystem>("targetSystem"); }
            set { BackingStore?.Set("targetSystem", value); }
        }
        /// <summary>Unique Azure AD tenant ID.</summary>
        public string TenantId {
            get { return BackingStore?.Get<string>("tenantId"); }
            set { BackingStore?.Set("tenantId", value); }
        }
        /// <summary>
        /// Instantiates a new provisioningObjectSummary and sets the default values.
        /// </summary>
        public ProvisioningObjectSummary() : base() {
            OdataType = "#microsoft.graph.provisioningObjectSummary";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ProvisioningObjectSummary CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ProvisioningObjectSummary();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"activityDateTime", n => { ActivityDateTime = n.GetDateTimeOffsetValue(); } },
                {"changeId", n => { ChangeId = n.GetStringValue(); } },
                {"cycleId", n => { CycleId = n.GetStringValue(); } },
                {"durationInMilliseconds", n => { DurationInMilliseconds = n.GetIntValue(); } },
                {"initiatedBy", n => { InitiatedBy = n.GetObjectValue<Initiator>(Initiator.CreateFromDiscriminatorValue); } },
                {"jobId", n => { JobId = n.GetStringValue(); } },
                {"modifiedProperties", n => { ModifiedProperties = n.GetCollectionOfObjectValues<ModifiedProperty>(ModifiedProperty.CreateFromDiscriminatorValue)?.ToList(); } },
                {"provisioningAction", n => { ProvisioningAction = n.GetEnumValue<ProvisioningAction>(); } },
                {"provisioningStatusInfo", n => { ProvisioningStatusInfo = n.GetObjectValue<Microsoft.Graph.Models.ProvisioningStatusInfo>(Microsoft.Graph.Models.ProvisioningStatusInfo.CreateFromDiscriminatorValue); } },
                {"provisioningSteps", n => { ProvisioningSteps = n.GetCollectionOfObjectValues<ProvisioningStep>(ProvisioningStep.CreateFromDiscriminatorValue)?.ToList(); } },
                {"servicePrincipal", n => { ServicePrincipal = n.GetObjectValue<ProvisioningServicePrincipal>(ProvisioningServicePrincipal.CreateFromDiscriminatorValue); } },
                {"sourceIdentity", n => { SourceIdentity = n.GetObjectValue<ProvisionedIdentity>(ProvisionedIdentity.CreateFromDiscriminatorValue); } },
                {"sourceSystem", n => { SourceSystem = n.GetObjectValue<ProvisioningSystem>(ProvisioningSystem.CreateFromDiscriminatorValue); } },
                {"targetIdentity", n => { TargetIdentity = n.GetObjectValue<ProvisionedIdentity>(ProvisionedIdentity.CreateFromDiscriminatorValue); } },
                {"targetSystem", n => { TargetSystem = n.GetObjectValue<ProvisioningSystem>(ProvisioningSystem.CreateFromDiscriminatorValue); } },
                {"tenantId", n => { TenantId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("activityDateTime", ActivityDateTime);
            writer.WriteStringValue("changeId", ChangeId);
            writer.WriteStringValue("cycleId", CycleId);
            writer.WriteIntValue("durationInMilliseconds", DurationInMilliseconds);
            writer.WriteObjectValue<Initiator>("initiatedBy", InitiatedBy);
            writer.WriteStringValue("jobId", JobId);
            writer.WriteCollectionOfObjectValues<ModifiedProperty>("modifiedProperties", ModifiedProperties);
            writer.WriteEnumValue<ProvisioningAction>("provisioningAction", ProvisioningAction);
            writer.WriteObjectValue<Microsoft.Graph.Models.ProvisioningStatusInfo>("provisioningStatusInfo", ProvisioningStatusInfo);
            writer.WriteCollectionOfObjectValues<ProvisioningStep>("provisioningSteps", ProvisioningSteps);
            writer.WriteObjectValue<ProvisioningServicePrincipal>("servicePrincipal", ServicePrincipal);
            writer.WriteObjectValue<ProvisionedIdentity>("sourceIdentity", SourceIdentity);
            writer.WriteObjectValue<ProvisioningSystem>("sourceSystem", SourceSystem);
            writer.WriteObjectValue<ProvisionedIdentity>("targetIdentity", TargetIdentity);
            writer.WriteObjectValue<ProvisioningSystem>("targetSystem", TargetSystem);
            writer.WriteStringValue("tenantId", TenantId);
        }
    }
}
