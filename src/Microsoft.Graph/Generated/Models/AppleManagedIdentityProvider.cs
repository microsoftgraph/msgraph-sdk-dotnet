using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AppleManagedIdentityProvider : IdentityProviderBase, IParsable {
        /// <summary>The certificate data which is a long string of text from the certificate, can be null.</summary>
        public string CertificateData {
            get { return BackingStore?.Get<string>("certificateData"); }
            set { BackingStore?.Set("certificateData", value); }
        }
        /// <summary>The Apple developer identifier. Required.</summary>
        public string DeveloperId {
            get { return BackingStore?.Get<string>("developerId"); }
            set { BackingStore?.Set("developerId", value); }
        }
        /// <summary>The Apple key identifier. Required.</summary>
        public string KeyId {
            get { return BackingStore?.Get<string>("keyId"); }
            set { BackingStore?.Set("keyId", value); }
        }
        /// <summary>The Apple service identifier. Required.</summary>
        public string ServiceId {
            get { return BackingStore?.Get<string>("serviceId"); }
            set { BackingStore?.Set("serviceId", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AppleManagedIdentityProvider CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AppleManagedIdentityProvider();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"certificateData", n => { CertificateData = n.GetStringValue(); } },
                {"developerId", n => { DeveloperId = n.GetStringValue(); } },
                {"keyId", n => { KeyId = n.GetStringValue(); } },
                {"serviceId", n => { ServiceId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("certificateData", CertificateData);
            writer.WriteStringValue("developerId", DeveloperId);
            writer.WriteStringValue("keyId", KeyId);
            writer.WriteStringValue("serviceId", ServiceId);
        }
    }
}
