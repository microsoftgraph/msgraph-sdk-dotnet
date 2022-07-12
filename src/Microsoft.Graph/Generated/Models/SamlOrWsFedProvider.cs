using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SamlOrWsFedProvider : IdentityProviderBase, IParsable {
        /// <summary>Issuer URI of the federation server.</summary>
        public string IssuerUri {
            get { return BackingStore?.Get<string>("issuerUri"); }
            set { BackingStore?.Set("issuerUri", value); }
        }
        /// <summary>URI of the metadata exchange endpoint used for authentication from rich client applications.</summary>
        public string MetadataExchangeUri {
            get { return BackingStore?.Get<string>("metadataExchangeUri"); }
            set { BackingStore?.Set("metadataExchangeUri", value); }
        }
        /// <summary>URI that web-based clients are directed to when signing in to Azure Active Directory (Azure AD) services.</summary>
        public string PassiveSignInUri {
            get { return BackingStore?.Get<string>("passiveSignInUri"); }
            set { BackingStore?.Set("passiveSignInUri", value); }
        }
        /// <summary>Preferred authentication protocol. Supported values include saml or wsfed.</summary>
        public AuthenticationProtocol? PreferredAuthenticationProtocol {
            get { return BackingStore?.Get<AuthenticationProtocol?>("preferredAuthenticationProtocol"); }
            set { BackingStore?.Set("preferredAuthenticationProtocol", value); }
        }
        /// <summary>Current certificate used to sign tokens passed to the Microsoft identity platform. The certificate is formatted as a Base64 encoded string of the public portion of the federated IdP&apos;s token signing certificate and must be compatible with the X509Certificate2 class.   This property is used in the following scenarios:  if a rollover is required outside of the autorollover update a new federation service is being set up  if the new token signing certificate isn&apos;t present in the federation properties after the federation service certificate has been updated.   Azure AD updates certificates via an autorollover process in which it attempts to retrieve a new certificate from the federation service metadata, 30 days before expiry of the current certificate. If a new certificate isn&apos;t available, Azure AD monitors the metadata daily and will update the federation settings for the domain when a new certificate is available.</summary>
        public string SigningCertificate {
            get { return BackingStore?.Get<string>("signingCertificate"); }
            set { BackingStore?.Set("signingCertificate", value); }
        }
        /// <summary>
        /// Instantiates a new SamlOrWsFedProvider and sets the default values.
        /// </summary>
        public SamlOrWsFedProvider() : base() {
            Type = "#microsoft.graph.samlOrWsFedProvider";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SamlOrWsFedProvider CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.internalDomainFederation" => new InternalDomainFederation(),
                "#microsoft.graph.samlOrWsFedExternalDomainFederation" => new SamlOrWsFedExternalDomainFederation(),
                _ => new SamlOrWsFedProvider(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"issuerUri", n => { IssuerUri = n.GetStringValue(); } },
                {"metadataExchangeUri", n => { MetadataExchangeUri = n.GetStringValue(); } },
                {"passiveSignInUri", n => { PassiveSignInUri = n.GetStringValue(); } },
                {"preferredAuthenticationProtocol", n => { PreferredAuthenticationProtocol = n.GetEnumValue<AuthenticationProtocol>(); } },
                {"signingCertificate", n => { SigningCertificate = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("issuerUri", IssuerUri);
            writer.WriteStringValue("metadataExchangeUri", MetadataExchangeUri);
            writer.WriteStringValue("passiveSignInUri", PassiveSignInUri);
            writer.WriteEnumValue<AuthenticationProtocol>("preferredAuthenticationProtocol", PreferredAuthenticationProtocol);
            writer.WriteStringValue("signingCertificate", SigningCertificate);
        }
    }
}
