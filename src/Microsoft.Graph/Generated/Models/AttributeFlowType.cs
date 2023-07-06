using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AttributeFlowType {
        [EnumMember(Value = "Always")]
        Always,
        [EnumMember(Value = "AttributeAddOnly")]
        AttributeAddOnly,
        [EnumMember(Value = "MultiValueAddOnly")]
        MultiValueAddOnly,
        [EnumMember(Value = "ObjectAddOnly")]
        ObjectAddOnly,
        [EnumMember(Value = "ValueAddOnly")]
        ValueAddOnly,
    }
}
