using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AuthenticationMethodFeature {
        [EnumMember(Value = "mfaCapable")]
        MfaCapable,
        [EnumMember(Value = "passwordlessCapable")]
        PasswordlessCapable,
        [EnumMember(Value = "ssprCapable")]
        SsprCapable,
        [EnumMember(Value = "ssprEnabled")]
        SsprEnabled,
        [EnumMember(Value = "ssprRegistered")]
        SsprRegistered,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
