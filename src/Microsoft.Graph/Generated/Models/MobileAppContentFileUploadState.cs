namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum MobileAppContentFileUploadState {
        Success,
        TransientError,
        Error,
        Unknown,
        AzureStorageUriRequestSuccess,
        AzureStorageUriRequestPending,
        AzureStorageUriRequestFailed,
        AzureStorageUriRequestTimedOut,
        AzureStorageUriRenewalSuccess,
        AzureStorageUriRenewalPending,
        AzureStorageUriRenewalFailed,
        AzureStorageUriRenewalTimedOut,
        CommitFileSuccess,
        CommitFilePending,
        CommitFileFailed,
        CommitFileTimedOut,
    }
}
