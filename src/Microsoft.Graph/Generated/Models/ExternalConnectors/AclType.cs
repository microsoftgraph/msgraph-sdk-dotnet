namespace Microsoft.Graph.Models.ExternalConnectors {
    /// <summary>Provides operations to manage the collection of externalConnection entities.</summary>
    public enum AclType {
        User,
        Group,
        Everyone,
        EveryoneExceptGuests,
        ExternalGroup,
        UnknownFutureValue,
    }
}
