using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SecurityResourceType {
        [EnumMember(Value = "attacked")]
        Attacked,
        [EnumMember(Value = "related")]
        Related,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
