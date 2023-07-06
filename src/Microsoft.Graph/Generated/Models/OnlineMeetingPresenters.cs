using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum OnlineMeetingPresenters {
        [EnumMember(Value = "everyone")]
        Everyone,
        [EnumMember(Value = "organization")]
        Organization,
        [EnumMember(Value = "organizer")]
        Organizer,
        [EnumMember(Value = "roleIsPresenter")]
        RoleIsPresenter,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
