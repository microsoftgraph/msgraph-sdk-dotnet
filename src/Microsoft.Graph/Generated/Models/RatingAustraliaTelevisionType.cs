namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RatingAustraliaTelevisionType {
        /// <summary>Default value, allow all TV shows content</summary>
        AllAllowed,
        /// <summary>Do not allow any TV shows content</summary>
        AllBlocked,
        /// <summary>The P classification is intended for preschoolers</summary>
        Preschoolers,
        /// <summary>The C classification is intended for children under 14</summary>
        Children,
        /// <summary>The G classification is suitable for all ages</summary>
        General,
        /// <summary>The PG classification is recommended for young viewers</summary>
        ParentalGuidance,
        /// <summary>The M classification is recommended for viewers over 15</summary>
        Mature,
        /// <summary>The MA15+ classification is not suitable for viewers under 15</summary>
        AgesAbove15,
        /// <summary>The AV15+ classification is not suitable for viewers under 15, adult violence-specific</summary>
        AgesAbove15AdultViolence,
    }
}
