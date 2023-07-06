using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TeamworkConversationIdentityType {
        [EnumMember(Value = "channel")]
        Channel,
        [EnumMember(Value = "chat")]
        Chat,
        [EnumMember(Value = "team")]
        Team,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
