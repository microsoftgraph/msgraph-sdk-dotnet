using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.ExternalConnectors {
    public enum ConnectionState {
        [EnumMember(Value = "draft")]
        Draft,
        [EnumMember(Value = "limitExceeded")]
        LimitExceeded,
        [EnumMember(Value = "obsolete")]
        Obsolete,
        [EnumMember(Value = "ready")]
        Ready,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
