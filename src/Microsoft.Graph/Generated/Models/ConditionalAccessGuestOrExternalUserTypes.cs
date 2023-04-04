using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ConditionalAccessGuestOrExternalUserTypes {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "internalGuest")]
        InternalGuest,
        [EnumMember(Value = "b2bCollaborationGuest")]
        B2bCollaborationGuest,
        [EnumMember(Value = "b2bCollaborationMember")]
        B2bCollaborationMember,
        [EnumMember(Value = "b2bDirectConnectUser")]
        B2bDirectConnectUser,
        [EnumMember(Value = "otherExternalUser")]
        OtherExternalUser,
        [EnumMember(Value = "serviceProvider")]
        ServiceProvider,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
