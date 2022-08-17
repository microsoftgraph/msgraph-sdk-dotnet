namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum DefenderScanType {
        /// <summary>User Defined, default value, no intent.</summary>
        UserDefined,
        /// <summary>System scan disabled.</summary>
        Disabled,
        /// <summary>Quick system scan.</summary>
        Quick,
        /// <summary>Full system scan.</summary>
        Full,
    }
}
