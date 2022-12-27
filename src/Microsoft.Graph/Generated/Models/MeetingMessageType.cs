namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the appCatalogs singleton.</summary>
    public enum MeetingMessageType {
        None,
        MeetingRequest,
        MeetingCancelled,
        MeetingAccepted,
        MeetingTenativelyAccepted,
        MeetingDeclined,
    }
}
