using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Auto restart required notification dismissal method</summary>
    public enum AutoRestartNotificationDismissalMethod {
        /// <summary>Auto dismissal Indicates that the notification is automatically dismissed without user intervention</summary>
        [EnumMember(Value = "automatic")]
        Automatic,
        /// <summary>Not configured</summary>
        [EnumMember(Value = "notConfigured")]
        NotConfigured,
        /// <summary>Evolvable enum member</summary>
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        /// <summary>User dismissal. Allows the user to dismiss the notification</summary>
        [EnumMember(Value = "user")]
        User,
    }
}
