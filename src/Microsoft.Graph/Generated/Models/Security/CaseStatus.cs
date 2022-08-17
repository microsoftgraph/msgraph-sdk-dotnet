namespace Microsoft.Graph.Models.Security {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum CaseStatus {
        Unknown,
        Active,
        PendingDelete,
        Closing,
        Closed,
        ClosedWithError,
        UnknownFutureValue,
    }
}
