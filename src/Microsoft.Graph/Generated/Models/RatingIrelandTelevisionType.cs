namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum RatingIrelandTelevisionType {
        /// <summary>Default value, allow all TV shows content</summary>
        AllAllowed,
        /// <summary>Do not allow any TV shows content</summary>
        AllBlocked,
        /// <summary>The GA classification is suitable for all audiences</summary>
        General,
        /// <summary>The CH classification is suitable for children</summary>
        Children,
        /// <summary>The YA classification is suitable for teenage audience</summary>
        YoungAdults,
        /// <summary>The PS classification invites parents and guardians to consider restriction children’s access</summary>
        ParentalSupervision,
        /// <summary>The MA classification is suitable for adults</summary>
        Mature,
    }
}
