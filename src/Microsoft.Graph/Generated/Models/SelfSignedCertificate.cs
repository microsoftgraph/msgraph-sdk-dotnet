using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SelfSignedCertificate : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Custom key identifier.</summary>
        public byte[] CustomKeyIdentifier {
            get { return BackingStore?.Get<byte[]>("customKeyIdentifier"); }
            set { BackingStore?.Set("customKeyIdentifier", value); }
        }
        /// <summary>The friendly name for the key.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The date and time at which the credential expires. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? EndDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
        /// <summary>The value for the key credential. Should be a base-64 encoded value.</summary>
        public byte[] Key {
            get { return BackingStore?.Get<byte[]>("key"); }
            set { BackingStore?.Set("key", value); }
        }
        /// <summary>The unique identifier (GUID) for the key.</summary>
        public string KeyId {
            get { return BackingStore?.Get<string>("keyId"); }
            set { BackingStore?.Set("keyId", value); }
        }
        /// <summary>The date and time at which the credential becomes valid. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? StartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
        /// <summary>The thumbprint value for the key.</summary>
        public string Thumbprint {
            get { return BackingStore?.Get<string>("thumbprint"); }
            set { BackingStore?.Set("thumbprint", value); }
        }
        /// <summary>The type of key credential. &apos;AsymmetricX509Cert&apos;.</summary>
        public string Type {
            get { return BackingStore?.Get<string>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>A string that describes the purpose for which the key can be used. For example, &apos;Verify&apos;.</summary>
        public string Usage {
            get { return BackingStore?.Get<string>("usage"); }
            set { BackingStore?.Set("usage", value); }
        }
        /// <summary>
        /// Instantiates a new SelfSignedCertificate and sets the default values.
        /// </summary>
        public SelfSignedCertificate() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SelfSignedCertificate CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SelfSignedCertificate();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"customKeyIdentifier", n => { CustomKeyIdentifier = n.GetByteArrayValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"endDateTime", n => { EndDateTime = n.GetDateTimeOffsetValue(); } },
                {"key", n => { Key = n.GetByteArrayValue(); } },
                {"keyId", n => { KeyId = n.GetStringValue(); } },
                {"startDateTime", n => { StartDateTime = n.GetDateTimeOffsetValue(); } },
                {"thumbprint", n => { Thumbprint = n.GetStringValue(); } },
                {"type", n => { Type = n.GetStringValue(); } },
                {"usage", n => { Usage = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteByteArrayValue("customKeyIdentifier", CustomKeyIdentifier);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteDateTimeOffsetValue("endDateTime", EndDateTime);
            writer.WriteByteArrayValue("key", Key);
            writer.WriteStringValue("keyId", KeyId);
            writer.WriteDateTimeOffsetValue("startDateTime", StartDateTime);
            writer.WriteStringValue("thumbprint", Thumbprint);
            writer.WriteStringValue("type", Type);
            writer.WriteStringValue("usage", Usage);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
