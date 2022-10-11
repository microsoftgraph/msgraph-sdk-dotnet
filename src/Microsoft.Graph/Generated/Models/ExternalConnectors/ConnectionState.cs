namespace Microsoft.Graph.Models.ExternalConnectors {
    /// <summary>Provides operations to manage the collection of externalConnection entities.</summary>
    public enum ConnectionState {
        Draft,
        Ready,
        Obsolete,
        LimitExceeded,
        UnknownFutureValue,
    }
}
