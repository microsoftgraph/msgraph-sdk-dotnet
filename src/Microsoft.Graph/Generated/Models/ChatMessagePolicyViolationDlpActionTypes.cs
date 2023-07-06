using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ChatMessagePolicyViolationDlpActionTypes {
        [EnumMember(Value = "blockAccess")]
        BlockAccess,
        [EnumMember(Value = "blockAccessExternal")]
        BlockAccessExternal,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "notifySender")]
        NotifySender,
    }
}
