using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum DiskType {
        /// <summary>Enum member for unknown or default diskType</summary>
        [EnumMember(Value = "unknown")]
        Unknown,
        /// <summary>Enum member for HDD devices</summary>
        [EnumMember(Value = "hdd")]
        Hdd,
        /// <summary>Enum member for SSD devices</summary>
        [EnumMember(Value = "ssd")]
        Ssd,
        /// <summary>Evolvable enum member</summary>
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
