using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum MeetingRequestType {
        [EnumMember(Value = "fullUpdate")]
        FullUpdate,
        [EnumMember(Value = "informationalUpdate")]
        InformationalUpdate,
        [EnumMember(Value = "newMeetingRequest")]
        NewMeetingRequest,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "outdated")]
        Outdated,
        [EnumMember(Value = "principalWantsCopy")]
        PrincipalWantsCopy,
        [EnumMember(Value = "silentUpdate")]
        SilentUpdate,
    }
}
