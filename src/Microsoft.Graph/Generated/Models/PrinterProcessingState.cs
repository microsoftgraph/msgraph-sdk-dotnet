using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PrinterProcessingState {
        [EnumMember(Value = "idle")]
        Idle,
        [EnumMember(Value = "processing")]
        Processing,
        [EnumMember(Value = "stopped")]
        Stopped,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
