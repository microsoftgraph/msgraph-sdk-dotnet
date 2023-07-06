using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum HostReputationClassification {
        [EnumMember(Value = "malicious")]
        Malicious,
        [EnumMember(Value = "neutral")]
        Neutral,
        [EnumMember(Value = "suspicious")]
        Suspicious,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
