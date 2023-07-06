using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum VolumeType {
        [EnumMember(Value = "fixedDataVolume")]
        FixedDataVolume,
        [EnumMember(Value = "operatingSystemVolume")]
        OperatingSystemVolume,
        [EnumMember(Value = "removableDataVolume")]
        RemovableDataVolume,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
