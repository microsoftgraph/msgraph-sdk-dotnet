using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessPackageCatalog : Entity, IParsable {
        /// <summary>The access packages in this catalog. Read-only. Nullable. Supports $expand.</summary>
        public List<AccessPackage> AccessPackages {
            get { return BackingStore?.Get<List<AccessPackage>>("accessPackages"); }
            set { BackingStore?.Set("accessPackages", value); }
        }
        /// <summary>One of UserManaged or ServiceDefault.</summary>
        public AccessPackageCatalogType? CatalogType {
            get { return BackingStore?.Get<AccessPackageCatalogType?>("catalogType"); }
            set { BackingStore?.Set("catalogType", value); }
        }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The description of the access package catalog.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The display name of the access package catalog. Supports $filter (eq, contains).</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Whether the access packages in this catalog can be requested by users outside of the tenant.</summary>
        public bool? IsExternallyVisible {
            get { return BackingStore?.Get<bool?>("isExternallyVisible"); }
            set { BackingStore?.Set("isExternallyVisible", value); }
        }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? ModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("modifiedDateTime"); }
            set { BackingStore?.Set("modifiedDateTime", value); }
        }
        /// <summary>Has the value published if the access packages are available for management. The possible values are: unpublished, published, unknownFutureValue.</summary>
        public AccessPackageCatalogState? State {
            get { return BackingStore?.Get<AccessPackageCatalogState?>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AccessPackageCatalog CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessPackageCatalog();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"accessPackages", n => { AccessPackages = n.GetCollectionOfObjectValues<AccessPackage>(AccessPackage.CreateFromDiscriminatorValue).ToList(); } },
                {"catalogType", n => { CatalogType = n.GetEnumValue<AccessPackageCatalogType>(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"isExternallyVisible", n => { IsExternallyVisible = n.GetBoolValue(); } },
                {"modifiedDateTime", n => { ModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"state", n => { State = n.GetEnumValue<AccessPackageCatalogState>(); } },
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
