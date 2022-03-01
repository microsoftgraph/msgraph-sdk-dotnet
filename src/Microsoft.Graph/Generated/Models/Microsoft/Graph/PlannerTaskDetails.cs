using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class PlannerTaskDetails : Entity, IParsable {
        /// <summary>The collection of checklist items on the task.</summary>
        public PlannerChecklistItems Checklist { get; set; }
        /// <summary>Description of the task.</summary>
        public string Description { get; set; }
        /// <summary>This sets the type of preview that shows up on the task. The possible values are: automatic, noPreview, checklist, description, reference. When set to automatic the displayed preview is chosen by the app viewing the task.</summary>
        public PlannerPreviewType? PreviewType { get; set; }
        /// <summary>The collection of references on the task.</summary>
        public PlannerExternalReferences References { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"checklist", (o,n) => { (o as PlannerTaskDetails).Checklist = n.GetObjectValue<PlannerChecklistItems>(); } },
                {"description", (o,n) => { (o as PlannerTaskDetails).Description = n.GetStringValue(); } },
                {"previewType", (o,n) => { (o as PlannerTaskDetails).PreviewType = n.GetEnumValue<PlannerPreviewType>(); } },
                {"references", (o,n) => { (o as PlannerTaskDetails).References = n.GetObjectValue<PlannerExternalReferences>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<PlannerChecklistItems>("checklist", Checklist);
            writer.WriteStringValue("description", Description);
            writer.WriteEnumValue<PlannerPreviewType>("previewType", PreviewType);
            writer.WriteObjectValue<PlannerExternalReferences>("references", References);
        }
    }
}
