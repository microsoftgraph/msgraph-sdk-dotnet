using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum WorkforceIntegrationSupportedEntities {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "shift")]
        Shift,
        [EnumMember(Value = "swapRequest")]
        SwapRequest,
        [EnumMember(Value = "userShiftPreferences")]
        UserShiftPreferences,
        [EnumMember(Value = "openShift")]
        OpenShift,
        [EnumMember(Value = "openShiftRequest")]
        OpenShiftRequest,
        [EnumMember(Value = "offerShiftRequest")]
        OfferShiftRequest,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
