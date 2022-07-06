namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public enum ComplianceStatus {
        Unknown,
        NotApplicable,
        Compliant,
        Remediated,
        NonCompliant,
        Error,
        Conflict,
        NotAssigned,
    }
}
