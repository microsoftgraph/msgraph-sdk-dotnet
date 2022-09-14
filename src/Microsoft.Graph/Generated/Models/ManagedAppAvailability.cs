namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the deviceAppManagement singleton.</summary>
    public enum ManagedAppAvailability {
        /// <summary>A globally available app to all tenants.</summary>
        Global,
        /// <summary>A line of business apps private to an organization.</summary>
        LineOfBusiness,
    }
}
