using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class ListItem : BaseItem, IParsable {
        /// <summary>Analytics about the view activities that took place on this item.</summary>
        public ItemAnalytics Analytics { get; set; }
        /// <summary>The content type of this list item</summary>
        public ContentTypeInfo ContentType { get; set; }
        /// <summary>For document libraries, the driveItem relationship exposes the listItem as a [driveItem][]</summary>
        public DriveItem DriveItem { get; set; }
        /// <summary>The values of the columns set on this list item.</summary>
        public FieldValueSet Fields { get; set; }
        /// <summary>Returns identifiers useful for SharePoint REST compatibility. Read-only.</summary>
        public SharepointIds SharepointIds { get; set; }
        /// <summary>The list of previous versions of the list item.</summary>
        public List<ListItemVersion> Versions { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"analytics", (o,n) => { (o as ListItem).Analytics = n.GetObjectValue<ItemAnalytics>(); } },
                {"contentType", (o,n) => { (o as ListItem).ContentType = n.GetObjectValue<ContentTypeInfo>(); } },
                {"driveItem", (o,n) => { (o as ListItem).DriveItem = n.GetObjectValue<DriveItem>(); } },
                {"fields", (o,n) => { (o as ListItem).Fields = n.GetObjectValue<FieldValueSet>(); } },
                {"sharepointIds", (o,n) => { (o as ListItem).SharepointIds = n.GetObjectValue<SharepointIds>(); } },
                {"versions", (o,n) => { (o as ListItem).Versions = n.GetCollectionOfObjectValues<ListItemVersion>().ToList(); } },
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
            writer.WriteObjectValue<ContentTypeInfo>("contentType", ContentType);
            writer.WriteObjectValue<DriveItem>("driveItem", DriveItem);
            writer.WriteObjectValue<FieldValueSet>("fields", Fields);
            writer.WriteObjectValue<SharepointIds>("sharepointIds", SharepointIds);
            writer.WriteCollectionOfObjectValues<ListItemVersion>("versions", Versions);
        }
    }
}
