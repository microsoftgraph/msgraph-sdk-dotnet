using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ChatMessagePolicyViolationUserActionTypes {
        [EnumMember(Value = "override")]
        @Override,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "reportFalsePositive")]
        ReportFalsePositive,
    }
}
