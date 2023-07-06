using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum UserAccountSecurityType {
        [EnumMember(Value = "administrator")]
        Administrator,
        [EnumMember(Value = "power")]
        Power,
        [EnumMember(Value = "standard")]
        Standard,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
