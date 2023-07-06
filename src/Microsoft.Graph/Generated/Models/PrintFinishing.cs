using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PrintFinishing {
        [EnumMember(Value = "bind")]
        Bind,
        [EnumMember(Value = "cover")]
        Cover,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "punch")]
        Punch,
        [EnumMember(Value = "saddleStitch")]
        SaddleStitch,
        [EnumMember(Value = "staple")]
        Staple,
        [EnumMember(Value = "stapleBottomLeft")]
        StapleBottomLeft,
        [EnumMember(Value = "stapleBottomRight")]
        StapleBottomRight,
        [EnumMember(Value = "stapleDualBottom")]
        StapleDualBottom,
        [EnumMember(Value = "stapleDualLeft")]
        StapleDualLeft,
        [EnumMember(Value = "stapleDualRight")]
        StapleDualRight,
        [EnumMember(Value = "stapleDualTop")]
        StapleDualTop,
        [EnumMember(Value = "stapleTopLeft")]
        StapleTopLeft,
        [EnumMember(Value = "stapleTopRight")]
        StapleTopRight,
        [EnumMember(Value = "stitchBottomEdge")]
        StitchBottomEdge,
        [EnumMember(Value = "stitchEdge")]
        StitchEdge,
        [EnumMember(Value = "stitchLeftEdge")]
        StitchLeftEdge,
        [EnumMember(Value = "stitchRightEdge")]
        StitchRightEdge,
        [EnumMember(Value = "stitchTopEdge")]
        StitchTopEdge,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
