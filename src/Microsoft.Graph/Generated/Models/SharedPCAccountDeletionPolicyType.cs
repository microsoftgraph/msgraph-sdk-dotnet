namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum SharedPCAccountDeletionPolicyType {
        /// <summary>Delete immediately.</summary>
        Immediate,
        /// <summary>Delete at disk space threshold.</summary>
        DiskSpaceThreshold,
        /// <summary>Delete at disk space threshold or inactive threshold.</summary>
        DiskSpaceThresholdOrInactiveThreshold,
    }
}
