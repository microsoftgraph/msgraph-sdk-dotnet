using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum CaseAction {
        [EnumMember(Value = "addToReviewSet")]
        AddToReviewSet,
        [EnumMember(Value = "applyTags")]
        ApplyTags,
        [EnumMember(Value = "contentExport")]
        ContentExport,
        [EnumMember(Value = "convertToPdf")]
        ConvertToPdf,
        [EnumMember(Value = "estimateStatistics")]
        EstimateStatistics,
        [EnumMember(Value = "holdUpdate")]
        HoldUpdate,
        [EnumMember(Value = "index")]
        Index,
        [EnumMember(Value = "purgeData")]
        PurgeData,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
