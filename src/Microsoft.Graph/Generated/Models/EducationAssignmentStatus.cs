using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum EducationAssignmentStatus {
        [EnumMember(Value = "assigned")]
        Assigned,
        [EnumMember(Value = "draft")]
        Draft,
        [EnumMember(Value = "published")]
        Published,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
