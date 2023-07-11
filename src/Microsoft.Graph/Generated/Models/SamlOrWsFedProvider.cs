using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class SamlOrWsFedProvider : IdentityProviderBase, IParsable {
        /// <summary>Issuer URI of the federation server.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? IssuerUri {
            get { return BackingStore?.Get<string?>("issuerUri"); }
            set { BackingStore?.Set("issuerUri", value); }
        }
#nullable restore
#else
        public string IssuerUri {
            get { return BackingStore?.Get<string>("issuerUri"); }
            set { BackingStore?.Set("issuerUri", value); }
        }
#endif
        /// <summary>URI of the metadata exchange endpoint used for authentication from rich client applications.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? MetadataExchangeUri {
            get { return BackingStore?.Get<string?>("metadataExchangeUri"); }
            set { BackingStore?.Set("metadataExchangeUri", value); }
        }
#nullable restore
#else
        public string MetadataExchangeUri {
            get { return BackingStore?.Get<string>("metadataExchangeUri"); }
            set { BackingStore?.Set("metadataExchangeUri", value); }
        }
#endif
        /// <summary>URI that web-based clients are directed to when signing in to Azure Active Directory (Azure AD) services.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PassiveSignInUri {
            get { return BackingStore?.Get<string?>("passiveSignInUri"); }
            set { BackingStore?.Set("passiveSignInUri", value); }
        }
#nullable restore
#else
        public string PassiveSignInUri {
            get { return BackingStore?.Get<string>("passiveSignInUri"); }
            set { BackingStore?.Set("passiveSignInUri", value); }
        }
#endif
        /// <summary>Preferred authentication protocol. The possible values are: wsFed, saml, unknownFutureValue.</summary>
        public AuthenticationProtocol? PreferredAuthenticationProtocol {
            get { return BackingStore?.Get<AuthenticationProtocol?>("preferredAuthenticationProtocol"); }
            set { BackingStore?.Set("preferredAuthenticationProtocol", value); }
        }
        /// <summary>Current certificate used to sign tokens passed to the Microsoft identity platform. The certificate is formatted as a Base64 encoded string of the public portion of the federated IdP&apos;s token signing certificate and must be compatible with the X509Certificate2 class.   This property is used in the following scenarios:  if a rollover is required outside of the autorollover update a new federation service is being set up  if the new token signing certificate isn&apos;t present in the federation properties after the federation service certificate has been updated.   Azure AD updates certificates via an autorollover process in which it attempts to retrieve a new certificate from the federation service metadata, 30 days before expiry of the current certificate. If a new certificate isn&apos;t available, Azure AD monitors the metadata daily and will update the federation settings for the domain when a new certificate is available.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SigningCertificate {
            get { return BackingStore?.Get<string?>("signingCertificate"); }
            set { BackingStore?.Set("signingCertificate", value); }
        }
#nullable restore
#else
        public string SigningCertificate {
            get { return BackingStore?.Get<string>("signingCertificate"); }
            set { BackingStore?.Set("signingCertificate", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new samlOrWsFedProvider and sets the default values.
        /// </summary>
        public SamlOrWsFedProvider() : base() {
            OdataType = "#microsoft.graph.samlOrWsFedProvider";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new SamlOrWsFedProvider CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
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
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
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
