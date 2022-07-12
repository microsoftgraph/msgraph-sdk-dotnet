namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum IosUpdatesInstallStatus {
        DeviceOsHigherThanDesiredOsVersion,
        SharedDeviceUserLoggedInError,
        NotSupportedOperation,
        InstallFailed,
        InstallPhoneCallInProgress,
        InstallInsufficientPower,
        InstallInsufficientSpace,
        Installing,
        DownloadInsufficientNetwork,
        DownloadInsufficientPower,
        DownloadInsufficientSpace,
        DownloadRequiresComputer,
        DownloadFailed,
        Downloading,
        Success,
        Available,
        Idle,
        Unknown,
    }
}
