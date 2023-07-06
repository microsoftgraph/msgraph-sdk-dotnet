using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PartnerTenantType {
        [EnumMember(Value = "breadthPartner")]
        BreadthPartner,
        [EnumMember(Value = "breadthPartnerDelegatedAdmin")]
        BreadthPartnerDelegatedAdmin,
        [EnumMember(Value = "microsoftSupport")]
        MicrosoftSupport,
        [EnumMember(Value = "resellerPartnerDelegatedAdmin")]
        ResellerPartnerDelegatedAdmin,
        [EnumMember(Value = "syndicatePartner")]
        SyndicatePartner,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "valueAddedResellerPartnerDelegatedAdmin")]
        ValueAddedResellerPartnerDelegatedAdmin,
    }
}
