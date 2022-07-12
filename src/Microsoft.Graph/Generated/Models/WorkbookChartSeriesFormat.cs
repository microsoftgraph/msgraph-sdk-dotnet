using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkbookChartSeriesFormat : Entity, IParsable {
        /// <summary>Represents the fill format of a chart series, which includes background formating information. Read-only.</summary>
        public WorkbookChartFill Fill {
            get { return BackingStore?.Get<WorkbookChartFill>("fill"); }
            set { BackingStore?.Set("fill", value); }
        }
        /// <summary>Represents line formatting. Read-only.</summary>
        public WorkbookChartLineFormat Line {
            get { return BackingStore?.Get<WorkbookChartLineFormat>("line"); }
            set { BackingStore?.Set("line", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookChartSeriesFormat CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookChartSeriesFormat();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"fill", n => { Fill = n.GetObjectValue<WorkbookChartFill>(WorkbookChartFill.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<WorkbookChartFill>("fill", Fill);
            writer.WriteObjectValue<WorkbookChartLineFormat>("line", Line);
        }
    }
}
