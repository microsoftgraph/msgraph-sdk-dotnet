using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum MicrosoftAuthenticatorAuthenticationMode {
        [EnumMember(Value = "any")]
        Any,
        [EnumMember(Value = "deviceBasedPush")]
        DeviceBasedPush,
        [EnumMember(Value = "push")]
        Push,
    }
}
