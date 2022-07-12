using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SharingLink : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The app the link is associated with.</summary>
        public Identity Application {
            get { return BackingStore?.Get<Identity>("application"); }
            set { BackingStore?.Set("application", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>If true then the user can only use this link to view the item on the web, and cannot use it to download the contents of the item. Only for OneDrive for Business and SharePoint.</summary>
        public bool? PreventsDownload {
            get { return BackingStore?.Get<bool?>("preventsDownload"); }
            set { BackingStore?.Set("preventsDownload", value); }
        }
        /// <summary>The scope of the link represented by this permission. Value anonymous indicates the link is usable by anyone, organization indicates the link is only usable for users signed into the same tenant.</summary>
        public string Scope {
            get { return BackingStore?.Get<string>("scope"); }
            set { BackingStore?.Set("scope", value); }
        }
        /// <summary>The type of the link created.</summary>
        public string Type {
            get { return BackingStore?.Get<string>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>For embed links, this property contains the HTML code for an &lt;iframe&gt; element that will embed the item in a webpage.</summary>
        public string WebHtml {
            get { return BackingStore?.Get<string>("webHtml"); }
            set { BackingStore?.Set("webHtml", value); }
        }
        /// <summary>A URL that opens the item in the browser on the OneDrive website.</summary>
        public string WebUrl {
            get { return BackingStore?.Get<string>("webUrl"); }
            set { BackingStore?.Set("webUrl", value); }
        }
        /// <summary>
        /// Instantiates a new sharingLink and sets the default values.
        /// </summary>
        public SharingLink() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SharingLink CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SharingLink();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"application", n => { Application = n.GetObjectValue<Identity>(Identity.CreateFromDiscriminatorValue); } },
                {"preventsDownload", n => { PreventsDownload = n.GetBoolValue(); } },
                {"scope", n => { Scope = n.GetStringValue(); } },
                {"type", n => { Type = n.GetStringValue(); } },
                {"webHtml", n => { WebHtml = n.GetStringValue(); } },
                {"webUrl", n => { WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Identity>("application", Application);
            writer.WriteBoolValue("preventsDownload", PreventsDownload);
            writer.WriteStringValue("scope", Scope);
            writer.WriteStringValue("type", Type);
            writer.WriteStringValue("webHtml", WebHtml);
            writer.WriteStringValue("webUrl", WebUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
