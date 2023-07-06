using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum DetectionSource {
        [EnumMember(Value = "antivirus")]
        Antivirus,
        [EnumMember(Value = "appGovernanceDetection")]
        AppGovernanceDetection,
        [EnumMember(Value = "appGovernancePolicy")]
        AppGovernancePolicy,
        [EnumMember(Value = "automatedInvestigation")]
        AutomatedInvestigation,
        [EnumMember(Value = "azureAdIdentityProtection")]
        AzureAdIdentityProtection,
        [EnumMember(Value = "cloudAppSecurity")]
        CloudAppSecurity,
        [EnumMember(Value = "customDetection")]
        CustomDetection,
        [EnumMember(Value = "customTi")]
        CustomTi,
        [EnumMember(Value = "manual")]
        Manual,
        [EnumMember(Value = "microsoft365Defender")]
        Microsoft365Defender,
        [EnumMember(Value = "microsoftDataLossPrevention")]
        MicrosoftDataLossPrevention,
        [EnumMember(Value = "microsoftDefenderForCloud")]
        MicrosoftDefenderForCloud,
        [EnumMember(Value = "microsoftDefenderForEndpoint")]
        MicrosoftDefenderForEndpoint,
        [EnumMember(Value = "microsoftDefenderForIdentity")]
        MicrosoftDefenderForIdentity,
        [EnumMember(Value = "microsoftDefenderForOffice365")]
        MicrosoftDefenderForOffice365,
        [EnumMember(Value = "microsoftThreatExperts")]
        MicrosoftThreatExperts,
        [EnumMember(Value = "smartScreen")]
        SmartScreen,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
