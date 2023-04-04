using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RecipientScopeType {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "internal")]
        Internal,
        [EnumMember(Value = "external")]
        External,
        [EnumMember(Value = "externalPartner")]
        ExternalPartner,
        [EnumMember(Value = "externalNonPartner")]
        ExternalNonPartner,
    }
}
