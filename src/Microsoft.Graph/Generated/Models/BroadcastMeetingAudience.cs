using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BroadcastMeetingAudience {
        [EnumMember(Value = "everyone")]
        Everyone,
        [EnumMember(Value = "organization")]
        Organization,
        [EnumMember(Value = "roleIsAttendee")]
        RoleIsAttendee,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
