using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Drive : BaseItem, IParsable {
        /// <summary>Collection of [bundles][bundle] (albums and multi-select-shared sets of items). Only in personal OneDrive.</summary>
        public List<DriveItem> Bundles {
            get { return BackingStore?.Get<List<DriveItem>>("bundles"); }
            set { BackingStore?.Set("bundles", value); }
        }
        /// <summary>Describes the type of drive represented by this resource. OneDrive personal drives will return personal. OneDrive for Business will return business. SharePoint document libraries will return documentLibrary. Read-only.</summary>
        public string DriveType {
            get { return BackingStore?.Get<string>("driveType"); }
            set { BackingStore?.Set("driveType", value); }
        }
        /// <summary>The list of items the user is following. Only in OneDrive for Business.</summary>
        public List<DriveItem> Following {
            get { return BackingStore?.Get<List<DriveItem>>("following"); }
            set { BackingStore?.Set("following", value); }
        }
        /// <summary>All items contained in the drive. Read-only. Nullable.</summary>
        public List<DriveItem> Items {
            get { return BackingStore?.Get<List<DriveItem>>("items"); }
            set { BackingStore?.Set("items", value); }
        }
        /// <summary>For drives in SharePoint, the underlying document library list. Read-only. Nullable.</summary>
        public Microsoft.Graph.Models.List List {
            get { return BackingStore?.Get<Microsoft.Graph.Models.List>("list"); }
            set { BackingStore?.Set("list", value); }
        }
        /// <summary>Optional. The user account that owns the drive. Read-only.</summary>
        public IdentitySet Owner {
            get { return BackingStore?.Get<IdentitySet>("owner"); }
            set { BackingStore?.Set("owner", value); }
        }
        /// <summary>Optional. Information about the drive&apos;s storage space quota. Read-only.</summary>
        public Microsoft.Graph.Models.Quota Quota {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Quota>("quota"); }
            set { BackingStore?.Set("quota", value); }
        }
        /// <summary>The root folder of the drive. Read-only.</summary>
        public DriveItem Root {
            get { return BackingStore?.Get<DriveItem>("root"); }
            set { BackingStore?.Set("root", value); }
        }
        /// <summary>The sharePointIds property</summary>
        public Microsoft.Graph.Models.SharepointIds SharePointIds {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SharepointIds>("sharePointIds"); }
            set { BackingStore?.Set("sharePointIds", value); }
        }
        /// <summary>Collection of common folders available in OneDrive. Read-only. Nullable.</summary>
        public List<DriveItem> Special {
            get { return BackingStore?.Get<List<DriveItem>>("special"); }
            set { BackingStore?.Set("special", value); }
        }
        /// <summary>If present, indicates that this is a system-managed drive. Read-only.</summary>
        public SystemFacet System {
            get { return BackingStore?.Get<SystemFacet>("system"); }
            set { BackingStore?.Set("system", value); }
        }
        /// <summary>
        /// Instantiates a new Drive and sets the default values.
        /// </summary>
        public Drive() : base() {
            OdataType = "#microsoft.graph.drive";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Drive CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Drive();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"bundles", n => { Bundles = n.GetCollectionOfObjectValues<DriveItem>(DriveItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"driveType", n => { DriveType = n.GetStringValue(); } },
                {"following", n => { Following = n.GetCollectionOfObjectValues<DriveItem>(DriveItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"items", n => { Items = n.GetCollectionOfObjectValues<DriveItem>(DriveItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"list", n => { List = n.GetObjectValue<Microsoft.Graph.Models.List>(Microsoft.Graph.Models.List.CreateFromDiscriminatorValue); } },
                {"owner", n => { Owner = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"quota", n => { Quota = n.GetObjectValue<Microsoft.Graph.Models.Quota>(Microsoft.Graph.Models.Quota.CreateFromDiscriminatorValue); } },
                {"root", n => { Root = n.GetObjectValue<DriveItem>(DriveItem.CreateFromDiscriminatorValue); } },
                {"sharePointIds", n => { SharePointIds = n.GetObjectValue<Microsoft.Graph.Models.SharepointIds>(Microsoft.Graph.Models.SharepointIds.CreateFromDiscriminatorValue); } },
                {"special", n => { Special = n.GetCollectionOfObjectValues<DriveItem>(DriveItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"system", n => { System = n.GetObjectValue<SystemFacet>(SystemFacet.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<DriveItem>("bundles", Bundles);
            writer.WriteStringValue("driveType", DriveType);
            writer.WriteCollectionOfObjectValues<DriveItem>("following", Following);
            writer.WriteCollectionOfObjectValues<DriveItem>("items", Items);
            writer.WriteObjectValue<Microsoft.Graph.Models.List>("list", List);
            writer.WriteObjectValue<IdentitySet>("owner", Owner);
            writer.WriteObjectValue<Microsoft.Graph.Models.Quota>("quota", Quota);
            writer.WriteObjectValue<DriveItem>("root", Root);
            writer.WriteObjectValue<Microsoft.Graph.Models.SharepointIds>("sharePointIds", SharePointIds);
            writer.WriteCollectionOfObjectValues<DriveItem>("special", Special);
            writer.WriteObjectValue<SystemFacet>("system", System);
        }
    }
}
