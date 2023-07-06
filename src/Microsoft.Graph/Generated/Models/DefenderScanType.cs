using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Possible values for system scan type.</summary>
    public enum DefenderScanType {
        /// <summary>System scan disabled.</summary>
        [EnumMember(Value = "disabled")]
        Disabled,
        /// <summary>Full system scan.</summary>
        [EnumMember(Value = "full")]
        Full,
        /// <summary>Quick system scan.</summary>
        [EnumMember(Value = "quick")]
        Quick,
        /// <summary>User Defined, default value, no intent.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
    }
}
