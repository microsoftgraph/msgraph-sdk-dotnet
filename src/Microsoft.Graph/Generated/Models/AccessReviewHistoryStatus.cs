using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AccessReviewHistoryStatus {
        [EnumMember(Value = "done")]
        Done,
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "inprogress")]
        Inprogress,
        [EnumMember(Value = "requested")]
        Requested,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
