using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum RegistryHive {
        [EnumMember(Value = "currentConfig")]
        CurrentConfig,
        [EnumMember(Value = "currentUser")]
        CurrentUser,
        [EnumMember(Value = "localMachineSam")]
        LocalMachineSam,
        [EnumMember(Value = "localMachineSecurity")]
        LocalMachineSecurity,
        [EnumMember(Value = "localMachineSoftware")]
        LocalMachineSoftware,
        [EnumMember(Value = "localMachineSystem")]
        LocalMachineSystem,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "usersDefault")]
        UsersDefault,
    }
}
