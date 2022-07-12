namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum RatingCanadaMoviesType {
        /// <summary>Default value, allow all movies content</summary>
        AllAllowed,
        /// <summary>Do not allow any movies content</summary>
        AllBlocked,
        /// <summary>The G classification is suitable for all ages</summary>
        General,
        /// <summary>The PG classification advises parental guidance</summary>
        ParentalGuidance,
        /// <summary>The 14A classification is suitable for viewers above 14 or older</summary>
        AgesAbove14,
        /// <summary>The 18A classification is suitable for viewers above 18 or older</summary>
        AgesAbove18,
        /// <summary>The R classification is restricted to 18 years and older</summary>
        Restricted,
    }
}
