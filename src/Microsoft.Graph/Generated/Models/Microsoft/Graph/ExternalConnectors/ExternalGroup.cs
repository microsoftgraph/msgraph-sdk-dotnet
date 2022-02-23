using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph.ExternalConnectors {
    public class ExternalGroup : Entity, IParsable {
        /// <summary>The description of the external group. Optional.</summary>
        public string Description { get; set; }
        /// <summary>The friendly name of the external group. Optional.</summary>
        public string DisplayName { get; set; }
        /// <summary>A member added to an externalGroup. You can add Azure Active Directory users, Azure Active Directory groups, or an externalGroup as members.</summary>
        public List<Identity> Members { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"description", (o,n) => { (o as ExternalGroup).Description = n.GetStringValue(); } },
                {"displayName", (o,n) => { (o as ExternalGroup).DisplayName = n.GetStringValue(); } },
                {"members", (o,n) => { (o as ExternalGroup).Members = n.GetCollectionOfObjectValues<Identity>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfObjectValues<Identity>("members", Members);
        }
    }
}
