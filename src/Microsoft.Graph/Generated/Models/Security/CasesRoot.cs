using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.Security {
    public class CasesRoot : Entity, IParsable {
        /// <summary>The ediscoveryCases property</summary>
        public List<EdiscoveryCase> EdiscoveryCases {
            get { return BackingStore?.Get<List<EdiscoveryCase>>("ediscoveryCases"); }
            set { BackingStore?.Set("ediscoveryCases", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CasesRoot CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CasesRoot();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"ediscoveryCases", n => { EdiscoveryCases = n.GetCollectionOfObjectValues<EdiscoveryCase>(EdiscoveryCase.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<EdiscoveryCase>("ediscoveryCases", EdiscoveryCases);
        }
    }
}
