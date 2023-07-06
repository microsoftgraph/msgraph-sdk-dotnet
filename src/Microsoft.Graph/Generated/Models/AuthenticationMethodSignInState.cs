using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AuthenticationMethodSignInState {
        [EnumMember(Value = "notAllowedByPolicy")]
        NotAllowedByPolicy,
        [EnumMember(Value = "notConfigured")]
        NotConfigured,
        [EnumMember(Value = "notEnabled")]
        NotEnabled,
        [EnumMember(Value = "notSupported")]
        NotSupported,
        [EnumMember(Value = "phoneNumberNotUnique")]
        PhoneNumberNotUnique,
        [EnumMember(Value = "ready")]
        Ready,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
