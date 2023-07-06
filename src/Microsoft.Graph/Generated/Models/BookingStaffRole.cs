using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BookingStaffRole {
        [EnumMember(Value = "administrator")]
        Administrator,
        [EnumMember(Value = "externalGuest")]
        ExternalGuest,
        [EnumMember(Value = "guest")]
        Guest,
        [EnumMember(Value = "scheduler")]
        Scheduler,
        [EnumMember(Value = "teamMember")]
        TeamMember,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "viewer")]
        Viewer,
    }
}
