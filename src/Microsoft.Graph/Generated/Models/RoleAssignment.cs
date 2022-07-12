using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>The Role Assignment resource. Role assignments tie together a role definition with members and scopes. There can be one or more role assignments per role. This applies to custom and built-in roles.</summary>
    public class RoleAssignment : Entity, IParsable {
        /// <summary>Description of the Role Assignment.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The display or friendly name of the role Assignment.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>List of ids of role scope member security groups.  These are IDs from Azure Active Directory.</summary>
        public List<string> ResourceScopes {
            get { return BackingStore?.Get<List<string>>("resourceScopes"); }
            set { BackingStore?.Set("resourceScopes", value); }
        }
        /// <summary>Role definition this assignment is part of.</summary>
        public Microsoft.Graph.Models.RoleDefinition RoleDefinition {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RoleDefinition>("roleDefinition"); }
            set { BackingStore?.Set("roleDefinition", value); }
        }
        /// <summary>
        /// Instantiates a new roleAssignment and sets the default values.
        /// </summary>
        public RoleAssignment() : base() {
            Type = "#microsoft.graph.roleAssignment";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new RoleAssignment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.deviceAndAppManagementRoleAssignment" => new DeviceAndAppManagementRoleAssignment(),
                _ => new RoleAssignment(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"resourceScopes", n => { ResourceScopes = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"roleDefinition", n => { RoleDefinition = n.GetObjectValue<Microsoft.Graph.Models.RoleDefinition>(Microsoft.Graph.Models.RoleDefinition.CreateFromDiscriminatorValue); } },
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
            writer.WriteCollectionOfPrimitiveValues<string>("resourceScopes", ResourceScopes);
            writer.WriteObjectValue<Microsoft.Graph.Models.RoleDefinition>("roleDefinition", RoleDefinition);
        }
    }
}
