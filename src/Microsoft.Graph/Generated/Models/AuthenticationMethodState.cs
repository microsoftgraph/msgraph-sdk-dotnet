using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AuthenticationMethodState {
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "enabled")]
        Enabled,
    }
}
