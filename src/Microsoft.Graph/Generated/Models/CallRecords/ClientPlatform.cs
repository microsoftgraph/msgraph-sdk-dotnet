using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public enum ClientPlatform {
        [EnumMember(Value = "android")]
        Android,
        [EnumMember(Value = "holoLens")]
        HoloLens,
        [EnumMember(Value = "iOS")]
        IOS,
        [EnumMember(Value = "ipPhone")]
        IpPhone,
        [EnumMember(Value = "macOS")]
        MacOS,
        [EnumMember(Value = "roomSystem")]
        RoomSystem,
        [EnumMember(Value = "surfaceHub")]
        SurfaceHub,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "web")]
        Web,
        [EnumMember(Value = "windows")]
        Windows,
    }
}
