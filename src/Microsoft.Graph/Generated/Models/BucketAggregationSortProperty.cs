using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BucketAggregationSortProperty {
        [EnumMember(Value = "count")]
        Count,
        [EnumMember(Value = "keyAsNumber")]
        KeyAsNumber,
        [EnumMember(Value = "keyAsString")]
        KeyAsString,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
