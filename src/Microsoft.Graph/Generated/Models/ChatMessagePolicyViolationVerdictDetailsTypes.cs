using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ChatMessagePolicyViolationVerdictDetailsTypes {
        [EnumMember(Value = "allowFalsePositiveOverride")]
        AllowFalsePositiveOverride,
        [EnumMember(Value = "allowOverrideWithJustification")]
        AllowOverrideWithJustification,
        [EnumMember(Value = "allowOverrideWithoutJustification")]
        AllowOverrideWithoutJustification,
        [EnumMember(Value = "none")]
        None,
    }
}
