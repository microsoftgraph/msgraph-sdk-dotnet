using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum SharingDomainRestrictionMode {
        [EnumMember(Value = "allowList")]
        AllowList,
        [EnumMember(Value = "blockList")]
        BlockList,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
