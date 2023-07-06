using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.Security {
    public enum DeviceHealthStatus {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "impairedCommunication")]
        ImpairedCommunication,
        [EnumMember(Value = "inactive")]
        Inactive,
        [EnumMember(Value = "noSensorData")]
        NoSensorData,
        [EnumMember(Value = "noSensorDataImpairedCommunication")]
        NoSensorDataImpairedCommunication,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
