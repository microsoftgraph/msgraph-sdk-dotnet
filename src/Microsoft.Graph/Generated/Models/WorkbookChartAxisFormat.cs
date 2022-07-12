using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkbookChartAxisFormat : Entity, IParsable {
        /// <summary>Represents the font attributes (font name, font size, color, etc.) for a chart axis element. Read-only.</summary>
        public WorkbookChartFont Font {
            get { return BackingStore?.Get<WorkbookChartFont>("font"); }
            set { BackingStore?.Set("font", value); }
        }
        /// <summary>Represents chart line formatting. Read-only.</summary>
        public WorkbookChartLineFormat Line {
            get { return BackingStore?.Get<WorkbookChartLineFormat>("line"); }
            set { BackingStore?.Set("line", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookChartAxisFormat CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookChartAxisFormat();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"font", n => { Font = n.GetObjectValue<WorkbookChartFont>(WorkbookChartFont.CreateFromDiscriminatorValue); } },
                {"line", n => { Line = n.GetObjectValue<WorkbookChartLineFormat>(WorkbookChartLineFormat.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<WorkbookChartFont>("font", Font);
            writer.WriteObjectValue<WorkbookChartLineFormat>("line", Line);
        }
    }
}
