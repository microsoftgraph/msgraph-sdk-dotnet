using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Windows Update Notification Display Options</summary>
    public enum WindowsUpdateNotificationDisplayOption {
        /// <summary>Use the default Windows Update notifications.</summary>
        [EnumMember(Value = "defaultNotifications")]
        DefaultNotifications,
        /// <summary>Turn off all notifications, including restart warnings.</summary>
        [EnumMember(Value = "disableAllNotifications")]
        DisableAllNotifications,
        /// <summary>Not configured</summary>
        [EnumMember(Value = "notConfigured")]
        NotConfigured,
        /// <summary>Turn off all notifications, excluding restart warnings.</summary>
        [EnumMember(Value = "restartWarningsOnly")]
        RestartWarningsOnly,
        /// <summary>Evolvable enum member</summary>
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
