using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public enum PstnCallDurationSource {
        [EnumMember(Value = "operator")]
        @Operator,
        [EnumMember(Value = "microsoft")]
        Microsoft,
    }
}
