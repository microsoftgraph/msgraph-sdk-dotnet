using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Possible values of a property</summary>
    public enum Enablement {
        /// <summary>Disables the setting on the device.</summary>
        [EnumMember(Value = "disabled")]
        Disabled,
        /// <summary>Enables the setting on the device.</summary>
        [EnumMember(Value = "enabled")]
        Enabled,
        /// <summary>Device default value, no intent.</summary>
        [EnumMember(Value = "notConfigured")]
        NotConfigured,
    }
}
