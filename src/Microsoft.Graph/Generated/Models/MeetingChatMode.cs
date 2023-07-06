using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum MeetingChatMode {
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "enabled")]
        Enabled,
        [EnumMember(Value = "limited")]
        Limited,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
