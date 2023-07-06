using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ProcessIntegrityLevel {
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "system")]
        System,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "untrusted")]
        Untrusted,
    }
}
