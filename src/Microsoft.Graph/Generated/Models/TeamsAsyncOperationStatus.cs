using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TeamsAsyncOperationStatus {
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "inProgress")]
        InProgress,
        [EnumMember(Value = "invalid")]
        Invalid,
        [EnumMember(Value = "notStarted")]
        NotStarted,
        [EnumMember(Value = "succeeded")]
        Succeeded,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
