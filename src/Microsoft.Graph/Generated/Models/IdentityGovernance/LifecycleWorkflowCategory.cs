using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.IdentityGovernance {
    public enum LifecycleWorkflowCategory {
        [EnumMember(Value = "joiner")]
        Joiner,
        [EnumMember(Value = "leaver")]
        Leaver,
        [EnumMember(Value = "mover")]
        Mover,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
