namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the deviceAppManagement singleton.</summary>
    public enum WindowsDeviceType {
        /// <summary>No flags set.</summary>
        None,
        /// <summary>Whether or not the Desktop Windows device type is supported.</summary>
        Desktop,
        /// <summary>Whether or not the Mobile Windows device type is supported.</summary>
        Mobile,
        /// <summary>Whether or not the Holographic Windows device type is supported.</summary>
        Holographic,
        /// <summary>Whether or not the Team Windows device type is supported.</summary>
        Team,
    }
}
