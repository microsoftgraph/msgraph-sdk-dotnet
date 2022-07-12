namespace Microsoft.Graph.Models.Security {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum DataSourceHoldStatus {
        NotApplied,
        Applied,
        Applying,
        Removing,
        Partial,
        UnknownFutureValue,
    }
}
