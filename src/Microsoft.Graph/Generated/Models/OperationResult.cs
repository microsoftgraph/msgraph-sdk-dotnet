using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum OperationResult {
        [EnumMember(Value = "failure")]
        Failure,
        [EnumMember(Value = "success")]
        Success,
        [EnumMember(Value = "timeout")]
        Timeout,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
