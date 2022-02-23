using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class Admin : IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>A container for service communications resources. Read-only.</summary>
        public ServiceAnnouncement ServiceAnnouncement { get; set; }
        /// <summary>
        /// Instantiates a new Admin and sets the default values.
        /// </summary>
        public Admin() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>> {
                {"serviceAnnouncement", (o,n) => { (o as Admin).ServiceAnnouncement = n.GetObjectValue<ServiceAnnouncement>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ServiceAnnouncement>("serviceAnnouncement", ServiceAnnouncement);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
