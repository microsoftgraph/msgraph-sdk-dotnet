using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum EvidenceRemediationStatus {
        [EnumMember(Value = "blocked")]
        Blocked,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "notFound")]
        NotFound,
        [EnumMember(Value = "prevented")]
        Prevented,
        [EnumMember(Value = "remediated")]
        Remediated,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
