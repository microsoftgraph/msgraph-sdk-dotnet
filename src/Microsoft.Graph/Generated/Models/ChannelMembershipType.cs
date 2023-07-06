using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ChannelMembershipType {
        [EnumMember(Value = "private")]
        @Private,
        [EnumMember(Value = "shared")]
        Shared,
        [EnumMember(Value = "standard")]
        Standard,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
