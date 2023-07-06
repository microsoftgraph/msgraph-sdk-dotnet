using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.IdentityGovernance {
    public enum WorkflowExecutionType {
        [EnumMember(Value = "onDemand")]
        OnDemand,
        [EnumMember(Value = "scheduled")]
        Scheduled,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
