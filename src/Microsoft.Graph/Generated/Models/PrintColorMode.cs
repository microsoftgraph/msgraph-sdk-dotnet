using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PrintColorMode {
        [EnumMember(Value = "auto")]
        Auto,
        [EnumMember(Value = "blackAndWhite")]
        BlackAndWhite,
        [EnumMember(Value = "color")]
        Color,
        [EnumMember(Value = "grayscale")]
        Grayscale,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
