using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RiskDetectionTimingType {
        [EnumMember(Value = "nearRealtime")]
        NearRealtime,
        [EnumMember(Value = "notDefined")]
        NotDefined,
        [EnumMember(Value = "offline")]
        Offline,
        [EnumMember(Value = "realtime")]
        Realtime,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
