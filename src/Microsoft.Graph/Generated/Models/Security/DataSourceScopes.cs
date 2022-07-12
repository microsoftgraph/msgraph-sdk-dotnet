namespace Microsoft.Graph.Models.Security {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum DataSourceScopes {
        None,
        AllTenantMailboxes,
        AllTenantSites,
        AllCaseCustodians,
        AllCaseNoncustodialDataSources,
        UnknownFutureValue,
    }
}
