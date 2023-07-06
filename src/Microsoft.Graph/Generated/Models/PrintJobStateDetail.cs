using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PrintJobStateDetail {
        [EnumMember(Value = "completedSuccessfully")]
        CompletedSuccessfully,
        [EnumMember(Value = "completedWithErrors")]
        CompletedWithErrors,
        [EnumMember(Value = "completedWithWarnings")]
        CompletedWithWarnings,
        [EnumMember(Value = "interpreting")]
        Interpreting,
        [EnumMember(Value = "releaseWait")]
        ReleaseWait,
        [EnumMember(Value = "transforming")]
        Transforming,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "uploadPending")]
        UploadPending,
    }
}
