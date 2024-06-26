// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models
{
    #pragma warning disable CS1591
    public class ProvisioningObjectSummary : Microsoft.Graph.Models.Entity, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.  SUpports $filter (eq, gt, lt) and orderby.</summary>
        public DateTimeOffset? ActivityDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("activityDateTime"); }
            set { BackingStore?.Set("activityDateTime", value); }
        }
        /// <summary>Unique ID of this change in this cycle. Supports $filter (eq, contains).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ChangeId
        {
            get { return BackingStore?.Get<string?>("changeId"); }
            set { BackingStore?.Set("changeId", value); }
        }
#nullable restore
#else
        public string ChangeId
        {
            get { return BackingStore?.Get<string>("changeId"); }
            set { BackingStore?.Set("changeId", value); }
        }
#endif
        /// <summary>Unique ID per job iteration. Supports $filter (eq, contains).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CycleId
        {
            get { return BackingStore?.Get<string?>("cycleId"); }
            set { BackingStore?.Set("cycleId", value); }
        }
#nullable restore
#else
        public string CycleId
        {
            get { return BackingStore?.Get<string>("cycleId"); }
            set { BackingStore?.Set("cycleId", value); }
        }
#endif
        /// <summary>Indicates how long this provisioning action took to finish. Measured in milliseconds.</summary>
        public int? DurationInMilliseconds
        {
            get { return BackingStore?.Get<int?>("durationInMilliseconds"); }
            set { BackingStore?.Set("durationInMilliseconds", value); }
        }
        /// <summary>Details of who initiated this provisioning. Supports $filter (eq, contains).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.Initiator? InitiatedBy
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Initiator?>("initiatedBy"); }
            set { BackingStore?.Set("initiatedBy", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.Initiator InitiatedBy
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Initiator>("initiatedBy"); }
            set { BackingStore?.Set("initiatedBy", value); }
        }
#endif
        /// <summary>The unique ID for the whole provisioning job. Supports $filter (eq, contains).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? JobId
        {
            get { return BackingStore?.Get<string?>("jobId"); }
            set { BackingStore?.Set("jobId", value); }
        }
#nullable restore
#else
        public string JobId
        {
            get { return BackingStore?.Get<string>("jobId"); }
            set { BackingStore?.Set("jobId", value); }
        }
#endif
        /// <summary>Details of each property that was modified in this provisioning action on this object.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.ModifiedProperty>? ModifiedProperties
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ModifiedProperty>?>("modifiedProperties"); }
            set { BackingStore?.Set("modifiedProperties", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.ModifiedProperty> ModifiedProperties
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ModifiedProperty>>("modifiedProperties"); }
            set { BackingStore?.Set("modifiedProperties", value); }
        }
#endif
        /// <summary>Indicates the activity name or the operation name. Possible values are: create, update, delete, stageddelete, disable, other and unknownFutureValue. For a list of activities logged, refer to Microsoft Entra activity list. Supports $filter (eq, contains).</summary>
        public Microsoft.Graph.Models.ProvisioningAction? ProvisioningAction
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningAction?>("provisioningAction"); }
            set { BackingStore?.Set("provisioningAction", value); }
        }
        /// <summary>Details of provisioning status.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.ProvisioningStatusInfo? ProvisioningStatusInfo
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningStatusInfo?>("provisioningStatusInfo"); }
            set { BackingStore?.Set("provisioningStatusInfo", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.ProvisioningStatusInfo ProvisioningStatusInfo
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningStatusInfo>("provisioningStatusInfo"); }
            set { BackingStore?.Set("provisioningStatusInfo", value); }
        }
#endif
        /// <summary>Details of each step in provisioning.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.ProvisioningStep>? ProvisioningSteps
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ProvisioningStep>?>("provisioningSteps"); }
            set { BackingStore?.Set("provisioningSteps", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.ProvisioningStep> ProvisioningSteps
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ProvisioningStep>>("provisioningSteps"); }
            set { BackingStore?.Set("provisioningSteps", value); }
        }
#endif
        /// <summary>Represents the service principal used for provisioning. Supports $filter (eq) for id and name.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.ProvisioningServicePrincipal? ServicePrincipal
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningServicePrincipal?>("servicePrincipal"); }
            set { BackingStore?.Set("servicePrincipal", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.ProvisioningServicePrincipal ServicePrincipal
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningServicePrincipal>("servicePrincipal"); }
            set { BackingStore?.Set("servicePrincipal", value); }
        }
#endif
        /// <summary>Details of source object being provisioned. Supports $filter (eq, contains) for identityType, id, and displayName.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.ProvisionedIdentity? SourceIdentity
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisionedIdentity?>("sourceIdentity"); }
            set { BackingStore?.Set("sourceIdentity", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.ProvisionedIdentity SourceIdentity
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisionedIdentity>("sourceIdentity"); }
            set { BackingStore?.Set("sourceIdentity", value); }
        }
#endif
        /// <summary>Details of source system of the object being provisioned. Supports $filter (eq, contains) for displayName.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.ProvisioningSystem? SourceSystem
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningSystem?>("sourceSystem"); }
            set { BackingStore?.Set("sourceSystem", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.ProvisioningSystem SourceSystem
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningSystem>("sourceSystem"); }
            set { BackingStore?.Set("sourceSystem", value); }
        }
#endif
        /// <summary>Details of target object being provisioned. Supports $filter (eq, contains) for identityType, id, and displayName.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.ProvisionedIdentity? TargetIdentity
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisionedIdentity?>("targetIdentity"); }
            set { BackingStore?.Set("targetIdentity", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.ProvisionedIdentity TargetIdentity
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisionedIdentity>("targetIdentity"); }
            set { BackingStore?.Set("targetIdentity", value); }
        }
