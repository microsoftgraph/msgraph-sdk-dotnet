using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SecurityNetworkProtocol {
        [EnumMember(Value = "ggp")]
        Ggp,
        [EnumMember(Value = "icmp")]
        Icmp,
        [EnumMember(Value = "icmpV6")]
        IcmpV6,
        [EnumMember(Value = "idp")]
        Idp,
        [EnumMember(Value = "igmp")]
        Igmp,
        [EnumMember(Value = "ip")]
        Ip,
        [EnumMember(Value = "ipSecAuthenticationHeader")]
        IpSecAuthenticationHeader,
        [EnumMember(Value = "ipSecEncapsulatingSecurityPayload")]
        IpSecEncapsulatingSecurityPayload,
        [EnumMember(Value = "ipv4")]
        Ipv4,
        [EnumMember(Value = "ipv6")]
        Ipv6,
        [EnumMember(Value = "ipv6DestinationOptions")]
        Ipv6DestinationOptions,
        [EnumMember(Value = "ipv6FragmentHeader")]
        Ipv6FragmentHeader,
        [EnumMember(Value = "ipv6NoNextHeader")]
        Ipv6NoNextHeader,
        [EnumMember(Value = "ipv6RoutingHeader")]
        Ipv6RoutingHeader,
        [EnumMember(Value = "ipx")]
        Ipx,
        [EnumMember(Value = "nd")]
        Nd,
        [EnumMember(Value = "pup")]
        Pup,
        [EnumMember(Value = "raw")]
        Raw,
        [EnumMember(Value = "spx")]
        Spx,
        [EnumMember(Value = "spxII")]
        SpxII,
        [EnumMember(Value = "tcp")]
        Tcp,
        [EnumMember(Value = "udp")]
        Udp,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
