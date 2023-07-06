using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SynchronizationStatusCode {
        [EnumMember(Value = "Active")]
        Active,
        [EnumMember(Value = "NotConfigured")]
        NotConfigured,
        [EnumMember(Value = "NotRun")]
        NotRun,
        [EnumMember(Value = "Paused")]
        Paused,
        [EnumMember(Value = "Quarantine")]
        Quarantine,
    }
}
