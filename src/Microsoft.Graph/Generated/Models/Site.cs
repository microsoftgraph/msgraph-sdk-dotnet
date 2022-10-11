using Microsoft.Graph.Models.TermStore;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Site : BaseItem, IParsable {
        /// <summary>Analytics about the view activities that took place in this site.</summary>
        public ItemAnalytics Analytics {
            get { return BackingStore?.Get<ItemAnalytics>("analytics"); }
            set { BackingStore?.Set("analytics", value); }
        }
        /// <summary>The collection of column definitions reusable across lists under this site.</summary>
        public List<ColumnDefinition> Columns {
            get { return BackingStore?.Get<List<ColumnDefinition>>("columns"); }
            set { BackingStore?.Set("columns", value); }
        }
        /// <summary>The collection of content types defined for this site.</summary>
        public List<ContentType> ContentTypes {
            get { return BackingStore?.Get<List<ContentType>>("contentTypes"); }
            set { BackingStore?.Set("contentTypes", value); }
        }
        /// <summary>The full title for the site. Read-only.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The default drive (document library) for this site.</summary>
        public Microsoft.Graph.Models.Drive Drive {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Drive>("drive"); }
            set { BackingStore?.Set("drive", value); }
        }
        /// <summary>The collection of drives (document libraries) under this site.</summary>
        public List<Microsoft.Graph.Models.Drive> Drives {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.Drive>>("drives"); }
            set { BackingStore?.Set("drives", value); }
        }
        /// <summary>The error property</summary>
        public PublicError Error {
            get { return BackingStore?.Get<PublicError>("error"); }
            set { BackingStore?.Set("error", value); }
        }
        /// <summary>The externalColumns property</summary>
        public List<ColumnDefinition> ExternalColumns {
            get { return BackingStore?.Get<List<ColumnDefinition>>("externalColumns"); }
            set { BackingStore?.Set("externalColumns", value); }
        }
        /// <summary>Used to address any item contained in this site. This collection can&apos;t be enumerated.</summary>
        public List<BaseItem> Items {
            get { return BackingStore?.Get<List<BaseItem>>("items"); }
            set { BackingStore?.Set("items", value); }
        }
        /// <summary>The collection of lists under this site.</summary>
        public List<List> Lists {
            get { return BackingStore?.Get<List<List>>("lists"); }
            set { BackingStore?.Set("lists", value); }
        }
        /// <summary>Calls the OneNote service for notebook related operations.</summary>
        public Microsoft.Graph.Models.Onenote Onenote {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Onenote>("onenote"); }
            set { BackingStore?.Set("onenote", value); }
        }
        /// <summary>The collection of long-running operations on the site.</summary>
        public List<RichLongRunningOperation> Operations {
            get { return BackingStore?.Get<List<RichLongRunningOperation>>("operations"); }
            set { BackingStore?.Set("operations", value); }
        }
        /// <summary>The permissions associated with the site. Nullable.</summary>
        public List<Permission> Permissions {
            get { return BackingStore?.Get<List<Permission>>("permissions"); }
            set { BackingStore?.Set("permissions", value); }
        }
        /// <summary>If present, indicates that this is the root site in the site collection. Read-only.</summary>
        public Microsoft.Graph.Models.Root Root {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Root>("root"); }
            set { BackingStore?.Set("root", value); }
        }
        /// <summary>Returns identifiers useful for SharePoint REST compatibility. Read-only.</summary>
        public Microsoft.Graph.Models.SharepointIds SharepointIds {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SharepointIds>("sharepointIds"); }
            set { BackingStore?.Set("sharepointIds", value); }
        }
        /// <summary>Provides details about the site&apos;s site collection. Available only on the root site. Read-only.</summary>
        public Microsoft.Graph.Models.SiteCollection SiteCollection {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SiteCollection>("siteCollection"); }
            set { BackingStore?.Set("siteCollection", value); }
        }
        /// <summary>The collection of the sub-sites under this site.</summary>
        public List<Site> Sites {
            get { return BackingStore?.Get<List<Site>>("sites"); }
            set { BackingStore?.Set("sites", value); }
        }
        /// <summary>The default termStore under this site.</summary>
        public Store TermStore {
            get { return BackingStore?.Get<Store>("termStore"); }
            set { BackingStore?.Set("termStore", value); }
        }
        /// <summary>The collection of termStores under this site.</summary>
        public List<Store> TermStores {
            get { return BackingStore?.Get<List<Store>>("termStores"); }
            set { BackingStore?.Set("termStores", value); }
        }
        /// <summary>
        /// Instantiates a new Site and sets the default values.
        /// </summary>
        public Site() : base() {
            OdataType = "#microsoft.graph.site";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Site CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Site();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"analytics", n => { Analytics = n.GetObjectValue<ItemAnalytics>(ItemAnalytics.CreateFromDiscriminatorValue); } },
                {"columns", n => { Columns = n.GetCollectionOfObjectValues<ColumnDefinition>(ColumnDefinition.CreateFromDiscriminatorValue)?.ToList(); } },
                {"contentTypes", n => { ContentTypes = n.GetCollectionOfObjectValues<ContentType>(ContentType.CreateFromDiscriminatorValue)?.ToList(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"drive", n => { Drive = n.GetObjectValue<Microsoft.Graph.Models.Drive>(Microsoft.Graph.Models.Drive.CreateFromDiscriminatorValue); } },
                {"drives", n => { Drives = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.Drive>(Microsoft.Graph.Models.Drive.CreateFromDiscriminatorValue)?.ToList(); } },
                {"error", n => { Error = n.GetObjectValue<PublicError>(PublicError.CreateFromDiscriminatorValue); } },
                {"externalColumns", n => { ExternalColumns = n.GetCollectionOfObjectValues<ColumnDefinition>(ColumnDefinition.CreateFromDiscriminatorValue)?.ToList(); } },
                {"items", n => { Items = n.GetCollectionOfObjectValues<BaseItem>(BaseItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"lists", n => { Lists = n.GetCollectionOfObjectValues<List>(List.CreateFromDiscriminatorValue)?.ToList(); } },
                {"onenote", n => { Onenote = n.GetObjectValue<Microsoft.Graph.Models.Onenote>(Microsoft.Graph.Models.Onenote.CreateFromDiscriminatorValue); } },
                {"operations", n => { Operations = n.GetCollectionOfObjectValues<RichLongRunningOperation>(RichLongRunningOperation.CreateFromDiscriminatorValue)?.ToList(); } },
                {"permissions", n => { Permissions = n.GetCollectionOfObjectValues<Permission>(Permission.CreateFromDiscriminatorValue)?.ToList(); } },
                {"root", n => { Root = n.GetObjectValue<Microsoft.Graph.Models.Root>(Microsoft.Graph.Models.Root.CreateFromDiscriminatorValue); } },
                {"sharepointIds", n => { SharepointIds = n.GetObjectValue<Microsoft.Graph.Models.SharepointIds>(Microsoft.Graph.Models.SharepointIds.CreateFromDiscriminatorValue); } },
                {"siteCollection", n => { SiteCollection = n.GetObjectValue<Microsoft.Graph.Models.SiteCollection>(Microsoft.Graph.Models.SiteCollection.CreateFromDiscriminatorValue); } },
                {"sites", n => { Sites = n.GetCollectionOfObjectValues<Site>(Site.CreateFromDiscriminatorValue)?.ToList(); } },
                {"termStore", n => { TermStore = n.GetObjectValue<Store>(Store.CreateFromDiscriminatorValue); } },
                {"termStores", n => { TermStores = n.GetCollectionOfObjectValues<Store>(Store.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ItemAnalytics>("analytics", Analytics);
            writer.WriteCollectionOfObjectValues<ColumnDefinition>("columns", Columns);
            writer.WriteCollectionOfObjectValues<ContentType>("contentTypes", ContentTypes);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<Microsoft.Graph.Models.Drive>("drive", Drive);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.Drive>("drives", Drives);
            writer.WriteObjectValue<PublicError>("error", Error);
            writer.WriteCollectionOfObjectValues<ColumnDefinition>("externalColumns", ExternalColumns);
            writer.WriteCollectionOfObjectValues<BaseItem>("items", Items);
            writer.WriteCollectionOfObjectValues<List>("lists", Lists);
            writer.WriteObjectValue<Microsoft.Graph.Models.Onenote>("onenote", Onenote);
            writer.WriteCollectionOfObjectValues<RichLongRunningOperation>("operations", Operations);
            writer.WriteCollectionOfObjectValues<Permission>("permissions", Permissions);
            writer.WriteObjectValue<Microsoft.Graph.Models.Root>("root", Root);
            writer.WriteObjectValue<Microsoft.Graph.Models.SharepointIds>("sharepointIds", SharepointIds);
            writer.WriteObjectValue<Microsoft.Graph.Models.SiteCollection>("siteCollection", SiteCollection);
            writer.WriteCollectionOfObjectValues<Site>("sites", Sites);
            writer.WriteObjectValue<Store>("termStore", TermStore);
            writer.WriteCollectionOfObjectValues<Store>("termStores", TermStores);
        }
    }
}
