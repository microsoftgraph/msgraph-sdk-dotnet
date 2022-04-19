namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the deviceManagement singleton.</summary>
    public enum ManagedDevicePartnerReportedHealthState {
        Unknown,
        Activated,
        Deactivated,
        Secured,
        LowSeverity,
        MediumSeverity,
        HighSeverity,
        Unresponsive,
        Compromised,
        Misconfigured,
    }
}
