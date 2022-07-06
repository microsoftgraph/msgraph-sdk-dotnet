namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum ManagedDevicePartnerReportedHealthState {
        /// <summary>Device health state is not yet reported</summary>
        Unknown,
        /// <summary>Device has been activated by a mobile threat defense partner, but has not yet reported health.</summary>
        Activated,
        /// <summary>Device has been deactivated by a mobile threat defense partner. The device health is not known.</summary>
        Deactivated,
        /// <summary>Device is considered secured by the mobile threat defense partner.</summary>
        Secured,
        /// <summary>Device is considered low threat by the mobile threat defense partner.</summary>
        LowSeverity,
        /// <summary>Device is considered medium threat by the mobile threat defense partner.</summary>
        MediumSeverity,
        /// <summary>Device is considered high threat by the mobile threat defense partner.</summary>
        HighSeverity,
        /// <summary>Device is considered unresponsive by the mobile threat defense partner. The device health is not known.</summary>
        Unresponsive,
        /// <summary>Device is considered compromised by the Threat Defense partner. This means the device has an active Threat or Risk which cannot be easily remediated by the end user and the user should contact their IT Admin.</summary>
        Compromised,
        /// <summary>Device is considered misconfigured with the Threat Defense partner. This means the device is missing a required profile or configuration for the Threat Defense Partner to function properly and is thus threat or risk analysis is not able to complete.</summary>
        Misconfigured,
    }
}
