using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PermissionClassificationType {
        [EnumMember(Value = "high")]
        High,
        [EnumMember(Value = "low")]
        Low,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
