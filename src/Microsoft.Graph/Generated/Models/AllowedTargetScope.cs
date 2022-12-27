namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the appCatalogs singleton.</summary>
    public enum AllowedTargetScope {
        NotSpecified,
        SpecificDirectoryUsers,
        SpecificConnectedOrganizationUsers,
        SpecificDirectoryServicePrincipals,
        AllMemberUsers,
        AllDirectoryUsers,
        AllDirectoryServicePrincipals,
        AllConfiguredConnectedOrganizationUsers,
        AllExternalUsers,
        UnknownFutureValue,
    }
}
