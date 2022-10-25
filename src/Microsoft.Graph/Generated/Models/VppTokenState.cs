namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum VppTokenState {
        /// <summary>Default state.</summary>
        Unknown,
        /// <summary>Token is valid.</summary>
        Valid,
        /// <summary>Token is expired.</summary>
        Expired,
        /// <summary>Token is invalid.</summary>
        Invalid,
        /// <summary>Token is managed by another MDM Service.</summary>
        AssignedToExternalMDM,
    }
}
