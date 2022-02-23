using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class BaseItem : Entity, IParsable {
        /// <summary>Identity of the user, device, or application which created the item. Read-only.</summary>
        public IdentitySet CreatedBy { get; set; }
        /// <summary>Identity of the user who created the item. Read-only.</summary>
        public User CreatedByUser { get; set; }
        /// <summary>Date and time of item creation. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>Provides a user-visible description of the item. Optional.</summary>
        public string Description { get; set; }
        /// <summary>ETag for the item. Read-only.</summary>
        public string ETag { get; set; }
        /// <summary>Identity of the user, device, and application which last modified the item. Read-only.</summary>
        public IdentitySet LastModifiedBy { get; set; }
        /// <summary>Identity of the user who last modified the item. Read-only.</summary>
        public User LastModifiedByUser { get; set; }
        /// <summary>Date and time the item was last modified. Read-only.</summary>
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        /// <summary>The name of the item. Read-write.</summary>
        public string Name { get; set; }
        /// <summary>Parent information, if the item has a parent. Read-write.</summary>
        public ItemReference ParentReference { get; set; }
        /// <summary>URL that displays the resource in the browser. Read-only.</summary>
        public string WebUrl { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"createdBy", (o,n) => { (o as BaseItem).CreatedBy = n.GetObjectValue<IdentitySet>(); } },
                {"createdByUser", (o,n) => { (o as BaseItem).CreatedByUser = n.GetObjectValue<User>(); } },
                {"createdDateTime", (o,n) => { (o as BaseItem).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", (o,n) => { (o as BaseItem).Description = n.GetStringValue(); } },
                {"eTag", (o,n) => { (o as BaseItem).ETag = n.GetStringValue(); } },
                {"lastModifiedBy", (o,n) => { (o as BaseItem).LastModifiedBy = n.GetObjectValue<IdentitySet>(); } },
                {"lastModifiedByUser", (o,n) => { (o as BaseItem).LastModifiedByUser = n.GetObjectValue<User>(); } },
                {"lastModifiedDateTime", (o,n) => { (o as BaseItem).LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"name", (o,n) => { (o as BaseItem).Name = n.GetStringValue(); } },
                {"parentReference", (o,n) => { (o as BaseItem).ParentReference = n.GetObjectValue<ItemReference>(); } },
                {"webUrl", (o,n) => { (o as BaseItem).WebUrl = n.GetStringValue(); } },
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
