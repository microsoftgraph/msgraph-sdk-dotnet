using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public class WorkbookChartPoint : Entity, IParsable {
        /// <summary>Encapsulates the format properties chart point. Read-only.</summary>
        public WorkbookChartPointFormat Format {
            get { return BackingStore?.Get<WorkbookChartPointFormat>("format"); }
            set { BackingStore?.Set("format", value); }
        }
        /// <summary>Returns the value of a chart point. Read-only.</summary>
        public Json Value {
            get { return BackingStore?.Get<Json>("value"); }
            set { BackingStore?.Set("value", value); }
        }
        /// <summary>
        /// Instantiates a new workbookChartPoint and sets the default values.
        /// </summary>
        public WorkbookChartPoint() : base() {
            OdataType = "#microsoft.graph.workbookChartPoint";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookChartPoint CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookChartPoint();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"format", n => { Format = n.GetObjectValue<WorkbookChartPointFormat>(WorkbookChartPointFormat.CreateFromDiscriminatorValue); } },
                {"value", n => { Value = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<WorkbookChartPointFormat>("format", Format);
            writer.WriteObjectValue<Json>("value", Value);
        }
    }
}
