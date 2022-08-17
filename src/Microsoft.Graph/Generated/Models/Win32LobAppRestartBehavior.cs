namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum Win32LobAppRestartBehavior {
        /// <summary>Intune will restart the device after running the app installation if the operation returns a reboot code.</summary>
        BasedOnReturnCode,
        /// <summary>Intune will not take any specific action on reboot codes resulting from app installations. Intune will not attempt to suppress restarts for MSI apps.</summary>
        Allow,
        /// <summary>Intune will attempt to suppress restarts for MSI apps.</summary>
        Suppress,
        /// <summary>Intune will force the device to restart immediately after the app installation operation.</summary>
        Force,
    }
}
