using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class UnifiedRoleScheduleBase : Entity, IParsable {
        /// <summary>Read-only property with details of the app-specific scope when the role eligibility or assignment is scoped to an app. Nullable.</summary>
        public Microsoft.Graph.Models.AppScope AppScope {
            get { return BackingStore?.Get<Microsoft.Graph.Models.AppScope>("appScope"); }
            set { BackingStore?.Set("appScope", value); }
        }
        /// <summary>Identifier of the app-specific scope when the assignment or eligibility is scoped to an app. The scope of an assignment or eligibility determines the set of resources for which the principal has been granted access. App scopes are scopes that are defined and understood by this application only. Use / for tenant-wide app scopes. Use directoryScopeId to limit the scope to particular directory objects, for example, administrative units.</summary>
        public string AppScopeId {
            get { return BackingStore?.Get<string>("appScopeId"); }
            set { BackingStore?.Set("appScopeId", value); }
        }
        /// <summary>When the schedule was created.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Identifier of the object through which this schedule was created.</summary>
        public string CreatedUsing {
            get { return BackingStore?.Get<string>("createdUsing"); }
            set { BackingStore?.Set("createdUsing", value); }
        }
        /// <summary>The directory object that is the scope of the role eligibility or assignment. Read-only.</summary>
        public DirectoryObject DirectoryScope {
            get { return BackingStore?.Get<DirectoryObject>("directoryScope"); }
            set { BackingStore?.Set("directoryScope", value); }
        }
        /// <summary>Identifier of the directory object representing the scope of the assignment or eligibility. The scope of an assignment or eligibility determines the set of resources for which the principal has been granted access. Directory scopes are shared scopes stored in the directory that are understood by multiple applications. Use / for tenant-wide scope. Use appScopeId to limit the scope to an application only.</summary>
        public string DirectoryScopeId {
            get { return BackingStore?.Get<string>("directoryScopeId"); }
            set { BackingStore?.Set("directoryScopeId", value); }
        }
        /// <summary>When the schedule was last modified.</summary>
        public DateTimeOffset? ModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("modifiedDateTime"); }
            set { BackingStore?.Set("modifiedDateTime", value); }
        }
        /// <summary>The principal that&apos;s getting a role assignment or that&apos;s eligible for a role through the request.</summary>
        public DirectoryObject Principal {
            get { return BackingStore?.Get<DirectoryObject>("principal"); }
            set { BackingStore?.Set("principal", value); }
        }
        /// <summary>Identifier of the principal that has been granted the role assignment or eligibility.</summary>
        public string PrincipalId {
            get { return BackingStore?.Get<string>("principalId"); }
            set { BackingStore?.Set("principalId", value); }
        }
        /// <summary>Detailed information for the roleDefinition object that is referenced through the roleDefinitionId property.</summary>
        public UnifiedRoleDefinition RoleDefinition {
            get { return BackingStore?.Get<UnifiedRoleDefinition>("roleDefinition"); }
            set { BackingStore?.Set("roleDefinition", value); }
        }
        /// <summary>Identifier of the unifiedRoleDefinition object that is being assigned to the principal or that a principal is eligible for.</summary>
        public string RoleDefinitionId {
            get { return BackingStore?.Get<string>("roleDefinitionId"); }
            set { BackingStore?.Set("roleDefinitionId", value); }
        }
        /// <summary>The status of the role assignment or eligibility request.</summary>
        public string Status {
            get { return BackingStore?.Get<string>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new unifiedRoleScheduleBase and sets the default values.
        /// </summary>
        public UnifiedRoleScheduleBase() : base() {
            Type = "#microsoft.graph.unifiedRoleScheduleBase";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new UnifiedRoleScheduleBase CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.unifiedRoleAssignmentSchedule" => new UnifiedRoleAssignmentSchedule(),
                "#microsoft.graph.unifiedRoleEligibilitySchedule" => new UnifiedRoleEligibilitySchedule(),
                _ => new UnifiedRoleScheduleBase(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appScope", n => { AppScope = n.GetObjectValue<Microsoft.Graph.Models.AppScope>(Microsoft.Graph.Models.AppScope.CreateFromDiscriminatorValue); } },
                {"appScopeId", n => { AppScopeId = n.GetStringValue(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"createdUsing", n => { CreatedUsing = n.GetStringValue(); } },
                {"directoryScope", n => { DirectoryScope = n.GetObjectValue<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue); } },
                {"directoryScopeId", n => { DirectoryScopeId = n.GetStringValue(); } },
                {"modifiedDateTime", n => { ModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"principal", n => { Principal = n.GetObjectValue<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue); } },
                {"principalId", n => { PrincipalId = n.GetStringValue(); } },
                {"roleDefinition", n => { RoleDefinition = n.GetObjectValue<UnifiedRoleDefinition>(UnifiedRoleDefinition.CreateFromDiscriminatorValue); } },
                {"roleDefinitionId", n => { RoleDefinitionId = n.GetStringValue(); } },
                {"status", n => { Status = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.AppScope>("appScope", AppScope);
            writer.WriteStringValue("appScopeId", AppScopeId);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("createdUsing", CreatedUsing);
            writer.WriteObjectValue<DirectoryObject>("directoryScope", DirectoryScope);
            writer.WriteStringValue("directoryScopeId", DirectoryScopeId);
            writer.WriteDateTimeOffsetValue("modifiedDateTime", ModifiedDateTime);
            writer.WriteObjectValue<DirectoryObject>("principal", Principal);
            writer.WriteStringValue("principalId", PrincipalId);
            writer.WriteObjectValue<UnifiedRoleDefinition>("roleDefinition", RoleDefinition);
            writer.WriteStringValue("roleDefinitionId", RoleDefinitionId);
            writer.WriteStringValue("status", Status);
        }
    }
}
