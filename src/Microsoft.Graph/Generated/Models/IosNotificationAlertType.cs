using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Notification Settings Alert Type.</summary>
    public enum IosNotificationAlertType {
        /// <summary>Banner.</summary>
        [EnumMember(Value = "banner")]
        Banner,
        /// <summary>Device default value, no intent.</summary>
        [EnumMember(Value = "deviceDefault")]
        DeviceDefault,
        /// <summary>Modal.</summary>
        [EnumMember(Value = "modal")]
        Modal,
        /// <summary>None.</summary>
        [EnumMember(Value = "none")]
        None,
    }
}
