namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the deviceAppManagement singleton.</summary>
    public enum WindowsArchitecture {
        /// <summary>No flags set.</summary>
        None,
        /// <summary>Whether or not the X86 Windows architecture type is supported.</summary>
        X86,
        /// <summary>Whether or not the X64 Windows architecture type is supported.</summary>
        X64,
        /// <summary>Whether or not the Arm Windows architecture type is supported.</summary>
        Arm,
        /// <summary>Whether or not the Neutral Windows architecture type is supported.</summary>
        Neutral,
    }
}
