using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Pkcs12CertificateInformation : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Represents whether the certificate is the active certificate to be used for calling the API connector. The active certificate is the most recently uploaded certificate which is not yet expired but whose notBefore time is in the past.</summary>
        public bool? IsActive {
            get { return BackingStore?.Get<bool?>("isActive"); }
            set { BackingStore?.Set("isActive", value); }
        }
        /// <summary>The certificate&apos;s expiry. This value is a NumericDate as defined in RFC 7519 (A JSON numeric value representing the number of seconds from 1970-01-01T00:00:00Z UTC until the specified UTC date/time, ignoring leap seconds.)</summary>
        public long? NotAfter {
            get { return BackingStore?.Get<long?>("notAfter"); }
            set { BackingStore?.Set("notAfter", value); }
        }
        /// <summary>The certificate&apos;s issue time (not before). This value is a NumericDate as defined in RFC 7519 (A JSON numeric value representing the number of seconds from 1970-01-01T00:00:00Z UTC until the specified UTC date/time, ignoring leap seconds.)</summary>
        public long? NotBefore {
            get { return BackingStore?.Get<long?>("notBefore"); }
            set { BackingStore?.Set("notBefore", value); }
        }
        /// <summary>The certificate thumbprint.</summary>
        public string Thumbprint {
            get { return BackingStore?.Get<string>("thumbprint"); }
            set { BackingStore?.Set("thumbprint", value); }
        }
        /// <summary>
        /// Instantiates a new pkcs12CertificateInformation and sets the default values.
        /// </summary>
        public Pkcs12CertificateInformation() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Pkcs12CertificateInformation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Pkcs12CertificateInformation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"isActive", n => { IsActive = n.GetBoolValue(); } },
                {"notAfter", n => { NotAfter = n.GetLongValue(); } },
                {"notBefore", n => { NotBefore = n.GetLongValue(); } },
                {"thumbprint", n => { Thumbprint = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("isActive", IsActive);
            writer.WriteLongValue("notAfter", NotAfter);
            writer.WriteLongValue("notBefore", NotBefore);
            writer.WriteStringValue("thumbprint", Thumbprint);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
