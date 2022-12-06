namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum RiskEventType {
        UnlikelyTravel,
        AnonymizedIPAddress,
        MaliciousIPAddress,
        UnfamiliarFeatures,
        MalwareInfectedIPAddress,
        SuspiciousIPAddress,
        LeakedCredentials,
        InvestigationsThreatIntelligence,
        Generic,
        AdminConfirmedUserCompromised,
        McasImpossibleTravel,
        McasSuspiciousInboxManipulationRules,
        InvestigationsThreatIntelligenceSigninLinked,
        MaliciousIPAddressValidCredentialsBlockedIP,
        UnknownFutureValue,
    }
}
