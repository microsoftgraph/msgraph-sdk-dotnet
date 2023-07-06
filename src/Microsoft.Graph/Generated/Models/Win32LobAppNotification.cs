using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Contains value for notification status.</summary>
    public enum Win32LobAppNotification {
        /// <summary>Hide all notifications.</summary>
        [EnumMember(Value = "hideAll")]
        HideAll,
        /// <summary>Show all notifications.</summary>
        [EnumMember(Value = "showAll")]
        ShowAll,
        /// <summary>Only show restart notification and suppress other notifications.</summary>
        [EnumMember(Value = "showReboot")]
        ShowReboot,
    }
}
