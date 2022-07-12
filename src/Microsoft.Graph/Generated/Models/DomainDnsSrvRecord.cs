using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class DomainDnsSrvRecord : DomainDnsRecord, IParsable {
        /// <summary>Value to use when configuring the Target property of the SRV record at the DNS host.</summary>
        public string NameTarget {
            get { return BackingStore?.Get<string>("nameTarget"); }
            set { BackingStore?.Set("nameTarget", value); }
        }
        /// <summary>Value to use when configuring the port property of the SRV record at the DNS host.</summary>
        public int? Port {
            get { return BackingStore?.Get<int?>("port"); }
            set { BackingStore?.Set("port", value); }
        }
        /// <summary>Value to use when configuring the priority property of the SRV record at the DNS host.</summary>
        public int? Priority {
            get { return BackingStore?.Get<int?>("priority"); }
            set { BackingStore?.Set("priority", value); }
        }
        /// <summary>Value to use when configuring the protocol property of the SRV record at the DNS host.</summary>
        public string Protocol {
            get { return BackingStore?.Get<string>("protocol"); }
            set { BackingStore?.Set("protocol", value); }
        }
        /// <summary>Value to use when configuring the service property of the SRV record at the DNS host.</summary>
        public string Service {
            get { return BackingStore?.Get<string>("service"); }
            set { BackingStore?.Set("service", value); }
        }
        /// <summary>Value to use when configuring the weight property of the SRV record at the DNS host.</summary>
        public int? Weight {
            get { return BackingStore?.Get<int?>("weight"); }
            set { BackingStore?.Set("weight", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DomainDnsSrvRecord CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DomainDnsSrvRecord();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"nameTarget", n => { NameTarget = n.GetStringValue(); } },
                {"port", n => { Port = n.GetIntValue(); } },
                {"priority", n => { Priority = n.GetIntValue(); } },
                {"protocol", n => { Protocol = n.GetStringValue(); } },
                {"service", n => { Service = n.GetStringValue(); } },
                {"weight", n => { Weight = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("nameTarget", NameTarget);
            writer.WriteIntValue("port", Port);
            writer.WriteIntValue("priority", Priority);
            writer.WriteStringValue("protocol", Protocol);
            writer.WriteStringValue("service", Service);
            writer.WriteIntValue("weight", Weight);
        }
    }
}
