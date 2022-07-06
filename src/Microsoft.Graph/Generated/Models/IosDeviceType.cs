using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Contains properties of the possible iOS device types the mobile app can run on.</summary>
    public class IosDeviceType : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Whether the app should run on iPads.</summary>
        public bool? IPad {
            get { return BackingStore?.Get<bool?>("iPad"); }
            set { BackingStore?.Set("iPad", value); }
        }
        /// <summary>Whether the app should run on iPhones and iPods.</summary>
        public bool? IPhoneAndIPod {
            get { return BackingStore?.Get<bool?>("iPhoneAndIPod"); }
            set { BackingStore?.Set("iPhoneAndIPod", value); }
        }
        /// <summary>
        /// Instantiates a new iosDeviceType and sets the default values.
        /// </summary>
        public IosDeviceType() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static IosDeviceType CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IosDeviceType();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"iPad", n => { IPad = n.GetBoolValue(); } },
                {"iPhoneAndIPod", n => { IPhoneAndIPod = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("iPad", IPad);
            writer.WriteBoolValue("iPhoneAndIPod", IPhoneAndIPod);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
