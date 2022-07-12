using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>OMA Settings definition.</summary>
    public class OmaSetting : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Description.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>Display Name.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>OMA.</summary>
        public string OmaUri {
            get { return BackingStore?.Get<string>("omaUri"); }
            set { BackingStore?.Set("omaUri", value); }
        }
        /// <summary>The type property</summary>
        public string Type {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>
        /// Instantiates a new omaSetting and sets the default values.
        /// </summary>
        public OmaSetting() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
            Type = "#microsoft.graph.omaSetting";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static OmaSetting CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.omaSettingBase64" => new OmaSettingBase64(),
                "#microsoft.graph.omaSettingBoolean" => new OmaSettingBoolean(),
                "#microsoft.graph.omaSettingDateTime" => new OmaSettingDateTime(),
                "#microsoft.graph.omaSettingFloatingPoint" => new OmaSettingFloatingPoint(),
                "#microsoft.graph.omaSettingInteger" => new OmaSettingInteger(),
                "#microsoft.graph.omaSettingString" => new OmaSettingString(),
                "#microsoft.graph.omaSettingStringXml" => new OmaSettingStringXml(),
                _ => new OmaSetting(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"omaUri", n => { OmaUri = n.GetStringValue(); } },
                {"@odata.type", n => { Type = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("omaUri", OmaUri);
            writer.WriteStringValue("@odata.type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
