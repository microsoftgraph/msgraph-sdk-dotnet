using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ServiceUpdateCategory {
        [EnumMember(Value = "planForChange")]
        PlanForChange,
        [EnumMember(Value = "preventOrFixIssue")]
        PreventOrFixIssue,
        [EnumMember(Value = "stayInformed")]
        StayInformed,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
