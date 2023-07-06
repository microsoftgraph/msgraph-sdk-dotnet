using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum OnenoteUserRole {
        [EnumMember(Value = "Contributor")]
        Contributor,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Owner")]
        Owner,
        [EnumMember(Value = "Reader")]
        Reader,
    }
}
