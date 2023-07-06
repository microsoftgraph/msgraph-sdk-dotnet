using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public enum MediaStreamDirection {
        [EnumMember(Value = "calleeToCaller")]
        CalleeToCaller,
        [EnumMember(Value = "callerToCallee")]
        CallerToCallee,
    }
}
