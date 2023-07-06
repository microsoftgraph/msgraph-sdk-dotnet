using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public enum NetworkConnectionType {
        [EnumMember(Value = "mobile")]
        Mobile,
        [EnumMember(Value = "tunnel")]
        Tunnel,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "wifi")]
        Wifi,
        [EnumMember(Value = "wired")]
        Wired,
    }
}
