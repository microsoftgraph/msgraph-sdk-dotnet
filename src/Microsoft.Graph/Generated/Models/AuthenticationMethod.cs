using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class AuthenticationMethod : Entity, IParsable {
        /// <summary>
        /// Instantiates a new authenticationMethod and sets the default values.
        /// </summary>
        public AuthenticationMethod() : base() {
            OdataType = "#microsoft.graph.authenticationMethod";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AuthenticationMethod CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.emailAuthenticationMethod" => new EmailAuthenticationMethod(),
                "#microsoft.graph.fido2AuthenticationMethod" => new Fido2AuthenticationMethod(),
                "#microsoft.graph.microsoftAuthenticatorAuthenticationMethod" => new MicrosoftAuthenticatorAuthenticationMethod(),
                "#microsoft.graph.passwordAuthenticationMethod" => new PasswordAuthenticationMethod(),
                "#microsoft.graph.phoneAuthenticationMethod" => new PhoneAuthenticationMethod(),
                "#microsoft.graph.softwareOathAuthenticationMethod" => new SoftwareOathAuthenticationMethod(),
                "#microsoft.graph.temporaryAccessPassAuthenticationMethod" => new TemporaryAccessPassAuthenticationMethod(),
                "#microsoft.graph.windowsHelloForBusinessAuthenticationMethod" => new WindowsHelloForBusinessAuthenticationMethod(),
                _ => new AuthenticationMethod(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
        }
    }
}
