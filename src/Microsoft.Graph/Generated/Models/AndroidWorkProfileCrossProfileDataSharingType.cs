namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum AndroidWorkProfileCrossProfileDataSharingType {
        /// <summary>Device default value, no intent.</summary>
        DeviceDefault,
        /// <summary>Prevent any sharing.</summary>
        PreventAny,
        /// <summary>Allow data sharing request from personal profile to work profile.</summary>
        AllowPersonalToWork,
        /// <summary>No restrictions on sharing.</summary>
        NoRestrictions,
    }
}
