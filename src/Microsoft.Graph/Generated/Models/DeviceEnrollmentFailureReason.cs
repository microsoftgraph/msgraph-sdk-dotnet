namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum DeviceEnrollmentFailureReason {
        /// <summary>Default value, failure reason is unknown.</summary>
        Unknown,
        /// <summary>Authentication failed</summary>
        Authentication,
        /// <summary>Call was authenticated, but not authorized to enroll.</summary>
        Authorization,
        /// <summary>Failed to validate the account for enrollment. (Account blocked, enrollment not enabled)</summary>
        AccountValidation,
        /// <summary>User could not be validated. (User does not exist, missing license)</summary>
        UserValidation,
        /// <summary>Device is not supported for mobile device management.</summary>
        DeviceNotSupported,
        /// <summary>Account is in maintenance.</summary>
        InMaintenance,
        /// <summary>Client sent a request that is not understood/supported by the service.</summary>
        BadRequest,
        /// <summary>Feature(s) used by this enrollment are not supported for this account.</summary>
        FeatureNotSupported,
        /// <summary>Enrollment restrictions configured by admin blocked this enrollment.</summary>
        EnrollmentRestrictionsEnforced,
        /// <summary>Client timed out or enrollment was aborted by enduser.</summary>
        ClientDisconnected,
        /// <summary>Enrollment was abandoned by enduser. (Enduser started onboarding but failed to complete it in timely manner)</summary>
        UserAbandonment,
    }
}
