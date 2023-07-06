using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ConditionalAccessPolicyState {
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "enabled")]
        Enabled,
        [EnumMember(Value = "enabledForReportingButNotEnforced")]
        EnabledForReportingButNotEnforced,
    }
}
