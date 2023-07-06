using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.IdentityGovernance {
    public enum ValueTypeObject {
        [EnumMember(Value = "bool")]
        @Bool,
        [EnumMember(Value = "enum")]
        @Enum,
        [EnumMember(Value = "int")]
        @Int,
        [EnumMember(Value = "string")]
        @String,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
