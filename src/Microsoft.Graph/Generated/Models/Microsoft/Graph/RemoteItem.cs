using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class RemoteItem : IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Identity of the user, device, and application which created the item. Read-only.</summary>
        public IdentitySet CreatedBy { get; set; }
        /// <summary>Date and time of item creation. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>Indicates that the remote item is a file. Read-only.</summary>
        public File File { get; set; }
        /// <summary>Information about the remote item from the local file system. Read-only.</summary>
        public FileSystemInfo FileSystemInfo { get; set; }
        /// <summary>Indicates that the remote item is a folder. Read-only.</summary>
        public Folder Folder { get; set; }
        /// <summary>Unique identifier for the remote item in its drive. Read-only.</summary>
        public string Id { get; set; }
        /// <summary>Image metadata, if the item is an image. Read-only.</summary>
        public Image Image { get; set; }
        /// <summary>Identity of the user, device, and application which last modified the item. Read-only.</summary>
        public IdentitySet LastModifiedBy { get; set; }
        /// <summary>Date and time the item was last modified. Read-only.</summary>
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        /// <summary>Optional. Filename of the remote item. Read-only.</summary>
        public string Name { get; set; }
        /// <summary>If present, indicates that this item is a package instead of a folder or file. Packages are treated like files in some contexts and folders in others. Read-only.</summary>
        public Package Package { get; set; }
        /// <summary>Properties of the parent of the remote item. Read-only.</summary>
        public ItemReference ParentReference { get; set; }
        /// <summary>Indicates that the item has been shared with others and provides information about the shared state of the item. Read-only.</summary>
        public Shared Shared { get; set; }
        /// <summary>Provides interop between items in OneDrive for Business and SharePoint with the full set of item identifiers. Read-only.</summary>
        public SharepointIds SharepointIds { get; set; }
        /// <summary>Size of the remote item. Read-only.</summary>
        public long? Size { get; set; }
        /// <summary>If the current item is also available as a special folder, this facet is returned. Read-only.</summary>
        public SpecialFolder SpecialFolder { get; set; }
        /// <summary>Video metadata, if the item is a video. Read-only.</summary>
        public Video Video { get; set; }
        /// <summary>DAV compatible URL for the item.</summary>
        public string WebDavUrl { get; set; }
        /// <summary>URL that displays the resource in the browser. Read-only.</summary>
        public string WebUrl { get; set; }
        /// <summary>
        /// Instantiates a new remoteItem and sets the default values.
        /// </summary>
        public RemoteItem() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>> {
                {"createdBy", (o,n) => { (o as RemoteItem).CreatedBy = n.GetObjectValue<IdentitySet>(); } },
                {"createdDateTime", (o,n) => { (o as RemoteItem).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"file", (o,n) => { (o as RemoteItem).File = n.GetObjectValue<File>(); } },
                {"fileSystemInfo", (o,n) => { (o as RemoteItem).FileSystemInfo = n.GetObjectValue<FileSystemInfo>(); } },
                {"folder", (o,n) => { (o as RemoteItem).Folder = n.GetObjectValue<Folder>(); } },
                {"id", (o,n) => { (o as RemoteItem).Id = n.GetStringValue(); } },
                {"image", (o,n) => { (o as RemoteItem).Image = n.GetObjectValue<Image>(); } },
                {"lastModifiedBy", (o,n) => { (o as RemoteItem).LastModifiedBy = n.GetObjectValue<IdentitySet>(); } },
                {"lastModifiedDateTime", (o,n) => { (o as RemoteItem).LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"name", (o,n) => { (o as RemoteItem).Name = n.GetStringValue(); } },
                {"package", (o,n) => { (o as RemoteItem).Package = n.GetObjectValue<Package>(); } },
                {"parentReference", (o,n) => { (o as RemoteItem).ParentReference = n.GetObjectValue<ItemReference>(); } },
                {"shared", (o,n) => { (o as RemoteItem).Shared = n.GetObjectValue<Shared>(); } },
                {"sharepointIds", (o,n) => { (o as RemoteItem).SharepointIds = n.GetObjectValue<SharepointIds>(); } },
                {"size", (o,n) => { (o as RemoteItem).Size = n.GetLongValue(); } },
                {"specialFolder", (o,n) => { (o as RemoteItem).SpecialFolder = n.GetObjectValue<SpecialFolder>(); } },
                {"video", (o,n) => { (o as RemoteItem).Video = n.GetObjectValue<Video>(); } },
                {"webDavUrl", (o,n) => { (o as RemoteItem).WebDavUrl = n.GetStringValue(); } },
                {"webUrl", (o,n) => { (o as RemoteItem).WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<IdentitySet>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteObjectValue<File>("file", File);
            writer.WriteObjectValue<FileSystemInfo>("fileSystemInfo", FileSystemInfo);
            writer.WriteObjectValue<Folder>("folder", Folder);
            writer.WriteStringValue("id", Id);
            writer.WriteObjectValue<Image>("image", Image);
            writer.WriteObjectValue<IdentitySet>("lastModifiedBy", LastModifiedBy);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteStringValue("name", Name);
            writer.WriteObjectValue<Package>("package", Package);
            writer.WriteObjectValue<ItemReference>("parentReference", ParentReference);
            writer.WriteObjectValue<Shared>("shared", Shared);
            writer.WriteObjectValue<SharepointIds>("sharepointIds", SharepointIds);
            writer.WriteLongValue("size", Size);
            writer.WriteObjectValue<SpecialFolder>("specialFolder", SpecialFolder);
            writer.WriteObjectValue<Video>("video", Video);
            writer.WriteStringValue("webDavUrl", WebDavUrl);
            writer.WriteStringValue("webUrl", WebUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
