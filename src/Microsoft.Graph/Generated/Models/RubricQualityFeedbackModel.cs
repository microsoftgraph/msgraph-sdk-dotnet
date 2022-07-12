using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RubricQualityFeedbackModel : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Specific feedback for one quality of this rubric.</summary>
        public EducationItemBody Feedback {
            get { return BackingStore?.Get<EducationItemBody>("feedback"); }
            set { BackingStore?.Set("feedback", value); }
        }
        /// <summary>The ID of the rubricQuality that this feedback is related to.</summary>
        public string QualityId {
            get { return BackingStore?.Get<string>("qualityId"); }
            set { BackingStore?.Set("qualityId", value); }
        }
        /// <summary>
        /// Instantiates a new rubricQualityFeedbackModel and sets the default values.
        /// </summary>
        public RubricQualityFeedbackModel() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static RubricQualityFeedbackModel CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RubricQualityFeedbackModel();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"feedback", n => { Feedback = n.GetObjectValue<EducationItemBody>(EducationItemBody.CreateFromDiscriminatorValue); } },
                {"qualityId", n => { QualityId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<EducationItemBody>("feedback", Feedback);
            writer.WriteStringValue("qualityId", QualityId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
