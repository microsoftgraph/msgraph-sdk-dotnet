using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>
    /// Provides operations to manage the collection of application entities.
    /// </summary>
    public class PolicyBase : DirectoryObject, IParsable {
        /// <summary>Description for this policy. Required.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>Display name for this policy. Required.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>
        /// Instantiates a new policyBase and sets the default values.
        /// </summary>
        public PolicyBase() : base() {
            OdataType = "#microsoft.graph.policyBase";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new PolicyBase CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.activityBasedTimeoutPolicy" => new ActivityBasedTimeoutPolicy(),
                "#microsoft.graph.authorizationPolicy" => new AuthorizationPolicy(),
                "#microsoft.graph.claimsMappingPolicy" => new ClaimsMappingPolicy(),
                "#microsoft.graph.crossTenantAccessPolicy" => new CrossTenantAccessPolicy(),
                "#microsoft.graph.homeRealmDiscoveryPolicy" => new HomeRealmDiscoveryPolicy(),
                "#microsoft.graph.identitySecurityDefaultsEnforcementPolicy" => new IdentitySecurityDefaultsEnforcementPolicy(),
                "#microsoft.graph.permissionGrantPolicy" => new PermissionGrantPolicy(),
                "#microsoft.graph.stsPolicy" => new StsPolicy(),
                "#microsoft.graph.tokenIssuancePolicy" => new TokenIssuancePolicy(),
                "#microsoft.graph.tokenLifetimePolicy" => new TokenLifetimePolicy(),
                _ => new PolicyBase(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
        }
    }
}
