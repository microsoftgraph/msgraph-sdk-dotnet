using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum EducationExternalSource {
        [EnumMember(Value = "manual")]
        Manual,
        [EnumMember(Value = "sis")]
        Sis,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
