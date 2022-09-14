namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the deviceAppManagement singleton.</summary>
    public enum InstallIntent {
        /// <summary>Available install intent.</summary>
        Available,
        /// <summary>Required install intent.</summary>
        Required,
        /// <summary>Uninstall install intent.</summary>
        Uninstall,
        /// <summary>Available without enrollment install intent.</summary>
        AvailableWithoutEnrollment,
    }
}
