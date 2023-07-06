using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum UnifiedRoleManagementPolicyRuleTargetOperations {
        [EnumMember(Value = "remove")]
        @Remove,
        [EnumMember(Value = "activate")]
        Activate,
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "assign")]
        Assign,
        [EnumMember(Value = "deactivate")]
        Deactivate,
        [EnumMember(Value = "extend")]
        Extend,
        [EnumMember(Value = "renew")]
        Renew,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "update")]
        Update,
    }
}
