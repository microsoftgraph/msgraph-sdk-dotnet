using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SubjectRightsRequestStageStatus {
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "current")]
        Current,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "notStarted")]
        NotStarted,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
