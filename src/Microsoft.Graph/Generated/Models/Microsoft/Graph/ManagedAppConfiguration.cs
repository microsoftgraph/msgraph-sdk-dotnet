using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class ManagedAppConfiguration : ManagedAppPolicy, IParsable {
        /// <summary>A set of string key and string value pairs to be sent to apps for users to whom the configuration is scoped, unalterned by this service</summary>
        public List<KeyValuePair> CustomSettings { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"customSettings", (o,n) => { (o as ManagedAppConfiguration).CustomSettings = n.GetCollectionOfObjectValues<KeyValuePair>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<KeyValuePair>("customSettings", CustomSettings);
        }
    }
}
