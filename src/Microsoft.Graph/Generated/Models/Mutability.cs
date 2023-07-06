using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum Mutability {
        [EnumMember(Value = "ReadOnly")]
        @ReadOnly,
        [EnumMember(Value = "Immutable")]
        Immutable,
        [EnumMember(Value = "ReadWrite")]
        ReadWrite,
        [EnumMember(Value = "WriteOnly")]
        WriteOnly,
    }
}
