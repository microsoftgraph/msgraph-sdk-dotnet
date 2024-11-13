//  -- https://github.com/microsoftgraph/
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    /// <summary>
    /// Graph error codes
    /// https://developer.microsoft.com/en-us/graph/docs/concepts/errors
    /// </summary>
    public enum GraphErrorCode
    {
        /// The caller doesn't have permission to perform the action.
        AccessDenied,
        /// The app or user has been throttled.
        ActivityLimitReached,
        /// Access restricted to the item's owner.
        AccessRestricted,
        /// Authentication cancelled.
        AuthenticationCancelled,
        /// Authentication failed.
        AuthenticationFailure,
        /// Failed to get a consistent delta snapshot. Try again later.
        CannotSnapshotTree,
        /// Max limit on the number of child items was reached.
        ChildItemCountExceeded,
        /// ETag does not match the current item's value.
        EntityTagDoesNotMatch,
        /// Declared total size for this fragment is different from that of the upload session.
        FragmentLengthMismatch,
        /// Uploaded fragment is out of order.
        FragmentOutOfOrder,
        /// Uploaded fragment overlaps with existing data.
        FragmentOverlap,
        /// An unspecified error has occurred.
        GeneralException,
        /// Invalid accept type.
        InvalidAcceptType,
        /// Invalid parameter format.
        InvalidParameterFormat,
        /// Name contains invalid characters.
        InvalidPath,
        /// Invalid query option.
        InvalidQueryOption,
        /// The specified byte range is invalid or unavailable.
        InvalidRange,
        /// The request is malformed or incorrect.
        InvalidRequest,
        /// Invalid start index.
        InvalidStartIndex,
        /// The image could not be found.
        ImageNotFound,
        /// The resource could not be found.
        ItemNotFound,
        /// Lock token does not match existing lock.
        LockMismatch,
        /// There is currently no unexpired lock on the item.
        LockNotFoundOrAlreadyExpired,
        /// Lock Owner ID does not match provided ID.
        LockOwnerMismatch,
        /// ETag header is malformed. ETags must be quoted strings.
        MalformedEntityTag,
        /// Malware was detected in the requested resource.
        MalwareDetected,
        /// Max limit on number of Documents is reached.
        MaxDocumentCountExceeded,
        /// Max file size exceeded.
        MaxFileSizeExceeded,
        /// Max limit on number of Folders is reached.
        MaxFolderCountExceeded,
        /// Max file size exceeded.
        MaxFragmentLengthExceeded,
        /// Max limit on number of Items is reached.
        MaxItemCountExceeded,
        /// Max query length exceeded.
        MaxQueryLengthExceeded,
        /// Maximum stream size exceeded.
        MaxStreamSizeExceeded,
        /// The specified item name already exists.
        NameAlreadyExists,
        /// The action is not allowed by the system.
        NotAllowed,
        /// The requested item is not found.
        NotFound,
        /// The request is not supported by the system.
        NotSupported,
        /// Parameter Exceeds Maximum Length.
        ParameterIsTooLong,
        /// Parameter is smaller than minimum value.
        ParameterIsTooSmall,
        /// Path exceeds maximum length.
        PathIsTooLong,
        /// Folder hierarchy depth limit reached.
        PathTooDeep,
        /// Property not updateable.
        PropertyNotUpdateable,
        /// The requested resource is not found.
        Request_ResourceNotFound,
        /// The resource being updated has changed since the caller last read it, usually an eTag mismatch.
        ResourceModified,
        /// Resync required. Replace any local items with the server's version (including deletes) 
        /// if you're sure that the service was up to date with your local changes when you last sync'd. 
        /// Upload any local changes that the server doesn't know about.
        ResyncApplyDifferences,
        /// The delta token is no longer valid, and the app must reset the sync state.
        ResyncRequired,
        /// Resync required. Upload any local items that the service did not return, and upload any files 
        /// that differ from the server's version (keeping both copies if you're not sure which one is more up-to-date).
        ResyncUploadDifferences,
        /// The service is not available. Try the request again after a delay. There may be a Retry-After header.
        ServiceNotAvailable,
        /// Resource is temporarily read-only.
        ServiceReadOnly,
        /// Too many requests.
        ThrottledRequest,
        /// The server, while acting as a proxy, did not receive a timely response from the upstream server it needed 
        /// to access in attempting to complete the request. May occur together with 503.
        Timeout,
        /// Client application has been throttled and should not attempt to repeat the request until an amount of time has elapsed.
        TooManyRedirects,
        /// Too many results requested.
        TooManyResultsRequested,
        /// Too many terms in the query.
        TooManyTermsInQuery,
        /// Operation is not allowed because the number of affected items exceeds threshold.
        TotalAffectedItemCountExceeded,
        /// Data truncation is not allowed.
        TruncationNotAllowed,
        /// The user has reached their quota limit.
        QuotaLimitReached,
        /// The caller is not authenticated.
        Unauthenticated,
        /// Upload session failed.
        UploadSessionFailed,
        /// Upload session incomplete.
        UploadSessionIncomplete,
        /// Upload session not found.
        UploadSessionNotFound,
        /// This document is suspicious and may have a virus.
        VirusSuspicious,
        /// Zero or fewer results requested.
        ZeroOrFewerResultsRequested,
    }
}
