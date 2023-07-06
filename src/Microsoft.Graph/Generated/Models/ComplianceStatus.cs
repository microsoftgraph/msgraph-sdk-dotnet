using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ComplianceStatus {
        [EnumMember(Value = "compliant")]
        Compliant,
        [EnumMember(Value = "conflict")]
        Conflict,
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "nonCompliant")]
        NonCompliant,
        [EnumMember(Value = "notApplicable")]
        NotApplicable,
        [EnumMember(Value = "notAssigned")]
        NotAssigned,
        [EnumMember(Value = "remediated")]
        Remediated,
        [EnumMember(Value = "unknown")]
        Unknown,
    }
}
