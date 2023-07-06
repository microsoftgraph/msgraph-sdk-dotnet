using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public enum NetworkTransportProtocol {
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
