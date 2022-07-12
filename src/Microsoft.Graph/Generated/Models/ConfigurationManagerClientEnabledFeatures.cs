using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>configuration Manager client enabled features</summary>
    public class ConfigurationManagerClientEnabledFeatures : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Whether compliance policy is managed by Intune</summary>
        public bool? CompliancePolicy {
            get { return BackingStore?.Get<bool?>("compliancePolicy"); }
            set { BackingStore?.Set("compliancePolicy", value); }
        }
        /// <summary>Whether device configuration is managed by Intune</summary>
        public bool? DeviceConfiguration {
            get { return BackingStore?.Get<bool?>("deviceConfiguration"); }
            set { BackingStore?.Set("deviceConfiguration", value); }
        }
        /// <summary>Whether inventory is managed by Intune</summary>
        public bool? Inventory {
            get { return BackingStore?.Get<bool?>("inventory"); }
            set { BackingStore?.Set("inventory", value); }
        }
        /// <summary>Whether modern application is managed by Intune</summary>
        public bool? ModernApps {
            get { return BackingStore?.Get<bool?>("modernApps"); }
            set { BackingStore?.Set("modernApps", value); }
        }
        /// <summary>Whether resource access is managed by Intune</summary>
        public bool? ResourceAccess {
            get { return BackingStore?.Get<bool?>("resourceAccess"); }
            set { BackingStore?.Set("resourceAccess", value); }
        }
        /// <summary>Whether Windows Update for Business is managed by Intune</summary>
        public bool? WindowsUpdateForBusiness {
            get { return BackingStore?.Get<bool?>("windowsUpdateForBusiness"); }
            set { BackingStore?.Set("windowsUpdateForBusiness", value); }
        }
        /// <summary>
        /// Instantiates a new configurationManagerClientEnabledFeatures and sets the default values.
        /// </summary>
        public ConfigurationManagerClientEnabledFeatures() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ConfigurationManagerClientEnabledFeatures CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ConfigurationManagerClientEnabledFeatures();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"compliancePolicy", n => { CompliancePolicy = n.GetBoolValue(); } },
                {"deviceConfiguration", n => { DeviceConfiguration = n.GetBoolValue(); } },
                {"inventory", n => { Inventory = n.GetBoolValue(); } },
                {"modernApps", n => { ModernApps = n.GetBoolValue(); } },
                {"resourceAccess", n => { ResourceAccess = n.GetBoolValue(); } },
                {"windowsUpdateForBusiness", n => { WindowsUpdateForBusiness = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("compliancePolicy", CompliancePolicy);
            writer.WriteBoolValue("deviceConfiguration", DeviceConfiguration);
            writer.WriteBoolValue("inventory", Inventory);
            writer.WriteBoolValue("modernApps", ModernApps);
            writer.WriteBoolValue("resourceAccess", ResourceAccess);
            writer.WriteBoolValue("windowsUpdateForBusiness", WindowsUpdateForBusiness);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
