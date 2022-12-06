namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RatingAustraliaMoviesType {
        /// <summary>Default value, allow all movies content</summary>
        AllAllowed,
        /// <summary>Do not allow any movies content</summary>
        AllBlocked,
        /// <summary>The G classification is suitable for everyone</summary>
        General,
        /// <summary>The PG recommends viewers under 15 with guidance from parents or guardians</summary>
        ParentalGuidance,
        /// <summary>The M classification is not recommended for viewers under 15</summary>
        Mature,
        /// <summary>The MA15+ classification is not suitable for viewers under 15</summary>
        AgesAbove15,
        /// <summary>The R18+ classification is not suitable for viewers under 18</summary>
        AgesAbove18,
    }
}
