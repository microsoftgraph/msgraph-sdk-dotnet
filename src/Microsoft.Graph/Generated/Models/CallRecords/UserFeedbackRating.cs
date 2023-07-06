using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public enum UserFeedbackRating {
        [EnumMember(Value = "bad")]
        Bad,
        [EnumMember(Value = "excellent")]
        Excellent,
        [EnumMember(Value = "fair")]
        Fair,
        [EnumMember(Value = "good")]
        Good,
        [EnumMember(Value = "notRated")]
        NotRated,
        [EnumMember(Value = "poor")]
        Poor,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
