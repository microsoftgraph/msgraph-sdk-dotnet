using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.Security {
    public class OcrSettings : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Indicates whether or not OCR is enabled for the case.</summary>
        public bool? IsEnabled {
            get { return BackingStore?.Get<bool?>("isEnabled"); }
            set { BackingStore?.Set("isEnabled", value); }
        }
        /// <summary>Maximum image size that will be processed in KB).</summary>
        public int? MaxImageSize {
            get { return BackingStore?.Get<int?>("maxImageSize"); }
            set { BackingStore?.Set("maxImageSize", value); }
        }
        /// <summary>The timeout duration for the OCR engine. A longer timeout may increase success of OCR, but may add to the total processing time.</summary>
        public TimeSpan? Timeout {
            get { return BackingStore?.Get<TimeSpan?>("timeout"); }
            set { BackingStore?.Set("timeout", value); }
        }
        /// <summary>
        /// Instantiates a new ocrSettings and sets the default values.
        /// </summary>
        public OcrSettings() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static OcrSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OcrSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"isEnabled", n => { IsEnabled = n.GetBoolValue(); } },
                {"maxImageSize", n => { MaxImageSize = n.GetIntValue(); } },
                {"timeout", n => { Timeout = n.GetTimeSpanValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("isEnabled", IsEnabled);
            writer.WriteIntValue("maxImageSize", MaxImageSize);
            writer.WriteTimeSpanValue("timeout", Timeout);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
