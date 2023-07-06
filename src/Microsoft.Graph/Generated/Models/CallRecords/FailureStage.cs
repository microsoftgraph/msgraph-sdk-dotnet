using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public enum FailureStage {
        [EnumMember(Value = "callSetup")]
        CallSetup,
        [EnumMember(Value = "midcall")]
        Midcall,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
