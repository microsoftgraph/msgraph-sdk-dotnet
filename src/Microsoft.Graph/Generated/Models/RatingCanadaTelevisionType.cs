namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RatingCanadaTelevisionType {
        /// <summary>Default value, allow all TV shows content</summary>
        AllAllowed,
        /// <summary>Do not allow any TV shows content</summary>
        AllBlocked,
        /// <summary>The C classification is suitable for children ages of 2 to 7 years</summary>
        Children,
        /// <summary>The C8 classification is suitable for children ages 8+</summary>
        ChildrenAbove8,
        /// <summary>The G classification is suitable for general audience</summary>
        General,
        /// <summary>PG, Parental Guidance</summary>
        ParentalGuidance,
        /// <summary>The 14+ classification is intended for viewers ages 14 and older</summary>
        AgesAbove14,
        /// <summary>The 18+ classification is intended for viewers ages 18 and older</summary>
        AgesAbove18,
    }
}
