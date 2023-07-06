using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum OnboardingStatus {
        [EnumMember(Value = "canBeOnboarded")]
        CanBeOnboarded,
        [EnumMember(Value = "insufficientInfo")]
        InsufficientInfo,
        [EnumMember(Value = "onboarded")]
        Onboarded,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "unsupported")]
        Unsupported,
    }
}
