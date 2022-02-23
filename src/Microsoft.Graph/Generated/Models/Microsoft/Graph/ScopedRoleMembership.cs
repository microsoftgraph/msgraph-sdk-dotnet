using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class ScopedRoleMembership : Entity, IParsable {
        /// <summary>Unique identifier for the administrative unit that the directory role is scoped to</summary>
        public string AdministrativeUnitId { get; set; }
        /// <summary>Unique identifier for the directory role that the member is in.</summary>
        public string RoleId { get; set; }
        public Identity RoleMemberInfo { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"administrativeUnitId", (o,n) => { (o as ScopedRoleMembership).AdministrativeUnitId = n.GetStringValue(); } },
                {"roleId", (o,n) => { (o as ScopedRoleMembership).RoleId = n.GetStringValue(); } },
                {"roleMemberInfo", (o,n) => { (o as ScopedRoleMembership).RoleMemberInfo = n.GetObjectValue<Identity>(); } },
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
