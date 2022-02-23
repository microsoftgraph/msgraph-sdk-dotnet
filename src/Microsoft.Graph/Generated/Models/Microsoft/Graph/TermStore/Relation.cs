using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph.TermStore {
    public class Relation : Entity, IParsable {
        /// <summary>The from [term] of the relation. The term from which the relationship is defined. A null value would indicate the relation is directly with the [set].</summary>
        public Term FromTerm { get; set; }
        /// <summary>The type of relation. Possible values are: pin, reuse.</summary>
        public RelationType? Relationship { get; set; }
        /// <summary>The [set] in which the relation is relevant.</summary>
        public Set Set { get; set; }
        /// <summary>The to [term] of the relation. The term to which the relationship is defined.</summary>
        public Term ToTerm { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"fromTerm", (o,n) => { (o as Relation).FromTerm = n.GetObjectValue<Term>(); } },
                {"relationship", (o,n) => { (o as Relation).Relationship = n.GetEnumValue<RelationType>(); } },
                {"set", (o,n) => { (o as Relation).Set = n.GetObjectValue<Set>(); } },
                {"toTerm", (o,n) => { (o as Relation).ToTerm = n.GetObjectValue<Term>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Term>("fromTerm", FromTerm);
            writer.WriteEnumValue<RelationType>("relationship", Relationship);
            writer.WriteObjectValue<Set>("set", Set);
            writer.WriteObjectValue<Term>("toTerm", ToTerm);
        }
    }
}
