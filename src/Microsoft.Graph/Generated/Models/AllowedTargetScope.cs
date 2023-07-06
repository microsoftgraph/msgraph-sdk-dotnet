using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum AllowedTargetScope {
        [EnumMember(Value = "allConfiguredConnectedOrganizationUsers")]
        AllConfiguredConnectedOrganizationUsers,
        [EnumMember(Value = "allDirectoryServicePrincipals")]
        AllDirectoryServicePrincipals,
        [EnumMember(Value = "allDirectoryUsers")]
        AllDirectoryUsers,
        [EnumMember(Value = "allExternalUsers")]
        AllExternalUsers,
        [EnumMember(Value = "allMemberUsers")]
        AllMemberUsers,
        [EnumMember(Value = "notSpecified")]
        NotSpecified,
        [EnumMember(Value = "specificConnectedOrganizationUsers")]
        SpecificConnectedOrganizationUsers,
        [EnumMember(Value = "specificDirectoryServicePrincipals")]
        SpecificDirectoryServicePrincipals,
        [EnumMember(Value = "specificDirectoryUsers")]
        SpecificDirectoryUsers,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
