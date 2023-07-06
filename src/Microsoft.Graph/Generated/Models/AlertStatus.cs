using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AlertStatus {
        [EnumMember(Value = "dismissed")]
        Dismissed,
        [EnumMember(Value = "inProgress")]
        InProgress,
        [EnumMember(Value = "newAlert")]
        NewAlert,
        [EnumMember(Value = "resolved")]
        Resolved,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
