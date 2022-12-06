namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum StagedFeatureName {
        PassthroughAuthentication,
        SeamlessSso,
        PasswordHashSync,
        EmailAsAlternateId,
        UnknownFutureValue,
        CertificateBasedAuthentication,
        MultiFactorAuthentication,
    }
}
