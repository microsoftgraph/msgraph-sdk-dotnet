namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RatingAppsType {
        /// <summary>Default value, allow all apps content</summary>
        AllAllowed,
        /// <summary>Do not allow any apps content</summary>
        AllBlocked,
        /// <summary>4+, age 4 and above</summary>
        AgesAbove4,
        /// <summary>9+, age 9 and above</summary>
        AgesAbove9,
        /// <summary>12+, age 12 and above </summary>
        AgesAbove12,
        /// <summary>17+, age 17 and above</summary>
        AgesAbove17,
    }
}
