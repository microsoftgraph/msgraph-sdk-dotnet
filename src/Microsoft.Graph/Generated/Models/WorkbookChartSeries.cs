using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class WorkbookChartSeries : Entity, IParsable {
        /// <summary>Represents the formatting of a chart series, which includes fill and line formatting. Read-only.</summary>
        public WorkbookChartSeriesFormat Format {
            get { return BackingStore?.Get<WorkbookChartSeriesFormat>("format"); }
            set { BackingStore?.Set("format", value); }
        }
        /// <summary>Represents the name of a series in a chart.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>Represents a collection of all points in the series. Read-only.</summary>
        public List<WorkbookChartPoint> Points {
            get { return BackingStore?.Get<List<WorkbookChartPoint>>("points"); }
            set { BackingStore?.Set("points", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookChartSeries CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookChartSeries();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"format", n => { Format = n.GetObjectValue<WorkbookChartSeriesFormat>(WorkbookChartSeriesFormat.CreateFromDiscriminatorValue); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"points", n => { Points = n.GetCollectionOfObjectValues<WorkbookChartPoint>(WorkbookChartPoint.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<WorkbookChartSeriesFormat>("format", Format);
            writer.WriteStringValue("name", Name);
            writer.WriteCollectionOfObjectValues<WorkbookChartPoint>("points", Points);
        }
    }
}
