using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TeamSpecialization {
        [EnumMember(Value = "educationClass")]
        EducationClass,
        [EnumMember(Value = "educationProfessionalLearningCommunity")]
        EducationProfessionalLearningCommunity,
        [EnumMember(Value = "educationStaff")]
        EducationStaff,
        [EnumMember(Value = "educationStandard")]
        EducationStandard,
        [EnumMember(Value = "healthcareCareCoordination")]
        HealthcareCareCoordination,
        [EnumMember(Value = "healthcareStandard")]
        HealthcareStandard,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
