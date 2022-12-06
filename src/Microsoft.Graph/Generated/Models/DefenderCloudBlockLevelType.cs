namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum DefenderCloudBlockLevelType {
        /// <summary>Default value, uses the default Windows Defender Antivirus blocking level and provides strong detection without increasing the risk of detecting legitimate files</summary>
        NotConfigured,
        /// <summary>High applies a strong level of detection.</summary>
        High,
        /// <summary>High + uses the High level and applies addition protection measures</summary>
        HighPlus,
        /// <summary>Zero tolerance blocks all unknown executables</summary>
        ZeroTolerance,
    }
}
