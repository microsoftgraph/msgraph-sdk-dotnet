using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum IndicatorSource {
        [EnumMember(Value = "public")]
        @Public,
        [EnumMember(Value = "microsoft")]
        Microsoft,
        [EnumMember(Value = "osint")]
        Osint,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
