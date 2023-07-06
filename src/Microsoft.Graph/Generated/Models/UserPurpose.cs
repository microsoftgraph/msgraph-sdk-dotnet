using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum UserPurpose {
        [EnumMember(Value = "equipment")]
        Equipment,
        [EnumMember(Value = "linked")]
        Linked,
        [EnumMember(Value = "others")]
        Others,
        [EnumMember(Value = "room")]
        Room,
        [EnumMember(Value = "shared")]
        Shared,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "user")]
        User,
    }
}
