using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Apple push notification certificate.</summary>
    public class ApplePushNotificationCertificate : Entity, IParsable {
        /// <summary>Apple Id of the account used to create the MDM push certificate.</summary>
        public string AppleIdentifier {
            get { return BackingStore?.Get<string>("appleIdentifier"); }
            set { BackingStore?.Set("appleIdentifier", value); }
        }
        /// <summary>Not yet documented</summary>
        public string Certificate {
            get { return BackingStore?.Get<string>("certificate"); }
            set { BackingStore?.Set("certificate", value); }
        }
        /// <summary>Certificate serial number. This property is read-only.</summary>
        public string CertificateSerialNumber {
            get { return BackingStore?.Get<string>("certificateSerialNumber"); }
            set { BackingStore?.Set("certificateSerialNumber", value); }
        }
        /// <summary>The expiration date and time for Apple push notification certificate.</summary>
        public DateTimeOffset? ExpirationDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("expirationDateTime"); }
            set { BackingStore?.Set("expirationDateTime", value); }
        }
        /// <summary>Last modified date and time for Apple push notification certificate.</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>Topic Id.</summary>
        public string TopicIdentifier {
            get { return BackingStore?.Get<string>("topicIdentifier"); }
            set { BackingStore?.Set("topicIdentifier", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ApplePushNotificationCertificate CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ApplePushNotificationCertificate();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appleIdentifier", n => { AppleIdentifier = n.GetStringValue(); } },
                {"certificate", n => { Certificate = n.GetStringValue(); } },
                {"certificateSerialNumber", n => { CertificateSerialNumber = n.GetStringValue(); } },
                {"expirationDateTime", n => { ExpirationDateTime = n.GetDateTimeOffsetValue(); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"topicIdentifier", n => { TopicIdentifier = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("appleIdentifier", AppleIdentifier);
            writer.WriteStringValue("certificate", Certificate);
            writer.WriteStringValue("certificateSerialNumber", CertificateSerialNumber);
            writer.WriteDateTimeOffsetValue("expirationDateTime", ExpirationDateTime);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteStringValue("topicIdentifier", TopicIdentifier);
        }
    }
}
