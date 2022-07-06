namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum WelcomeScreenMeetingInformation {
        /// <summary>User Defined, default value, no intent.</summary>
        UserDefined,
        /// <summary>Show organizer and time only.</summary>
        ShowOrganizerAndTimeOnly,
        /// <summary>Show organizer, time and subject (subject is hidden for private meetings).</summary>
        ShowOrganizerAndTimeAndSubject,
    }
}
