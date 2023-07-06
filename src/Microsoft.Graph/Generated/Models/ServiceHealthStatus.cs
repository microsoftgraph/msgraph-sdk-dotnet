using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ServiceHealthStatus {
        [EnumMember(Value = "confirmed")]
        Confirmed,
        [EnumMember(Value = "extendedRecovery")]
        ExtendedRecovery,
        [EnumMember(Value = "falsePositive")]
        FalsePositive,
        [EnumMember(Value = "investigating")]
        Investigating,
        [EnumMember(Value = "investigationSuspended")]
        InvestigationSuspended,
        [EnumMember(Value = "mitigated")]
        Mitigated,
        [EnumMember(Value = "mitigatedExternal")]
        MitigatedExternal,
        [EnumMember(Value = "postIncidentReviewPublished")]
        PostIncidentReviewPublished,
        [EnumMember(Value = "reported")]
        Reported,
        [EnumMember(Value = "resolved")]
        Resolved,
        [EnumMember(Value = "resolvedExternal")]
        ResolvedExternal,
        [EnumMember(Value = "restoringService")]
        RestoringService,
        [EnumMember(Value = "serviceDegradation")]
        ServiceDegradation,
        [EnumMember(Value = "serviceInterruption")]
        ServiceInterruption,
        [EnumMember(Value = "serviceOperational")]
        ServiceOperational,
        [EnumMember(Value = "serviceRestored")]
        ServiceRestored,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "verifyingService")]
        VerifyingService,
    }
}
