using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SharepointIds : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The unique identifier (guid) for the item&apos;s list in SharePoint.</summary>
        public string ListId {
            get { return BackingStore?.Get<string>("listId"); }
            set { BackingStore?.Set("listId", value); }
        }
        /// <summary>An integer identifier for the item within the containing list.</summary>
        public string ListItemId {
            get { return BackingStore?.Get<string>("listItemId"); }
            set { BackingStore?.Set("listItemId", value); }
        }
        /// <summary>The unique identifier (guid) for the item within OneDrive for Business or a SharePoint site.</summary>
        public string ListItemUniqueId {
            get { return BackingStore?.Get<string>("listItemUniqueId"); }
            set { BackingStore?.Set("listItemUniqueId", value); }
        }
        /// <summary>The unique identifier (guid) for the item&apos;s site collection (SPSite).</summary>
        public string SiteId {
            get { return BackingStore?.Get<string>("siteId"); }
            set { BackingStore?.Set("siteId", value); }
        }
        /// <summary>The SharePoint URL for the site that contains the item.</summary>
        public string SiteUrl {
            get { return BackingStore?.Get<string>("siteUrl"); }
            set { BackingStore?.Set("siteUrl", value); }
        }
        /// <summary>The unique identifier (guid) for the tenancy.</summary>
        public string TenantId {
            get { return BackingStore?.Get<string>("tenantId"); }
            set { BackingStore?.Set("tenantId", value); }
        }
        /// <summary>The unique identifier (guid) for the item&apos;s site (SPWeb).</summary>
        public string WebId {
            get { return BackingStore?.Get<string>("webId"); }
            set { BackingStore?.Set("webId", value); }
        }
        /// <summary>
        /// Instantiates a new sharepointIds and sets the default values.
        /// </summary>
        public SharepointIds() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SharepointIds CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SharepointIds();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"listId", n => { ListId = n.GetStringValue(); } },
                {"listItemId", n => { ListItemId = n.GetStringValue(); } },
                {"listItemUniqueId", n => { ListItemUniqueId = n.GetStringValue(); } },
                {"siteId", n => { SiteId = n.GetStringValue(); } },
                {"siteUrl", n => { SiteUrl = n.GetStringValue(); } },
                {"tenantId", n => { TenantId = n.GetStringValue(); } },
                {"webId", n => { WebId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("listId", ListId);
            writer.WriteStringValue("listItemId", ListItemId);
            writer.WriteStringValue("listItemUniqueId", ListItemUniqueId);
            writer.WriteStringValue("siteId", SiteId);
            writer.WriteStringValue("siteUrl", SiteUrl);
            writer.WriteStringValue("tenantId", TenantId);
            writer.WriteStringValue("webId", WebId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
