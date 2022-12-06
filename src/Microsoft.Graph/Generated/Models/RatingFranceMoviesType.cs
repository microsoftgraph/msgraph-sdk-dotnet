namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RatingFranceMoviesType {
        /// <summary>Default value, allow all movies content</summary>
        AllAllowed,
        /// <summary>Do not allow any movies content</summary>
        AllBlocked,
        /// <summary>The 10 classification prohibits the screening of the film to minors under 10</summary>
        AgesAbove10,
        /// <summary>The 12 classification prohibits the screening of the film to minors under 12</summary>
        AgesAbove12,
        /// <summary>The 16 classification prohibits the screening of the film to minors under 16</summary>
        AgesAbove16,
        /// <summary>The 18 classification prohibits the screening to minors under 18</summary>
        AgesAbove18,
    }
}
