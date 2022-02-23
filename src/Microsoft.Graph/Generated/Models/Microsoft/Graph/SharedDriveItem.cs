using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class SharedDriveItem : BaseItem, IParsable {
        /// <summary>Used to access the underlying driveItem</summary>
        public DriveItem DriveItem { get; set; }
        /// <summary>All driveItems contained in the sharing root. This collection cannot be enumerated.</summary>
        public List<DriveItem> Items { get; set; }
        /// <summary>Used to access the underlying list</summary>
        public List List { get; set; }
        /// <summary>Used to access the underlying listItem</summary>
        public ListItem ListItem { get; set; }
        /// <summary>Information about the owner of the shared item being referenced.</summary>
        public IdentitySet Owner { get; set; }
        /// <summary>Used to access the permission representing the underlying sharing link</summary>
        public Permission Permission { get; set; }
        /// <summary>Used to access the underlying driveItem. Deprecated -- use driveItem instead.</summary>
        public DriveItem Root { get; set; }
        /// <summary>Used to access the underlying site</summary>
        public Site Site { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"driveItem", (o,n) => { (o as SharedDriveItem).DriveItem = n.GetObjectValue<DriveItem>(); } },
                {"items", (o,n) => { (o as SharedDriveItem).Items = n.GetCollectionOfObjectValues<DriveItem>().ToList(); } },
                {"list", (o,n) => { (o as SharedDriveItem).List = n.GetObjectValue<List>(); } },
                {"listItem", (o,n) => { (o as SharedDriveItem).ListItem = n.GetObjectValue<ListItem>(); } },
                {"owner", (o,n) => { (o as SharedDriveItem).Owner = n.GetObjectValue<IdentitySet>(); } },
                {"permission", (o,n) => { (o as SharedDriveItem).Permission = n.GetObjectValue<Permission>(); } },
                {"root", (o,n) => { (o as SharedDriveItem).Root = n.GetObjectValue<DriveItem>(); } },
                {"site", (o,n) => { (o as SharedDriveItem).Site = n.GetObjectValue<Site>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<DriveItem>("driveItem", DriveItem);
            writer.WriteCollectionOfObjectValues<DriveItem>("items", Items);
            writer.WriteObjectValue<List>("list", List);
            writer.WriteObjectValue<ListItem>("listItem", ListItem);
            writer.WriteObjectValue<IdentitySet>("owner", Owner);
            writer.WriteObjectValue<Permission>("permission", Permission);
            writer.WriteObjectValue<DriveItem>("root", Root);
            writer.WriteObjectValue<Site>("site", Site);
        }
    }
}
