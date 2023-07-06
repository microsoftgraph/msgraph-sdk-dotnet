using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum IncludedUserTypes {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "guest")]
        Guest,
        [EnumMember(Value = "member")]
        Member,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
