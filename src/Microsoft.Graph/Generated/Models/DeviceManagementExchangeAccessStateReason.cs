namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the deviceManagement singleton.</summary>
    public enum DeviceManagementExchangeAccessStateReason {
        None,
        Unknown,
        ExchangeGlobalRule,
        ExchangeIndividualRule,
        ExchangeDeviceRule,
        ExchangeUpgrade,
        ExchangeMailboxPolicy,
        Other,
        Compliant,
        NotCompliant,
        NotEnrolled,
        UnknownLocation,
        MfaRequired,
        AzureADBlockDueToAccessPolicy,
        CompromisedPassword,
        DeviceNotKnownWithManagedApp,
    }
}
