namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the deviceManagement singleton.</summary>
    public enum DeviceEnrollmentType {
        Unknown,
        UserEnrollment,
        DeviceEnrollmentManager,
        AppleBulkWithUser,
        AppleBulkWithoutUser,
        WindowsAzureADJoin,
        WindowsBulkUserless,
        WindowsAutoEnrollment,
        WindowsBulkAzureDomainJoin,
        WindowsCoManagement,
        WindowsAzureADJoinUsingDeviceAuth,
        AppleUserEnrollment,
        AppleUserEnrollmentWithServiceAccount,
    }
}
