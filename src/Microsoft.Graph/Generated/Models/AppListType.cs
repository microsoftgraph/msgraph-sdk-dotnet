namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum AppListType {
        /// <summary>Default value, no intent.</summary>
        None,
        /// <summary>The list represents the apps that will be considered compliant (only apps on the list are compliant).</summary>
        AppsInListCompliant,
        /// <summary>The list represents the apps that will be considered non compliant (all apps are compliant except apps on the list).</summary>
        AppsNotInListCompliant,
    }
}
