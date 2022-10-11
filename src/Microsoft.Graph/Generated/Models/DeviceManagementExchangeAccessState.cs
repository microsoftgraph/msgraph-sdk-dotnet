namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum DeviceManagementExchangeAccessState {
        /// <summary>No access state discovered from Exchange</summary>
        None,
        /// <summary>Device access state to Exchange is unknown</summary>
        Unknown,
        /// <summary>Device has access to Exchange</summary>
        Allowed,
        /// <summary>Device is Blocked in Exchange</summary>
        Blocked,
        /// <summary>Device is Quarantined in Exchange</summary>
        Quarantined,
    }
}
