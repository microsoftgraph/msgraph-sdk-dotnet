namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum WebBrowserCookieSettings {
        /// <summary>Browser default value, no intent.</summary>
        BrowserDefault,
        /// <summary>Always block cookies.</summary>
        BlockAlways,
        /// <summary>Allow cookies from current Web site.</summary>
        AllowCurrentWebSite,
        /// <summary>Allow Cookies from websites visited.</summary>
        AllowFromWebsitesVisited,
        /// <summary>Always allow cookies.</summary>
        AllowAlways,
    }
}
