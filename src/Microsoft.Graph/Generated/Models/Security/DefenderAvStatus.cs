using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum DefenderAvStatus {
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "notReporting")]
        NotReporting,
        [EnumMember(Value = "notSupported")]
        NotSupported,
        [EnumMember(Value = "notUpdated")]
        NotUpdated,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "updated")]
        Updated,
    }
}
