using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum FreeBusyStatus {
        [EnumMember(Value = "busy")]
        Busy,
        [EnumMember(Value = "free")]
        Free,
        [EnumMember(Value = "oof")]
        Oof,
        [EnumMember(Value = "tentative")]
        Tentative,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "workingElsewhere")]
        WorkingElsewhere,
    }
}
