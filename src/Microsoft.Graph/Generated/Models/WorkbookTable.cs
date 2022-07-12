using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class WorkbookTable : Entity, IParsable {
        /// <summary>Represents a collection of all the columns in the table. Read-only.</summary>
        public List<WorkbookTableColumn> Columns {
            get { return BackingStore?.Get<List<WorkbookTableColumn>>("columns"); }
            set { BackingStore?.Set("columns", value); }
        }
        /// <summary>Indicates whether the first column contains special formatting.</summary>
        public bool? HighlightFirstColumn {
            get { return BackingStore?.Get<bool?>("highlightFirstColumn"); }
            set { BackingStore?.Set("highlightFirstColumn", value); }
        }
        /// <summary>Indicates whether the last column contains special formatting.</summary>
        public bool? HighlightLastColumn {
            get { return BackingStore?.Get<bool?>("highlightLastColumn"); }
            set { BackingStore?.Set("highlightLastColumn", value); }
        }
        /// <summary>Legacy Id used in older Excle clients. The value of the identifier remains the same even when the table is renamed. This property should be interpreted as an opaque string value and should not be parsed to any other type. Read-only.</summary>
        public string LegacyId {
            get { return BackingStore?.Get<string>("legacyId"); }
            set { BackingStore?.Set("legacyId", value); }
        }
        /// <summary>Name of the table.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>Represents a collection of all the rows in the table. Read-only.</summary>
        public List<WorkbookTableRow> Rows {
            get { return BackingStore?.Get<List<WorkbookTableRow>>("rows"); }
            set { BackingStore?.Set("rows", value); }
        }
        /// <summary>Indicates whether the columns show banded formatting in which odd columns are highlighted differently from even ones to make reading the table easier.</summary>
        public bool? ShowBandedColumns {
            get { return BackingStore?.Get<bool?>("showBandedColumns"); }
            set { BackingStore?.Set("showBandedColumns", value); }
        }
        /// <summary>Indicates whether the rows show banded formatting in which odd rows are highlighted differently from even ones to make reading the table easier.</summary>
        public bool? ShowBandedRows {
            get { return BackingStore?.Get<bool?>("showBandedRows"); }
            set { BackingStore?.Set("showBandedRows", value); }
        }
        /// <summary>Indicates whether the filter buttons are visible at the top of each column header. Setting this is only allowed if the table contains a header row.</summary>
        public bool? ShowFilterButton {
            get { return BackingStore?.Get<bool?>("showFilterButton"); }
            set { BackingStore?.Set("showFilterButton", value); }
        }
        /// <summary>Indicates whether the header row is visible or not. This value can be set to show or remove the header row.</summary>
        public bool? ShowHeaders {
            get { return BackingStore?.Get<bool?>("showHeaders"); }
            set { BackingStore?.Set("showHeaders", value); }
        }
        /// <summary>Indicates whether the total row is visible or not. This value can be set to show or remove the total row.</summary>
        public bool? ShowTotals {
            get { return BackingStore?.Get<bool?>("showTotals"); }
            set { BackingStore?.Set("showTotals", value); }
        }
        /// <summary>Represents the sorting for the table. Read-only.</summary>
        public WorkbookTableSort Sort {
            get { return BackingStore?.Get<WorkbookTableSort>("sort"); }
            set { BackingStore?.Set("sort", value); }
        }
        /// <summary>Constant value that represents the Table style. Possible values are: TableStyleLight1 thru TableStyleLight21, TableStyleMedium1 thru TableStyleMedium28, TableStyleStyleDark1 thru TableStyleStyleDark11. A custom user-defined style present in the workbook can also be specified.</summary>
        public string Style {
            get { return BackingStore?.Get<string>("style"); }
            set { BackingStore?.Set("style", value); }
        }
        /// <summary>The worksheet containing the current table. Read-only.</summary>
        public WorkbookWorksheet Worksheet {
            get { return BackingStore?.Get<WorkbookWorksheet>("worksheet"); }
            set { BackingStore?.Set("worksheet", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookTable CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookTable();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"columns", n => { Columns = n.GetCollectionOfObjectValues<WorkbookTableColumn>(WorkbookTableColumn.CreateFromDiscriminatorValue).ToList(); } },
                {"highlightFirstColumn", n => { HighlightFirstColumn = n.GetBoolValue(); } },
                {"highlightLastColumn", n => { HighlightLastColumn = n.GetBoolValue(); } },
                {"legacyId", n => { LegacyId = n.GetStringValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"rows", n => { Rows = n.GetCollectionOfObjectValues<WorkbookTableRow>(WorkbookTableRow.CreateFromDiscriminatorValue).ToList(); } },
                {"showBandedColumns", n => { ShowBandedColumns = n.GetBoolValue(); } },
                {"showBandedRows", n => { ShowBandedRows = n.GetBoolValue(); } },
                {"showFilterButton", n => { ShowFilterButton = n.GetBoolValue(); } },
                {"showHeaders", n => { ShowHeaders = n.GetBoolValue(); } },
                {"showTotals", n => { ShowTotals = n.GetBoolValue(); } },
                {"sort", n => { Sort = n.GetObjectValue<WorkbookTableSort>(WorkbookTableSort.CreateFromDiscriminatorValue); } },
                {"style", n => { Style = n.GetStringValue(); } },
                {"worksheet", n => { Worksheet = n.GetObjectValue<WorkbookWorksheet>(WorkbookWorksheet.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<WorkbookTableColumn>("columns", Columns);
            writer.WriteBoolValue("highlightFirstColumn", HighlightFirstColumn);
            writer.WriteBoolValue("highlightLastColumn", HighlightLastColumn);
            writer.WriteStringValue("legacyId", LegacyId);
            writer.WriteStringValue("name", Name);
            writer.WriteCollectionOfObjectValues<WorkbookTableRow>("rows", Rows);
            writer.WriteBoolValue("showBandedColumns", ShowBandedColumns);
            writer.WriteBoolValue("showBandedRows", ShowBandedRows);
            writer.WriteBoolValue("showFilterButton", ShowFilterButton);
            writer.WriteBoolValue("showHeaders", ShowHeaders);
            writer.WriteBoolValue("showTotals", ShowTotals);
            writer.WriteObjectValue<WorkbookTableSort>("sort", Sort);
            writer.WriteStringValue("style", Style);
            writer.WriteObjectValue<WorkbookWorksheet>("worksheet", Worksheet);
        }
    }
}
