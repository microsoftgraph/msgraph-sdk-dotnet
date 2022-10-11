using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class UnifiedRoleAssignment : Entity, IParsable {
        /// <summary>Read-only property with details of the app specific scope when the assignment scope is app specific. Containment entity. Supports $expand.</summary>
        public Microsoft.Graph.Models.AppScope AppScope {
            get { return BackingStore?.Get<Microsoft.Graph.Models.AppScope>("appScope"); }
            set { BackingStore?.Set("appScope", value); }
        }
        /// <summary>Identifier of the app-specific scope when the assignment scope is app-specific.  Either this property or directoryScopeId is required. App scopes are scopes that are defined and understood by this application only. Use / for tenant-wide app scopes. Use directoryScopeId to limit the scope to particular directory objects, for example, administrative units. Supports $filter (eq, in).</summary>
        public string AppScopeId {
            get { return BackingStore?.Get<string>("appScopeId"); }
            set { BackingStore?.Set("appScopeId", value); }
        }
        /// <summary>The condition property</summary>
        public string Condition {
            get { return BackingStore?.Get<string>("condition"); }
            set { BackingStore?.Set("condition", value); }
        }
        /// <summary>The directory object that is the scope of the assignment. Read-only. Supports $expand.</summary>
        public DirectoryObject DirectoryScope {
            get { return BackingStore?.Get<DirectoryObject>("directoryScope"); }
            set { BackingStore?.Set("directoryScope", value); }
        }
        /// <summary>Identifier of the directory object representing the scope of the assignment.  Either this property or appScopeId is required. The scope of an assignment determines the set of resources for which the principal has been granted access. Directory scopes are shared scopes stored in the directory that are understood by multiple applications. Use / for tenant-wide scope. Use appScopeId to limit the scope to an application only. Supports $filter (eq, in).</summary>
        public string DirectoryScopeId {
            get { return BackingStore?.Get<string>("directoryScopeId"); }
            set { BackingStore?.Set("directoryScopeId", value); }
        }
        /// <summary>Referencing the assigned principal. Read-only. Supports $expand.</summary>
        public DirectoryObject Principal {
            get { return BackingStore?.Get<DirectoryObject>("principal"); }
            set { BackingStore?.Set("principal", value); }
        }
        /// <summary>Identifier of the principal to which the assignment is granted. Supports $filter (eq, in).</summary>
        public string PrincipalId {
            get { return BackingStore?.Get<string>("principalId"); }
            set { BackingStore?.Set("principalId", value); }
        }
        /// <summary>The roleDefinition the assignment is for.  Supports $expand. roleDefinition.Id will be auto expanded.</summary>
        public UnifiedRoleDefinition RoleDefinition {
            get { return BackingStore?.Get<UnifiedRoleDefinition>("roleDefinition"); }
            set { BackingStore?.Set("roleDefinition", value); }
        }
        /// <summary>Identifier of the role definition the assignment is for. Read only. Supports $filter (eq, in).</summary>
        public string RoleDefinitionId {
            get { return BackingStore?.Get<string>("roleDefinitionId"); }
            set { BackingStore?.Set("roleDefinitionId", value); }
        }
        /// <summary>
        /// Instantiates a new unifiedRoleAssignment and sets the default values.
        /// </summary>
        public UnifiedRoleAssignment() : base() {
            OdataType = "#microsoft.graph.unifiedRoleAssignment";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new UnifiedRoleAssignment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UnifiedRoleAssignment();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appScope", n => { AppScope = n.GetObjectValue<Microsoft.Graph.Models.AppScope>(Microsoft.Graph.Models.AppScope.CreateFromDiscriminatorValue); } },
                {"appScopeId", n => { AppScopeId = n.GetStringValue(); } },
                {"condition", n => { Condition = n.GetStringValue(); } },
                {"directoryScope", n => { DirectoryScope = n.GetObjectValue<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue); } },
                {"directoryScopeId", n => { DirectoryScopeId = n.GetStringValue(); } },
                {"principal", n => { Principal = n.GetObjectValue<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue); } },
                {"principalId", n => { PrincipalId = n.GetStringValue(); } },
                {"roleDefinition", n => { RoleDefinition = n.GetObjectValue<UnifiedRoleDefinition>(UnifiedRoleDefinition.CreateFromDiscriminatorValue); } },
                {"roleDefinitionId", n => { RoleDefinitionId = n.GetStringValue(); } },
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
            writer.WriteStringValue("condition", Condition);
            writer.WriteObjectValue<DirectoryObject>("directoryScope", DirectoryScope);
            writer.WriteStringValue("directoryScopeId", DirectoryScopeId);
            writer.WriteObjectValue<DirectoryObject>("principal", Principal);
            writer.WriteStringValue("principalId", PrincipalId);
            writer.WriteObjectValue<UnifiedRoleDefinition>("roleDefinition", RoleDefinition);
            writer.WriteStringValue("roleDefinitionId", RoleDefinitionId);
        }
    }
}
