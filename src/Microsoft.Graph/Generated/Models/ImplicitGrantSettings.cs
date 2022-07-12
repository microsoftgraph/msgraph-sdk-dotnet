using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ImplicitGrantSettings : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Specifies whether this web application can request an access token using the OAuth 2.0 implicit flow.</summary>
        public bool? EnableAccessTokenIssuance {
            get { return BackingStore?.Get<bool?>("enableAccessTokenIssuance"); }
            set { BackingStore?.Set("enableAccessTokenIssuance", value); }
        }
        /// <summary>Specifies whether this web application can request an ID token using the OAuth 2.0 implicit flow.</summary>
        public bool? EnableIdTokenIssuance {
            get { return BackingStore?.Get<bool?>("enableIdTokenIssuance"); }
            set { BackingStore?.Set("enableIdTokenIssuance", value); }
        }
        /// <summary>
        /// Instantiates a new implicitGrantSettings and sets the default values.
        /// </summary>
        public ImplicitGrantSettings() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ImplicitGrantSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ImplicitGrantSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"enableAccessTokenIssuance", n => { EnableAccessTokenIssuance = n.GetBoolValue(); } },
                {"enableIdTokenIssuance", n => { EnableIdTokenIssuance = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("enableAccessTokenIssuance", EnableAccessTokenIssuance);
            writer.WriteBoolValue("enableIdTokenIssuance", EnableIdTokenIssuance);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
