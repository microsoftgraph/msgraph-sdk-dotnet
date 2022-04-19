namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the deviceManagement singleton.</summary>
    public enum DeviceRegistrationState {
        NotRegistered,
        Registered,
        Revoked,
        KeyConflict,
        ApprovalPending,
        CertificateReset,
        NotRegisteredPendingEnrollment,
        Unknown,
    }
}
