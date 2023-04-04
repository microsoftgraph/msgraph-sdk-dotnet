using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Contains properties for Windows architecture.</summary>
    public enum WindowsArchitecture {
        /// <summary>No flags set.</summary>
        [EnumMember(Value = "none")]
        None,
        /// <summary>Whether or not the X86 Windows architecture type is supported.</summary>
        [EnumMember(Value = "x86")]
        X86,
        /// <summary>Whether or not the X64 Windows architecture type is supported.</summary>
        [EnumMember(Value = "x64")]
        X64,
        /// <summary>Whether or not the Arm Windows architecture type is supported.</summary>
        [EnumMember(Value = "arm")]
        Arm,
        /// <summary>Whether or not the Neutral Windows architecture type is supported.</summary>
        [EnumMember(Value = "neutral")]
        Neutral,
    }
}
