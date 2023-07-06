using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>The current status of the Exchange Connector.</summary>
    public enum DeviceManagementExchangeConnectorStatus {
        /// <summary>Connected to the Exchange Environment</summary>
        [EnumMember(Value = "connected")]
        Connected,
        /// <summary>Pending Connection to the Exchange Environment.</summary>
        [EnumMember(Value = "connectionPending")]
        ConnectionPending,
        /// <summary>Disconnected from the Exchange Environment</summary>
        [EnumMember(Value = "disconnected")]
        Disconnected,
        /// <summary>No Connector exists.</summary>
        [EnumMember(Value = "none")]
        None,
        /// <summary>Evolvable enumeration sentinel value. Do not use.</summary>
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
