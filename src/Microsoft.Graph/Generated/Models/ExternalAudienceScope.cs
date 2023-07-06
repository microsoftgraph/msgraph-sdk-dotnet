using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ExternalAudienceScope {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "contactsOnly")]
        ContactsOnly,
        [EnumMember(Value = "none")]
        None,
    }
}
