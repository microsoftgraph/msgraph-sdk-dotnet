using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum EducationSubmissionStatus {
        [EnumMember(Value = "reassigned")]
        Reassigned,
        [EnumMember(Value = "released")]
        Released,
        [EnumMember(Value = "returned")]
        Returned,
        [EnumMember(Value = "submitted")]
        Submitted,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "working")]
        Working,
    }
}
