using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RoleDefinition : Entity, IParsable {
        /// <summary>Description of the Role definition.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>Display Name of the Role definition.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Type of Role. Set to True if it is built-in, or set to False if it is a custom role definition.</summary>
        public bool? IsBuiltIn {
            get { return BackingStore?.Get<bool?>("isBuiltIn"); }
            set { BackingStore?.Set("isBuiltIn", value); }
        }
        /// <summary>List of Role assignments for this role definition.</summary>
        public List<RoleAssignment> RoleAssignments {
            get { return BackingStore?.Get<List<RoleAssignment>>("roleAssignments"); }
            set { BackingStore?.Set("roleAssignments", value); }
        }
        /// <summary>List of Role Permissions this role is allowed to perform. These must match the actionName that is defined as part of the rolePermission.</summary>
        public List<RolePermission> RolePermissions {
            get { return BackingStore?.Get<List<RolePermission>>("rolePermissions"); }
            set { BackingStore?.Set("rolePermissions", value); }
        }
        /// <summary>
        /// Instantiates a new roleDefinition and sets the default values.
        /// </summary>
        public RoleDefinition() : base() {
            Type = "#microsoft.graph.roleDefinition";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new RoleDefinition CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.deviceAndAppManagementRoleDefinition" => new DeviceAndAppManagementRoleDefinition(),
                _ => new RoleDefinition(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"isBuiltIn", n => { IsBuiltIn = n.GetBoolValue(); } },
                {"roleAssignments", n => { RoleAssignments = n.GetCollectionOfObjectValues<RoleAssignment>(RoleAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"rolePermissions", n => { RolePermissions = n.GetCollectionOfObjectValues<RolePermission>(RolePermission.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteBoolValue("isBuiltIn", IsBuiltIn);
            writer.WriteCollectionOfObjectValues<RoleAssignment>("roleAssignments", RoleAssignments);
            writer.WriteCollectionOfObjectValues<RolePermission>("rolePermissions", RolePermissions);
        }
    }
}
