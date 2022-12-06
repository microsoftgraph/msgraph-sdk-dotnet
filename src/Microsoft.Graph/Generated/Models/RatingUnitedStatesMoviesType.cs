namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RatingUnitedStatesMoviesType {
        /// <summary>Default value, allow all movies content</summary>
        AllAllowed,
        /// <summary>Do not allow any movies content</summary>
        AllBlocked,
        /// <summary>G, all ages admitted</summary>
        General,
        /// <summary>PG, some material may not be suitable for children</summary>
        ParentalGuidance,
        /// <summary>PG13, some material may be inappropriate for children under 13</summary>
        ParentalGuidance13,
        /// <summary>R, viewers under 17 require accompanying parent or adult guardian</summary>
        Restricted,
        /// <summary>NC17, adults only</summary>
        Adults,
    }
}
