namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum AutomaticUpdateMode {
        /// <summary>User Defined, default value, no intent.</summary>
        UserDefined,
        /// <summary>Notify on download.</summary>
        NotifyDownload,
        /// <summary>Auto-install at maintenance time.</summary>
        AutoInstallAtMaintenanceTime,
        /// <summary>Auto-install and reboot at maintenance time.</summary>
        AutoInstallAndRebootAtMaintenanceTime,
        /// <summary>Auto-install and reboot at scheduled time.</summary>
        AutoInstallAndRebootAtScheduledTime,
        /// <summary>Auto-install and restart without end-user control</summary>
        AutoInstallAndRebootWithoutEndUserControl,
    }
}
