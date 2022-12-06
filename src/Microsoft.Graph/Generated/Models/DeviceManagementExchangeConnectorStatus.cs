namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public enum DeviceManagementExchangeConnectorStatus {
        /// <summary>No Connector exists.</summary>
        None,
        /// <summary>Pending Connection to the Exchange Environment.</summary>
        ConnectionPending,
        /// <summary>Connected to the Exchange Environment</summary>
        Connected,
        /// <summary>Disconnected from the Exchange Environment</summary>
        Disconnected,
    }
}
