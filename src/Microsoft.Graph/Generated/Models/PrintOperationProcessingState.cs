using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PrintOperationProcessingState {
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "notStarted")]
        NotStarted,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "succeeded")]
        Succeeded,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
