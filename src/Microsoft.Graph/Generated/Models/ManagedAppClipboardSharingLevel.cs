namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum ManagedAppClipboardSharingLevel {
        /// <summary>Sharing is allowed between all apps, managed or not</summary>
        AllApps,
        /// <summary>Sharing is allowed between all managed apps with paste in enabled</summary>
        ManagedAppsWithPasteIn,
        /// <summary>Sharing is allowed between all managed apps</summary>
        ManagedApps,
        /// <summary>Sharing between apps is disabled</summary>
        Blocked,
    }
}
