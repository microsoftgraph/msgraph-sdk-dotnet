using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum UserFlowType {
        [EnumMember(Value = "passwordReset")]
        PasswordReset,
        [EnumMember(Value = "profileUpdate")]
        ProfileUpdate,
        [EnumMember(Value = "resourceOwner")]
        ResourceOwner,
        [EnumMember(Value = "signIn")]
        SignIn,
        [EnumMember(Value = "signUp")]
        SignUp,
        [EnumMember(Value = "signUpOrSignIn")]
        SignUpOrSignIn,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
