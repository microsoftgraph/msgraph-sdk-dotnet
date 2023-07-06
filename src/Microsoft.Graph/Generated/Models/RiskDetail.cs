using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RiskDetail {
        [EnumMember(Value = "adminConfirmedServicePrincipalCompromised")]
        AdminConfirmedServicePrincipalCompromised,
        [EnumMember(Value = "adminConfirmedSigninCompromised")]
        AdminConfirmedSigninCompromised,
        [EnumMember(Value = "adminConfirmedSigninSafe")]
        AdminConfirmedSigninSafe,
        [EnumMember(Value = "adminConfirmedUserCompromised")]
        AdminConfirmedUserCompromised,
        [EnumMember(Value = "adminDismissedAllRiskForServicePrincipal")]
        AdminDismissedAllRiskForServicePrincipal,
        [EnumMember(Value = "adminDismissedAllRiskForUser")]
        AdminDismissedAllRiskForUser,
        [EnumMember(Value = "adminGeneratedTemporaryPassword")]
        AdminGeneratedTemporaryPassword,
        [EnumMember(Value = "aiConfirmedSigninSafe")]
        AiConfirmedSigninSafe,
        [EnumMember(Value = "hidden")]
        Hidden,
        [EnumMember(Value = "m365DAdminDismissedDetection")]
        M365DAdminDismissedDetection,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "userPassedMFADrivenByRiskBasedPolicy")]
        UserPassedMFADrivenByRiskBasedPolicy,
        [EnumMember(Value = "userPerformedSecuredPasswordChange")]
        UserPerformedSecuredPasswordChange,
        [EnumMember(Value = "userPerformedSecuredPasswordReset")]
        UserPerformedSecuredPasswordReset,
    }
}
