using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SubjectRightsRequestStage {
        [EnumMember(Value = "caseResolved")]
        CaseResolved,
        [EnumMember(Value = "contentDeletion")]
        ContentDeletion,
        [EnumMember(Value = "contentEstimate")]
        ContentEstimate,
        [EnumMember(Value = "contentRetrieval")]
        ContentRetrieval,
        [EnumMember(Value = "contentReview")]
        ContentReview,
        [EnumMember(Value = "generateReport")]
        GenerateReport,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
