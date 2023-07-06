using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum EmailRole {
        [EnumMember(Value = "recipient")]
        Recipient,
        [EnumMember(Value = "sender")]
        Sender,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
