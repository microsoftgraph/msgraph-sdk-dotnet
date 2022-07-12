namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum SiteSecurityLevel {
        /// <summary>User Defined, default value, no intent.</summary>
        UserDefined,
        /// <summary>Low.</summary>
        Low,
        /// <summary>Medium-low.</summary>
        MediumLow,
        /// <summary>Medium.</summary>
        Medium,
        /// <summary>Medium-high.</summary>
        MediumHigh,
        /// <summary>High.</summary>
        High,
    }
}
