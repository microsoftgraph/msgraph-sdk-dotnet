using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum DeviceRiskScore {
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "informational")]
        Informational,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
