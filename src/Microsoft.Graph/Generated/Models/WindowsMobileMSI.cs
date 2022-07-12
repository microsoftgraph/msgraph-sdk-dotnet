using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WindowsMobileMSI : MobileLobApp, IParsable {
        /// <summary>The command line.</summary>
        public string CommandLine {
            get { return BackingStore?.Get<string>("commandLine"); }
            set { BackingStore?.Set("commandLine", value); }
        }
        /// <summary>A boolean to control whether the app&apos;s version will be used to detect the app after it is installed on a device. Set this to true for Windows Mobile MSI Line of Business (LoB) apps that use a self update feature.</summary>
        public bool? IgnoreVersionDetection {
            get { return BackingStore?.Get<bool?>("ignoreVersionDetection"); }
            set { BackingStore?.Set("ignoreVersionDetection", value); }
        }
        /// <summary>The product code.</summary>
        public string ProductCode {
            get { return BackingStore?.Get<string>("productCode"); }
            set { BackingStore?.Set("productCode", value); }
        }
        /// <summary>The product version of Windows Mobile MSI Line of Business (LoB) app.</summary>
        public string ProductVersion {
            get { return BackingStore?.Get<string>("productVersion"); }
            set { BackingStore?.Set("productVersion", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WindowsMobileMSI CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WindowsMobileMSI();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"commandLine", n => { CommandLine = n.GetStringValue(); } },
                {"ignoreVersionDetection", n => { IgnoreVersionDetection = n.GetBoolValue(); } },
                {"productCode", n => { ProductCode = n.GetStringValue(); } },
                {"productVersion", n => { ProductVersion = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("commandLine", CommandLine);
            writer.WriteBoolValue("ignoreVersionDetection", IgnoreVersionDetection);
            writer.WriteStringValue("productCode", ProductCode);
            writer.WriteStringValue("productVersion", ProductVersion);
        }
    }
}
