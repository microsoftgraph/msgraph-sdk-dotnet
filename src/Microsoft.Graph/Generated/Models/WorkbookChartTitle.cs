using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkbookChartTitle : Entity, IParsable {
        /// <summary>Represents the formatting of a chart title, which includes fill and font formatting. Read-only.</summary>
        public WorkbookChartTitleFormat Format {
            get { return BackingStore?.Get<WorkbookChartTitleFormat>("format"); }
            set { BackingStore?.Set("format", value); }
        }
        /// <summary>Boolean value representing if the chart title will overlay the chart or not.</summary>
        public bool? Overlay {
            get { return BackingStore?.Get<bool?>("overlay"); }
            set { BackingStore?.Set("overlay", value); }
        }
        /// <summary>Represents the title text of a chart.</summary>
        public string Text {
            get { return BackingStore?.Get<string>("text"); }
            set { BackingStore?.Set("text", value); }
        }
        /// <summary>A boolean value the represents the visibility of a chart title object.</summary>
        public bool? Visible {
            get { return BackingStore?.Get<bool?>("visible"); }
            set { BackingStore?.Set("visible", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookChartTitle CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookChartTitle();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"format", n => { Format = n.GetObjectValue<WorkbookChartTitleFormat>(WorkbookChartTitleFormat.CreateFromDiscriminatorValue); } },
                {"overlay", n => { Overlay = n.GetBoolValue(); } },
                {"text", n => { Text = n.GetStringValue(); } },
                {"visible", n => { Visible = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<WorkbookChartTitleFormat>("format", Format);
            writer.WriteBoolValue("overlay", Overlay);
            writer.WriteStringValue("text", Text);
            writer.WriteBoolValue("visible", Visible);
        }
    }
}
