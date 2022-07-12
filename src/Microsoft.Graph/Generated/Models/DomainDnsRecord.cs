using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class DomainDnsRecord : Entity, IParsable {
        /// <summary>If false, this record must be configured by the customer at the DNS host for Microsoft Online Services to operate correctly with the domain.</summary>
        public bool? IsOptional {
            get { return BackingStore?.Get<bool?>("isOptional"); }
            set { BackingStore?.Set("isOptional", value); }
        }
        /// <summary>Value used when configuring the name of the DNS record at the DNS host.</summary>
        public string Label {
            get { return BackingStore?.Get<string>("label"); }
            set { BackingStore?.Set("label", value); }
        }
        /// <summary>Indicates what type of DNS record this entity represents.The value can be one of the following: CName, Mx, Srv, Txt.</summary>
        public string RecordType {
            get { return BackingStore?.Get<string>("recordType"); }
            set { BackingStore?.Set("recordType", value); }
        }
        /// <summary>Microsoft Online Service or feature that has a dependency on this DNS record.Can be one of the following values: null, Email, Sharepoint, EmailInternalRelayOnly, OfficeCommunicationsOnline, SharePointDefaultDomain, FullRedelegation, SharePointPublic, OrgIdAuthentication, Yammer, Intune.</summary>
        public string SupportedService {
            get { return BackingStore?.Get<string>("supportedService"); }
            set { BackingStore?.Set("supportedService", value); }
        }
        /// <summary>Value to use when configuring the time-to-live (ttl) property of the DNS record at the DNS host. Not nullable.</summary>
        public int? Ttl {
            get { return BackingStore?.Get<int?>("ttl"); }
            set { BackingStore?.Set("ttl", value); }
        }
        /// <summary>
        /// Instantiates a new domainDnsRecord and sets the default values.
        /// </summary>
        public DomainDnsRecord() : base() {
            Type = "#microsoft.graph.domainDnsRecord";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DomainDnsRecord CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.domainDnsCnameRecord" => new DomainDnsCnameRecord(),
                "#microsoft.graph.domainDnsMxRecord" => new DomainDnsMxRecord(),
                "#microsoft.graph.domainDnsSrvRecord" => new DomainDnsSrvRecord(),
                "#microsoft.graph.domainDnsTxtRecord" => new DomainDnsTxtRecord(),
                "#microsoft.graph.domainDnsUnavailableRecord" => new DomainDnsUnavailableRecord(),
                _ => new DomainDnsRecord(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"isOptional", n => { IsOptional = n.GetBoolValue(); } },
                {"label", n => { Label = n.GetStringValue(); } },
                {"recordType", n => { RecordType = n.GetStringValue(); } },
                {"supportedService", n => { SupportedService = n.GetStringValue(); } },
                {"ttl", n => { Ttl = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("isOptional", IsOptional);
            writer.WriteStringValue("label", Label);
            writer.WriteStringValue("recordType", RecordType);
            writer.WriteStringValue("supportedService", SupportedService);
            writer.WriteIntValue("ttl", Ttl);
        }
    }
}
