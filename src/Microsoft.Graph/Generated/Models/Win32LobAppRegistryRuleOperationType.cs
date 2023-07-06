using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Contains all supported registry data detection type.</summary>
    public enum Win32LobAppRegistryRuleOperationType {
        /// <summary>String value type.</summary>
        [EnumMember(Value = "string")]
        @String,
        /// <summary>The specified registry key or value does not exist.</summary>
        [EnumMember(Value = "doesNotExist")]
        DoesNotExist,
        /// <summary>The specified registry key or value exists.</summary>
        [EnumMember(Value = "exists")]
        Exists,
        /// <summary>Integer value type.</summary>
        [EnumMember(Value = "integer")]
        Integer,
        /// <summary>Not configured.</summary>
        [EnumMember(Value = "notConfigured")]
        NotConfigured,
        /// <summary>Version value type.</summary>
        [EnumMember(Value = "version")]
        Version,
    }
}
