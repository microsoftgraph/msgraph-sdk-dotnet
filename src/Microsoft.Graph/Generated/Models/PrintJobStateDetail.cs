namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
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
