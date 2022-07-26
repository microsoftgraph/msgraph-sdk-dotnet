using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class DirectoryObject : Entity, IParsable {
        /// <summary>Date and time when this object was deleted. Always null when the object hasn&apos;t been deleted.</summary>
        public DateTimeOffset? DeletedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("deletedDateTime"); }
            set { BackingStore?.Set("deletedDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new directoryObject and sets the default values.
        /// </summary>
        public DirectoryObject() : base() {
            OdataType = "#microsoft.graph.directoryObject";
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
                "#microsoft.graph.activityBasedTimeoutPolicy" => new ActivityBasedTimeoutPolicy(),
                "#microsoft.graph.administrativeUnit" => new AdministrativeUnit(),
                "#microsoft.graph.application" => new Application(),
                "#microsoft.graph.appRoleAssignment" => new AppRoleAssignment(),
                "#microsoft.graph.authorizationPolicy" => new AuthorizationPolicy(),
                "#microsoft.graph.claimsMappingPolicy" => new ClaimsMappingPolicy(),
                "#microsoft.graph.contract" => new Contract(),
                "#microsoft.graph.crossTenantAccessPolicy" => new CrossTenantAccessPolicy(),
                "#microsoft.graph.device" => new Device(),
                "#microsoft.graph.directoryObjectPartnerReference" => new DirectoryObjectPartnerReference(),
                "#microsoft.graph.directoryRole" => new DirectoryRole(),
                "#microsoft.graph.directoryRoleTemplate" => new DirectoryRoleTemplate(),
                "#microsoft.graph.endpoint" => new Endpoint(),
                "#microsoft.graph.extensionProperty" => new ExtensionProperty(),
                "#microsoft.graph.group" => new Group(),
                "#microsoft.graph.groupSettingTemplate" => new GroupSettingTemplate(),
                "#microsoft.graph.homeRealmDiscoveryPolicy" => new HomeRealmDiscoveryPolicy(),
                "#microsoft.graph.identitySecurityDefaultsEnforcementPolicy" => new IdentitySecurityDefaultsEnforcementPolicy(),
                "#microsoft.graph.organization" => new Organization(),
                "#microsoft.graph.orgContact" => new OrgContact(),
                "#microsoft.graph.permissionGrantPolicy" => new PermissionGrantPolicy(),
                "#microsoft.graph.policyBase" => new PolicyBase(),
                "#microsoft.graph.resourceSpecificPermissionGrant" => new ResourceSpecificPermissionGrant(),
                "#microsoft.graph.servicePrincipal" => new ServicePrincipal(),
                "#microsoft.graph.stsPolicy" => new StsPolicy(),
                "#microsoft.graph.tokenIssuancePolicy" => new TokenIssuancePolicy(),
                "#microsoft.graph.tokenLifetimePolicy" => new TokenLifetimePolicy(),
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
        }
    }
}
