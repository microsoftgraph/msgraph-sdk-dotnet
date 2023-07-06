using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Type of display modes for the start menu.</summary>
    public enum WindowsStartMenuModeType {
        /// <summary>Full screen.</summary>
        [EnumMember(Value = "fullScreen")]
        FullScreen,
        /// <summary>Non-full screen.</summary>
        [EnumMember(Value = "nonFullScreen")]
        NonFullScreen,
        /// <summary>User defined. Default value.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
    }
}
