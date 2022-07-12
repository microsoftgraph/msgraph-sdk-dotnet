namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum MeetingMessageType {
        None,
        MeetingRequest,
        MeetingCancelled,
        MeetingAccepted,
        MeetingTenativelyAccepted,
        MeetingDeclined,
    }
}
