namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum MeetingRequestType {
        None,
        NewMeetingRequest,
        FullUpdate,
        InformationalUpdate,
        SilentUpdate,
        Outdated,
        PrincipalWantsCopy,
    }
}
