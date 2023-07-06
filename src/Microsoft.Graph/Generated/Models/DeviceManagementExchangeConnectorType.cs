using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>The type of Exchange Connector.</summary>
    public enum DeviceManagementExchangeConnectorType {
        /// <summary>Connects to O365 Dedicated Exchange environment.</summary>
        [EnumMember(Value = "dedicated")]
        Dedicated,
        /// <summary>Connects to O365 multi-tenant Exchange environment</summary>
        [EnumMember(Value = "hosted")]
        Hosted,
        /// <summary>Connects to on-premises Exchange Environment.</summary>
        [EnumMember(Value = "onPremises")]
        OnPremises,
        /// <summary>Intune Service connects directly to O365 multi-tenant Exchange environment</summary>
        [EnumMember(Value = "serviceToService")]
        ServiceToService,
        /// <summary>Evolvable enumeration sentinel value. Do not use.</summary>
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
