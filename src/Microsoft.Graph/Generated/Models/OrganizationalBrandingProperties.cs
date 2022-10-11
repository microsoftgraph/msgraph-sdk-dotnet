using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the organizationalBranding singleton.</summary>
    public class OrganizationalBrandingProperties : Entity, IParsable {
        /// <summary>Color that will appear in place of the background image in low-bandwidth connections. We recommend that you use the primary color of your banner logo or your organization color. Specify this in hexadecimal format, for example, white is #FFFFFF.</summary>
        public string BackgroundColor {
            get { return BackingStore?.Get<string>("backgroundColor"); }
            set { BackingStore?.Set("backgroundColor", value); }
        }
        /// <summary>Image that appears as the background of the sign-in page. The allowed types are PNG or JPEG not smaller than 300 KB and not larger than 1920 × 1080 pixels. A smaller image will reduce bandwidth requirements and make the page load faster.</summary>
        public byte[] BackgroundImage {
            get { return BackingStore?.Get<byte[]>("backgroundImage"); }
            set { BackingStore?.Set("backgroundImage", value); }
        }
        /// <summary>A relative URL for the backgroundImage property that is combined with a CDN base URL from the cdnList to provide the version served by a CDN. Read-only.</summary>
        public string BackgroundImageRelativeUrl {
            get { return BackingStore?.Get<string>("backgroundImageRelativeUrl"); }
            set { BackingStore?.Set("backgroundImageRelativeUrl", value); }
        }
        /// <summary>A banner version of your company logo that appears on the sign-in page. The allowed types are PNG or JPEG no larger than 36 × 245 pixels. We recommend using a transparent image with no padding around the logo.</summary>
        public byte[] BannerLogo {
            get { return BackingStore?.Get<byte[]>("bannerLogo"); }
            set { BackingStore?.Set("bannerLogo", value); }
        }
        /// <summary>A relative url for the bannerLogo property that is combined with a CDN base URL from the cdnList to provide the read-only version served by a CDN. Read-only.</summary>
        public string BannerLogoRelativeUrl {
            get { return BackingStore?.Get<string>("bannerLogoRelativeUrl"); }
            set { BackingStore?.Set("bannerLogoRelativeUrl", value); }
        }
        /// <summary>A list of base URLs for all available CDN providers that are serving the assets of the current resource. Several CDN providers are used at the same time for high availability of read requests. Read-only.</summary>
        public List<string> CdnList {
            get { return BackingStore?.Get<List<string>>("cdnList"); }
            set { BackingStore?.Set("cdnList", value); }
        }
        /// <summary>Text that appears at the bottom of the sign-in box. You can use this to communicate additional information, such as the phone number to your help desk or a legal statement. This text must be Unicode and not exceed 1024 characters.</summary>
        public string SignInPageText {
            get { return BackingStore?.Get<string>("signInPageText"); }
            set { BackingStore?.Set("signInPageText", value); }
        }
        /// <summary>A square version of your company logo that appears in Windows 10 out-of-box experiences (OOBE) and when Windows Autopilot is enabled for deployment. Allowed types are PNG or JPEG no larger than 240 x 240 pixels and no more than 10 KB in size. We recommend using a transparent image with no padding around the logo.</summary>
        public byte[] SquareLogo {
            get { return BackingStore?.Get<byte[]>("squareLogo"); }
            set { BackingStore?.Set("squareLogo", value); }
        }
        /// <summary>A relative url for the squareLogo property that is combined with a CDN base URL from the cdnList to provide the version served by a CDN. Read-only.</summary>
        public string SquareLogoRelativeUrl {
            get { return BackingStore?.Get<string>("squareLogoRelativeUrl"); }
            set { BackingStore?.Set("squareLogoRelativeUrl", value); }
        }
        /// <summary>String that shows as the hint in the username textbox on the sign-in screen. This text must be a Unicode, without links or code, and can&apos;t exceed 64 characters.</summary>
        public string UsernameHintText {
            get { return BackingStore?.Get<string>("usernameHintText"); }
            set { BackingStore?.Set("usernameHintText", value); }
        }
        /// <summary>
        /// Instantiates a new organizationalBrandingProperties and sets the default values.
        /// </summary>
        public OrganizationalBrandingProperties() : base() {
            OdataType = "#microsoft.graph.organizationalBrandingProperties";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new OrganizationalBrandingProperties CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.organizationalBranding" => new OrganizationalBranding(),
                "#microsoft.graph.organizationalBrandingLocalization" => new OrganizationalBrandingLocalization(),
                _ => new OrganizationalBrandingProperties(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"backgroundColor", n => { BackgroundColor = n.GetStringValue(); } },
                {"backgroundImage", n => { BackgroundImage = n.GetByteArrayValue(); } },
                {"backgroundImageRelativeUrl", n => { BackgroundImageRelativeUrl = n.GetStringValue(); } },
                {"bannerLogo", n => { BannerLogo = n.GetByteArrayValue(); } },
                {"bannerLogoRelativeUrl", n => { BannerLogoRelativeUrl = n.GetStringValue(); } },
                {"cdnList", n => { CdnList = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"signInPageText", n => { SignInPageText = n.GetStringValue(); } },
                {"squareLogo", n => { SquareLogo = n.GetByteArrayValue(); } },
                {"squareLogoRelativeUrl", n => { SquareLogoRelativeUrl = n.GetStringValue(); } },
                {"usernameHintText", n => { UsernameHintText = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("backgroundColor", BackgroundColor);
            writer.WriteByteArrayValue("backgroundImage", BackgroundImage);
            writer.WriteStringValue("backgroundImageRelativeUrl", BackgroundImageRelativeUrl);
            writer.WriteByteArrayValue("bannerLogo", BannerLogo);
            writer.WriteStringValue("bannerLogoRelativeUrl", BannerLogoRelativeUrl);
            writer.WriteCollectionOfPrimitiveValues<string>("cdnList", CdnList);
            writer.WriteStringValue("signInPageText", SignInPageText);
            writer.WriteByteArrayValue("squareLogo", SquareLogo);
            writer.WriteStringValue("squareLogoRelativeUrl", SquareLogoRelativeUrl);
            writer.WriteStringValue("usernameHintText", UsernameHintText);
        }
    }
}
