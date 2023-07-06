using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum StagedFeatureName {
        [EnumMember(Value = "certificateBasedAuthentication")]
        CertificateBasedAuthentication,
        [EnumMember(Value = "emailAsAlternateId")]
        EmailAsAlternateId,
        [EnumMember(Value = "multiFactorAuthentication")]
        MultiFactorAuthentication,
        [EnumMember(Value = "passthroughAuthentication")]
        PassthroughAuthentication,
        [EnumMember(Value = "passwordHashSync")]
        PasswordHashSync,
        [EnumMember(Value = "seamlessSso")]
        SeamlessSso,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
