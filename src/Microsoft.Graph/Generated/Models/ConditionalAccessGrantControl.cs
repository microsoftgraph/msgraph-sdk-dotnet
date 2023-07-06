using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ConditionalAccessGrantControl {
        [EnumMember(Value = "approvedApplication")]
        ApprovedApplication,
        [EnumMember(Value = "block")]
        Block,
        [EnumMember(Value = "compliantApplication")]
        CompliantApplication,
        [EnumMember(Value = "compliantDevice")]
        CompliantDevice,
        [EnumMember(Value = "domainJoinedDevice")]
        DomainJoinedDevice,
        [EnumMember(Value = "mfa")]
        Mfa,
        [EnumMember(Value = "passwordChange")]
        PasswordChange,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
