using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum LocationUniqueIdType {
        [EnumMember(Value = "private")]
        @Private,
        [EnumMember(Value = "bing")]
        Bing,
        [EnumMember(Value = "directory")]
        Directory,
        [EnumMember(Value = "locationStore")]
        LocationStore,
        [EnumMember(Value = "unknown")]
        Unknown,
    }
}
