using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ScheduleEntityTheme {
        [EnumMember(Value = "blue")]
        Blue,
        [EnumMember(Value = "darkBlue")]
        DarkBlue,
        [EnumMember(Value = "darkGreen")]
        DarkGreen,
        [EnumMember(Value = "darkPink")]
        DarkPink,
        [EnumMember(Value = "darkPurple")]
        DarkPurple,
        [EnumMember(Value = "darkYellow")]
        DarkYellow,
        [EnumMember(Value = "gray")]
        Gray,
        [EnumMember(Value = "green")]
        Green,
        [EnumMember(Value = "pink")]
        Pink,
        [EnumMember(Value = "purple")]
        Purple,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "white")]
        White,
        [EnumMember(Value = "yellow")]
        Yellow,
    }
}
