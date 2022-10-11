namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum AccessPackageRequestState {
        Submitted,
        PendingApproval,
        Delivering,
        Delivered,
        DeliveryFailed,
        Denied,
        Scheduled,
        Canceled,
        PartiallyDelivered,
        UnknownFutureValue,
    }
}
