using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CertificateAuthority : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Required. The base64 encoded string representing the public certificate.</summary>
        public byte[] Certificate {
            get { return BackingStore?.Get<byte[]>("certificate"); }
            set { BackingStore?.Set("certificate", value); }
        }
        /// <summary>The URL of the certificate revocation list.</summary>
        public string CertificateRevocationListUrl {
            get { return BackingStore?.Get<string>("certificateRevocationListUrl"); }
            set { BackingStore?.Set("certificateRevocationListUrl", value); }
        }
        /// <summary>The URL contains the list of all revoked certificates since the last time a full certificate revocaton list was created.</summary>
        public string DeltaCertificateRevocationListUrl {
            get { return BackingStore?.Get<string>("deltaCertificateRevocationListUrl"); }
            set { BackingStore?.Set("deltaCertificateRevocationListUrl", value); }
        }
        /// <summary>Required. true if the trusted certificate is a root authority, false if the trusted certificate is an intermediate authority.</summary>
        public bool? IsRootAuthority {
            get { return BackingStore?.Get<bool?>("isRootAuthority"); }
            set { BackingStore?.Set("isRootAuthority", value); }
        }
        /// <summary>The issuer of the certificate, calculated from the certificate value. Read-only.</summary>
        public string Issuer {
            get { return BackingStore?.Get<string>("issuer"); }
            set { BackingStore?.Set("issuer", value); }
        }
        /// <summary>The subject key identifier of the certificate, calculated from the certificate value. Read-only.</summary>
        public string IssuerSki {
            get { return BackingStore?.Get<string>("issuerSki"); }
            set { BackingStore?.Set("issuerSki", value); }
        }
        /// <summary>
        /// Instantiates a new certificateAuthority and sets the default values.
        /// </summary>
        public CertificateAuthority() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static CertificateAuthority CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CertificateAuthority();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"certificate", n => { Certificate = n.GetByteArrayValue(); } },
                {"certificateRevocationListUrl", n => { CertificateRevocationListUrl = n.GetStringValue(); } },
                {"deltaCertificateRevocationListUrl", n => { DeltaCertificateRevocationListUrl = n.GetStringValue(); } },
                {"isRootAuthority", n => { IsRootAuthority = n.GetBoolValue(); } },
                {"issuer", n => { Issuer = n.GetStringValue(); } },
                {"issuerSki", n => { IssuerSki = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteByteArrayValue("certificate", Certificate);
            writer.WriteStringValue("certificateRevocationListUrl", CertificateRevocationListUrl);
            writer.WriteStringValue("deltaCertificateRevocationListUrl", DeltaCertificateRevocationListUrl);
            writer.WriteBoolValue("isRootAuthority", IsRootAuthority);
            writer.WriteStringValue("issuer", Issuer);
            writer.WriteStringValue("issuerSki", IssuerSki);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
