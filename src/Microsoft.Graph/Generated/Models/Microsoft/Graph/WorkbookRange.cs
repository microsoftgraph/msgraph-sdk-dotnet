using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class WorkbookRange : Entity, IParsable {
        /// <summary>Represents the range reference in A1-style. Address value will contain the Sheet reference (e.g. Sheet1!A1:B4). Read-only.</summary>
        public string Address { get; set; }
        /// <summary>Represents range reference for the specified range in the language of the user. Read-only.</summary>
        public string AddressLocal { get; set; }
        /// <summary>Number of cells in the range. Read-only.</summary>
        public int? CellCount { get; set; }
        /// <summary>Represents the total number of columns in the range. Read-only.</summary>
        public int? ColumnCount { get; set; }
        /// <summary>Represents if all columns of the current range are hidden.</summary>
        public bool? ColumnHidden { get; set; }
        /// <summary>Represents the column number of the first cell in the range. Zero-indexed. Read-only.</summary>
        public int? ColumnIndex { get; set; }
        /// <summary>Returns a format object, encapsulating the range's font, fill, borders, alignment, and other properties. Read-only.</summary>
        public WorkbookRangeFormat Format { get; set; }
        /// <summary>Represents the formula in A1-style notation.</summary>
        public Json Formulas { get; set; }
        /// <summary>Represents the formula in A1-style notation, in the user's language and number-formatting locale.  For example, the English '=SUM(A1, 1.5)' formula would become '=SUMME(A1; 1,5)' in German.</summary>
        public Json FormulasLocal { get; set; }
        /// <summary>Represents the formula in R1C1-style notation.</summary>
        public Json FormulasR1C1 { get; set; }
        /// <summary>Represents if all cells of the current range are hidden. Read-only.</summary>
        public bool? Hidden { get; set; }
        /// <summary>Represents Excel's number format code for the given cell.</summary>
        public Json NumberFormat { get; set; }
        /// <summary>Returns the total number of rows in the range. Read-only.</summary>
        public int? RowCount { get; set; }
        /// <summary>Represents if all rows of the current range are hidden.</summary>
        public bool? RowHidden { get; set; }
        /// <summary>Returns the row number of the first cell in the range. Zero-indexed. Read-only.</summary>
        public int? RowIndex { get; set; }
        /// <summary>The worksheet containing the current range. Read-only.</summary>
        public WorkbookRangeSort Sort { get; set; }
        /// <summary>Text values of the specified range. The Text value will not depend on the cell width. The # sign substitution that happens in Excel UI will not affect the text value returned by the API. Read-only.</summary>
        public Json Text { get; set; }
        /// <summary>Represents the raw values of the specified range. The data returned could be of type string, number, or a boolean. Cell that contain an error will return the error string.</summary>
        public Json Values { get; set; }
        /// <summary>Represents the type of data of each cell. The possible values are: Unknown, Empty, String, Integer, Double, Boolean, Error. Read-only.</summary>
        public Json ValueTypes { get; set; }
        /// <summary>The worksheet containing the current range. Read-only.</summary>
        public WorkbookWorksheet Worksheet { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"address", (o,n) => { (o as WorkbookRange).Address = n.GetStringValue(); } },
                {"addressLocal", (o,n) => { (o as WorkbookRange).AddressLocal = n.GetStringValue(); } },
                {"cellCount", (o,n) => { (o as WorkbookRange).CellCount = n.GetIntValue(); } },
                {"columnCount", (o,n) => { (o as WorkbookRange).ColumnCount = n.GetIntValue(); } },
                {"columnHidden", (o,n) => { (o as WorkbookRange).ColumnHidden = n.GetBoolValue(); } },
                {"columnIndex", (o,n) => { (o as WorkbookRange).ColumnIndex = n.GetIntValue(); } },
                {"format", (o,n) => { (o as WorkbookRange).Format = n.GetObjectValue<WorkbookRangeFormat>(); } },
                {"formulas", (o,n) => { (o as WorkbookRange).Formulas = n.GetObjectValue<Json>(); } },
                {"formulasLocal", (o,n) => { (o as WorkbookRange).FormulasLocal = n.GetObjectValue<Json>(); } },
                {"formulasR1C1", (o,n) => { (o as WorkbookRange).FormulasR1C1 = n.GetObjectValue<Json>(); } },
                {"hidden", (o,n) => { (o as WorkbookRange).Hidden = n.GetBoolValue(); } },
                {"numberFormat", (o,n) => { (o as WorkbookRange).NumberFormat = n.GetObjectValue<Json>(); } },
                {"rowCount", (o,n) => { (o as WorkbookRange).RowCount = n.GetIntValue(); } },
                {"rowHidden", (o,n) => { (o as WorkbookRange).RowHidden = n.GetBoolValue(); } },
                {"rowIndex", (o,n) => { (o as WorkbookRange).RowIndex = n.GetIntValue(); } },
                {"sort", (o,n) => { (o as WorkbookRange).Sort = n.GetObjectValue<WorkbookRangeSort>(); } },
                {"text", (o,n) => { (o as WorkbookRange).Text = n.GetObjectValue<Json>(); } },
                {"values", (o,n) => { (o as WorkbookRange).Values = n.GetObjectValue<Json>(); } },
                {"valueTypes", (o,n) => { (o as WorkbookRange).ValueTypes = n.GetObjectValue<Json>(); } },
                {"worksheet", (o,n) => { (o as WorkbookRange).Worksheet = n.GetObjectValue<WorkbookWorksheet>(); } },
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
