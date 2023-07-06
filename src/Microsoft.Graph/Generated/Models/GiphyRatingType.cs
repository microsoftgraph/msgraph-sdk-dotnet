using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum GiphyRatingType {
        [EnumMember(Value = "moderate")]
        Moderate,
        [EnumMember(Value = "strict")]
        Strict,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
