using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AlertSeverity {
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "informational")]
        Informational,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
