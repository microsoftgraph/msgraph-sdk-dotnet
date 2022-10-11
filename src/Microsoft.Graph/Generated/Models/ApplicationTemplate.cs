using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of applicationTemplate entities.</summary>
    public class ApplicationTemplate : Entity, IParsable {
        /// <summary>The list of categories for the application. Supported values can be: Collaboration, Business Management, Consumer, Content management, CRM, Data services, Developer services, E-commerce, Education, ERP, Finance, Health, Human resources, IT infrastructure, Mail, Management, Marketing, Media, Productivity, Project management, Telecommunications, Tools, Travel, and Web design &amp; hosting.</summary>
        public List<string> Categories {
            get { return BackingStore?.Get<List<string>>("categories"); }
            set { BackingStore?.Set("categories", value); }
        }
        /// <summary>A description of the application.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The name of the application.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The home page URL of the application.</summary>
        public string HomePageUrl {
            get { return BackingStore?.Get<string>("homePageUrl"); }
            set { BackingStore?.Set("homePageUrl", value); }
        }
        /// <summary>The URL to get the logo for this application.</summary>
        public string LogoUrl {
            get { return BackingStore?.Get<string>("logoUrl"); }
            set { BackingStore?.Set("logoUrl", value); }
        }
        /// <summary>The name of the publisher for this application.</summary>
        public string Publisher {
            get { return BackingStore?.Get<string>("publisher"); }
            set { BackingStore?.Set("publisher", value); }
        }
        /// <summary>The list of provisioning modes supported by this application. The only valid value is sync.</summary>
        public List<string> SupportedProvisioningTypes {
            get { return BackingStore?.Get<List<string>>("supportedProvisioningTypes"); }
            set { BackingStore?.Set("supportedProvisioningTypes", value); }
        }
        /// <summary>The list of single sign-on modes supported by this application. The supported values are oidc, password, saml, and notSupported.</summary>
        public List<string> SupportedSingleSignOnModes {
            get { return BackingStore?.Get<List<string>>("supportedSingleSignOnModes"); }
            set { BackingStore?.Set("supportedSingleSignOnModes", value); }
        }
        /// <summary>
        /// Instantiates a new applicationTemplate and sets the default values.
        /// </summary>
        public ApplicationTemplate() : base() {
            OdataType = "#microsoft.graph.applicationTemplate";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ApplicationTemplate CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ApplicationTemplate();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"categories", n => { Categories = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"homePageUrl", n => { HomePageUrl = n.GetStringValue(); } },
                {"logoUrl", n => { LogoUrl = n.GetStringValue(); } },
                {"publisher", n => { Publisher = n.GetStringValue(); } },
                {"supportedProvisioningTypes", n => { SupportedProvisioningTypes = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"supportedSingleSignOnModes", n => { SupportedSingleSignOnModes = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfPrimitiveValues<string>("categories", Categories);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("homePageUrl", HomePageUrl);
            writer.WriteStringValue("logoUrl", LogoUrl);
            writer.WriteStringValue("publisher", Publisher);
            writer.WriteCollectionOfPrimitiveValues<string>("supportedProvisioningTypes", SupportedProvisioningTypes);
            writer.WriteCollectionOfPrimitiveValues<string>("supportedSingleSignOnModes", SupportedSingleSignOnModes);
        }
    }
}
