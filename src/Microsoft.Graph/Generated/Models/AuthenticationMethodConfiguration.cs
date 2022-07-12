using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of authenticationMethodConfiguration entities.</summary>
    public class AuthenticationMethodConfiguration : Entity, IParsable {
        /// <summary>The state of the policy. Possible values are: enabled, disabled.</summary>
        public AuthenticationMethodState? State {
            get { return BackingStore?.Get<AuthenticationMethodState?>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>
        /// Instantiates a new authenticationMethodConfiguration and sets the default values.
        /// </summary>
        public AuthenticationMethodConfiguration() : base() {
            Type = "#microsoft.graph.authenticationMethodConfiguration";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AuthenticationMethodConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.emailAuthenticationMethodConfiguration" => new EmailAuthenticationMethodConfiguration(),
                "#microsoft.graph.fido2AuthenticationMethodConfiguration" => new Fido2AuthenticationMethodConfiguration(),
                "#microsoft.graph.microsoftAuthenticatorAuthenticationMethodConfiguration" => new MicrosoftAuthenticatorAuthenticationMethodConfiguration(),
                "#microsoft.graph.temporaryAccessPassAuthenticationMethodConfiguration" => new TemporaryAccessPassAuthenticationMethodConfiguration(),
                _ => new AuthenticationMethodConfiguration(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"state", n => { State = n.GetEnumValue<AuthenticationMethodState>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<AuthenticationMethodState>("state", State);
        }
    }
}
