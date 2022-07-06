namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum LobbyBypassScope {
        Organizer,
        Organization,
        OrganizationAndFederated,
        Everyone,
        UnknownFutureValue,
        Invited,
        OrganizationExcludingGuests,
    }
}
