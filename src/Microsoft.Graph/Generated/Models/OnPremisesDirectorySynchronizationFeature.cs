using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class OnPremisesDirectorySynchronizationFeature : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The blockCloudObjectTakeoverThroughHardMatchEnabled property</summary>
        public bool? BlockCloudObjectTakeoverThroughHardMatchEnabled {
            get { return BackingStore?.Get<bool?>("blockCloudObjectTakeoverThroughHardMatchEnabled"); }
            set { BackingStore?.Set("blockCloudObjectTakeoverThroughHardMatchEnabled", value); }
        }
        /// <summary>The blockSoftMatchEnabled property</summary>
        public bool? BlockSoftMatchEnabled {
            get { return BackingStore?.Get<bool?>("blockSoftMatchEnabled"); }
            set { BackingStore?.Set("blockSoftMatchEnabled", value); }
        }
        /// <summary>The bypassDirSyncOverridesEnabled property</summary>
        public bool? BypassDirSyncOverridesEnabled {
            get { return BackingStore?.Get<bool?>("bypassDirSyncOverridesEnabled"); }
            set { BackingStore?.Set("bypassDirSyncOverridesEnabled", value); }
        }
        /// <summary>The cloudPasswordPolicyForPasswordSyncedUsersEnabled property</summary>
        public bool? CloudPasswordPolicyForPasswordSyncedUsersEnabled {
            get { return BackingStore?.Get<bool?>("cloudPasswordPolicyForPasswordSyncedUsersEnabled"); }
            set { BackingStore?.Set("cloudPasswordPolicyForPasswordSyncedUsersEnabled", value); }
        }
        /// <summary>The concurrentCredentialUpdateEnabled property</summary>
        public bool? ConcurrentCredentialUpdateEnabled {
            get { return BackingStore?.Get<bool?>("concurrentCredentialUpdateEnabled"); }
            set { BackingStore?.Set("concurrentCredentialUpdateEnabled", value); }
        }
        /// <summary>The concurrentOrgIdProvisioningEnabled property</summary>
        public bool? ConcurrentOrgIdProvisioningEnabled {
            get { return BackingStore?.Get<bool?>("concurrentOrgIdProvisioningEnabled"); }
            set { BackingStore?.Set("concurrentOrgIdProvisioningEnabled", value); }
        }
        /// <summary>The deviceWritebackEnabled property</summary>
        public bool? DeviceWritebackEnabled {
            get { return BackingStore?.Get<bool?>("deviceWritebackEnabled"); }
            set { BackingStore?.Set("deviceWritebackEnabled", value); }
        }
        /// <summary>The directoryExtensionsEnabled property</summary>
        public bool? DirectoryExtensionsEnabled {
            get { return BackingStore?.Get<bool?>("directoryExtensionsEnabled"); }
            set { BackingStore?.Set("directoryExtensionsEnabled", value); }
        }
        /// <summary>The fopeConflictResolutionEnabled property</summary>
        public bool? FopeConflictResolutionEnabled {
            get { return BackingStore?.Get<bool?>("fopeConflictResolutionEnabled"); }
            set { BackingStore?.Set("fopeConflictResolutionEnabled", value); }
        }
        /// <summary>The groupWriteBackEnabled property</summary>
        public bool? GroupWriteBackEnabled {
            get { return BackingStore?.Get<bool?>("groupWriteBackEnabled"); }
            set { BackingStore?.Set("groupWriteBackEnabled", value); }
        }
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>The passwordSyncEnabled property</summary>
        public bool? PasswordSyncEnabled {
            get { return BackingStore?.Get<bool?>("passwordSyncEnabled"); }
            set { BackingStore?.Set("passwordSyncEnabled", value); }
        }
        /// <summary>The passwordWritebackEnabled property</summary>
        public bool? PasswordWritebackEnabled {
            get { return BackingStore?.Get<bool?>("passwordWritebackEnabled"); }
            set { BackingStore?.Set("passwordWritebackEnabled", value); }
        }
        /// <summary>The quarantineUponProxyAddressesConflictEnabled property</summary>
        public bool? QuarantineUponProxyAddressesConflictEnabled {
            get { return BackingStore?.Get<bool?>("quarantineUponProxyAddressesConflictEnabled"); }
            set { BackingStore?.Set("quarantineUponProxyAddressesConflictEnabled", value); }
        }
        /// <summary>The quarantineUponUpnConflictEnabled property</summary>
        public bool? QuarantineUponUpnConflictEnabled {
            get { return BackingStore?.Get<bool?>("quarantineUponUpnConflictEnabled"); }
            set { BackingStore?.Set("quarantineUponUpnConflictEnabled", value); }
        }
        /// <summary>The softMatchOnUpnEnabled property</summary>
        public bool? SoftMatchOnUpnEnabled {
            get { return BackingStore?.Get<bool?>("softMatchOnUpnEnabled"); }
            set { BackingStore?.Set("softMatchOnUpnEnabled", value); }
        }
        /// <summary>The synchronizeUpnForManagedUsersEnabled property</summary>
        public bool? SynchronizeUpnForManagedUsersEnabled {
            get { return BackingStore?.Get<bool?>("synchronizeUpnForManagedUsersEnabled"); }
            set { BackingStore?.Set("synchronizeUpnForManagedUsersEnabled", value); }
        }
        /// <summary>The unifiedGroupWritebackEnabled property</summary>
        public bool? UnifiedGroupWritebackEnabled {
            get { return BackingStore?.Get<bool?>("unifiedGroupWritebackEnabled"); }
            set { BackingStore?.Set("unifiedGroupWritebackEnabled", value); }
        }
        /// <summary>The userForcePasswordChangeOnLogonEnabled property</summary>
        public bool? UserForcePasswordChangeOnLogonEnabled {
            get { return BackingStore?.Get<bool?>("userForcePasswordChangeOnLogonEnabled"); }
            set { BackingStore?.Set("userForcePasswordChangeOnLogonEnabled", value); }
        }
        /// <summary>The userWritebackEnabled property</summary>
        public bool? UserWritebackEnabled {
            get { return BackingStore?.Get<bool?>("userWritebackEnabled"); }
            set { BackingStore?.Set("userWritebackEnabled", value); }
        }
        /// <summary>
        /// Instantiates a new onPremisesDirectorySynchronizationFeature and sets the default values.
        /// </summary>
        public OnPremisesDirectorySynchronizationFeature() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OnPremisesDirectorySynchronizationFeature CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OnPremisesDirectorySynchronizationFeature();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"blockCloudObjectTakeoverThroughHardMatchEnabled", n => { BlockCloudObjectTakeoverThroughHardMatchEnabled = n.GetBoolValue(); } },
                {"blockSoftMatchEnabled", n => { BlockSoftMatchEnabled = n.GetBoolValue(); } },
                {"bypassDirSyncOverridesEnabled", n => { BypassDirSyncOverridesEnabled = n.GetBoolValue(); } },
                {"cloudPasswordPolicyForPasswordSyncedUsersEnabled", n => { CloudPasswordPolicyForPasswordSyncedUsersEnabled = n.GetBoolValue(); } },
                {"concurrentCredentialUpdateEnabled", n => { ConcurrentCredentialUpdateEnabled = n.GetBoolValue(); } },
                {"concurrentOrgIdProvisioningEnabled", n => { ConcurrentOrgIdProvisioningEnabled = n.GetBoolValue(); } },
                {"deviceWritebackEnabled", n => { DeviceWritebackEnabled = n.GetBoolValue(); } },
                {"directoryExtensionsEnabled", n => { DirectoryExtensionsEnabled = n.GetBoolValue(); } },
                {"fopeConflictResolutionEnabled", n => { FopeConflictResolutionEnabled = n.GetBoolValue(); } },
                {"groupWriteBackEnabled", n => { GroupWriteBackEnabled = n.GetBoolValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"passwordSyncEnabled", n => { PasswordSyncEnabled = n.GetBoolValue(); } },
                {"passwordWritebackEnabled", n => { PasswordWritebackEnabled = n.GetBoolValue(); } },
                {"quarantineUponProxyAddressesConflictEnabled", n => { QuarantineUponProxyAddressesConflictEnabled = n.GetBoolValue(); } },
                {"quarantineUponUpnConflictEnabled", n => { QuarantineUponUpnConflictEnabled = n.GetBoolValue(); } },
                {"softMatchOnUpnEnabled", n => { SoftMatchOnUpnEnabled = n.GetBoolValue(); } },
                {"synchronizeUpnForManagedUsersEnabled", n => { SynchronizeUpnForManagedUsersEnabled = n.GetBoolValue(); } },
                {"unifiedGroupWritebackEnabled", n => { UnifiedGroupWritebackEnabled = n.GetBoolValue(); } },
                {"userForcePasswordChangeOnLogonEnabled", n => { UserForcePasswordChangeOnLogonEnabled = n.GetBoolValue(); } },
                {"userWritebackEnabled", n => { UserWritebackEnabled = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("blockCloudObjectTakeoverThroughHardMatchEnabled", BlockCloudObjectTakeoverThroughHardMatchEnabled);
            writer.WriteBoolValue("blockSoftMatchEnabled", BlockSoftMatchEnabled);
            writer.WriteBoolValue("bypassDirSyncOverridesEnabled", BypassDirSyncOverridesEnabled);
            writer.WriteBoolValue("cloudPasswordPolicyForPasswordSyncedUsersEnabled", CloudPasswordPolicyForPasswordSyncedUsersEnabled);
            writer.WriteBoolValue("concurrentCredentialUpdateEnabled", ConcurrentCredentialUpdateEnabled);
            writer.WriteBoolValue("concurrentOrgIdProvisioningEnabled", ConcurrentOrgIdProvisioningEnabled);
            writer.WriteBoolValue("deviceWritebackEnabled", DeviceWritebackEnabled);
            writer.WriteBoolValue("directoryExtensionsEnabled", DirectoryExtensionsEnabled);
            writer.WriteBoolValue("fopeConflictResolutionEnabled", FopeConflictResolutionEnabled);
            writer.WriteBoolValue("groupWriteBackEnabled", GroupWriteBackEnabled);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteBoolValue("passwordSyncEnabled", PasswordSyncEnabled);
            writer.WriteBoolValue("passwordWritebackEnabled", PasswordWritebackEnabled);
            writer.WriteBoolValue("quarantineUponProxyAddressesConflictEnabled", QuarantineUponProxyAddressesConflictEnabled);
            writer.WriteBoolValue("quarantineUponUpnConflictEnabled", QuarantineUponUpnConflictEnabled);
            writer.WriteBoolValue("softMatchOnUpnEnabled", SoftMatchOnUpnEnabled);
            writer.WriteBoolValue("synchronizeUpnForManagedUsersEnabled", SynchronizeUpnForManagedUsersEnabled);
            writer.WriteBoolValue("unifiedGroupWritebackEnabled", UnifiedGroupWritebackEnabled);
            writer.WriteBoolValue("userForcePasswordChangeOnLogonEnabled", UserForcePasswordChangeOnLogonEnabled);
            writer.WriteBoolValue("userWritebackEnabled", UserWritebackEnabled);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
