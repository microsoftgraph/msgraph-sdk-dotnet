using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WindowsInformationProtectionDesktopApp : WindowsInformationProtectionApp, IParsable {
        /// <summary>The binary name.</summary>
        public string BinaryName {
            get { return BackingStore?.Get<string>("binaryName"); }
            set { BackingStore?.Set("binaryName", value); }
        }
        /// <summary>The high binary version.</summary>
        public string BinaryVersionHigh {
            get { return BackingStore?.Get<string>("binaryVersionHigh"); }
            set { BackingStore?.Set("binaryVersionHigh", value); }
        }
        /// <summary>The lower binary version.</summary>
        public string BinaryVersionLow {
            get { return BackingStore?.Get<string>("binaryVersionLow"); }
            set { BackingStore?.Set("binaryVersionLow", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WindowsInformationProtectionDesktopApp CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WindowsInformationProtectionDesktopApp();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"binaryName", n => { BinaryName = n.GetStringValue(); } },
                {"binaryVersionHigh", n => { BinaryVersionHigh = n.GetStringValue(); } },
                {"binaryVersionLow", n => { BinaryVersionLow = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("binaryName", BinaryName);
            writer.WriteStringValue("binaryVersionHigh", BinaryVersionHigh);
            writer.WriteStringValue("binaryVersionLow", BinaryVersionLow);
        }
    }
}
