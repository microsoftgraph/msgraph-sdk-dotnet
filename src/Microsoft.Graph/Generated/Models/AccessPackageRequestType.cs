using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AccessPackageRequestType {
        [EnumMember(Value = "adminAdd")]
        AdminAdd,
        [EnumMember(Value = "adminRemove")]
        AdminRemove,
        [EnumMember(Value = "adminUpdate")]
        AdminUpdate,
        [EnumMember(Value = "notSpecified")]
        NotSpecified,
        [EnumMember(Value = "onBehalfAdd")]
        OnBehalfAdd,
        [EnumMember(Value = "systemAdd")]
        SystemAdd,
        [EnumMember(Value = "systemRemove")]
        SystemRemove,
        [EnumMember(Value = "systemUpdate")]
        SystemUpdate,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "userAdd")]
        UserAdd,
        [EnumMember(Value = "userRemove")]
        UserRemove,
        [EnumMember(Value = "userUpdate")]
        UserUpdate,
    }
}
