using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class BroadcastMeetingCaptionSettings : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Indicates whether captions are enabled for this Teams live event.</summary>
        public bool? IsCaptionEnabled {
            get { return BackingStore?.Get<bool?>("isCaptionEnabled"); }
            set { BackingStore?.Set("isCaptionEnabled", value); }
        }
        /// <summary>The OdataType property</summary>
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>The spoken language.</summary>
        public string SpokenLanguage {
            get { return BackingStore?.Get<string>("spokenLanguage"); }
            set { BackingStore?.Set("spokenLanguage", value); }
        }
        /// <summary>The translation languages (choose up to 6).</summary>
        public List<string> TranslationLanguages {
            get { return BackingStore?.Get<List<string>>("translationLanguages"); }
            set { BackingStore?.Set("translationLanguages", value); }
        }
        /// <summary>
        /// Instantiates a new broadcastMeetingCaptionSettings and sets the default values.
        /// </summary>
        public BroadcastMeetingCaptionSettings() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
            OdataType = "#microsoft.graph.broadcastMeetingCaptionSettings";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static BroadcastMeetingCaptionSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BroadcastMeetingCaptionSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"isCaptionEnabled", n => { IsCaptionEnabled = n.GetBoolValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"spokenLanguage", n => { SpokenLanguage = n.GetStringValue(); } },
                {"translationLanguages", n => { TranslationLanguages = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("isCaptionEnabled", IsCaptionEnabled);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteStringValue("spokenLanguage", SpokenLanguage);
            writer.WriteCollectionOfPrimitiveValues<string>("translationLanguages", TranslationLanguages);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
