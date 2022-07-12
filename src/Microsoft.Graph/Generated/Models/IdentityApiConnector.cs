using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IdentityApiConnector : Entity, IParsable {
        /// <summary>The object which describes the authentication configuration details for calling the API. Basic and PKCS 12 client certificate are supported.</summary>
        public ApiAuthenticationConfigurationBase AuthenticationConfiguration {
            get { return BackingStore?.Get<ApiAuthenticationConfigurationBase>("authenticationConfiguration"); }
            set { BackingStore?.Set("authenticationConfiguration", value); }
        }
        /// <summary>The name of the API connector.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The URL of the API endpoint to call.</summary>
        public string TargetUrl {
            get { return BackingStore?.Get<string>("targetUrl"); }
            set { BackingStore?.Set("targetUrl", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new IdentityApiConnector CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IdentityApiConnector();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"authenticationConfiguration", n => { AuthenticationConfiguration = n.GetObjectValue<ApiAuthenticationConfigurationBase>(ApiAuthenticationConfigurationBase.CreateFromDiscriminatorValue); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"targetUrl", n => { TargetUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ApiAuthenticationConfigurationBase>("authenticationConfiguration", AuthenticationConfiguration);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("targetUrl", TargetUrl);
        }
    }
}
