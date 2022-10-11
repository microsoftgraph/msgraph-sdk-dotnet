using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of authenticationMethodConfiguration entities.</summary>
    public class AuthenticationMethodTarget : Entity, IParsable {
        /// <summary>Determines if the user is enforced to register the authentication method.</summary>
        public bool? IsRegistrationRequired {
            get { return BackingStore?.Get<bool?>("isRegistrationRequired"); }
            set { BackingStore?.Set("isRegistrationRequired", value); }
        }
        /// <summary>The targetType property</summary>
        public AuthenticationMethodTargetType? TargetType {
            get { return BackingStore?.Get<AuthenticationMethodTargetType?>("targetType"); }
            set { BackingStore?.Set("targetType", value); }
        }
        /// <summary>
        /// Instantiates a new authenticationMethodTarget and sets the default values.
        /// </summary>
        public AuthenticationMethodTarget() : base() {
            OdataType = "#microsoft.graph.authenticationMethodTarget";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AuthenticationMethodTarget CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.microsoftAuthenticatorAuthenticationMethodTarget" => new MicrosoftAuthenticatorAuthenticationMethodTarget(),
                _ => new AuthenticationMethodTarget(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"isRegistrationRequired", n => { IsRegistrationRequired = n.GetBoolValue(); } },
                {"targetType", n => { TargetType = n.GetEnumValue<AuthenticationMethodTargetType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("isRegistrationRequired", IsRegistrationRequired);
            writer.WriteEnumValue<AuthenticationMethodTargetType>("targetType", TargetType);
        }
    }
}
