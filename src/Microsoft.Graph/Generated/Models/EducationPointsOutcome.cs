using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EducationPointsOutcome : EducationOutcome, IParsable {
        /// <summary>The numeric grade the teacher has given the student for this assignment.</summary>
        public EducationAssignmentPointsGrade Points {
            get { return BackingStore?.Get<EducationAssignmentPointsGrade>("points"); }
            set { BackingStore?.Set("points", value); }
        }
        /// <summary>A copy of the points property that is made when the grade is released to the student.</summary>
        public EducationAssignmentPointsGrade PublishedPoints {
            get { return BackingStore?.Get<EducationAssignmentPointsGrade>("publishedPoints"); }
            set { BackingStore?.Set("publishedPoints", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EducationPointsOutcome CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EducationPointsOutcome();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"points", n => { Points = n.GetObjectValue<EducationAssignmentPointsGrade>(EducationAssignmentPointsGrade.CreateFromDiscriminatorValue); } },
                {"publishedPoints", n => { PublishedPoints = n.GetObjectValue<EducationAssignmentPointsGrade>(EducationAssignmentPointsGrade.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<EducationAssignmentPointsGrade>("points", Points);
            writer.WriteObjectValue<EducationAssignmentPointsGrade>("publishedPoints", PublishedPoints);
        }
    }
}
