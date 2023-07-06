using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TeamsAppPublishingState {
        [EnumMember(Value = "published")]
        Published,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "submitted")]
        Submitted,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
