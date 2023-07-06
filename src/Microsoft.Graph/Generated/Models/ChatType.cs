using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ChatType {
        [EnumMember(Value = "group")]
        Group,
        [EnumMember(Value = "meeting")]
        Meeting,
        [EnumMember(Value = "oneOnOne")]
        OneOnOne,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
