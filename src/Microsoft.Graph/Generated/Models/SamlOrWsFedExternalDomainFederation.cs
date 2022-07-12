using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SamlOrWsFedExternalDomainFederation : SamlOrWsFedProvider, IParsable {
        /// <summary>Collection of domain names of the external organizations that the tenant is federating with. Supports $filter (eq).</summary>
        public List<ExternalDomainName> Domains {
            get { return BackingStore?.Get<List<ExternalDomainName>>("domains"); }
            set { BackingStore?.Set("domains", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SamlOrWsFedExternalDomainFederation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SamlOrWsFedExternalDomainFederation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"domains", n => { Domains = n.GetCollectionOfObjectValues<ExternalDomainName>(ExternalDomainName.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ExternalDomainName>("domains", Domains);
        }
    }
}
