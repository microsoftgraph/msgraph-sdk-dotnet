using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SimulationAutomationRunStatus {
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "skipped")]
        Skipped,
        [EnumMember(Value = "succeeded")]
        Succeeded,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
