namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RiskState {
        None,
        ConfirmedSafe,
        Remediated,
        Dismissed,
        AtRisk,
        ConfirmedCompromised,
        UnknownFutureValue,
    }
}
