using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AuthenticationMethodKeyStrength {
        [EnumMember(Value = "normal")]
        Normal,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "weak")]
        Weak,
    }
}
