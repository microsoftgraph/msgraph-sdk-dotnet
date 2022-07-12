using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class MediaContentRatingUnitedStates : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Movies rating labels in United States</summary>
        public RatingUnitedStatesMoviesType? MovieRating {
            get { return BackingStore?.Get<RatingUnitedStatesMoviesType?>("movieRating"); }
            set { BackingStore?.Set("movieRating", value); }
        }
        /// <summary>TV content rating labels in United States</summary>
        public RatingUnitedStatesTelevisionType? TvRating {
            get { return BackingStore?.Get<RatingUnitedStatesTelevisionType?>("tvRating"); }
            set { BackingStore?.Set("tvRating", value); }
        }
        /// <summary>
        /// Instantiates a new mediaContentRatingUnitedStates and sets the default values.
        /// </summary>
        public MediaContentRatingUnitedStates() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static MediaContentRatingUnitedStates CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MediaContentRatingUnitedStates();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"movieRating", n => { MovieRating = n.GetEnumValue<RatingUnitedStatesMoviesType>(); } },
                {"tvRating", n => { TvRating = n.GetEnumValue<RatingUnitedStatesTelevisionType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<RatingUnitedStatesMoviesType>("movieRating", MovieRating);
            writer.WriteEnumValue<RatingUnitedStatesTelevisionType>("tvRating", TvRating);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
