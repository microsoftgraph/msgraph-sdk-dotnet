using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Type of start menu app list visibility.</summary>
    public enum WindowsStartMenuAppListVisibilityType {
        /// <summary>User defined. Default value.</summary>
        [EnumMember(Value = "userDefined")]
        UserDefined,
        /// <summary>Collapse the app list on the start menu.</summary>
        [EnumMember(Value = "collapse")]
        Collapse,
        /// <summary>Removes the app list entirely from the start menu.</summary>
        [EnumMember(Value = "remove")]
        Remove,
        /// <summary>Disables the corresponding toggle (Collapse or Remove) in the Settings app.</summary>
        [EnumMember(Value = "disableSettingsApp")]
        DisableSettingsApp,
    }
}
