using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Contains properties for Windows device type.</summary>
    public enum WindowsDeviceType {
        /// <summary>No flags set.</summary>
        [EnumMember(Value = "none")]
        None,
        /// <summary>Whether or not the Desktop Windows device type is supported.</summary>
        [EnumMember(Value = "desktop")]
        Desktop,
        /// <summary>Whether or not the Mobile Windows device type is supported.</summary>
        [EnumMember(Value = "mobile")]
        Mobile,
        /// <summary>Whether or not the Holographic Windows device type is supported.</summary>
        [EnumMember(Value = "holographic")]
        Holographic,
        /// <summary>Whether or not the Team Windows device type is supported.</summary>
        [EnumMember(Value = "team")]
        Team,
    }
}
