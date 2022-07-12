using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AuthenticationMethodsRegistrationCampaignIncludeTarget : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The object identifier of an Azure AD user or group.</summary>
        public string Id {
            get { return BackingStore?.Get<string>("id"); }
            set { BackingStore?.Set("id", value); }
        }
        /// <summary>The authentication method that the user is prompted to register. The value must be microsoftAuthenticator.</summary>
        public string TargetedAuthenticationMethod {
            get { return BackingStore?.Get<string>("targetedAuthenticationMethod"); }
            set { BackingStore?.Set("targetedAuthenticationMethod", value); }
        }
        /// <summary>The targetType property</summary>
        public AuthenticationMethodTargetType? TargetType {
            get { return BackingStore?.Get<AuthenticationMethodTargetType?>("targetType"); }
            set { BackingStore?.Set("targetType", value); }
        }
        /// <summary>
        /// Instantiates a new authenticationMethodsRegistrationCampaignIncludeTarget and sets the default values.
        /// </summary>
        public AuthenticationMethodsRegistrationCampaignIncludeTarget() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AuthenticationMethodsRegistrationCampaignIncludeTarget CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AuthenticationMethodsRegistrationCampaignIncludeTarget();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"id", n => { Id = n.GetStringValue(); } },
                {"targetedAuthenticationMethod", n => { TargetedAuthenticationMethod = n.GetStringValue(); } },
                {"targetType", n => { TargetType = n.GetEnumValue<AuthenticationMethodTargetType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("targetedAuthenticationMethod", TargetedAuthenticationMethod);
            writer.WriteEnumValue<AuthenticationMethodTargetType>("targetType", TargetType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
