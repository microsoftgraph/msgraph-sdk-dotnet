namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum DeviceComplianceActionType {
        /// <summary>No Action</summary>
        NoAction,
        /// <summary>Send Notification</summary>
        Notification,
        /// <summary>Block the device in AAD</summary>
        Block,
        /// <summary>Retire the device</summary>
        Retire,
        /// <summary>Wipe the device</summary>
        Wipe,
        /// <summary>Remove Resource Access Profiles from the device</summary>
        RemoveResourceAccessProfiles,
        /// <summary>Send push notification to device</summary>
        PushNotification,
    }
}
