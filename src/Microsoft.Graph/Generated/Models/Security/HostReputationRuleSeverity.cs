using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum HostReputationRuleSeverity {
        [EnumMember(Value = "high")]
        High,
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
