using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class TeamFunSettings : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>If set to true, enables users to include custom memes.</summary>
        public bool? AllowCustomMemes {
            get { return BackingStore?.Get<bool?>("allowCustomMemes"); }
            set { BackingStore?.Set("allowCustomMemes", value); }
        }
        /// <summary>If set to true, enables Giphy use.</summary>
        public bool? AllowGiphy {
            get { return BackingStore?.Get<bool?>("allowGiphy"); }
            set { BackingStore?.Set("allowGiphy", value); }
        }
        /// <summary>If set to true, enables users to include stickers and memes.</summary>
        public bool? AllowStickersAndMemes {
            get { return BackingStore?.Get<bool?>("allowStickersAndMemes"); }
            set { BackingStore?.Set("allowStickersAndMemes", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Giphy content rating. Possible values are: moderate, strict.</summary>
        public GiphyRatingType? GiphyContentRating {
            get { return BackingStore?.Get<GiphyRatingType?>("giphyContentRating"); }
            set { BackingStore?.Set("giphyContentRating", value); }
        }
        /// <summary>
        /// Instantiates a new teamFunSettings and sets the default values.
        /// </summary>
        public TeamFunSettings() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TeamFunSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TeamFunSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allowCustomMemes", n => { AllowCustomMemes = n.GetBoolValue(); } },
                {"allowGiphy", n => { AllowGiphy = n.GetBoolValue(); } },
                {"allowStickersAndMemes", n => { AllowStickersAndMemes = n.GetBoolValue(); } },
                {"giphyContentRating", n => { GiphyContentRating = n.GetEnumValue<GiphyRatingType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("allowCustomMemes", AllowCustomMemes);
            writer.WriteBoolValue("allowGiphy", AllowGiphy);
            writer.WriteBoolValue("allowStickersAndMemes", AllowStickersAndMemes);
            writer.WriteEnumValue<GiphyRatingType>("giphyContentRating", GiphyContentRating);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
