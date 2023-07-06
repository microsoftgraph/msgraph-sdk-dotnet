using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SimulationStatus {
        [EnumMember(Value = "cancelled")]
        Cancelled,
        [EnumMember(Value = "draft")]
        Draft,
        [EnumMember(Value = "excluded")]
        Excluded,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "scheduled")]
        Scheduled,
        [EnumMember(Value = "succeeded")]
        Succeeded,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
