using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum EducationAddedStudentAction {
        [EnumMember(Value = "assignIfOpen")]
        AssignIfOpen,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
