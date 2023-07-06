using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RecipientScopeType {
        [EnumMember(Value = "internal")]
        @Internal,
        [EnumMember(Value = "external")]
        External,
        [EnumMember(Value = "externalNonPartner")]
        ExternalNonPartner,
        [EnumMember(Value = "externalPartner")]
        ExternalPartner,
        [EnumMember(Value = "none")]
        None,
    }
}
