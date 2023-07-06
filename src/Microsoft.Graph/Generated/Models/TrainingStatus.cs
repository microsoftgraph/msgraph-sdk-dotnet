using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TrainingStatus {
        [EnumMember(Value = "assigned")]
        Assigned,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "inProgress")]
        InProgress,
        [EnumMember(Value = "overdue")]
        Overdue,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
