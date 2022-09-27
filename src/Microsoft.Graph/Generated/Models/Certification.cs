using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Certification : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>URL that shows certification details for the application.</summary>
        public string CertificationDetailsUrl {
            get { return BackingStore?.Get<string>("certificationDetailsUrl"); }
            set { BackingStore?.Set("certificationDetailsUrl", value); }
        }
        /// <summary>The timestamp when the current certification for the application will expire.</summary>
        public DateTimeOffset? CertificationExpirationDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("certificationExpirationDateTime"); }
            set { BackingStore?.Set("certificationExpirationDateTime", value); }
        }
        /// <summary>Indicates whether the application is certified by Microsoft.</summary>
        public bool? IsCertifiedByMicrosoft {
            get { return BackingStore?.Get<bool?>("isCertifiedByMicrosoft"); }
            set { BackingStore?.Set("isCertifiedByMicrosoft", value); }
        }
        /// <summary>Indicates whether the application has been self-attested by the application developer or the publisher.</summary>
        public bool? IsPublisherAttested {
            get { return BackingStore?.Get<bool?>("isPublisherAttested"); }
            set { BackingStore?.Set("isPublisherAttested", value); }
        }
        /// <summary>The timestamp when the certification for the application was most recently added or updated.</summary>
        public DateTimeOffset? LastCertificationDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastCertificationDateTime"); }
            set { BackingStore?.Set("lastCertificationDateTime", value); }
        }
        /// <summary>The OdataType property</summary>
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>
        /// Instantiates a new certification and sets the default values.
        /// </summary>
        public Certification() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
            OdataType = "#microsoft.graph.certification";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Certification CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Certification();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"certificationDetailsUrl", n => { CertificationDetailsUrl = n.GetStringValue(); } },
                {"certificationExpirationDateTime", n => { CertificationExpirationDateTime = n.GetDateTimeOffsetValue(); } },
                {"isCertifiedByMicrosoft", n => { IsCertifiedByMicrosoft = n.GetBoolValue(); } },
                {"isPublisherAttested", n => { IsPublisherAttested = n.GetBoolValue(); } },
                {"lastCertificationDateTime", n => { LastCertificationDateTime = n.GetDateTimeOffsetValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("certificationExpirationDateTime", CertificationExpirationDateTime);
            writer.WriteBoolValue("isPublisherAttested", IsPublisherAttested);
            writer.WriteDateTimeOffsetValue("lastCertificationDateTime", LastCertificationDateTime);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
