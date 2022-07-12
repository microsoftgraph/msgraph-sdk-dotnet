using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkbookChartLegendFormat : Entity, IParsable {
        /// <summary>Represents the fill format of an object, which includes background formating information. Read-only.</summary>
        public WorkbookChartFill Fill {
            get { return BackingStore?.Get<WorkbookChartFill>("fill"); }
            set { BackingStore?.Set("fill", value); }
        }
        /// <summary>Represents the font attributes such as font name, font size, color, etc. of a chart legend. Read-only.</summary>
        public WorkbookChartFont Font {
            get { return BackingStore?.Get<WorkbookChartFont>("font"); }
            set { BackingStore?.Set("font", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookChartLegendFormat CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookChartLegendFormat();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"fill", n => { Fill = n.GetObjectValue<WorkbookChartFill>(WorkbookChartFill.CreateFromDiscriminatorValue); } },
                {"font", n => { Font = n.GetObjectValue<WorkbookChartFont>(WorkbookChartFont.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<WorkbookChartFill>("fill", Fill);
            writer.WriteObjectValue<WorkbookChartFont>("font", Font);
        }
    }
}
