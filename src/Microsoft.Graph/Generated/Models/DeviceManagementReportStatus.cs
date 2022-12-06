namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum DeviceManagementReportStatus {
        /// <summary>Report generation status is unknown</summary>
        Unknown,
        /// <summary>Report generation has not started</summary>
        NotStarted,
        /// <summary>Report generation is in progress</summary>
        InProgress,
        /// <summary>Report generation is completed</summary>
        Completed,
        /// <summary>Report generation has failed</summary>
        Failed,
    }
}
