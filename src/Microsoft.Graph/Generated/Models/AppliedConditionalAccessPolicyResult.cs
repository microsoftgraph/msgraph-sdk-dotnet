using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AppliedConditionalAccessPolicyResult {
        [EnumMember(Value = "failure")]
        Failure,
        [EnumMember(Value = "notApplied")]
        NotApplied,
        [EnumMember(Value = "notEnabled")]
        NotEnabled,
        [EnumMember(Value = "success")]
        Success,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
