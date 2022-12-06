namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RatingGermanyMoviesType {
        /// <summary>Default value, allow all movies content</summary>
        AllAllowed,
        /// <summary>Do not allow any movies content</summary>
        AllBlocked,
        /// <summary>Ab 0 Jahren, no age restrictions</summary>
        General,
        /// <summary>Ab 6 Jahren, ages 6 and older</summary>
        AgesAbove6,
        /// <summary>Ab 12 Jahren, ages 12 and older</summary>
        AgesAbove12,
        /// <summary>Ab 16 Jahren, ages 16 and older</summary>
        AgesAbove16,
        /// <summary>Ab 18 Jahren, adults only</summary>
        Adults,
    }
}
