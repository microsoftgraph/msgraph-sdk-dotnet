namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum RatingUnitedStatesTelevisionType {
        /// <summary>Default value, allow all TV shows content</summary>
        AllAllowed,
        /// <summary>Do not allow any TV shows content</summary>
        AllBlocked,
        /// <summary>TV-Y, all children</summary>
        ChildrenAll,
        /// <summary>TV-Y7, children age 7 and above</summary>
        ChildrenAbove7,
        /// <summary>TV-G, suitable for all ages</summary>
        General,
        /// <summary>TV-PG, parental guidance</summary>
        ParentalGuidance,
        /// <summary>TV-14, children age 14 and above</summary>
        ChildrenAbove14,
        /// <summary>TV-MA, adults only</summary>
        Adults,
    }
}
