namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum RatingJapanMoviesType {
        /// <summary>Default value, allow all movies content</summary>
        AllAllowed,
        /// <summary>Do not allow any movies content</summary>
        AllBlocked,
        /// <summary>Suitable for all ages</summary>
        General,
        /// <summary>The PG-12 classification requests parental guidance for young people under 12</summary>
        ParentalGuidance,
        /// <summary>The R15+ classification is suitable for viewers of 15 or older</summary>
        AgesAbove15,
        /// <summary>The R18+ classification is suitable for viewers of 18 or older</summary>
        AgesAbove18,
    }
}
