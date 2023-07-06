using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum TokenIssuerType {
        [EnumMember(Value = "ADFederationServices")]
        ADFederationServices,
        [EnumMember(Value = "ADFederationServicesMFAAdapter")]
        ADFederationServicesMFAAdapter,
        [EnumMember(Value = "AzureAD")]
        AzureAD,
        [EnumMember(Value = "AzureADBackupAuth")]
        AzureADBackupAuth,
        [EnumMember(Value = "NPSExtension")]
        NPSExtension,
        [EnumMember(Value = "UnknownFutureValue")]
        UnknownFutureValue,
    }
}
