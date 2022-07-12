namespace Microsoft.Graph.Models.Security {
    /// <summary>Provides operations to manage the admin singleton.</summary>
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
