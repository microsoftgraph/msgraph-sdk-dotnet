namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum DeviceManagementSubscriptionState {
        /// <summary>Pending</summary>
        Pending,
        /// <summary>Active</summary>
        Active,
        /// <summary>Warning</summary>
        Warning,
        /// <summary>Disabled</summary>
        Disabled,
        /// <summary>Deleted</summary>
        Deleted,
        /// <summary>Blocked</summary>
        Blocked,
        /// <summary>LockedOut</summary>
        LockedOut,
    }
}
