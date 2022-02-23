using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class DriveItem : BaseItem, IParsable {
        /// <summary>Analytics about the view activities that took place on this item.</summary>
        public ItemAnalytics Analytics { get; set; }
        /// <summary>Audio metadata, if the item is an audio file. Read-only. Only on OneDrive Personal.</summary>
        public Audio Audio { get; set; }
        public Bundle Bundle { get; set; }
        /// <summary>Collection containing Item objects for the immediate children of Item. Only items representing folders have children. Read-only. Nullable.</summary>
        public List<DriveItem> Children { get; set; }
        /// <summary>The content stream, if the item represents a file.</summary>
        public byte[] Content { get; set; }
        /// <summary>An eTag for the content of the item. This eTag is not changed if only the metadata is changed. Note This property is not returned if the item is a folder. Read-only.</summary>
        public string CTag { get; set; }
        /// <summary>Information about the deleted state of the item. Read-only.</summary>
        public Deleted Deleted { get; set; }
        /// <summary>File metadata, if the item is a file. Read-only.</summary>
        public File File { get; set; }
        /// <summary>File system information on client. Read-write.</summary>
        public FileSystemInfo FileSystemInfo { get; set; }
        /// <summary>Folder metadata, if the item is a folder. Read-only.</summary>
        public Folder Folder { get; set; }
        /// <summary>Image metadata, if the item is an image. Read-only.</summary>
        public Image Image { get; set; }
        /// <summary>For drives in SharePoint, the associated document library list item. Read-only. Nullable.</summary>
        public ListItem ListItem { get; set; }
        /// <summary>Location metadata, if the item has location data. Read-only.</summary>
        public GeoCoordinates Location { get; set; }
        /// <summary>Malware metadata, if the item was detected to contain malware. Read-only.</summary>
        public Malware Malware { get; set; }
        /// <summary>If present, indicates that this item is a package instead of a folder or file. Packages are treated like files in some contexts and folders in others. Read-only.</summary>
        public Package Package { get; set; }
        /// <summary>If present, indicates that one or more operations that might affect the state of the driveItem are pending completion. Read-only.</summary>
        public PendingOperations PendingOperations { get; set; }
        /// <summary>The set of permissions for the item. Read-only. Nullable.</summary>
        public List<Permission> Permissions { get; set; }
        /// <summary>Photo metadata, if the item is a photo. Read-only.</summary>
        public Photo Photo { get; set; }
        /// <summary>Provides information about the published or checked-out state of an item, in locations that support such actions. This property is not returned by default. Read-only.</summary>
        public PublicationFacet Publication { get; set; }
        /// <summary>Remote item data, if the item is shared from a drive other than the one being accessed. Read-only.</summary>
        public RemoteItem RemoteItem { get; set; }
        /// <summary>If this property is non-null, it indicates that the driveItem is the top-most driveItem in the drive.</summary>
        public Root Root { get; set; }
        /// <summary>Search metadata, if the item is from a search result. Read-only.</summary>
        public SearchResult SearchResult { get; set; }
        /// <summary>Indicates that the item has been shared with others and provides information about the shared state of the item. Read-only.</summary>
        public Shared Shared { get; set; }
        /// <summary>Returns identifiers useful for SharePoint REST compatibility. Read-only.</summary>
        public SharepointIds SharepointIds { get; set; }
        /// <summary>Size of the item in bytes. Read-only.</summary>
        public long? Size { get; set; }
        /// <summary>If the current item is also available as a special folder, this facet is returned. Read-only.</summary>
        public SpecialFolder SpecialFolder { get; set; }
        /// <summary>The set of subscriptions on the item. Only supported on the root of a drive.</summary>
        public List<Subscription> Subscriptions { get; set; }
        /// <summary>Collection containing [ThumbnailSet][] objects associated with the item. For more info, see [getting thumbnails][]. Read-only. Nullable.</summary>
        public List<ThumbnailSet> Thumbnails { get; set; }
        /// <summary>The list of previous versions of the item. For more info, see [getting previous versions][]. Read-only. Nullable.</summary>
        public List<DriveItemVersion> Versions { get; set; }
        /// <summary>Video metadata, if the item is a video. Read-only.</summary>
        public Video Video { get; set; }
        /// <summary>WebDAV compatible URL for the item.</summary>
        public string WebDavUrl { get; set; }
        /// <summary>For files that are Excel spreadsheets, accesses the workbook API to work with the spreadsheet's contents. Nullable.</summary>
        public Workbook Workbook { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"analytics", (o,n) => { (o as DriveItem).Analytics = n.GetObjectValue<ItemAnalytics>(); } },
                {"audio", (o,n) => { (o as DriveItem).Audio = n.GetObjectValue<Audio>(); } },
                {"bundle", (o,n) => { (o as DriveItem).Bundle = n.GetObjectValue<Bundle>(); } },
                {"children", (o,n) => { (o as DriveItem).Children = n.GetCollectionOfObjectValues<DriveItem>().ToList(); } },
                {"content", (o,n) => { (o as DriveItem).Content = n.GetByteArrayValue(); } },
                {"cTag", (o,n) => { (o as DriveItem).CTag = n.GetStringValue(); } },
                {"deleted", (o,n) => { (o as DriveItem).Deleted = n.GetObjectValue<Deleted>(); } },
                {"file", (o,n) => { (o as DriveItem).File = n.GetObjectValue<File>(); } },
                {"fileSystemInfo", (o,n) => { (o as DriveItem).FileSystemInfo = n.GetObjectValue<FileSystemInfo>(); } },
                {"folder", (o,n) => { (o as DriveItem).Folder = n.GetObjectValue<Folder>(); } },
                {"image", (o,n) => { (o as DriveItem).Image = n.GetObjectValue<Image>(); } },
                {"listItem", (o,n) => { (o as DriveItem).ListItem = n.GetObjectValue<ListItem>(); } },
                {"location", (o,n) => { (o as DriveItem).Location = n.GetObjectValue<GeoCoordinates>(); } },
                {"malware", (o,n) => { (o as DriveItem).Malware = n.GetObjectValue<Malware>(); } },
                {"package", (o,n) => { (o as DriveItem).Package = n.GetObjectValue<Package>(); } },
                {"pendingOperations", (o,n) => { (o as DriveItem).PendingOperations = n.GetObjectValue<PendingOperations>(); } },
                {"permissions", (o,n) => { (o as DriveItem).Permissions = n.GetCollectionOfObjectValues<Permission>().ToList(); } },
                {"photo", (o,n) => { (o as DriveItem).Photo = n.GetObjectValue<Photo>(); } },
                {"publication", (o,n) => { (o as DriveItem).Publication = n.GetObjectValue<PublicationFacet>(); } },
                {"remoteItem", (o,n) => { (o as DriveItem).RemoteItem = n.GetObjectValue<RemoteItem>(); } },
                {"root", (o,n) => { (o as DriveItem).Root = n.GetObjectValue<Root>(); } },
                {"searchResult", (o,n) => { (o as DriveItem).SearchResult = n.GetObjectValue<SearchResult>(); } },
                {"shared", (o,n) => { (o as DriveItem).Shared = n.GetObjectValue<Shared>(); } },
                {"sharepointIds", (o,n) => { (o as DriveItem).SharepointIds = n.GetObjectValue<SharepointIds>(); } },
                {"size", (o,n) => { (o as DriveItem).Size = n.GetLongValue(); } },
                {"specialFolder", (o,n) => { (o as DriveItem).SpecialFolder = n.GetObjectValue<SpecialFolder>(); } },
                {"subscriptions", (o,n) => { (o as DriveItem).Subscriptions = n.GetCollectionOfObjectValues<Subscription>().ToList(); } },
                {"thumbnails", (o,n) => { (o as DriveItem).Thumbnails = n.GetCollectionOfObjectValues<ThumbnailSet>().ToList(); } },
                {"versions", (o,n) => { (o as DriveItem).Versions = n.GetCollectionOfObjectValues<DriveItemVersion>().ToList(); } },
                {"video", (o,n) => { (o as DriveItem).Video = n.GetObjectValue<Video>(); } },
                {"webDavUrl", (o,n) => { (o as DriveItem).WebDavUrl = n.GetStringValue(); } },
                {"workbook", (o,n) => { (o as DriveItem).Workbook = n.GetObjectValue<Workbook>(); } },
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
            writer.WriteObjectValue<Audio>("audio", Audio);
            writer.WriteObjectValue<Bundle>("bundle", Bundle);
            writer.WriteCollectionOfObjectValues<DriveItem>("children", Children);
            writer.WriteByteArrayValue("content", Content);
            writer.WriteStringValue("cTag", CTag);
            writer.WriteObjectValue<Deleted>("deleted", Deleted);
            writer.WriteObjectValue<File>("file", File);
            writer.WriteObjectValue<FileSystemInfo>("fileSystemInfo", FileSystemInfo);
            writer.WriteObjectValue<Folder>("folder", Folder);
            writer.WriteObjectValue<Image>("image", Image);
            writer.WriteObjectValue<ListItem>("listItem", ListItem);
            writer.WriteObjectValue<GeoCoordinates>("location", Location);
            writer.WriteObjectValue<Malware>("malware", Malware);
            writer.WriteObjectValue<Package>("package", Package);
            writer.WriteObjectValue<PendingOperations>("pendingOperations", PendingOperations);
            writer.WriteCollectionOfObjectValues<Permission>("permissions", Permissions);
            writer.WriteObjectValue<Photo>("photo", Photo);
            writer.WriteObjectValue<PublicationFacet>("publication", Publication);
            writer.WriteObjectValue<RemoteItem>("remoteItem", RemoteItem);
            writer.WriteObjectValue<Root>("root", Root);
            writer.WriteObjectValue<SearchResult>("searchResult", SearchResult);
            writer.WriteObjectValue<Shared>("shared", Shared);
            writer.WriteObjectValue<SharepointIds>("sharepointIds", SharepointIds);
            writer.WriteLongValue("size", Size);
            writer.WriteObjectValue<SpecialFolder>("specialFolder", SpecialFolder);
            writer.WriteCollectionOfObjectValues<Subscription>("subscriptions", Subscriptions);
            writer.WriteCollectionOfObjectValues<ThumbnailSet>("thumbnails", Thumbnails);
            writer.WriteCollectionOfObjectValues<DriveItemVersion>("versions", Versions);
            writer.WriteObjectValue<Video>("video", Video);
            writer.WriteStringValue("webDavUrl", WebDavUrl);
            writer.WriteObjectValue<Workbook>("workbook", Workbook);
        }
    }
}
