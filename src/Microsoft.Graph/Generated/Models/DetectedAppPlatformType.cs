namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum DetectedAppPlatformType {
        /// <summary>Default. Set to unknown when platform cannot be determined.</summary>
        Unknown,
        /// <summary>Indicates that the platform of the detected application is Windows.</summary>
        Windows,
        /// <summary>Indicates that the platform of the detected application is Windows Mobile.</summary>
        WindowsMobile,
        /// <summary>Indicates that the platform of the detected application is Windows Holographic.</summary>
        WindowsHolographic,
        /// <summary>Indicates that the platform of the detected application is iOS.</summary>
        Ios,
        /// <summary>Indicates that the platform of the detected application is macOS.</summary>
        MacOS,
        /// <summary>Indicates that the platform of the detected application is ChromeOS.</summary>
        ChromeOS,
        /// <summary>Indicates that the platform of the detected application is Android open source project.</summary>
        AndroidOSP,
        /// <summary>Indicates that the platform of the detected application is Android device administrator.</summary>
        AndroidDeviceAdministrator,
        /// <summary>Indicates that the platform of the detected application is Android work profile.</summary>
        AndroidWorkProfile,
        /// <summary>Indicates that the platform of the detected application is Android dedicated and fully managed.</summary>
        AndroidDedicatedAndFullyManaged,
    }
}
