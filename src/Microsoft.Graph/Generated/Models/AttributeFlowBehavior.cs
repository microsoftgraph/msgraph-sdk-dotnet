using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AttributeFlowBehavior {
        [EnumMember(Value = "FlowAlways")]
        FlowAlways,
        [EnumMember(Value = "FlowWhenChanged")]
        FlowWhenChanged,
    }
}
