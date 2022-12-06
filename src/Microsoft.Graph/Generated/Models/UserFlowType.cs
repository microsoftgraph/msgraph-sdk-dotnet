namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum UserFlowType {
        SignUp,
        SignIn,
        SignUpOrSignIn,
        PasswordReset,
        ProfileUpdate,
        ResourceOwner,
        UnknownFutureValue,
    }
}
