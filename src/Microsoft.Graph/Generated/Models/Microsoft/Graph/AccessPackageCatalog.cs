using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class AccessPackageCatalog : Entity, IParsable {
        /// <summary>The access packages in this catalog. Read-only. Nullable.</summary>
        public List<AccessPackage> AccessPackages { get; set; }
        /// <summary>Whether the catalog is created by a user or entitlement management. The possible values are: userManaged, serviceDefault, serviceManaged, unknownFutureValue.</summary>
        public AccessPackageCatalogType? CatalogType { get; set; }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>The description of the access package catalog.</summary>
        public string Description { get; set; }
        /// <summary>The display name of the access package catalog.</summary>
        public string DisplayName { get; set; }
        /// <summary>Whether the access packages in this catalog can be requested by users outside of the tenant.</summary>
        public bool? IsExternallyVisible { get; set; }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? ModifiedDateTime { get; set; }
        /// <summary>Has the value published if the access packages are available for management. The possible values are: unpublished, published, unknownFutureValue.</summary>
        public AccessPackageCatalogState? State { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"accessPackages", (o,n) => { (o as AccessPackageCatalog).AccessPackages = n.GetCollectionOfObjectValues<AccessPackage>().ToList(); } },
                {"catalogType", (o,n) => { (o as AccessPackageCatalog).CatalogType = n.GetEnumValue<AccessPackageCatalogType>(); } },
                {"createdDateTime", (o,n) => { (o as AccessPackageCatalog).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", (o,n) => { (o as AccessPackageCatalog).Description = n.GetStringValue(); } },
                {"displayName", (o,n) => { (o as AccessPackageCatalog).DisplayName = n.GetStringValue(); } },
                {"isExternallyVisible", (o,n) => { (o as AccessPackageCatalog).IsExternallyVisible = n.GetBoolValue(); } },
                {"modifiedDateTime", (o,n) => { (o as AccessPackageCatalog).ModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"state", (o,n) => { (o as AccessPackageCatalog).State = n.GetEnumValue<AccessPackageCatalogState>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<AccessPackage>("accessPackages", AccessPackages);
            writer.WriteEnumValue<AccessPackageCatalogType>("catalogType", CatalogType);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteBoolValue("isExternallyVisible", IsExternallyVisible);
            writer.WriteDateTimeOffsetValue("modifiedDateTime", ModifiedDateTime);
            writer.WriteEnumValue<AccessPackageCatalogState>("state", State);
        }
    }
}
