using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ProvisioningSystem : Identity, IParsable {
        /// <summary>Details of the system.</summary>
        public DetailsInfo Details {
            get { return BackingStore?.Get<DetailsInfo>("details"); }
            set { BackingStore?.Set("details", value); }
        }
        /// <summary>
        /// Instantiates a new provisioningSystem and sets the default values.
        /// </summary>
        public ProvisioningSystem() : base() {
            OdataType = "#microsoft.graph.provisioningSystem";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new ProvisioningSystem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ProvisioningSystem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"details", n => { Details = n.GetObjectValue<DetailsInfo>(DetailsInfo.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<DetailsInfo>("details", Details);
        }
    }
}
