using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum LogonType {
        [EnumMember(Value = "batch")]
        Batch,
        [EnumMember(Value = "interactive")]
        Interactive,
        [EnumMember(Value = "network")]
        Network,
        [EnumMember(Value = "remoteInteractive")]
        RemoteInteractive,
        [EnumMember(Value = "service")]
        Service,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
