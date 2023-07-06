using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum DataSourceHoldStatus {
        [EnumMember(Value = "partial")]
        @Partial,
        [EnumMember(Value = "applied")]
        Applied,
        [EnumMember(Value = "applying")]
        Applying,
        [EnumMember(Value = "notApplied")]
        NotApplied,
        [EnumMember(Value = "removing")]
        Removing,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
