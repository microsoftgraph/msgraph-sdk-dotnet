namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
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
