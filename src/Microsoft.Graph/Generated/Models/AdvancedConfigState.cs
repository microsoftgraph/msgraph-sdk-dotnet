using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AdvancedConfigState {
        [EnumMember(Value = "default")]
        @Default,
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "enabled")]
        Enabled,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
