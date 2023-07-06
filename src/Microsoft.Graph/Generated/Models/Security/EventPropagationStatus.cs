using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum EventPropagationStatus {
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "inProcessing")]
        InProcessing,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "success")]
        Success,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
