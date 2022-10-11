namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum ConditionalAccessGrantControl {
        Block,
        Mfa,
        CompliantDevice,
        DomainJoinedDevice,
        ApprovedApplication,
        CompliantApplication,
        PasswordChange,
        UnknownFutureValue,
    }
}
