using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public class DirectoryObject : Entity, IParsable {
        /// <summary>Date and time when this object was deleted. Always null when the object hasn&apos;t been deleted.</summary>
        public DateTimeOffset? DeletedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("deletedDateTime"); }
            set { BackingStore?.Set("deletedDateTime", value); }
        }
        /// <summary>The type property</summary>
        public string Type {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DirectoryObject CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.administrativeUnit" => new AdministrativeUnit(),
                "#microsoft.graph.application" => new Application(),
                "#microsoft.graph.appRoleAssignment" => new AppRoleAssignment(),
                "#microsoft.graph.contract" => new Contract(),
                "#microsoft.graph.device" => new Device(),
                "#microsoft.graph.directoryObjectPartnerReference" => new DirectoryObjectPartnerReference(),
                "#microsoft.graph.directoryRole" => new DirectoryRole(),
                "#microsoft.graph.directoryRoleTemplate" => new DirectoryRoleTemplate(),
                "#microsoft.graph.endpoint" => new Endpoint(),
                "#microsoft.graph.extensionProperty" => new ExtensionProperty(),
                "#microsoft.graph.group" => new Group(),
                "#microsoft.graph.groupSettingTemplate" => new GroupSettingTemplate(),
                "#microsoft.graph.organization" => new Organization(),
                "#microsoft.graph.orgContact" => new OrgContact(),
                "#microsoft.graph.policyBase" => new PolicyBase(),
                "#microsoft.graph.resourceSpecificPermissionGrant" => new ResourceSpecificPermissionGrant(),
                "#microsoft.graph.servicePrincipal" => new ServicePrincipal(),
                "#microsoft.graph.user" => new User(),
                _ => new DirectoryObject(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"deletedDateTime", n => { DeletedDateTime = n.GetDateTimeOffsetValue(); } },
                {"@odata.type", n => { Type = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("deletedDateTime", DeletedDateTime);
            writer.WriteStringValue("@odata.type", Type);
        }
    }
}
