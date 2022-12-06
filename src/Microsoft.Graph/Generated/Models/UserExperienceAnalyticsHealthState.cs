namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum UserExperienceAnalyticsHealthState {
        Unknown,
        InsufficientData,
        NeedsAttention,
        MeetingGoals,
        /// <summary>Evolvable enum member</summary>
        UnknownFutureValue,
    }
}
