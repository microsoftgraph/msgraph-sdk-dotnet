namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum SharedPCAccountDeletionPolicyType {
        /// <summary>Delete immediately.</summary>
        Immediate,
        /// <summary>Delete at disk space threshold.</summary>
        DiskSpaceThreshold,
        /// <summary>Delete at disk space threshold or inactive threshold.</summary>
        DiskSpaceThresholdOrInactiveThreshold,
    }
}
