namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum DeviceThreatProtectionLevel {
        /// <summary>Default Value. Do not use.</summary>
        Unavailable,
        /// <summary>Device Threat Level requirement: Secured. This is the most secure level, and represents that no threats were found on the device.</summary>
        Secured,
        /// <summary>Device Threat Protection level requirement: Low. Low represents a severity of threat that poses minimal risk to the device or device data.</summary>
        Low,
        /// <summary>Device Threat Protection level requirement: Medium. Medium represents a severity of threat that poses moderate risk to the device or device data.</summary>
        Medium,
        /// <summary>Device Threat Protection level requirement: High. High represents a severity of threat that poses severe risk to the device or device data.</summary>
        High,
        /// <summary>Device Threat Protection level requirement: Not Set. Not set represents that there is no requirement for the device to meet a Threat Protection level.</summary>
        NotSet,
    }
}
