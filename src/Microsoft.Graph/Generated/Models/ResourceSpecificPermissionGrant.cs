using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class ResourceSpecificPermissionGrant : DirectoryObject, IParsable {
        /// <summary>ID of the service principal of the Azure AD app that has been granted access. Read-only.</summary>
        public string ClientAppId {
            get { return BackingStore?.Get<string>("clientAppId"); }
            set { BackingStore?.Set("clientAppId", value); }
        }
        /// <summary>ID of the Azure AD app that has been granted access. Read-only.</summary>
        public string ClientId {
            get { return BackingStore?.Get<string>("clientId"); }
            set { BackingStore?.Set("clientId", value); }
        }
        /// <summary>The name of the resource-specific permission. Read-only.</summary>
        public string Permission {
            get { return BackingStore?.Get<string>("permission"); }
            set { BackingStore?.Set("permission", value); }
        }
        /// <summary>The type of permission. Possible values are: Application, Delegated. Read-only.</summary>
        public string PermissionType {
            get { return BackingStore?.Get<string>("permissionType"); }
            set { BackingStore?.Set("permissionType", value); }
        }
        /// <summary>ID of the Azure AD app that is hosting the resource. Read-only.</summary>
        public string ResourceAppId {
            get { return BackingStore?.Get<string>("resourceAppId"); }
            set { BackingStore?.Set("resourceAppId", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ResourceSpecificPermissionGrant CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ResourceSpecificPermissionGrant();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"clientAppId", n => { ClientAppId = n.GetStringValue(); } },
                {"clientId", n => { ClientId = n.GetStringValue(); } },
                {"permission", n => { Permission = n.GetStringValue(); } },
                {"permissionType", n => { PermissionType = n.GetStringValue(); } },
                {"resourceAppId", n => { ResourceAppId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("clientAppId", ClientAppId);
            writer.WriteStringValue("clientId", ClientId);
            writer.WriteStringValue("permission", Permission);
            writer.WriteStringValue("permissionType", PermissionType);
            writer.WriteStringValue("resourceAppId", ResourceAppId);
        }
    }
}
