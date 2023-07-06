using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Top level failure categories for enrollment.</summary>
    public enum DeviceEnrollmentFailureReason {
        /// <summary>Failed to validate the account for enrollment. (Account blocked, enrollment not enabled)</summary>
        [EnumMember(Value = "accountValidation")]
        AccountValidation,
        /// <summary>Authentication failed</summary>
        [EnumMember(Value = "authentication")]
        Authentication,
        /// <summary>Call was authenticated, but not authorized to enroll.</summary>
        [EnumMember(Value = "authorization")]
        Authorization,
        /// <summary>Client sent a request that is not understood/supported by the service.</summary>
        [EnumMember(Value = "badRequest")]
        BadRequest,
        /// <summary>Client timed out or enrollment was aborted by enduser.</summary>
        [EnumMember(Value = "clientDisconnected")]
        ClientDisconnected,
        /// <summary>Device is not supported for mobile device management.</summary>
        [EnumMember(Value = "deviceNotSupported")]
        DeviceNotSupported,
        /// <summary>Enrollment restrictions configured by admin blocked this enrollment.</summary>
        [EnumMember(Value = "enrollmentRestrictionsEnforced")]
        EnrollmentRestrictionsEnforced,
        /// <summary>Feature(s) used by this enrollment are not supported for this account.</summary>
        [EnumMember(Value = "featureNotSupported")]
        FeatureNotSupported,
        /// <summary>Account is in maintenance.</summary>
        [EnumMember(Value = "inMaintenance")]
        InMaintenance,
        /// <summary>Default value, failure reason is unknown.</summary>
        [EnumMember(Value = "unknown")]
        Unknown,
        /// <summary>Enrollment was abandoned by enduser. (Enduser started onboarding but failed to complete it in timely manner)</summary>
        [EnumMember(Value = "userAbandonment")]
        UserAbandonment,
        /// <summary>User could not be validated. (User does not exist, missing license)</summary>
        [EnumMember(Value = "userValidation")]
        UserValidation,
    }
}
