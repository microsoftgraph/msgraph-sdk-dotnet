using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum SourceType {
        [EnumMember(Value = "mailbox")]
        Mailbox,
        [EnumMember(Value = "site")]
        Site,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
