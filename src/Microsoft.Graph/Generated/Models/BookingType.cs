using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum BookingType {
        [EnumMember(Value = "reserved")]
        Reserved,
        [EnumMember(Value = "standard")]
        Standard,
        [EnumMember(Value = "unknown")]
        Unknown,
    }
}
