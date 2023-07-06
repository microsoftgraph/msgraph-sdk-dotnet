using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum CaseOperationStatus {
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "notStarted")]
        NotStarted,
        [EnumMember(Value = "partiallySucceeded")]
        PartiallySucceeded,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "submissionFailed")]
        SubmissionFailed,
        [EnumMember(Value = "succeeded")]
        Succeeded,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
