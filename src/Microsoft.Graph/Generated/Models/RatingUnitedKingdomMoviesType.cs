namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum RatingUnitedKingdomMoviesType {
        /// <summary>Default value, allow all movies content</summary>
        AllAllowed,
        /// <summary>Do not allow any movies content</summary>
        AllBlocked,
        /// <summary>The U classification is suitable for all ages</summary>
        General,
        /// <summary>The UC classification is suitable for pre-school children, an old rating label</summary>
        UniversalChildren,
        /// <summary>The PG classification is suitable for mature</summary>
        ParentalGuidance,
        /// <summary>12, video release suitable for 12 years and over</summary>
        AgesAbove12Video,
        /// <summary>12A, cinema release suitable for 12 years and over</summary>
        AgesAbove12Cinema,
        /// <summary>15, suitable only for 15 years and older</summary>
        AgesAbove15,
        /// <summary>Suitable only for adults</summary>
        Adults,
    }
}
