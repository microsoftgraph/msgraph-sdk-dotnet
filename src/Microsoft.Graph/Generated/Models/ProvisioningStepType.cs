namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum ProvisioningStepType {
        Import,
        Scoping,
        Matching,
        Processing,
        ReferenceResolution,
        Export,
        UnknownFutureValue,
    }
}
