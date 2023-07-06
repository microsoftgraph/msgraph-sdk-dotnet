using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RiskLevel {
        [EnumMember(Value = "hidden")]
        Hidden,
        [EnumMember(Value = "high")]
        High,
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
