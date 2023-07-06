using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ConnectionStatus {
        [EnumMember(Value = "attempted")]
        Attempted,
        [EnumMember(Value = "blocked")]
        Blocked,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "succeeded")]
        Succeeded,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
