using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkbookRangeFormat : Entity, IParsable {
        /// <summary>Collection of border objects that apply to the overall range selected Read-only.</summary>
        public List<WorkbookRangeBorder> Borders {
            get { return BackingStore?.Get<List<WorkbookRangeBorder>>("borders"); }
            set { BackingStore?.Set("borders", value); }
        }
        /// <summary>Gets or sets the width of all colums within the range. If the column widths are not uniform, null will be returned.</summary>
        public double? ColumnWidth {
            get { return BackingStore?.Get<double?>("columnWidth"); }
            set { BackingStore?.Set("columnWidth", value); }
        }
        /// <summary>Returns the fill object defined on the overall range. Read-only.</summary>
        public WorkbookRangeFill Fill {
            get { return BackingStore?.Get<WorkbookRangeFill>("fill"); }
            set { BackingStore?.Set("fill", value); }
        }
        /// <summary>Returns the font object defined on the overall range selected Read-only.</summary>
        public WorkbookRangeFont Font {
            get { return BackingStore?.Get<WorkbookRangeFont>("font"); }
            set { BackingStore?.Set("font", value); }
        }
        /// <summary>Represents the horizontal alignment for the specified object. Possible values are: General, Left, Center, Right, Fill, Justify, CenterAcrossSelection, Distributed.</summary>
        public string HorizontalAlignment {
            get { return BackingStore?.Get<string>("horizontalAlignment"); }
            set { BackingStore?.Set("horizontalAlignment", value); }
        }
        /// <summary>Returns the format protection object for a range. Read-only.</summary>
        public WorkbookFormatProtection Protection {
            get { return BackingStore?.Get<WorkbookFormatProtection>("protection"); }
            set { BackingStore?.Set("protection", value); }
        }
        /// <summary>Gets or sets the height of all rows in the range. If the row heights are not uniform null will be returned.</summary>
        public double? RowHeight {
            get { return BackingStore?.Get<double?>("rowHeight"); }
            set { BackingStore?.Set("rowHeight", value); }
        }
        /// <summary>Represents the vertical alignment for the specified object. Possible values are: Top, Center, Bottom, Justify, Distributed.</summary>
        public string VerticalAlignment {
            get { return BackingStore?.Get<string>("verticalAlignment"); }
            set { BackingStore?.Set("verticalAlignment", value); }
        }
        /// <summary>Indicates if Excel wraps the text in the object. A null value indicates that the entire range doesn&apos;t have uniform wrap setting</summary>
        public bool? WrapText {
            get { return BackingStore?.Get<bool?>("wrapText"); }
            set { BackingStore?.Set("wrapText", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookRangeFormat CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookRangeFormat();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"borders", n => { Borders = n.GetCollectionOfObjectValues<WorkbookRangeBorder>(WorkbookRangeBorder.CreateFromDiscriminatorValue).ToList(); } },
                {"columnWidth", n => { ColumnWidth = n.GetDoubleValue(); } },
                {"fill", n => { Fill = n.GetObjectValue<WorkbookRangeFill>(WorkbookRangeFill.CreateFromDiscriminatorValue); } },
                {"font", n => { Font = n.GetObjectValue<WorkbookRangeFont>(WorkbookRangeFont.CreateFromDiscriminatorValue); } },
                {"horizontalAlignment", n => { HorizontalAlignment = n.GetStringValue(); } },
                {"protection", n => { Protection = n.GetObjectValue<WorkbookFormatProtection>(WorkbookFormatProtection.CreateFromDiscriminatorValue); } },
                {"rowHeight", n => { RowHeight = n.GetDoubleValue(); } },
                {"verticalAlignment", n => { VerticalAlignment = n.GetStringValue(); } },
                {"wrapText", n => { WrapText = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<WorkbookRangeBorder>("borders", Borders);
            writer.WriteDoubleValue("columnWidth", ColumnWidth);
            writer.WriteObjectValue<WorkbookRangeFill>("fill", Fill);
            writer.WriteObjectValue<WorkbookRangeFont>("font", Font);
            writer.WriteStringValue("horizontalAlignment", HorizontalAlignment);
            writer.WriteObjectValue<WorkbookFormatProtection>("protection", Protection);
            writer.WriteDoubleValue("rowHeight", RowHeight);
            writer.WriteStringValue("verticalAlignment", VerticalAlignment);
            writer.WriteBoolValue("wrapText", WrapText);
        }
    }
}
