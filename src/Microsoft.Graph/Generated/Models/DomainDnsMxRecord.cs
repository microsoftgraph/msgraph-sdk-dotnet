using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class DomainDnsMxRecord : DomainDnsRecord, IParsable {
        /// <summary>Value used when configuring the answer/destination/value of the MX record at the DNS host.</summary>
        public string MailExchange {
            get { return BackingStore?.Get<string>("mailExchange"); }
            set { BackingStore?.Set("mailExchange", value); }
        }
        /// <summary>Value used when configuring the Preference/Priority property of the MX record at the DNS host.</summary>
        public int? Preference {
            get { return BackingStore?.Get<int?>("preference"); }
            set { BackingStore?.Set("preference", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DomainDnsMxRecord CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DomainDnsMxRecord();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"mailExchange", n => { MailExchange = n.GetStringValue(); } },
                {"preference", n => { Preference = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("mailExchange", MailExchange);
            writer.WriteIntValue("preference", Preference);
        }
    }
}
