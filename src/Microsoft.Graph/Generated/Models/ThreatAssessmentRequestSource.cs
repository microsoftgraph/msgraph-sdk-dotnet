using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ThreatAssessmentRequestSource {
        [EnumMember(Value = "administrator")]
        Administrator,
        [EnumMember(Value = "undefined")]
        Undefined,
        [EnumMember(Value = "user")]
        User,
    }
}
