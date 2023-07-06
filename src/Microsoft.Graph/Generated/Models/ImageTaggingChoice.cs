using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ImageTaggingChoice {
        [EnumMember(Value = "basic")]
        Basic,
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "enhanced")]
        Enhanced,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
