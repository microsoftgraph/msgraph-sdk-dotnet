using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class BaseItem : Entity, IParsable {
        /// <summary>Identity of the user, device, or application which created the item. Read-only.</summary>
        public IdentitySet CreatedBy {
            get { return BackingStore?.Get<IdentitySet>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
        /// <summary>Identity of the user who created the item. Read-only.</summary>
        public User CreatedByUser {
            get { return BackingStore?.Get<User>("createdByUser"); }
            set { BackingStore?.Set("createdByUser", value); }
        }
        /// <summary>Date and time of item creation. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Provides a user-visible description of the item. Optional.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>ETag for the item. Read-only.</summary>
        public string ETag {
            get { return BackingStore?.Get<string>("eTag"); }
            set { BackingStore?.Set("eTag", value); }
        }
        /// <summary>Identity of the user, device, and application which last modified the item. Read-only.</summary>
        public IdentitySet LastModifiedBy {
            get { return BackingStore?.Get<IdentitySet>("lastModifiedBy"); }
            set { BackingStore?.Set("lastModifiedBy", value); }
        }
        /// <summary>Identity of the user who last modified the item. Read-only.</summary>
        public User LastModifiedByUser {
            get { return BackingStore?.Get<User>("lastModifiedByUser"); }
            set { BackingStore?.Set("lastModifiedByUser", value); }
        }
        /// <summary>Date and time the item was last modified. Read-only.</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>The name of the item. Read-write.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>Parent information, if the item has a parent. Read-write.</summary>
        public ItemReference ParentReference {
            get { return BackingStore?.Get<ItemReference>("parentReference"); }
            set { BackingStore?.Set("parentReference", value); }
        }
        /// <summary>URL that displays the resource in the browser. Read-only.</summary>
        public string WebUrl {
            get { return BackingStore?.Get<string>("webUrl"); }
            set { BackingStore?.Set("webUrl", value); }
        }
        /// <summary>
        /// Instantiates a new baseItem and sets the default values.
        /// </summary>
        public BaseItem() : base() {
            OdataType = "#microsoft.graph.baseItem";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new BaseItem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.drive" => new Drive(),
                "#microsoft.graph.driveItem" => new DriveItem(),
                "#microsoft.graph.list" => new List(),
                "#microsoft.graph.listItem" => new ListItem(),
                "#microsoft.graph.sharedDriveItem" => new SharedDriveItem(),
                "#microsoft.graph.site" => new Site(),
                _ => new BaseItem(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"createdBy", n => { CreatedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"createdByUser", n => { CreatedByUser = n.GetObjectValue<User>(User.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"eTag", n => { ETag = n.GetStringValue(); } },
                {"lastModifiedBy", n => { LastModifiedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"lastModifiedByUser", n => { LastModifiedByUser = n.GetObjectValue<User>(User.CreateFromDiscriminatorValue); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"parentReference", n => { ParentReference = n.GetObjectValue<ItemReference>(ItemReference.CreateFromDiscriminatorValue); } },
                {"webUrl", n => { WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<IdentitySet>("createdBy", CreatedBy);
            writer.WriteObjectValue<User>("createdByUser", CreatedByUser);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("eTag", ETag);
            writer.WriteObjectValue<IdentitySet>("lastModifiedBy", LastModifiedBy);
            writer.WriteObjectValue<User>("lastModifiedByUser", LastModifiedByUser);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteStringValue("name", Name);
            writer.WriteObjectValue<ItemReference>("parentReference", ParentReference);
            writer.WriteStringValue("webUrl", WebUrl);
        }
    }
}
