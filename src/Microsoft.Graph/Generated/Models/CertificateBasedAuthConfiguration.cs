using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of certificateBasedAuthConfiguration entities.</summary>
    public class CertificateBasedAuthConfiguration : Entity, IParsable {
        /// <summary>Collection of certificate authorities which creates a trusted certificate chain.</summary>
        public List<CertificateAuthority> CertificateAuthorities {
            get { return BackingStore?.Get<List<CertificateAuthority>>("certificateAuthorities"); }
            set { BackingStore?.Set("certificateAuthorities", value); }
        }
        /// <summary>
        /// Instantiates a new certificateBasedAuthConfiguration and sets the default values.
        /// </summary>
        public CertificateBasedAuthConfiguration() : base() {
            OdataType = "#microsoft.graph.certificateBasedAuthConfiguration";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CertificateBasedAuthConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CertificateBasedAuthConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"certificateAuthorities", n => { CertificateAuthorities = n.GetCollectionOfObjectValues<CertificateAuthority>(CertificateAuthority.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<CertificateAuthority>("certificateAuthorities", CertificateAuthorities);
        }
    }
}
