using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PrintMultipageLayout {
        [EnumMember(Value = "clockwiseFromBottomLeft")]
        ClockwiseFromBottomLeft,
        [EnumMember(Value = "clockwiseFromBottomRight")]
        ClockwiseFromBottomRight,
        [EnumMember(Value = "clockwiseFromTopLeft")]
        ClockwiseFromTopLeft,
        [EnumMember(Value = "clockwiseFromTopRight")]
        ClockwiseFromTopRight,
        [EnumMember(Value = "counterclockwiseFromBottomLeft")]
        CounterclockwiseFromBottomLeft,
        [EnumMember(Value = "counterclockwiseFromBottomRight")]
        CounterclockwiseFromBottomRight,
        [EnumMember(Value = "counterclockwiseFromTopLeft")]
        CounterclockwiseFromTopLeft,
        [EnumMember(Value = "counterclockwiseFromTopRight")]
        CounterclockwiseFromTopRight,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
