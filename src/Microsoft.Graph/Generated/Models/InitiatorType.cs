using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum InitiatorType {
        [EnumMember(Value = "application")]
        Application,
        [EnumMember(Value = "system")]
        System,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "user")]
        User,
    }
}
