using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TeamworkUserIdentityType {
        [EnumMember(Value = "aadUser")]
        AadUser,
        [EnumMember(Value = "anonymousGuest")]
        AnonymousGuest,
        [EnumMember(Value = "emailUser")]
        EmailUser,
        [EnumMember(Value = "federatedUser")]
        FederatedUser,
        [EnumMember(Value = "onPremiseAadUser")]
        OnPremiseAadUser,
        [EnumMember(Value = "personalMicrosoftAccountUser")]
        PersonalMicrosoftAccountUser,
        [EnumMember(Value = "phoneUser")]
        PhoneUser,
        [EnumMember(Value = "skypeUser")]
        SkypeUser,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
