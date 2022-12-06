namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RatingNewZealandMoviesType {
        /// <summary>Default value, allow all movies content</summary>
        AllAllowed,
        /// <summary>Do not allow any movies content</summary>
        AllBlocked,
        /// <summary>Suitable for general audience</summary>
        General,
        /// <summary>The PG classification recommends parental guidance</summary>
        ParentalGuidance,
        /// <summary>The M classification is suitable for mature audience</summary>
        Mature,
        /// <summary>The R13 classification is restricted to persons 13 years and over</summary>
        AgesAbove13,
        /// <summary>The R15 classification is restricted to persons 15 years and over</summary>
        AgesAbove15,
        /// <summary>The R16 classification is restricted to persons 16 years and over</summary>
        AgesAbove16,
        /// <summary>The R18 classification is restricted to persons 18 years and over</summary>
        AgesAbove18,
        /// <summary>The R classification is restricted to a certain audience</summary>
        Restricted,
        /// <summary>The RP16 classification requires viewers under 16 accompanied by a parent or an adult</summary>
        AgesAbove16Restricted,
    }
}
