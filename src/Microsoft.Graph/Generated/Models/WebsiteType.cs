using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum WebsiteType {
        [EnumMember(Value = "blog")]
        Blog,
        [EnumMember(Value = "home")]
        Home,
        [EnumMember(Value = "other")]
        Other,
        [EnumMember(Value = "profile")]
        Profile,
        [EnumMember(Value = "work")]
        Work,
    }
}
