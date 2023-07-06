using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SimulationAutomationStatus {
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "draft")]
        Draft,
        [EnumMember(Value = "notRunning")]
        NotRunning,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
