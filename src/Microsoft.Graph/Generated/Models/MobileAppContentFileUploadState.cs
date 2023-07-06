using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Contains properties for upload request states.</summary>
    public enum MobileAppContentFileUploadState {
        [EnumMember(Value = "azureStorageUriRenewalFailed")]
        AzureStorageUriRenewalFailed,
        [EnumMember(Value = "azureStorageUriRenewalPending")]
        AzureStorageUriRenewalPending,
        [EnumMember(Value = "azureStorageUriRenewalSuccess")]
        AzureStorageUriRenewalSuccess,
        [EnumMember(Value = "azureStorageUriRenewalTimedOut")]
        AzureStorageUriRenewalTimedOut,
        [EnumMember(Value = "azureStorageUriRequestFailed")]
        AzureStorageUriRequestFailed,
        [EnumMember(Value = "azureStorageUriRequestPending")]
        AzureStorageUriRequestPending,
        [EnumMember(Value = "azureStorageUriRequestSuccess")]
        AzureStorageUriRequestSuccess,
        [EnumMember(Value = "azureStorageUriRequestTimedOut")]
        AzureStorageUriRequestTimedOut,
        [EnumMember(Value = "commitFileFailed")]
        CommitFileFailed,
        [EnumMember(Value = "commitFilePending")]
        CommitFilePending,
        [EnumMember(Value = "commitFileSuccess")]
        CommitFileSuccess,
        [EnumMember(Value = "commitFileTimedOut")]
        CommitFileTimedOut,
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "success")]
        Success,
        [EnumMember(Value = "transientError")]
        TransientError,
        [EnumMember(Value = "unknown")]
        Unknown,
    }
}
