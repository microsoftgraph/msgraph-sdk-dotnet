using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.ExternalConnectors {
    public enum AclType {
        [EnumMember(Value = "everyone")]
        Everyone,
        [EnumMember(Value = "everyoneExceptGuests")]
        EveryoneExceptGuests,
        [EnumMember(Value = "externalGroup")]
        ExternalGroup,
        [EnumMember(Value = "group")]
        Group,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "user")]
        User,
    }
}
