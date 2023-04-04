using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum DetectionSource {
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "microsoftDefenderForEndpoint")]
        MicrosoftDefenderForEndpoint,
        [EnumMember(Value = "antivirus")]
        Antivirus,
        [EnumMember(Value = "smartScreen")]
        SmartScreen,
        [EnumMember(Value = "customTi")]
        CustomTi,
        [EnumMember(Value = "microsoftDefenderForOffice365")]
        MicrosoftDefenderForOffice365,
        [EnumMember(Value = "automatedInvestigation")]
        AutomatedInvestigation,
        [EnumMember(Value = "microsoftThreatExperts")]
        MicrosoftThreatExperts,
        [EnumMember(Value = "customDetection")]
        CustomDetection,
        [EnumMember(Value = "microsoftDefenderForIdentity")]
        MicrosoftDefenderForIdentity,
        [EnumMember(Value = "cloudAppSecurity")]
        CloudAppSecurity,
        [EnumMember(Value = "microsoft365Defender")]
        Microsoft365Defender,
        [EnumMember(Value = "azureAdIdentityProtection")]
        AzureAdIdentityProtection,
        [EnumMember(Value = "manual")]
        Manual,
        [EnumMember(Value = "microsoftDataLossPrevention")]
        MicrosoftDataLossPrevention,
        [EnumMember(Value = "appGovernancePolicy")]
        AppGovernancePolicy,
        [EnumMember(Value = "appGovernanceDetection")]
        AppGovernanceDetection,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
