using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TaskStatus {
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "deferred")]
        Deferred,
        [EnumMember(Value = "inProgress")]
        InProgress,
        [EnumMember(Value = "notStarted")]
        NotStarted,
        [EnumMember(Value = "waitingOnOthers")]
        WaitingOnOthers,
    }
}
