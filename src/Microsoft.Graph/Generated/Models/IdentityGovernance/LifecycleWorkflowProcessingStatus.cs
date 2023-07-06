using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.IdentityGovernance {
    public enum LifecycleWorkflowProcessingStatus {
        [EnumMember(Value = "canceled")]
        Canceled,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "completedWithErrors")]
        CompletedWithErrors,
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "inProgress")]
        InProgress,
        [EnumMember(Value = "queued")]
        Queued,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
