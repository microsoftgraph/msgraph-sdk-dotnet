using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum DataSourceScopes {
        [EnumMember(Value = "allCaseCustodians")]
        AllCaseCustodians,
        [EnumMember(Value = "allCaseNoncustodialDataSources")]
        AllCaseNoncustodialDataSources,
        [EnumMember(Value = "allTenantMailboxes")]
        AllTenantMailboxes,
        [EnumMember(Value = "allTenantSites")]
        AllTenantSites,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
