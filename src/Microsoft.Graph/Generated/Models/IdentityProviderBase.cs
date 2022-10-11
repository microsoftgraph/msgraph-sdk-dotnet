using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IdentityProviderBase : Entity, IParsable {
        /// <summary>The display name of the identity provider.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>
        /// Instantiates a new IdentityProviderBase and sets the default values.
        /// </summary>
        public IdentityProviderBase() : base() {
            OdataType = "#microsoft.graph.identityProviderBase";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new IdentityProviderBase CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.appleManagedIdentityProvider" => new AppleManagedIdentityProvider(),
                "#microsoft.graph.builtInIdentityProvider" => new BuiltInIdentityProvider(),
                "#microsoft.graph.internalDomainFederation" => new InternalDomainFederation(),
                "#microsoft.graph.samlOrWsFedExternalDomainFederation" => new SamlOrWsFedExternalDomainFederation(),
                "#microsoft.graph.samlOrWsFedProvider" => new SamlOrWsFedProvider(),
                "#microsoft.graph.socialIdentityProvider" => new SocialIdentityProvider(),
                _ => new IdentityProviderBase(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("displayName", DisplayName);
        }
    }
}
