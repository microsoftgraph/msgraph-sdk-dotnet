using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum PurgeType {
        [EnumMember(Value = "permanentlyDeleted")]
        PermanentlyDeleted,
        [EnumMember(Value = "recoverable")]
        Recoverable,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
