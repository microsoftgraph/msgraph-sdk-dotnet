using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ThreatAssessmentStatus {
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "pending")]
        Pending,
    }
}
