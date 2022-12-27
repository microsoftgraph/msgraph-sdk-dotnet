namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the appCatalogs singleton.</summary>
    public enum LongRunningOperationStatus {
        NotStarted,
        Running,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }
}
