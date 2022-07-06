using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IosMobileAppConfiguration : ManagedDeviceMobileAppConfiguration, IParsable {
        /// <summary>mdm app configuration Base64 binary.</summary>
        public byte[] EncodedSettingXml {
            get { return BackingStore?.Get<byte[]>("encodedSettingXml"); }
            set { BackingStore?.Set("encodedSettingXml", value); }
        }
        /// <summary>app configuration setting items.</summary>
        public List<AppConfigurationSettingItem> Settings {
            get { return BackingStore?.Get<List<AppConfigurationSettingItem>>("settings"); }
            set { BackingStore?.Set("settings", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new IosMobileAppConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IosMobileAppConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"encodedSettingXml", n => { EncodedSettingXml = n.GetByteArrayValue(); } },
                {"settings", n => { Settings = n.GetCollectionOfObjectValues<AppConfigurationSettingItem>(AppConfigurationSettingItem.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteByteArrayValue("encodedSettingXml", EncodedSettingXml);
            writer.WriteCollectionOfObjectValues<AppConfigurationSettingItem>("settings", Settings);
        }
    }
}
