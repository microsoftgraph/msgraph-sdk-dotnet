using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AccessPackageSubjectType {
        [EnumMember(Value = "notSpecified")]
        NotSpecified,
        [EnumMember(Value = "servicePrincipal")]
        ServicePrincipal,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "user")]
        User,
    }
}
