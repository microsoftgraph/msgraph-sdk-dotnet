using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Generic visibility state.</summary>
    public enum VisibilitySetting {
        /// <summary>Hide.</summary>
        [EnumMember(Value = "hide")]
        Hide,
        /// <summary>Not configured.</summary>
        [EnumMember(Value = "notConfigured")]
        NotConfigured,
        /// <summary>Show.</summary>
        [EnumMember(Value = "show")]
        Show,
    }
}
