using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum CallRecordingStatus {
        [EnumMember(Value = "chunkFinished")]
        ChunkFinished,
        [EnumMember(Value = "failure")]
        Failure,
        [EnumMember(Value = "initial")]
        Initial,
        [EnumMember(Value = "success")]
        Success,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
