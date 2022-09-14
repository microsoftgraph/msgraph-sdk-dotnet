using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WebApplication : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Home page or landing page of the application.</summary>
        public string HomePageUrl {
            get { return BackingStore?.Get<string>("homePageUrl"); }
            set { BackingStore?.Set("homePageUrl", value); }
        }
        /// <summary>Specifies whether this web application can request tokens using the OAuth 2.0 implicit flow.</summary>
        public Microsoft.Graph.Models.ImplicitGrantSettings ImplicitGrantSettings {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ImplicitGrantSettings>("implicitGrantSettings"); }
            set { BackingStore?.Set("implicitGrantSettings", value); }
        }
        /// <summary>Specifies the URL that will be used by Microsoft&apos;s authorization service to logout an user using front-channel, back-channel or SAML logout protocols.</summary>
        public string LogoutUrl {
            get { return BackingStore?.Get<string>("logoutUrl"); }
            set { BackingStore?.Set("logoutUrl", value); }
        }
        /// <summary>The OdataType property</summary>
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>Specifies the URLs where user tokens are sent for sign-in, or the redirect URIs where OAuth 2.0 authorization codes and access tokens are sent.</summary>
        public List<string> RedirectUris {
            get { return BackingStore?.Get<List<string>>("redirectUris"); }
            set { BackingStore?.Set("redirectUris", value); }
        }
        /// <summary>The redirectUriSettings property</summary>
        public List<Microsoft.Graph.Models.RedirectUriSettings> RedirectUriSettings {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.RedirectUriSettings>>("redirectUriSettings"); }
            set { BackingStore?.Set("redirectUriSettings", value); }
        }
        /// <summary>
        /// Instantiates a new webApplication and sets the default values.
        /// </summary>
        public WebApplication() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
            OdataType = "#microsoft.graph.webApplication";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static WebApplication CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WebApplication();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"homePageUrl", n => { HomePageUrl = n.GetStringValue(); } },
                {"implicitGrantSettings", n => { ImplicitGrantSettings = n.GetObjectValue<Microsoft.Graph.Models.ImplicitGrantSettings>(Microsoft.Graph.Models.ImplicitGrantSettings.CreateFromDiscriminatorValue); } },
                {"logoutUrl", n => { LogoutUrl = n.GetStringValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"redirectUris", n => { RedirectUris = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"redirectUriSettings", n => { RedirectUriSettings = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.RedirectUriSettings>(Microsoft.Graph.Models.RedirectUriSettings.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("homePageUrl", HomePageUrl);
            writer.WriteObjectValue<Microsoft.Graph.Models.ImplicitGrantSettings>("implicitGrantSettings", ImplicitGrantSettings);
            writer.WriteStringValue("logoutUrl", LogoutUrl);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteCollectionOfPrimitiveValues<string>("redirectUris", RedirectUris);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.RedirectUriSettings>("redirectUriSettings", RedirectUriSettings);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
