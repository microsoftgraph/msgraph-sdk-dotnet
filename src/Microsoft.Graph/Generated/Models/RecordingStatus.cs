using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RecordingStatus {
        [EnumMember(Value = "failed")]
        Failed,
        [EnumMember(Value = "notRecording")]
        NotRecording,
        [EnumMember(Value = "recording")]
        Recording,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
