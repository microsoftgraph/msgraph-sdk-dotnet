using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BookingsAvailabilityStatus {
        [EnumMember(Value = "available")]
        Available,
        [EnumMember(Value = "busy")]
        Busy,
        [EnumMember(Value = "outOfOffice")]
        OutOfOffice,
        [EnumMember(Value = "slotsAvailable")]
        SlotsAvailable,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
