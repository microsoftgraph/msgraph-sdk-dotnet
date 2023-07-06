using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ServiceUpdateSeverity {
        [EnumMember(Value = "critical")]
        Critical,
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "normal")]
        Normal,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
