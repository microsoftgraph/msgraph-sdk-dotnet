namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum DeviceEnrollmentType {
        /// <summary>Default value, enrollment type was not collected.</summary>
        Unknown,
        /// <summary>User driven enrollment through BYOD channel.</summary>
        UserEnrollment,
        /// <summary>User enrollment with a device enrollment manager account.</summary>
        DeviceEnrollmentManager,
        /// <summary>Apple bulk enrollment with user challenge. (DEP, Apple Configurator)</summary>
        AppleBulkWithUser,
        /// <summary>Apple bulk enrollment without user challenge. (DEP, Apple Configurator, Mobile Config)</summary>
        AppleBulkWithoutUser,
        /// <summary>Windows 10 Azure AD Join.</summary>
        WindowsAzureADJoin,
        /// <summary>Windows 10 Bulk enrollment through ICD with certificate.</summary>
        WindowsBulkUserless,
        /// <summary>Windows 10 automatic enrollment. (Add work account)</summary>
        WindowsAutoEnrollment,
        /// <summary>Windows 10 bulk Azure AD Join.</summary>
        WindowsBulkAzureDomainJoin,
        /// <summary>Windows 10 Co-Management triggered by AutoPilot or Group Policy.</summary>
        WindowsCoManagement,
        /// <summary>Windows 10 Azure AD Join using Device Auth.</summary>
        WindowsAzureADJoinUsingDeviceAuth,
        /// <summary>Device managed by Apple user enrollment</summary>
        AppleUserEnrollment,
        /// <summary>Device managed by Apple user enrollment with service account</summary>
        AppleUserEnrollmentWithServiceAccount,
    }
}
