using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum GoogleCloudLocationType {
        [EnumMember(Value = "global")]
        @Global,
        [EnumMember(Value = "regional")]
        Regional,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "zonal")]
        Zonal,
    }
}
