using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RiskEventType {
        [EnumMember(Value = "adminConfirmedUserCompromised")]
        AdminConfirmedUserCompromised,
        [EnumMember(Value = "anonymizedIPAddress")]
        AnonymizedIPAddress,
        [EnumMember(Value = "generic")]
        Generic,
        [EnumMember(Value = "investigationsThreatIntelligence")]
        InvestigationsThreatIntelligence,
        [EnumMember(Value = "investigationsThreatIntelligenceSigninLinked")]
        InvestigationsThreatIntelligenceSigninLinked,
        [EnumMember(Value = "leakedCredentials")]
        LeakedCredentials,
        [EnumMember(Value = "maliciousIPAddress")]
        MaliciousIPAddress,
        [EnumMember(Value = "maliciousIPAddressValidCredentialsBlockedIP")]
        MaliciousIPAddressValidCredentialsBlockedIP,
        [EnumMember(Value = "malwareInfectedIPAddress")]
        MalwareInfectedIPAddress,
        [EnumMember(Value = "mcasImpossibleTravel")]
        McasImpossibleTravel,
        [EnumMember(Value = "mcasSuspiciousInboxManipulationRules")]
        McasSuspiciousInboxManipulationRules,
        [EnumMember(Value = "suspiciousIPAddress")]
        SuspiciousIPAddress,
        [EnumMember(Value = "unfamiliarFeatures")]
        UnfamiliarFeatures,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "unlikelyTravel")]
        UnlikelyTravel,
    }
}