#endif
        /// <summary>Details of target system of the object being provisioned. Supports $filter (eq, contains) for displayName.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.ProvisioningSystem? TargetSystem
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningSystem?>("targetSystem"); }
            set { BackingStore?.Set("targetSystem", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.ProvisioningSystem TargetSystem
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ProvisioningSystem>("targetSystem"); }
            set { BackingStore?.Set("targetSystem", value); }
        }
#endif
        /// <summary>Unique Microsoft Entra tenant ID. Supports $filter (eq, contains).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? TenantId
        {
            get { return BackingStore?.Get<string?>("tenantId"); }
            set { BackingStore?.Set("tenantId", value); }
        }
#nullable restore
#else
        public string TenantId
        {
            get { return BackingStore?.Get<string>("tenantId"); }
            set { BackingStore?.Set("tenantId", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Microsoft.Graph.Models.ProvisioningObjectSummary"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Microsoft.Graph.Models.ProvisioningObjectSummary CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Microsoft.Graph.Models.ProvisioningObjectSummary();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "activityDateTime", n => { ActivityDateTime = n.GetDateTimeOffsetValue(); } },
                { "changeId", n => { ChangeId = n.GetStringValue(); } },
                { "cycleId", n => { CycleId = n.GetStringValue(); } },
                { "durationInMilliseconds", n => { DurationInMilliseconds = n.GetIntValue(); } },
                { "initiatedBy", n => { InitiatedBy = n.GetObjectValue<Microsoft.Graph.Models.Initiator>(Microsoft.Graph.Models.Initiator.CreateFromDiscriminatorValue); } },
                { "jobId", n => { JobId = n.GetStringValue(); } },
                { "modifiedProperties", n => { ModifiedProperties = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.ModifiedProperty>(Microsoft.Graph.Models.ModifiedProperty.CreateFromDiscriminatorValue)?.ToList(); } },
                { "provisioningAction", n => { ProvisioningAction = n.GetEnumValue<Microsoft.Graph.Models.ProvisioningAction>(); } },
                { "provisioningStatusInfo", n => { ProvisioningStatusInfo = n.GetObjectValue<Microsoft.Graph.Models.ProvisioningStatusInfo>(Microsoft.Graph.Models.ProvisioningStatusInfo.CreateFromDiscriminatorValue); } },
                { "provisioningSteps", n => { ProvisioningSteps = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.ProvisioningStep>(Microsoft.Graph.Models.ProvisioningStep.CreateFromDiscriminatorValue)?.ToList(); } },
                { "servicePrincipal", n => { ServicePrincipal = n.GetObjectValue<Microsoft.Graph.Models.ProvisioningServicePrincipal>(Microsoft.Graph.Models.ProvisioningServicePrincipal.CreateFromDiscriminatorValue); } },
                { "sourceIdentity", n => { SourceIdentity = n.GetObjectValue<Microsoft.Graph.Models.ProvisionedIdentity>(Microsoft.Graph.Models.ProvisionedIdentity.CreateFromDiscriminatorValue); } },
                { "sourceSystem", n => { SourceSystem = n.GetObjectValue<Microsoft.Graph.Models.ProvisioningSystem>(Microsoft.Graph.Models.ProvisioningSystem.CreateFromDiscriminatorValue); } },
                { "targetIdentity", n => { TargetIdentity = n.GetObjectValue<Microsoft.Graph.Models.ProvisionedIdentity>(Microsoft.Graph.Models.ProvisionedIdentity.CreateFromDiscriminatorValue); } },
                { "targetSystem", n => { TargetSystem = n.GetObjectValue<Microsoft.Graph.Models.ProvisioningSystem>(Microsoft.Graph.Models.ProvisioningSystem.CreateFromDiscriminatorValue); } },
                { "tenantId", n => { TenantId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("activityDateTime", ActivityDateTime);
            writer.WriteStringValue("changeId", ChangeId);
            writer.WriteStringValue("cycleId", CycleId);
            writer.WriteIntValue("durationInMilliseconds", DurationInMilliseconds);
            writer.WriteObjectValue<Microsoft.Graph.Models.Initiator>("initiatedBy", InitiatedBy);
            writer.WriteStringValue("jobId", JobId);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.ModifiedProperty>("modifiedProperties", ModifiedProperties);
            writer.WriteEnumValue<Microsoft.Graph.Models.ProvisioningAction>("provisioningAction", ProvisioningAction);
            writer.WriteObjectValue<Microsoft.Graph.Models.ProvisioningStatusInfo>("provisioningStatusInfo", ProvisioningStatusInfo);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.ProvisioningStep>("provisioningSteps", ProvisioningSteps);
            writer.WriteObjectValue<Microsoft.Graph.Models.ProvisioningServicePrincipal>("servicePrincipal", ServicePrincipal);
            writer.WriteObjectValue<Microsoft.Graph.Models.ProvisionedIdentity>("sourceIdentity", SourceIdentity);
            writer.WriteObjectValue<Microsoft.Graph.Models.ProvisioningSystem>("sourceSystem", SourceSystem);
            writer.WriteObjectValue<Microsoft.Graph.Models.ProvisionedIdentity>("targetIdentity", TargetIdentity);
            writer.WriteObjectValue<Microsoft.Graph.Models.ProvisioningSystem>("targetSystem", TargetSystem);
            writer.WriteStringValue("tenantId", TenantId);
        }
    }
}
