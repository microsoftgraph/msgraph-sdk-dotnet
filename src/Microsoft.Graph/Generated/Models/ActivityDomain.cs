using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ActivityDomain {
        [EnumMember(Value = "personal")]
        Personal,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unrestricted")]
        Unrestricted,
        [EnumMember(Value = "work")]
        Work,
    }
}
