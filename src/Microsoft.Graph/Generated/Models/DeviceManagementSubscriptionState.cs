using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Tenant mobile device management subscription state.</summary>
    public enum DeviceManagementSubscriptionState {
        /// <summary>Active</summary>
        [EnumMember(Value = "active")]
        Active,
        /// <summary>Blocked</summary>
        [EnumMember(Value = "blocked")]
        Blocked,
        /// <summary>Deleted</summary>
        [EnumMember(Value = "deleted")]
        Deleted,
        /// <summary>Disabled</summary>
        [EnumMember(Value = "disabled")]
        Disabled,
        /// <summary>LockedOut</summary>
        [EnumMember(Value = "lockedOut")]
        LockedOut,
        /// <summary>Pending</summary>
        [EnumMember(Value = "pending")]
        Pending,
        /// <summary>Warning</summary>
        [EnumMember(Value = "warning")]
        Warning,
    }
}
