using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Contains MSI app properties for a Win32 App.</summary>
    public class Win32LobAppMsiInformation : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Indicates the package type of an MSI Win32LobApp.</summary>
        public Win32LobAppMsiPackageType? PackageType {
            get { return BackingStore?.Get<Win32LobAppMsiPackageType?>("packageType"); }
            set { BackingStore?.Set("packageType", value); }
        }
        /// <summary>The MSI product code.</summary>
        public string ProductCode {
            get { return BackingStore?.Get<string>("productCode"); }
            set { BackingStore?.Set("productCode", value); }
        }
        /// <summary>The MSI product name.</summary>
        public string ProductName {
            get { return BackingStore?.Get<string>("productName"); }
            set { BackingStore?.Set("productName", value); }
        }
        /// <summary>The MSI product version.</summary>
        public string ProductVersion {
            get { return BackingStore?.Get<string>("productVersion"); }
            set { BackingStore?.Set("productVersion", value); }
        }
        /// <summary>The MSI publisher.</summary>
        public string Publisher {
            get { return BackingStore?.Get<string>("publisher"); }
            set { BackingStore?.Set("publisher", value); }
        }
        /// <summary>Whether the MSI app requires the machine to reboot to complete installation.</summary>
        public bool? RequiresReboot {
            get { return BackingStore?.Get<bool?>("requiresReboot"); }
            set { BackingStore?.Set("requiresReboot", value); }
        }
        /// <summary>The MSI upgrade code.</summary>
        public string UpgradeCode {
            get { return BackingStore?.Get<string>("upgradeCode"); }
            set { BackingStore?.Set("upgradeCode", value); }
        }
        /// <summary>
        /// Instantiates a new win32LobAppMsiInformation and sets the default values.
        /// </summary>
        public Win32LobAppMsiInformation() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Win32LobAppMsiInformation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Win32LobAppMsiInformation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"packageType", n => { PackageType = n.GetEnumValue<Win32LobAppMsiPackageType>(); } },
                {"productCode", n => { ProductCode = n.GetStringValue(); } },
                {"productName", n => { ProductName = n.GetStringValue(); } },
                {"productVersion", n => { ProductVersion = n.GetStringValue(); } },
                {"publisher", n => { Publisher = n.GetStringValue(); } },
                {"requiresReboot", n => { RequiresReboot = n.GetBoolValue(); } },
                {"upgradeCode", n => { UpgradeCode = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<Win32LobAppMsiPackageType>("packageType", PackageType);
            writer.WriteStringValue("productCode", ProductCode);
            writer.WriteStringValue("productName", ProductName);
            writer.WriteStringValue("productVersion", ProductVersion);
            writer.WriteStringValue("publisher", Publisher);
            writer.WriteBoolValue("requiresReboot", RequiresReboot);
            writer.WriteStringValue("upgradeCode", UpgradeCode);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
