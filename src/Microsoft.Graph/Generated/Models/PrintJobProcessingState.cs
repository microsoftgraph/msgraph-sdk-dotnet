namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the appCatalogs singleton.</summary>
    public enum PrintJobProcessingState {
        Unknown,
        Pending,
        Processing,
        Paused,
        Stopped,
        Completed,
        Canceled,
        Aborted,
        UnknownFutureValue,
    }
}
