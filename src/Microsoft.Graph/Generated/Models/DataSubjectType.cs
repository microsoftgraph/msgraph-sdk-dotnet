using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum DataSubjectType {
        [EnumMember(Value = "currentEmployee")]
        CurrentEmployee,
        [EnumMember(Value = "customer")]
        Customer,
        [EnumMember(Value = "faculty")]
        Faculty,
        [EnumMember(Value = "formerEmployee")]
        FormerEmployee,
        [EnumMember(Value = "other")]
        Other,
        [EnumMember(Value = "prospectiveEmployee")]
        ProspectiveEmployee,
        [EnumMember(Value = "student")]
        Student,
        [EnumMember(Value = "teacher")]
        Teacher,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
