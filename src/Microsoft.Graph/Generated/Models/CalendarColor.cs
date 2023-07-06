using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CalendarColor {
        [EnumMember(Value = "auto")]
        Auto,
        [EnumMember(Value = "lightBlue")]
        LightBlue,
        [EnumMember(Value = "lightBrown")]
        LightBrown,
        [EnumMember(Value = "lightGray")]
        LightGray,
        [EnumMember(Value = "lightGreen")]
        LightGreen,
        [EnumMember(Value = "lightOrange")]
        LightOrange,
        [EnumMember(Value = "lightPink")]
        LightPink,
        [EnumMember(Value = "lightRed")]
        LightRed,
        [EnumMember(Value = "lightTeal")]
        LightTeal,
        [EnumMember(Value = "lightYellow")]
        LightYellow,
        [EnumMember(Value = "maxColor")]
        MaxColor,
    }
}
