using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public enum ProductFamily {
        [EnumMember(Value = "azureCommunicationServices")]
        AzureCommunicationServices,
        [EnumMember(Value = "lync")]
        Lync,
        [EnumMember(Value = "skypeForBusiness")]
        SkypeForBusiness,
        [EnumMember(Value = "teams")]
        Teams,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
