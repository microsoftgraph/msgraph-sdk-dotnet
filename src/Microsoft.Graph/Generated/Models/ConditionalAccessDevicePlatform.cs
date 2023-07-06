using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ConditionalAccessDevicePlatform {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "android")]
        Android,
        [EnumMember(Value = "iOS")]
        IOS,
        [EnumMember(Value = "linux")]
        Linux,
        [EnumMember(Value = "macOS")]
        MacOS,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "windows")]
        Windows,
        [EnumMember(Value = "windowsPhone")]
        WindowsPhone,
    }
}
