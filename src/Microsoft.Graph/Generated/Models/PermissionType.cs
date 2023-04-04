using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PermissionType {
        [EnumMember(Value = "application")]
        Application,
        [EnumMember(Value = "delegated")]
        Delegated,
        [EnumMember(Value = "delegatedUserConsentable")]
        DelegatedUserConsentable,
    }
}
