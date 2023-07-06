using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PrintOrientation {
        [EnumMember(Value = "landscape")]
        Landscape,
        [EnumMember(Value = "portrait")]
        Portrait,
        [EnumMember(Value = "reverseLandscape")]
        ReverseLandscape,
        [EnumMember(Value = "reversePortrait")]
        ReversePortrait,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
