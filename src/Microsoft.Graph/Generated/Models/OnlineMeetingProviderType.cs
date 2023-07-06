using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum OnlineMeetingProviderType {
        [EnumMember(Value = "skypeForBusiness")]
        SkypeForBusiness,
        [EnumMember(Value = "skypeForConsumer")]
        SkypeForConsumer,
        [EnumMember(Value = "teamsForBusiness")]
        TeamsForBusiness,
        [EnumMember(Value = "unknown")]
        Unknown,
    }
}
