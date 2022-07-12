using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EducationRubricOutcome : EducationOutcome, IParsable {
        /// <summary>A copy of the rubricQualityFeedback property that is made when the grade is released to the student.</summary>
        public List<RubricQualityFeedbackModel> PublishedRubricQualityFeedback {
            get { return BackingStore?.Get<List<RubricQualityFeedbackModel>>("publishedRubricQualityFeedback"); }
            set { BackingStore?.Set("publishedRubricQualityFeedback", value); }
        }
        /// <summary>A copy of the rubricQualitySelectedLevels property that is made when the grade is released to the student.</summary>
        public List<RubricQualitySelectedColumnModel> PublishedRubricQualitySelectedLevels {
            get { return BackingStore?.Get<List<RubricQualitySelectedColumnModel>>("publishedRubricQualitySelectedLevels"); }
            set { BackingStore?.Set("publishedRubricQualitySelectedLevels", value); }
        }
        /// <summary>A collection of specific feedback for each quality of this rubric.</summary>
        public List<RubricQualityFeedbackModel> RubricQualityFeedback {
            get { return BackingStore?.Get<List<RubricQualityFeedbackModel>>("rubricQualityFeedback"); }
            set { BackingStore?.Set("rubricQualityFeedback", value); }
        }
        /// <summary>The level that the teacher has selected for each quality while grading this assignment.</summary>
        public List<RubricQualitySelectedColumnModel> RubricQualitySelectedLevels {
            get { return BackingStore?.Get<List<RubricQualitySelectedColumnModel>>("rubricQualitySelectedLevels"); }
            set { BackingStore?.Set("rubricQualitySelectedLevels", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EducationRubricOutcome CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EducationRubricOutcome();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"publishedRubricQualityFeedback", n => { PublishedRubricQualityFeedback = n.GetCollectionOfObjectValues<RubricQualityFeedbackModel>(RubricQualityFeedbackModel.CreateFromDiscriminatorValue).ToList(); } },
                {"publishedRubricQualitySelectedLevels", n => { PublishedRubricQualitySelectedLevels = n.GetCollectionOfObjectValues<RubricQualitySelectedColumnModel>(RubricQualitySelectedColumnModel.CreateFromDiscriminatorValue).ToList(); } },
                {"rubricQualityFeedback", n => { RubricQualityFeedback = n.GetCollectionOfObjectValues<RubricQualityFeedbackModel>(RubricQualityFeedbackModel.CreateFromDiscriminatorValue).ToList(); } },
                {"rubricQualitySelectedLevels", n => { RubricQualitySelectedLevels = n.GetCollectionOfObjectValues<RubricQualitySelectedColumnModel>(RubricQualitySelectedColumnModel.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<RubricQualityFeedbackModel>("publishedRubricQualityFeedback", PublishedRubricQualityFeedback);
            writer.WriteCollectionOfObjectValues<RubricQualitySelectedColumnModel>("publishedRubricQualitySelectedLevels", PublishedRubricQualitySelectedLevels);
            writer.WriteCollectionOfObjectValues<RubricQualityFeedbackModel>("rubricQualityFeedback", RubricQualityFeedback);
            writer.WriteCollectionOfObjectValues<RubricQualitySelectedColumnModel>("rubricQualitySelectedLevels", RubricQualitySelectedLevels);
        }
    }
}
