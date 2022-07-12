using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class OptionalClaims : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>The optional claims returned in the JWT access token.</summary>
        public List<OptionalClaim> AccessToken {
            get { return BackingStore?.Get<List<OptionalClaim>>("accessToken"); }
            set { BackingStore?.Set("accessToken", value); }
        }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The optional claims returned in the JWT ID token.</summary>
        public List<OptionalClaim> IdToken {
            get { return BackingStore?.Get<List<OptionalClaim>>("idToken"); }
            set { BackingStore?.Set("idToken", value); }
        }
        /// <summary>The optional claims returned in the SAML token.</summary>
        public List<OptionalClaim> Saml2Token {
            get { return BackingStore?.Get<List<OptionalClaim>>("saml2Token"); }
            set { BackingStore?.Set("saml2Token", value); }
        }
        /// <summary>
        /// Instantiates a new optionalClaims and sets the default values.
        /// </summary>
        public OptionalClaims() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static OptionalClaims CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OptionalClaims();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"accessToken", n => { AccessToken = n.GetCollectionOfObjectValues<OptionalClaim>(OptionalClaim.CreateFromDiscriminatorValue).ToList(); } },
                {"idToken", n => { IdToken = n.GetCollectionOfObjectValues<OptionalClaim>(OptionalClaim.CreateFromDiscriminatorValue).ToList(); } },
                {"saml2Token", n => { Saml2Token = n.GetCollectionOfObjectValues<OptionalClaim>(OptionalClaim.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<OptionalClaim>("accessToken", AccessToken);
            writer.WriteCollectionOfObjectValues<OptionalClaim>("idToken", IdToken);
            writer.WriteCollectionOfObjectValues<OptionalClaim>("saml2Token", Saml2Token);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
