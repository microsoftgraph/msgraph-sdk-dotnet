using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ChatMessageActions {
        [EnumMember(Value = "reactionAdded")]
        ReactionAdded,
        [EnumMember(Value = "reactionRemoved")]
        ReactionRemoved,
        [EnumMember(Value = "actionUndefined")]
        ActionUndefined,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
