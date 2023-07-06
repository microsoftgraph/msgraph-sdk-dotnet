using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum ServiceSource {
        [EnumMember(Value = "azureAdIdentityProtection")]
        AzureAdIdentityProtection,
        [EnumMember(Value = "dataLossPrevention")]
        DataLossPrevention,
        [EnumMember(Value = "microsoft365Defender")]
        Microsoft365Defender,
        [EnumMember(Value = "microsoftAppGovernance")]
        MicrosoftAppGovernance,
        [EnumMember(Value = "microsoftDefenderForCloud")]
        MicrosoftDefenderForCloud,
        [EnumMember(Value = "microsoftDefenderForCloudApps")]
        MicrosoftDefenderForCloudApps,
        [EnumMember(Value = "microsoftDefenderForEndpoint")]
        MicrosoftDefenderForEndpoint,
        [EnumMember(Value = "microsoftDefenderForIdentity")]
        MicrosoftDefenderForIdentity,
        [EnumMember(Value = "microsoftDefenderForOffice365")]
        MicrosoftDefenderForOffice365,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
