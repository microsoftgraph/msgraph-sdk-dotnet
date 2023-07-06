using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PromptLoginBehavior {
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "nativeSupport")]
        NativeSupport,
        [EnumMember(Value = "translateToFreshPasswordAuthentication")]
        TranslateToFreshPasswordAuthentication,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
