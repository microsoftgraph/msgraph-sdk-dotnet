using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum GroupType {
        [EnumMember(Value = "azureAD")]
        AzureAD,
        [EnumMember(Value = "unifiedGroups")]
        UnifiedGroups,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
