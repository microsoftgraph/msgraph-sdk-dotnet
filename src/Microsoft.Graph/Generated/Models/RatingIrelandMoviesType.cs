namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum RatingIrelandMoviesType {
        /// <summary>Default value, allow all movies content</summary>
        AllAllowed,
        /// <summary>Do not allow any movies content</summary>
        AllBlocked,
        /// <summary>Suitable for children of school going age</summary>
        General,
        /// <summary>The PG classification advises parental guidance</summary>
        ParentalGuidance,
        /// <summary>The 12A classification is suitable for viewers of 12 or older</summary>
        AgesAbove12,
        /// <summary>The 15A classification is suitable for viewers of 15 or older</summary>
        AgesAbove15,
        /// <summary>The 16 classification is suitable for viewers of 16 or older</summary>
        AgesAbove16,
        /// <summary>The 18 classification, suitable only for adults</summary>
        Adults,
    }
}
