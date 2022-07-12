using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SocialIdentityProvider : IdentityProviderBase, IParsable {
        /// <summary>The client identifier for the application obtained when registering the application with the identity provider. Required.</summary>
        public string ClientId {
            get { return BackingStore?.Get<string>("clientId"); }
            set { BackingStore?.Set("clientId", value); }
        }
        /// <summary>The client secret for the application that is obtained when the application is registered with the identity provider. This is write-only. A read operation returns ****. Required.</summary>
        public string ClientSecret {
            get { return BackingStore?.Get<string>("clientSecret"); }
            set { BackingStore?.Set("clientSecret", value); }
        }
        /// <summary>For a B2B scenario, possible values: Google, Facebook. For a B2C scenario, possible values: Microsoft, Google, Amazon, LinkedIn, Facebook, GitHub, Twitter, Weibo, QQ, WeChat. Required.</summary>
        public string IdentityProviderType {
            get { return BackingStore?.Get<string>("identityProviderType"); }
            set { BackingStore?.Set("identityProviderType", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SocialIdentityProvider CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SocialIdentityProvider();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"clientId", n => { ClientId = n.GetStringValue(); } },
                {"clientSecret", n => { ClientSecret = n.GetStringValue(); } },
                {"identityProviderType", n => { IdentityProviderType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("clientId", ClientId);
            writer.WriteStringValue("clientSecret", ClientSecret);
            writer.WriteStringValue("identityProviderType", IdentityProviderType);
        }
    }
}
