using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum EducationUserRole {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "student")]
        Student,
        [EnumMember(Value = "teacher")]
        Teacher,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
