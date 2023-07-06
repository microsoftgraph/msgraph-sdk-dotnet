using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SimulationAttackType {
        [EnumMember(Value = "cloud")]
        Cloud,
        [EnumMember(Value = "endpoint")]
        Endpoint,
        [EnumMember(Value = "social")]
        Social,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
