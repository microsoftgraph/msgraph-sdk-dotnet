namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the deviceAppManagement singleton.</summary>
    public enum InstallState {
        /// <summary>Not Applicable.</summary>
        NotApplicable,
        /// <summary>Installed.</summary>
        Installed,
        /// <summary>Failed.</summary>
        Failed,
        /// <summary>Not Installed.</summary>
        NotInstalled,
        /// <summary>Uninstall Failed.</summary>
        UninstallFailed,
        /// <summary>Unknown.</summary>
        Unknown,
    }
}
