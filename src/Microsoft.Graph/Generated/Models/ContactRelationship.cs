using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ContactRelationship {
        [EnumMember(Value = "aide")]
        Aide,
        [EnumMember(Value = "child")]
        Child,
        [EnumMember(Value = "doctor")]
        Doctor,
        [EnumMember(Value = "guardian")]
        Guardian,
        [EnumMember(Value = "other")]
        Other,
        [EnumMember(Value = "parent")]
        Parent,
        [EnumMember(Value = "relative")]
        Relative,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
