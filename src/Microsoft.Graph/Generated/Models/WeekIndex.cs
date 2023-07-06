using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum WeekIndex {
        [EnumMember(Value = "first")]
        First,
        [EnumMember(Value = "fourth")]
        Fourth,
        [EnumMember(Value = "last")]
        Last,
        [EnumMember(Value = "second")]
        Second,
        [EnumMember(Value = "third")]
        Third,
    }
}
