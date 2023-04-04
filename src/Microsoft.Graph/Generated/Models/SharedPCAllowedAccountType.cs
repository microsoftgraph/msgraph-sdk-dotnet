using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Type of accounts that are allowed to share the PC.</summary>
    public enum SharedPCAllowedAccountType {
        /// <summary>Only guest accounts.</summary>
        [EnumMember(Value = "guest")]
        Guest,
        /// <summary>Only domain-joined accounts.</summary>
        [EnumMember(Value = "domain")]
        Domain,
    }
}
