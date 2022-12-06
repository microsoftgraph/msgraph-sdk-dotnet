namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum WindowsDeliveryOptimizationMode {
        /// <summary>Allow the user to set.</summary>
        UserDefined,
        /// <summary>HTTP only, no peering</summary>
        HttpOnly,
        /// <summary>OS default – Http blended with peering behind the same network address translator</summary>
        HttpWithPeeringNat,
        /// <summary>HTTP blended with peering across a private group</summary>
        HttpWithPeeringPrivateGroup,
        /// <summary>HTTP blended with Internet peering</summary>
        HttpWithInternetPeering,
        /// <summary>Simple download mode with no peering</summary>
        SimpleDownload,
        /// <summary>Bypass mode. Do not use Delivery Optimization and use BITS instead</summary>
        BypassMode,
    }
}
