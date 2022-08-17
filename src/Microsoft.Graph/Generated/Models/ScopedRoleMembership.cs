using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public class ScopedRoleMembership : Entity, IParsable {
        /// <summary>Unique identifier for the administrative unit that the directory role is scoped to</summary>
        public string AdministrativeUnitId {
            get { return BackingStore?.Get<string>("administrativeUnitId"); }
            set { BackingStore?.Set("administrativeUnitId", value); }
        }
        /// <summary>Unique identifier for the directory role that the member is in.</summary>
        public string RoleId {
            get { return BackingStore?.Get<string>("roleId"); }
            set { BackingStore?.Set("roleId", value); }
        }
        /// <summary>The roleMemberInfo property</summary>
        public Identity RoleMemberInfo {
            get { return BackingStore?.Get<Identity>("roleMemberInfo"); }
            set { BackingStore?.Set("roleMemberInfo", value); }
        }
        /// <summary>
        /// Instantiates a new scopedRoleMembership and sets the default values.
        /// </summary>
        public ScopedRoleMembership() : base() {
            OdataType = "#microsoft.graph.scopedRoleMembership";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ScopedRoleMembership CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ScopedRoleMembership();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"administrativeUnitId", n => { AdministrativeUnitId = n.GetStringValue(); } },
                {"roleId", n => { RoleId = n.GetStringValue(); } },
                {"roleMemberInfo", n => { RoleMemberInfo = n.GetObjectValue<Identity>(Identity.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("administrativeUnitId", AdministrativeUnitId);
            writer.WriteStringValue("roleId", RoleId);
            writer.WriteObjectValue<Identity>("roleMemberInfo", RoleMemberInfo);
        }
    }
}
