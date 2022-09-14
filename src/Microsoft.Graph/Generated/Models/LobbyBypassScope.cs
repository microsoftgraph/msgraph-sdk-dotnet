namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the cloudCommunications singleton.</summary>
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
