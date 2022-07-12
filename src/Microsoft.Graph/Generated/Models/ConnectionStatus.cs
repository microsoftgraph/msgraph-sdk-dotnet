namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum ConnectionStatus {
        Unknown,
        Attempted,
        Succeeded,
        Blocked,
        Failed,
        UnknownFutureValue,
    }
}
