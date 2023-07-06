using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ExpirationPatternType {
        [EnumMember(Value = "afterDateTime")]
        AfterDateTime,
        [EnumMember(Value = "afterDuration")]
        AfterDuration,
        [EnumMember(Value = "noExpiration")]
        NoExpiration,
        [EnumMember(Value = "notSpecified")]
        NotSpecified,
    }
}
