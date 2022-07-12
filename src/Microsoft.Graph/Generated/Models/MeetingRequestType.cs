namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
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
