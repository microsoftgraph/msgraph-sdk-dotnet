using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class MicrosoftStoreForBusinessAppAssignmentSettings : MobileAppAssignmentSettings, IParsable {
        /// <summary>Whether or not to use device execution context for Microsoft Store for Business mobile app.</summary>
        public bool? UseDeviceContext {
            get { return BackingStore?.Get<bool?>("useDeviceContext"); }
            set { BackingStore?.Set("useDeviceContext", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new MicrosoftStoreForBusinessAppAssignmentSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MicrosoftStoreForBusinessAppAssignmentSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"useDeviceContext", n => { UseDeviceContext = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("useDeviceContext", UseDeviceContext);
        }
    }
}
