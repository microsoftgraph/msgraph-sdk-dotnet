using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkbookRange : Entity, IParsable {
        /// <summary>Represents the range reference in A1-style. Address value will contain the Sheet reference (e.g. Sheet1!A1:B4). Read-only.</summary>
        public string Address {
            get { return BackingStore?.Get<string>("address"); }
            set { BackingStore?.Set("address", value); }
        }
        /// <summary>Represents range reference for the specified range in the language of the user. Read-only.</summary>
        public string AddressLocal {
            get { return BackingStore?.Get<string>("addressLocal"); }
            set { BackingStore?.Set("addressLocal", value); }
        }
        /// <summary>Number of cells in the range. Read-only.</summary>
        public int? CellCount {
            get { return BackingStore?.Get<int?>("cellCount"); }
            set { BackingStore?.Set("cellCount", value); }
        }
        /// <summary>Represents the total number of columns in the range. Read-only.</summary>
        public int? ColumnCount {
            get { return BackingStore?.Get<int?>("columnCount"); }
            set { BackingStore?.Set("columnCount", value); }
        }
        /// <summary>Represents if all columns of the current range are hidden.</summary>
        public bool? ColumnHidden {
            get { return BackingStore?.Get<bool?>("columnHidden"); }
            set { BackingStore?.Set("columnHidden", value); }
        }
        /// <summary>Represents the column number of the first cell in the range. Zero-indexed. Read-only.</summary>
        public int? ColumnIndex {
            get { return BackingStore?.Get<int?>("columnIndex"); }
            set { BackingStore?.Set("columnIndex", value); }
        }
        /// <summary>Returns a format object, encapsulating the range&apos;s font, fill, borders, alignment, and other properties. Read-only.</summary>
        public WorkbookRangeFormat Format {
            get { return BackingStore?.Get<WorkbookRangeFormat>("format"); }
            set { BackingStore?.Set("format", value); }
        }
        /// <summary>Represents the formula in A1-style notation.</summary>
        public Json Formulas {
            get { return BackingStore?.Get<Json>("formulas"); }
            set { BackingStore?.Set("formulas", value); }
        }
        /// <summary>Represents the formula in A1-style notation, in the user&apos;s language and number-formatting locale.  For example, the English &apos;=SUM(A1, 1.5)&apos; formula would become &apos;=SUMME(A1; 1,5)&apos; in German.</summary>
        public Json FormulasLocal {
            get { return BackingStore?.Get<Json>("formulasLocal"); }
            set { BackingStore?.Set("formulasLocal", value); }
        }
        /// <summary>Represents the formula in R1C1-style notation.</summary>
        public Json FormulasR1C1 {
            get { return BackingStore?.Get<Json>("formulasR1C1"); }
            set { BackingStore?.Set("formulasR1C1", value); }
        }
        /// <summary>Represents if all cells of the current range are hidden. Read-only.</summary>
        public bool? Hidden {
            get { return BackingStore?.Get<bool?>("hidden"); }
            set { BackingStore?.Set("hidden", value); }
        }
        /// <summary>Represents Excel&apos;s number format code for the given cell.</summary>
        public Json NumberFormat {
            get { return BackingStore?.Get<Json>("numberFormat"); }
            set { BackingStore?.Set("numberFormat", value); }
        }
        /// <summary>Returns the total number of rows in the range. Read-only.</summary>
        public int? RowCount {
            get { return BackingStore?.Get<int?>("rowCount"); }
            set { BackingStore?.Set("rowCount", value); }
        }
        /// <summary>Represents if all rows of the current range are hidden.</summary>
        public bool? RowHidden {
            get { return BackingStore?.Get<bool?>("rowHidden"); }
            set { BackingStore?.Set("rowHidden", value); }
        }
        /// <summary>Returns the row number of the first cell in the range. Zero-indexed. Read-only.</summary>
        public int? RowIndex {
            get { return BackingStore?.Get<int?>("rowIndex"); }
            set { BackingStore?.Set("rowIndex", value); }
        }
        /// <summary>The worksheet containing the current range. Read-only.</summary>
        public WorkbookRangeSort Sort {
            get { return BackingStore?.Get<WorkbookRangeSort>("sort"); }
            set { BackingStore?.Set("sort", value); }
        }
        /// <summary>Text values of the specified range. The Text value will not depend on the cell width. The # sign substitution that happens in Excel UI will not affect the text value returned by the API. Read-only.</summary>
        public Json Text {
            get { return BackingStore?.Get<Json>("text"); }
            set { BackingStore?.Set("text", value); }
        }
        /// <summary>Represents the raw values of the specified range. The data returned could be of type string, number, or a boolean. Cell that contain an error will return the error string.</summary>
        public Json Values {
            get { return BackingStore?.Get<Json>("values"); }
            set { BackingStore?.Set("values", value); }
        }
        /// <summary>Represents the type of data of each cell. Possible values are: Unknown, Empty, String, Integer, Double, Boolean, Error. Read-only.</summary>
        public Json ValueTypes {
            get { return BackingStore?.Get<Json>("valueTypes"); }
            set { BackingStore?.Set("valueTypes", value); }
        }
        /// <summary>The worksheet containing the current range. Read-only.</summary>
        public WorkbookWorksheet Worksheet {
            get { return BackingStore?.Get<WorkbookWorksheet>("worksheet"); }
            set { BackingStore?.Set("worksheet", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookRange CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookRange();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"address", n => { Address = n.GetStringValue(); } },
                {"addressLocal", n => { AddressLocal = n.GetStringValue(); } },
                {"cellCount", n => { CellCount = n.GetIntValue(); } },
                {"columnCount", n => { ColumnCount = n.GetIntValue(); } },
                {"columnHidden", n => { ColumnHidden = n.GetBoolValue(); } },
                {"columnIndex", n => { ColumnIndex = n.GetIntValue(); } },
                {"format", n => { Format = n.GetObjectValue<WorkbookRangeFormat>(WorkbookRangeFormat.CreateFromDiscriminatorValue); } },
                {"formulas", n => { Formulas = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"formulasLocal", n => { FormulasLocal = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"formulasR1C1", n => { FormulasR1C1 = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"hidden", n => { Hidden = n.GetBoolValue(); } },
                {"numberFormat", n => { NumberFormat = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"rowCount", n => { RowCount = n.GetIntValue(); } },
                {"rowHidden", n => { RowHidden = n.GetBoolValue(); } },
                {"rowIndex", n => { RowIndex = n.GetIntValue(); } },
                {"sort", n => { Sort = n.GetObjectValue<WorkbookRangeSort>(WorkbookRangeSort.CreateFromDiscriminatorValue); } },
                {"text", n => { Text = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"values", n => { Values = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"valueTypes", n => { ValueTypes = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
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
            writer.WriteStringValue("address", Address);
            writer.WriteStringValue("addressLocal", AddressLocal);
            writer.WriteIntValue("cellCount", CellCount);
            writer.WriteIntValue("columnCount", ColumnCount);
            writer.WriteBoolValue("columnHidden", ColumnHidden);
            writer.WriteIntValue("columnIndex", ColumnIndex);
            writer.WriteObjectValue<WorkbookRangeFormat>("format", Format);
            writer.WriteObjectValue<Json>("formulas", Formulas);
            writer.WriteObjectValue<Json>("formulasLocal", FormulasLocal);
            writer.WriteObjectValue<Json>("formulasR1C1", FormulasR1C1);
            writer.WriteBoolValue("hidden", Hidden);
            writer.WriteObjectValue<Json>("numberFormat", NumberFormat);
            writer.WriteIntValue("rowCount", RowCount);
            writer.WriteBoolValue("rowHidden", RowHidden);
            writer.WriteIntValue("rowIndex", RowIndex);
            writer.WriteObjectValue<WorkbookRangeSort>("sort", Sort);
            writer.WriteObjectValue<Json>("text", Text);
            writer.WriteObjectValue<Json>("values", Values);
            writer.WriteObjectValue<Json>("valueTypes", ValueTypes);
            writer.WriteObjectValue<WorkbookWorksheet>("worksheet", Worksheet);
        }
    }
}
