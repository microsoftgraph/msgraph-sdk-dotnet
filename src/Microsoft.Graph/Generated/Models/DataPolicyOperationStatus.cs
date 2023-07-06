using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum DataPolicyOperationStatus {
        [EnumMember(Value = "complete")]
        Complete,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "notStarted")]
        NotStarted,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
