using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Abstract class to contain properties used to assign a mobile app to a group.</summary>
    public class MobileAppAssignmentSettings : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The type property</summary>
        public string Type {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>
        /// Instantiates a new mobileAppAssignmentSettings and sets the default values.
        /// </summary>
        public MobileAppAssignmentSettings() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
            Type = "#microsoft.graph.mobileAppAssignmentSettings";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static MobileAppAssignmentSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.iosLobAppAssignmentSettings" => new IosLobAppAssignmentSettings(),
                "#microsoft.graph.iosStoreAppAssignmentSettings" => new IosStoreAppAssignmentSettings(),
                "#microsoft.graph.iosVppAppAssignmentSettings" => new IosVppAppAssignmentSettings(),
                "#microsoft.graph.microsoftStoreForBusinessAppAssignmentSettings" => new MicrosoftStoreForBusinessAppAssignmentSettings(),
                "#microsoft.graph.win32LobAppAssignmentSettings" => new Win32LobAppAssignmentSettings(),
                _ => new MobileAppAssignmentSettings(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"@odata.type", n => { Type = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("@odata.type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
