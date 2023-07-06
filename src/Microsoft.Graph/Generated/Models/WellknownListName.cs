using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum WellknownListName {
        [EnumMember(Value = "defaultList")]
        DefaultList,
        [EnumMember(Value = "flaggedEmails")]
        FlaggedEmails,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
