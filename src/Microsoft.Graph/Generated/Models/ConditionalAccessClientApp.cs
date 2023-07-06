using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum ConditionalAccessClientApp {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "browser")]
        Browser,
        [EnumMember(Value = "easSupported")]
        EasSupported,
        [EnumMember(Value = "exchangeActiveSync")]
        ExchangeActiveSync,
        [EnumMember(Value = "mobileAppsAndDesktopClients")]
        MobileAppsAndDesktopClients,
        [EnumMember(Value = "other")]
        Other,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
