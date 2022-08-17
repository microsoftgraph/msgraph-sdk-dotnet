namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
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
