using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum AlertClassification {
        [EnumMember(Value = "falsePositive")]
        FalsePositive,
        [EnumMember(Value = "informationalExpectedActivity")]
        InformationalExpectedActivity,
        [EnumMember(Value = "truePositive")]
        TruePositive,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
