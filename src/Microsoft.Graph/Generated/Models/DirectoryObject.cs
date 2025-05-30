// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DirectoryObject : global::Microsoft.Graph.Models.Entity, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Date and time when this object was deleted. Always null when the object hasn&apos;t been deleted.</summary>
        public DateTimeOffset? DeletedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("deletedDateTime"); }
            set { BackingStore?.Set("deletedDateTime", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.DirectoryObject"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.DirectoryObject CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch
            {
                "#microsoft.graph.activityBasedTimeoutPolicy" => new global::Microsoft.Graph.Models.ActivityBasedTimeoutPolicy(),
                "#microsoft.graph.administrativeUnit" => new global::Microsoft.Graph.Models.AdministrativeUnit(),
                "#microsoft.graph.application" => new global::Microsoft.Graph.Models.Application(),
                "#microsoft.graph.appManagementPolicy" => new global::Microsoft.Graph.Models.AppManagementPolicy(),
                "#microsoft.graph.appRoleAssignment" => new global::Microsoft.Graph.Models.AppRoleAssignment(),
                "#microsoft.graph.authorizationPolicy" => new global::Microsoft.Graph.Models.AuthorizationPolicy(),
                "#microsoft.graph.certificateAuthorityDetail" => new global::Microsoft.Graph.Models.CertificateAuthorityDetail(),
                "#microsoft.graph.certificateBasedAuthPki" => new global::Microsoft.Graph.Models.CertificateBasedAuthPki(),
                "#microsoft.graph.claimsMappingPolicy" => new global::Microsoft.Graph.Models.ClaimsMappingPolicy(),
                "#microsoft.graph.contract" => new global::Microsoft.Graph.Models.Contract(),
                "#microsoft.graph.crossTenantAccessPolicy" => new global::Microsoft.Graph.Models.CrossTenantAccessPolicy(),
                "#microsoft.graph.device" => new global::Microsoft.Graph.Models.Device(),
                "#microsoft.graph.directoryObjectPartnerReference" => new global::Microsoft.Graph.Models.DirectoryObjectPartnerReference(),
                "#microsoft.graph.directoryRole" => new global::Microsoft.Graph.Models.DirectoryRole(),
                "#microsoft.graph.directoryRoleTemplate" => new global::Microsoft.Graph.Models.DirectoryRoleTemplate(),
                "#microsoft.graph.endpoint" => new global::Microsoft.Graph.Models.Endpoint(),
                "#microsoft.graph.extensionProperty" => new global::Microsoft.Graph.Models.ExtensionProperty(),
                "#microsoft.graph.group" => new global::Microsoft.Graph.Models.Group(),
                "#microsoft.graph.groupSettingTemplate" => new global::Microsoft.Graph.Models.GroupSettingTemplate(),
                "#microsoft.graph.homeRealmDiscoveryPolicy" => new global::Microsoft.Graph.Models.HomeRealmDiscoveryPolicy(),
                "#microsoft.graph.identitySecurityDefaultsEnforcementPolicy" => new global::Microsoft.Graph.Models.IdentitySecurityDefaultsEnforcementPolicy(),
                "#microsoft.graph.multiTenantOrganizationMember" => new global::Microsoft.Graph.Models.MultiTenantOrganizationMember(),
                "#microsoft.graph.organization" => new global::Microsoft.Graph.Models.Organization(),
                "#microsoft.graph.orgContact" => new global::Microsoft.Graph.Models.OrgContact(),
                "#microsoft.graph.permissionGrantPolicy" => new global::Microsoft.Graph.Models.PermissionGrantPolicy(),
                "#microsoft.graph.policyBase" => new global::Microsoft.Graph.Models.PolicyBase(),
                "#microsoft.graph.resourceSpecificPermissionGrant" => new global::Microsoft.Graph.Models.ResourceSpecificPermissionGrant(),
                "#microsoft.graph.servicePrincipal" => new global::Microsoft.Graph.Models.ServicePrincipal(),
                "#microsoft.graph.stsPolicy" => new global::Microsoft.Graph.Models.StsPolicy(),
                "#microsoft.graph.tenantAppManagementPolicy" => new global::Microsoft.Graph.Models.TenantAppManagementPolicy(),
                "#microsoft.graph.tokenIssuancePolicy" => new global::Microsoft.Graph.Models.TokenIssuancePolicy(),
                "#microsoft.graph.tokenLifetimePolicy" => new global::Microsoft.Graph.Models.TokenLifetimePolicy(),
                "#microsoft.graph.user" => new global::Microsoft.Graph.Models.User(),
                _ => new global::Microsoft.Graph.Models.DirectoryObject(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "deletedDateTime", n => { DeletedDateTime = n.GetDateTimeOffsetValue(); } },
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
            writer.WriteDateTimeOffsetValue("deletedDateTime", DeletedDateTime);
        }
    }
}
#pragma warning restore CS0618
