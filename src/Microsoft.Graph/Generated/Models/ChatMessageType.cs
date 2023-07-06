using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ChatMessageType {
        [EnumMember(Value = "chatEvent")]
        ChatEvent,
        [EnumMember(Value = "message")]
        Message,
        [EnumMember(Value = "systemEventMessage")]
        SystemEventMessage,
        [EnumMember(Value = "typing")]
        Typing,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
