using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AllowInvitesFrom {
        [EnumMember(Value = "adminsAndGuestInviters")]
        AdminsAndGuestInviters,
        [EnumMember(Value = "adminsGuestInvitersAndAllMembers")]
        AdminsGuestInvitersAndAllMembers,
        [EnumMember(Value = "everyone")]
        Everyone,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
