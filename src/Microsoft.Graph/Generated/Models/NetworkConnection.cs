using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class NetworkConnection : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Name of the application managing the network connection (for example, Facebook, SMTP, etc.).</summary>
        public string ApplicationName {
            get { return BackingStore?.Get<string>("applicationName"); }
            set { BackingStore?.Set("applicationName", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Destination IP address (of the network connection).</summary>
        public string DestinationAddress {
            get { return BackingStore?.Get<string>("destinationAddress"); }
            set { BackingStore?.Set("destinationAddress", value); }
        }
        /// <summary>Destination domain portion of the destination URL. (for example &apos;www.contoso.com&apos;).</summary>
        public string DestinationDomain {
            get { return BackingStore?.Get<string>("destinationDomain"); }
            set { BackingStore?.Set("destinationDomain", value); }
        }
        /// <summary>Location (by IP address mapping) associated with the destination of a network connection.</summary>
        public string DestinationLocation {
            get { return BackingStore?.Get<string>("destinationLocation"); }
            set { BackingStore?.Set("destinationLocation", value); }
        }
        /// <summary>Destination port (of the network connection).</summary>
        public string DestinationPort {
            get { return BackingStore?.Get<string>("destinationPort"); }
            set { BackingStore?.Set("destinationPort", value); }
        }
        /// <summary>Network connection URL/URI string - excluding parameters. (for example &apos;www.contoso.com/products/default.html&apos;)</summary>
        public string DestinationUrl {
            get { return BackingStore?.Get<string>("destinationUrl"); }
            set { BackingStore?.Set("destinationUrl", value); }
        }
        /// <summary>Network connection direction. Possible values are: unknown, inbound, outbound.</summary>
        public ConnectionDirection? Direction {
            get { return BackingStore?.Get<ConnectionDirection?>("direction"); }
            set { BackingStore?.Set("direction", value); }
        }
        /// <summary>Date when the destination domain was registered. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? DomainRegisteredDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("domainRegisteredDateTime"); }
            set { BackingStore?.Set("domainRegisteredDateTime", value); }
        }
        /// <summary>The local DNS name resolution as it appears in the host&apos;s local DNS cache (for example, in case the &apos;hosts&apos; file was tampered with).</summary>
        public string LocalDnsName {
            get { return BackingStore?.Get<string>("localDnsName"); }
            set { BackingStore?.Set("localDnsName", value); }
        }
        /// <summary>Network Address Translation destination IP address.</summary>
        public string NatDestinationAddress {
            get { return BackingStore?.Get<string>("natDestinationAddress"); }
            set { BackingStore?.Set("natDestinationAddress", value); }
        }
        /// <summary>Network Address Translation destination port.</summary>
        public string NatDestinationPort {
            get { return BackingStore?.Get<string>("natDestinationPort"); }
            set { BackingStore?.Set("natDestinationPort", value); }
        }
        /// <summary>Network Address Translation source IP address.</summary>
        public string NatSourceAddress {
            get { return BackingStore?.Get<string>("natSourceAddress"); }
            set { BackingStore?.Set("natSourceAddress", value); }
        }
        /// <summary>Network Address Translation source port.</summary>
        public string NatSourcePort {
            get { return BackingStore?.Get<string>("natSourcePort"); }
            set { BackingStore?.Set("natSourcePort", value); }
        }
        /// <summary>Network protocol. Possible values are: unknown, ip, icmp, igmp, ggp, ipv4, tcp, pup, udp, idp, ipv6, ipv6RoutingHeader, ipv6FragmentHeader, ipSecEncapsulatingSecurityPayload, ipSecAuthenticationHeader, icmpV6, ipv6NoNextHeader, ipv6DestinationOptions, nd, raw, ipx, spx, spxII.</summary>
        public SecurityNetworkProtocol? Protocol {
            get { return BackingStore?.Get<SecurityNetworkProtocol?>("protocol"); }
            set { BackingStore?.Set("protocol", value); }
        }
        /// <summary>Provider generated/calculated risk score of the network connection. Recommended value range of 0-1, which equates to a percentage.</summary>
        public string RiskScore {
            get { return BackingStore?.Get<string>("riskScore"); }
            set { BackingStore?.Set("riskScore", value); }
        }
        /// <summary>Source (i.e. origin) IP address (of the network connection).</summary>
        public string SourceAddress {
            get { return BackingStore?.Get<string>("sourceAddress"); }
            set { BackingStore?.Set("sourceAddress", value); }
        }
        /// <summary>Location (by IP address mapping) associated with the source of a network connection.</summary>
        public string SourceLocation {
            get { return BackingStore?.Get<string>("sourceLocation"); }
            set { BackingStore?.Set("sourceLocation", value); }
        }
        /// <summary>Source (i.e. origin) IP port (of the network connection).</summary>
        public string SourcePort {
            get { return BackingStore?.Get<string>("sourcePort"); }
            set { BackingStore?.Set("sourcePort", value); }
        }
        /// <summary>Network connection status. Possible values are: unknown, attempted, succeeded, blocked, failed.</summary>
        public ConnectionStatus? Status {
            get { return BackingStore?.Get<ConnectionStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>Parameters (suffix) of the destination URL.</summary>
        public string UrlParameters {
            get { return BackingStore?.Get<string>("urlParameters"); }
            set { BackingStore?.Set("urlParameters", value); }
        }
        /// <summary>
        /// Instantiates a new networkConnection and sets the default values.
        /// </summary>
        public NetworkConnection() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static NetworkConnection CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NetworkConnection();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"applicationName", n => { ApplicationName = n.GetStringValue(); } },
                {"destinationAddress", n => { DestinationAddress = n.GetStringValue(); } },
                {"destinationDomain", n => { DestinationDomain = n.GetStringValue(); } },
                {"destinationLocation", n => { DestinationLocation = n.GetStringValue(); } },
                {"destinationPort", n => { DestinationPort = n.GetStringValue(); } },
                {"destinationUrl", n => { DestinationUrl = n.GetStringValue(); } },
                {"direction", n => { Direction = n.GetEnumValue<ConnectionDirection>(); } },
                {"domainRegisteredDateTime", n => { DomainRegisteredDateTime = n.GetDateTimeOffsetValue(); } },
                {"localDnsName", n => { LocalDnsName = n.GetStringValue(); } },
                {"natDestinationAddress", n => { NatDestinationAddress = n.GetStringValue(); } },
                {"natDestinationPort", n => { NatDestinationPort = n.GetStringValue(); } },
                {"natSourceAddress", n => { NatSourceAddress = n.GetStringValue(); } },
                {"natSourcePort", n => { NatSourcePort = n.GetStringValue(); } },
                {"protocol", n => { Protocol = n.GetEnumValue<SecurityNetworkProtocol>(); } },
                {"riskScore", n => { RiskScore = n.GetStringValue(); } },
                {"sourceAddress", n => { SourceAddress = n.GetStringValue(); } },
                {"sourceLocation", n => { SourceLocation = n.GetStringValue(); } },
                {"sourcePort", n => { SourcePort = n.GetStringValue(); } },
                {"status", n => { Status = n.GetEnumValue<ConnectionStatus>(); } },
                {"urlParameters", n => { UrlParameters = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("applicationName", ApplicationName);
            writer.WriteStringValue("destinationAddress", DestinationAddress);
            writer.WriteStringValue("destinationDomain", DestinationDomain);
            writer.WriteStringValue("destinationLocation", DestinationLocation);
            writer.WriteStringValue("destinationPort", DestinationPort);
            writer.WriteStringValue("destinationUrl", DestinationUrl);
            writer.WriteEnumValue<ConnectionDirection>("direction", Direction);
            writer.WriteDateTimeOffsetValue("domainRegisteredDateTime", DomainRegisteredDateTime);
            writer.WriteStringValue("localDnsName", LocalDnsName);
            writer.WriteStringValue("natDestinationAddress", NatDestinationAddress);
            writer.WriteStringValue("natDestinationPort", NatDestinationPort);
            writer.WriteStringValue("natSourceAddress", NatSourceAddress);
            writer.WriteStringValue("natSourcePort", NatSourcePort);
            writer.WriteEnumValue<SecurityNetworkProtocol>("protocol", Protocol);
            writer.WriteStringValue("riskScore", RiskScore);
            writer.WriteStringValue("sourceAddress", SourceAddress);
            writer.WriteStringValue("sourceLocation", SourceLocation);
            writer.WriteStringValue("sourcePort", SourcePort);
            writer.WriteEnumValue<ConnectionStatus>("status", Status);
            writer.WriteStringValue("urlParameters", UrlParameters);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
