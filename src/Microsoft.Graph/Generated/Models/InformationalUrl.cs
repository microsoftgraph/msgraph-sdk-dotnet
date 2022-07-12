using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class InformationalUrl : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>CDN URL to the application&apos;s logo, Read-only.</summary>
        public string LogoUrl {
            get { return BackingStore?.Get<string>("logoUrl"); }
            set { BackingStore?.Set("logoUrl", value); }
        }
        /// <summary>Link to the application&apos;s marketing page. For example, https://www.contoso.com/app/marketing</summary>
        public string MarketingUrl {
            get { return BackingStore?.Get<string>("marketingUrl"); }
            set { BackingStore?.Set("marketingUrl", value); }
        }
        /// <summary>Link to the application&apos;s privacy statement. For example, https://www.contoso.com/app/privacy</summary>
        public string PrivacyStatementUrl {
            get { return BackingStore?.Get<string>("privacyStatementUrl"); }
            set { BackingStore?.Set("privacyStatementUrl", value); }
        }
        /// <summary>Link to the application&apos;s support page. For example, https://www.contoso.com/app/support</summary>
        public string SupportUrl {
            get { return BackingStore?.Get<string>("supportUrl"); }
            set { BackingStore?.Set("supportUrl", value); }
        }
        /// <summary>Link to the application&apos;s terms of service statement. For example, https://www.contoso.com/app/termsofservice</summary>
        public string TermsOfServiceUrl {
            get { return BackingStore?.Get<string>("termsOfServiceUrl"); }
            set { BackingStore?.Set("termsOfServiceUrl", value); }
        }
        /// <summary>
        /// Instantiates a new informationalUrl and sets the default values.
        /// </summary>
        public InformationalUrl() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static InformationalUrl CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new InformationalUrl();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"logoUrl", n => { LogoUrl = n.GetStringValue(); } },
                {"marketingUrl", n => { MarketingUrl = n.GetStringValue(); } },
                {"privacyStatementUrl", n => { PrivacyStatementUrl = n.GetStringValue(); } },
                {"supportUrl", n => { SupportUrl = n.GetStringValue(); } },
                {"termsOfServiceUrl", n => { TermsOfServiceUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("logoUrl", LogoUrl);
            writer.WriteStringValue("marketingUrl", MarketingUrl);
            writer.WriteStringValue("privacyStatementUrl", PrivacyStatementUrl);
            writer.WriteStringValue("supportUrl", SupportUrl);
            writer.WriteStringValue("termsOfServiceUrl", TermsOfServiceUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
