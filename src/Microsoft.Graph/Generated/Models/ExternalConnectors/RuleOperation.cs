using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.ExternalConnectors {
    public enum RuleOperation {
        [EnumMember(Value = "equals")]
        @Equals,
        [EnumMember(Value = "contains")]
        Contains,
        [EnumMember(Value = "greaterThan")]
        GreaterThan,
        [EnumMember(Value = "lessThan")]
        LessThan,
        [EnumMember(Value = "notContains")]
        NotContains,
        [EnumMember(Value = "notEquals")]
        NotEquals,
        [EnumMember(Value = "startsWith")]
        StartsWith,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
