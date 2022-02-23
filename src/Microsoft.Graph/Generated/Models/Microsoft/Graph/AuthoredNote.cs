using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class AuthoredNote : Entity, IParsable {
        /// <summary>Identity information about the note's author.</summary>
        public Identity Author { get; set; }
        /// <summary>The content of the note.</summary>
        public ItemBody Content { get; set; }
        /// <summary>The date and time when the entity was created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"author", (o,n) => { (o as AuthoredNote).Author = n.GetObjectValue<Identity>(); } },
                {"content", (o,n) => { (o as AuthoredNote).Content = n.GetObjectValue<ItemBody>(); } },
                {"createdDateTime", (o,n) => { (o as AuthoredNote).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Identity>("author", Author);
            writer.WriteObjectValue<ItemBody>("content", Content);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
        }
    }
}
