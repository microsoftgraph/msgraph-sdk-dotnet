namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum RatingFranceTelevisionType {
        /// <summary>Default value, allow all TV shows content</summary>
        AllAllowed,
        /// <summary>Do not allow any TV shows content</summary>
        AllBlocked,
        /// <summary>The -10 classification is not recommended for children under 10</summary>
        AgesAbove10,
        /// <summary>The -12 classification is not recommended for children under 12</summary>
        AgesAbove12,
        /// <summary>The -16 classification is not recommended for children under 16</summary>
        AgesAbove16,
        /// <summary>The -18 classification is not recommended for persons under 18</summary>
        AgesAbove18,
    }
}
