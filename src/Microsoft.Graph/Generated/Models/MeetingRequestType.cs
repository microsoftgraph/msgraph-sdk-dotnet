namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
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
