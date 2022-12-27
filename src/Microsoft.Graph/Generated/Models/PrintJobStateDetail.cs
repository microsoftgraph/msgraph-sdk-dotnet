namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the appCatalogs singleton.</summary>
    public enum PrintJobStateDetail {
        UploadPending,
        Transforming,
        CompletedSuccessfully,
        CompletedWithWarnings,
        CompletedWithErrors,
        ReleaseWait,
        Interpreting,
        UnknownFutureValue,
    }
}
