using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CourseStatus {
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "inProgress")]
        InProgress,
        [EnumMember(Value = "notStarted")]
        NotStarted,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
