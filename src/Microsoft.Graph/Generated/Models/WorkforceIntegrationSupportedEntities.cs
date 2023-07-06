using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum WorkforceIntegrationSupportedEntities {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "offerShiftRequest")]
        OfferShiftRequest,
        [EnumMember(Value = "openShift")]
        OpenShift,
        [EnumMember(Value = "openShiftRequest")]
        OpenShiftRequest,
        [EnumMember(Value = "shift")]
        Shift,
        [EnumMember(Value = "swapRequest")]
        SwapRequest,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "userShiftPreferences")]
        UserShiftPreferences,
    }
}
