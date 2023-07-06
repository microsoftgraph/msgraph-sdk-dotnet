using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum IncludedUserRoles {
        [EnumMember(Value = "admin")]
        Admin,
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "privilegedAdmin")]
        PrivilegedAdmin,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "user")]
        User,
    }
}
