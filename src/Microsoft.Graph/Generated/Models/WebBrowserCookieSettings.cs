using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>Web Browser Cookie Settings.</summary>
    public enum WebBrowserCookieSettings {
        /// <summary>Always allow cookies.</summary>
        [EnumMember(Value = "allowAlways")]
        AllowAlways,
        /// <summary>Allow cookies from current Web site.</summary>
        [EnumMember(Value = "allowCurrentWebSite")]
        AllowCurrentWebSite,
        /// <summary>Allow Cookies from websites visited.</summary>
        [EnumMember(Value = "allowFromWebsitesVisited")]
        AllowFromWebsitesVisited,
        /// <summary>Always block cookies.</summary>
        [EnumMember(Value = "blockAlways")]
        BlockAlways,
        /// <summary>Browser default value, no intent.</summary>
        [EnumMember(Value = "browserDefault")]
        BrowserDefault,
    }
}
