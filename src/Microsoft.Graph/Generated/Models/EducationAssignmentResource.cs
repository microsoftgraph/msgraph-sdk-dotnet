using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class EducationAssignmentResource : Entity, IParsable {
        /// <summary>Indicates whether this resource should be copied to each student submission for modification and submission. Required</summary>
        public bool? DistributeForStudentWork {
            get { return BackingStore?.Get<bool?>("distributeForStudentWork"); }
            set { BackingStore?.Set("distributeForStudentWork", value); }
        }
        /// <summary>Resource object that has been associated with this assignment.</summary>
        public EducationResource Resource {
            get { return BackingStore?.Get<EducationResource>("resource"); }
            set { BackingStore?.Set("resource", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EducationAssignmentResource CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EducationAssignmentResource();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"distributeForStudentWork", n => { DistributeForStudentWork = n.GetBoolValue(); } },
                {"resource", n => { Resource = n.GetObjectValue<EducationResource>(EducationResource.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("distributeForStudentWork", DistributeForStudentWork);
            writer.WriteObjectValue<EducationResource>("resource", Resource);
        }
    }
}
