using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class MicrosoftAuthenticatorAuthenticationMethodConfiguration : AuthenticationMethodConfiguration, IParsable {
        /// <summary>A collection of users or groups who are enabled to use the authentication method.</summary>
        public List<MicrosoftAuthenticatorAuthenticationMethodTarget> IncludeTargets {
            get { return BackingStore?.Get<List<MicrosoftAuthenticatorAuthenticationMethodTarget>>("includeTargets"); }
            set { BackingStore?.Set("includeTargets", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new MicrosoftAuthenticatorAuthenticationMethodConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MicrosoftAuthenticatorAuthenticationMethodConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"includeTargets", n => { IncludeTargets = n.GetCollectionOfObjectValues<MicrosoftAuthenticatorAuthenticationMethodTarget>(MicrosoftAuthenticatorAuthenticationMethodTarget.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<MicrosoftAuthenticatorAuthenticationMethodTarget>("includeTargets", IncludeTargets);
        }
    }
}
