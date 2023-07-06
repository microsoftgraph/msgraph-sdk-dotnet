using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum PhoneType {
        [EnumMember(Value = "assistant")]
        Assistant,
        [EnumMember(Value = "business")]
        Business,
        [EnumMember(Value = "businessFax")]
        BusinessFax,
        [EnumMember(Value = "home")]
        Home,
        [EnumMember(Value = "homeFax")]
        HomeFax,
        [EnumMember(Value = "mobile")]
        Mobile,
        [EnumMember(Value = "other")]
        Other,
        [EnumMember(Value = "otherFax")]
        OtherFax,
        [EnumMember(Value = "pager")]
        Pager,
        [EnumMember(Value = "radio")]
        Radio,
    }
}
