namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public enum ManagementAgentType {
        /// <summary>The device is managed by Exchange server.</summary>
        Eas,
        /// <summary>The device is managed by Intune MDM.</summary>
        Mdm,
        /// <summary>The device is managed by both Exchange server and Intune MDM.</summary>
        EasMdm,
        /// <summary>Intune client managed.</summary>
        IntuneClient,
        /// <summary>The device is EAS and Intune client dual managed.</summary>
        EasIntuneClient,
        /// <summary>The device is managed by Configuration Manager.</summary>
        ConfigurationManagerClient,
        /// <summary>The device is managed by Configuration Manager and MDM.</summary>
        ConfigurationManagerClientMdm,
        /// <summary>The device is managed by Configuration Manager, MDM and Eas.</summary>
        ConfigurationManagerClientMdmEas,
        /// <summary>Unknown management agent type.</summary>
        Unknown,
        /// <summary>The device attributes are fetched from Jamf.</summary>
        Jamf,
        /// <summary>The device is managed by Google&apos;s CloudDPC.</summary>
        GoogleCloudDevicePolicyController,
        /// <summary>This device is managed by Microsoft 365 through Intune.</summary>
        Microsoft365ManagedMdm,
        MsSense,
    }
}
