namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the appCatalogs singleton.</summary>
    public enum DeviceManagementExchangeAccessStateReason {
        /// <summary>No access state reason discovered from Exchange</summary>
        None,
        /// <summary>Unknown access state reason</summary>
        Unknown,
        /// <summary>Access state determined by Exchange Global rule</summary>
        ExchangeGlobalRule,
        /// <summary>Access state determined by Exchange Individual rule</summary>
        ExchangeIndividualRule,
        /// <summary>Access state determined by Exchange Device rule</summary>
        ExchangeDeviceRule,
        /// <summary>Access state due to Exchange upgrade</summary>
        ExchangeUpgrade,
        /// <summary>Access state determined by Exchange Mailbox Policy</summary>
        ExchangeMailboxPolicy,
        /// <summary>Access state determined by Exchange</summary>
        Other,
        /// <summary>Access state granted by compliance challenge</summary>
        Compliant,
        /// <summary>Access state revoked by compliance challenge</summary>
        NotCompliant,
        /// <summary>Access state revoked by management challenge</summary>
        NotEnrolled,
        /// <summary>Access state due to unknown location</summary>
        UnknownLocation,
        /// <summary>Access state due to MFA challenge</summary>
        MfaRequired,
        /// <summary>Access State revoked by AAD Access Policy</summary>
        AzureADBlockDueToAccessPolicy,
        /// <summary>Access State revoked by compromised password</summary>
        CompromisedPassword,
        /// <summary>Access state revoked by managed application challenge</summary>
        DeviceNotKnownWithManagedApp,
    }
}
