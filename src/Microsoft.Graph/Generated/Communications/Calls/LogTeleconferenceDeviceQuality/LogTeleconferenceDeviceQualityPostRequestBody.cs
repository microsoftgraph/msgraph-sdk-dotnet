using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Communications.Calls.LogTeleconferenceDeviceQuality {
    /// <summary>Provides operations to call the logTeleconferenceDeviceQuality method.</summary>
    public class LogTeleconferenceDeviceQualityPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The quality property</summary>
        public TeleconferenceDeviceQuality Quality {
            get { return BackingStore?.Get<TeleconferenceDeviceQuality>("quality"); }
            set { BackingStore?.Set("quality", value); }
        }
        /// <summary>
        /// Instantiates a new logTeleconferenceDeviceQualityPostRequestBody and sets the default values.
        /// </summary>
        public LogTeleconferenceDeviceQualityPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static LogTeleconferenceDeviceQualityPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LogTeleconferenceDeviceQualityPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"quality", n => { Quality = n.GetObjectValue<TeleconferenceDeviceQuality>(TeleconferenceDeviceQuality.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<TeleconferenceDeviceQuality>("quality", Quality);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
