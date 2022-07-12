using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkbookChartAxisTitle : Entity, IParsable {
        /// <summary>Represents the formatting of chart axis title. Read-only.</summary>
        public WorkbookChartAxisTitleFormat Format {
            get { return BackingStore?.Get<WorkbookChartAxisTitleFormat>("format"); }
            set { BackingStore?.Set("format", value); }
        }
        /// <summary>Represents the axis title.</summary>
        public string Text {
            get { return BackingStore?.Get<string>("text"); }
            set { BackingStore?.Set("text", value); }
        }
        /// <summary>A boolean that specifies the visibility of an axis title.</summary>
        public bool? Visible {
            get { return BackingStore?.Get<bool?>("visible"); }
            set { BackingStore?.Set("visible", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookChartAxisTitle CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookChartAxisTitle();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"format", n => { Format = n.GetObjectValue<WorkbookChartAxisTitleFormat>(WorkbookChartAxisTitleFormat.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<WorkbookChartAxisTitleFormat>("format", Format);
            writer.WriteStringValue("text", Text);
            writer.WriteBoolValue("visible", Visible);
        }
    }
}
