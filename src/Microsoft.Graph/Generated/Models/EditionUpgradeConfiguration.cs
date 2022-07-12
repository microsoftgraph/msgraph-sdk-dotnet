using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EditionUpgradeConfiguration : DeviceConfiguration, IParsable {
        /// <summary>Edition Upgrade License File Content.</summary>
        public string License {
            get { return BackingStore?.Get<string>("license"); }
            set { BackingStore?.Set("license", value); }
        }
        /// <summary>Edition Upgrade License type</summary>
        public EditionUpgradeLicenseType? LicenseType {
            get { return BackingStore?.Get<EditionUpgradeLicenseType?>("licenseType"); }
            set { BackingStore?.Set("licenseType", value); }
        }
        /// <summary>Edition Upgrade Product Key.</summary>
        public string ProductKey {
            get { return BackingStore?.Get<string>("productKey"); }
            set { BackingStore?.Set("productKey", value); }
        }
        /// <summary>Windows 10 Edition type.</summary>
        public Windows10EditionType? TargetEdition {
            get { return BackingStore?.Get<Windows10EditionType?>("targetEdition"); }
            set { BackingStore?.Set("targetEdition", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EditionUpgradeConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EditionUpgradeConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"license", n => { License = n.GetStringValue(); } },
                {"licenseType", n => { LicenseType = n.GetEnumValue<EditionUpgradeLicenseType>(); } },
                {"productKey", n => { ProductKey = n.GetStringValue(); } },
                {"targetEdition", n => { TargetEdition = n.GetEnumValue<Windows10EditionType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("license", License);
            writer.WriteEnumValue<EditionUpgradeLicenseType>("licenseType", LicenseType);
            writer.WriteStringValue("productKey", ProductKey);
            writer.WriteEnumValue<Windows10EditionType>("targetEdition", TargetEdition);
        }
    }
}
