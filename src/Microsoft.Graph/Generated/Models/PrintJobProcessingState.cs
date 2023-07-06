using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PrintJobProcessingState {
        [EnumMember(Value = "aborted")]
        Aborted,
        [EnumMember(Value = "canceled")]
        Canceled,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "paused")]
        Paused,
        [EnumMember(Value = "pending")]
        Pending,
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
