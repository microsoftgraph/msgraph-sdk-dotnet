using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum Status {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "deleted")]
        Deleted,
        [EnumMember(Value = "ignored")]
        Ignored,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "updated")]
        Updated,
    }
}
