namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum VppTokenSyncStatus {
        /// <summary>Default status.</summary>
        None,
        /// <summary>Last Sync in progress.</summary>
        InProgress,
        /// <summary>Last Sync completed successfully.</summary>
        Completed,
        /// <summary>Last Sync failed.</summary>
        Failed,
    }
}
