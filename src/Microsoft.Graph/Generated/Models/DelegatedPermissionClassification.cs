using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to call the instantiate method.</summary>
    public class DelegatedPermissionClassification : Entity, IParsable {
        /// <summary>The classification value being given. Possible value: low. Does not support $filter.</summary>
        public PermissionClassificationType? Classification {
            get { return BackingStore?.Get<PermissionClassificationType?>("classification"); }
            set { BackingStore?.Set("classification", value); }
        }
        /// <summary>The unique identifier (id) for the delegated permission listed in the oauth2PermissionScopes collection of the servicePrincipal. Required on create. Does not support $filter.</summary>
        public string PermissionId {
            get { return BackingStore?.Get<string>("permissionId"); }
            set { BackingStore?.Set("permissionId", value); }
        }
        /// <summary>The claim value (value) for the delegated permission listed in the oauth2PermissionScopes collection of the servicePrincipal. Does not support $filter.</summary>
        public string PermissionName {
            get { return BackingStore?.Get<string>("permissionName"); }
            set { BackingStore?.Set("permissionName", value); }
        }
        /// <summary>
        /// Instantiates a new delegatedPermissionClassification and sets the default values.
        /// </summary>
        public DelegatedPermissionClassification() : base() {
            OdataType = "#microsoft.graph.delegatedPermissionClassification";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DelegatedPermissionClassification CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DelegatedPermissionClassification();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"classification", n => { Classification = n.GetEnumValue<PermissionClassificationType>(); } },
                {"permissionId", n => { PermissionId = n.GetStringValue(); } },
                {"permissionName", n => { PermissionName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<PermissionClassificationType>("classification", Classification);
            writer.WriteStringValue("permissionId", PermissionId);
            writer.WriteStringValue("permissionName", PermissionName);
        }
    }
}
