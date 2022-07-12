using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ListItem : BaseItem, IParsable {
        /// <summary>Analytics about the view activities that took place on this item.</summary>
        public ItemAnalytics Analytics {
            get { return BackingStore?.Get<ItemAnalytics>("analytics"); }
            set { BackingStore?.Set("analytics", value); }
        }
        /// <summary>The content type of this list item</summary>
        public ContentTypeInfo ContentType {
            get { return BackingStore?.Get<ContentTypeInfo>("contentType"); }
            set { BackingStore?.Set("contentType", value); }
        }
        /// <summary>For document libraries, the driveItem relationship exposes the listItem as a [driveItem][]</summary>
        public Microsoft.Graph.Models.DriveItem DriveItem {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DriveItem>("driveItem"); }
            set { BackingStore?.Set("driveItem", value); }
        }
        /// <summary>The values of the columns set on this list item.</summary>
        public FieldValueSet Fields {
            get { return BackingStore?.Get<FieldValueSet>("fields"); }
            set { BackingStore?.Set("fields", value); }
        }
        /// <summary>Returns identifiers useful for SharePoint REST compatibility. Read-only.</summary>
        public Microsoft.Graph.Models.SharepointIds SharepointIds {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SharepointIds>("sharepointIds"); }
            set { BackingStore?.Set("sharepointIds", value); }
        }
        /// <summary>The list of previous versions of the list item.</summary>
        public List<ListItemVersion> Versions {
            get { return BackingStore?.Get<List<ListItemVersion>>("versions"); }
            set { BackingStore?.Set("versions", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ListItem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ListItem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"analytics", n => { Analytics = n.GetObjectValue<ItemAnalytics>(ItemAnalytics.CreateFromDiscriminatorValue); } },
                {"contentType", n => { ContentType = n.GetObjectValue<ContentTypeInfo>(ContentTypeInfo.CreateFromDiscriminatorValue); } },
                {"driveItem", n => { DriveItem = n.GetObjectValue<Microsoft.Graph.Models.DriveItem>(Microsoft.Graph.Models.DriveItem.CreateFromDiscriminatorValue); } },
                {"fields", n => { Fields = n.GetObjectValue<FieldValueSet>(FieldValueSet.CreateFromDiscriminatorValue); } },
                {"sharepointIds", n => { SharepointIds = n.GetObjectValue<Microsoft.Graph.Models.SharepointIds>(Microsoft.Graph.Models.SharepointIds.CreateFromDiscriminatorValue); } },
                {"versions", n => { Versions = n.GetCollectionOfObjectValues<ListItemVersion>(ListItemVersion.CreateFromDiscriminatorValue).ToList(); } },
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
            writer.WriteObjectValue<Microsoft.Graph.Models.DriveItem>("driveItem", DriveItem);
            writer.WriteObjectValue<FieldValueSet>("fields", Fields);
            writer.WriteObjectValue<Microsoft.Graph.Models.SharepointIds>("sharepointIds", SharepointIds);
            writer.WriteCollectionOfObjectValues<ListItemVersion>("versions", Versions);
        }
    }
}
