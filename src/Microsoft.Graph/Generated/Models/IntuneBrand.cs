using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>intuneBrand contains data which is used in customizing the appearance of the Company Portal applications as well as the end user web portal.</summary>
    public class IntuneBrand : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Email address of the person/organization responsible for IT support.</summary>
        public string ContactITEmailAddress {
            get { return BackingStore?.Get<string>("contactITEmailAddress"); }
            set { BackingStore?.Set("contactITEmailAddress", value); }
        }
        /// <summary>Name of the person/organization responsible for IT support.</summary>
        public string ContactITName {
            get { return BackingStore?.Get<string>("contactITName"); }
            set { BackingStore?.Set("contactITName", value); }
        }
        /// <summary>Text comments regarding the person/organization responsible for IT support.</summary>
        public string ContactITNotes {
            get { return BackingStore?.Get<string>("contactITNotes"); }
            set { BackingStore?.Set("contactITNotes", value); }
        }
        /// <summary>Phone number of the person/organization responsible for IT support.</summary>
        public string ContactITPhoneNumber {
            get { return BackingStore?.Get<string>("contactITPhoneNumber"); }
            set { BackingStore?.Set("contactITPhoneNumber", value); }
        }
        /// <summary>Logo image displayed in Company Portal apps which have a dark background behind the logo.</summary>
        public MimeContent DarkBackgroundLogo {
            get { return BackingStore?.Get<MimeContent>("darkBackgroundLogo"); }
            set { BackingStore?.Set("darkBackgroundLogo", value); }
        }
        /// <summary>Company/organization name that is displayed to end users.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Logo image displayed in Company Portal apps which have a light background behind the logo.</summary>
        public MimeContent LightBackgroundLogo {
            get { return BackingStore?.Get<MimeContent>("lightBackgroundLogo"); }
            set { BackingStore?.Set("lightBackgroundLogo", value); }
        }
        /// <summary>Display name of the company/organization’s IT helpdesk site.</summary>
        public string OnlineSupportSiteName {
            get { return BackingStore?.Get<string>("onlineSupportSiteName"); }
            set { BackingStore?.Set("onlineSupportSiteName", value); }
        }
        /// <summary>URL to the company/organization’s IT helpdesk site.</summary>
        public string OnlineSupportSiteUrl {
            get { return BackingStore?.Get<string>("onlineSupportSiteUrl"); }
            set { BackingStore?.Set("onlineSupportSiteUrl", value); }
        }
        /// <summary>URL to the company/organization’s privacy policy.</summary>
        public string PrivacyUrl {
            get { return BackingStore?.Get<string>("privacyUrl"); }
            set { BackingStore?.Set("privacyUrl", value); }
        }
        /// <summary>Boolean that represents whether the administrator-supplied display name will be shown next to the logo image.</summary>
        public bool? ShowDisplayNameNextToLogo {
            get { return BackingStore?.Get<bool?>("showDisplayNameNextToLogo"); }
            set { BackingStore?.Set("showDisplayNameNextToLogo", value); }
        }
        /// <summary>Boolean that represents whether the administrator-supplied logo images are shown or not shown.</summary>
        public bool? ShowLogo {
            get { return BackingStore?.Get<bool?>("showLogo"); }
            set { BackingStore?.Set("showLogo", value); }
        }
        /// <summary>Boolean that represents whether the administrator-supplied display name will be shown next to the logo image.</summary>
        public bool? ShowNameNextToLogo {
            get { return BackingStore?.Get<bool?>("showNameNextToLogo"); }
            set { BackingStore?.Set("showNameNextToLogo", value); }
        }
        /// <summary>Primary theme color used in the Company Portal applications and web portal.</summary>
        public RgbColor ThemeColor {
            get { return BackingStore?.Get<RgbColor>("themeColor"); }
            set { BackingStore?.Set("themeColor", value); }
        }
        /// <summary>
        /// Instantiates a new intuneBrand and sets the default values.
        /// </summary>
        public IntuneBrand() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static IntuneBrand CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IntuneBrand();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"contactITEmailAddress", n => { ContactITEmailAddress = n.GetStringValue(); } },
                {"contactITName", n => { ContactITName = n.GetStringValue(); } },
                {"contactITNotes", n => { ContactITNotes = n.GetStringValue(); } },
                {"contactITPhoneNumber", n => { ContactITPhoneNumber = n.GetStringValue(); } },
                {"darkBackgroundLogo", n => { DarkBackgroundLogo = n.GetObjectValue<MimeContent>(MimeContent.CreateFromDiscriminatorValue); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"lightBackgroundLogo", n => { LightBackgroundLogo = n.GetObjectValue<MimeContent>(MimeContent.CreateFromDiscriminatorValue); } },
                {"onlineSupportSiteName", n => { OnlineSupportSiteName = n.GetStringValue(); } },
                {"onlineSupportSiteUrl", n => { OnlineSupportSiteUrl = n.GetStringValue(); } },
                {"privacyUrl", n => { PrivacyUrl = n.GetStringValue(); } },
                {"showDisplayNameNextToLogo", n => { ShowDisplayNameNextToLogo = n.GetBoolValue(); } },
                {"showLogo", n => { ShowLogo = n.GetBoolValue(); } },
                {"showNameNextToLogo", n => { ShowNameNextToLogo = n.GetBoolValue(); } },
                {"themeColor", n => { ThemeColor = n.GetObjectValue<RgbColor>(RgbColor.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("contactITEmailAddress", ContactITEmailAddress);
            writer.WriteStringValue("contactITName", ContactITName);
            writer.WriteStringValue("contactITNotes", ContactITNotes);
            writer.WriteStringValue("contactITPhoneNumber", ContactITPhoneNumber);
            writer.WriteObjectValue<MimeContent>("darkBackgroundLogo", DarkBackgroundLogo);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<MimeContent>("lightBackgroundLogo", LightBackgroundLogo);
            writer.WriteStringValue("onlineSupportSiteName", OnlineSupportSiteName);
            writer.WriteStringValue("onlineSupportSiteUrl", OnlineSupportSiteUrl);
            writer.WriteStringValue("privacyUrl", PrivacyUrl);
            writer.WriteBoolValue("showDisplayNameNextToLogo", ShowDisplayNameNextToLogo);
            writer.WriteBoolValue("showLogo", ShowLogo);
            writer.WriteBoolValue("showNameNextToLogo", ShowNameNextToLogo);
            writer.WriteObjectValue<RgbColor>("themeColor", ThemeColor);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
