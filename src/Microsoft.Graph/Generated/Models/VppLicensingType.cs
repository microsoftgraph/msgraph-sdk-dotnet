using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Contains properties for iOS Volume-Purchased Program (Vpp) Licensing Type.</summary>
    public class VppLicensingType : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Whether the program supports the device licensing type.</summary>
        public bool? SupportsDeviceLicensing {
            get { return BackingStore?.Get<bool?>("supportsDeviceLicensing"); }
            set { BackingStore?.Set("supportsDeviceLicensing", value); }
        }
        /// <summary>Whether the program supports the user licensing type.</summary>
        public bool? SupportsUserLicensing {
            get { return BackingStore?.Get<bool?>("supportsUserLicensing"); }
            set { BackingStore?.Set("supportsUserLicensing", value); }
        }
        /// <summary>
        /// Instantiates a new vppLicensingType and sets the default values.
        /// </summary>
        public VppLicensingType() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static VppLicensingType CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new VppLicensingType();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"supportsDeviceLicensing", n => { SupportsDeviceLicensing = n.GetBoolValue(); } },
                {"supportsUserLicensing", n => { SupportsUserLicensing = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("supportsDeviceLicensing", SupportsDeviceLicensing);
            writer.WriteBoolValue("supportsUserLicensing", SupportsUserLicensing);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
