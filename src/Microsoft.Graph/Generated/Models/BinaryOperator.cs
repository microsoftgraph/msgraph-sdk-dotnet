using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BinaryOperator {
        [EnumMember(Value = "and")]
        @And,
        [EnumMember(Value = "or")]
        @Or,
    }
}
