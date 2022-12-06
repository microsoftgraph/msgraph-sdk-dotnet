namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum DiagnosticDataSubmissionMode {
        /// <summary>Allow the user to set.</summary>
        UserDefined,
        /// <summary>No telemetry data is sent from OS components. Note: This value is only applicable to enterprise and server devices. Using this setting on other devices is equivalent to setting the value of 1.</summary>
        None,
        /// <summary>Sends basic telemetry data.</summary>
        Basic,
        /// <summary>Sends enhanced telemetry data including usage and insights data.</summary>
        Enhanced,
        /// <summary>Sends full telemetry data including diagnostic data, such as system state.</summary>
        Full,
    }
}
