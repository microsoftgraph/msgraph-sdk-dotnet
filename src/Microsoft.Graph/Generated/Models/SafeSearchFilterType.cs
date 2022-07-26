namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum SafeSearchFilterType {
        /// <summary>User Defined, default value, no intent.</summary>
        UserDefined,
        /// <summary>Strict, highest filtering against adult content.</summary>
        Strict,
        /// <summary>Moderate filtering against adult content (valid search results will not be filtered).</summary>
        Moderate,
    }
}
