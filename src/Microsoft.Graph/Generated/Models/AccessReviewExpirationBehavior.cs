using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AccessReviewExpirationBehavior {
        [EnumMember(Value = "acceptAccessRecommendation")]
        AcceptAccessRecommendation,
        [EnumMember(Value = "keepAccess")]
        KeepAccess,
        [EnumMember(Value = "removeAccess")]
        RemoveAccess,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
