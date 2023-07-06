using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum LobbyBypassScope {
        [EnumMember(Value = "everyone")]
        Everyone,
        [EnumMember(Value = "invited")]
        Invited,
        [EnumMember(Value = "organization")]
        Organization,
        [EnumMember(Value = "organizationAndFederated")]
        OrganizationAndFederated,
        [EnumMember(Value = "organizationExcludingGuests")]
        OrganizationExcludingGuests,
        [EnumMember(Value = "organizer")]
        Organizer,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
