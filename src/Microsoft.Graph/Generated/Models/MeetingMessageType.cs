using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum MeetingMessageType {
        [EnumMember(Value = "meetingAccepted")]
        MeetingAccepted,
        [EnumMember(Value = "meetingCancelled")]
        MeetingCancelled,
        [EnumMember(Value = "meetingDeclined")]
        MeetingDeclined,
        [EnumMember(Value = "meetingRequest")]
        MeetingRequest,
        [EnumMember(Value = "meetingTenativelyAccepted")]
        MeetingTenativelyAccepted,
        [EnumMember(Value = "none")]
        None,
    }
}
