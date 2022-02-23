using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class WorkbookRangeView : Entity, IParsable {
        /// <summary>Represents the cell addresses</summary>
        public Json CellAddresses { get; set; }
        /// <summary>Returns the number of visible columns. Read-only.</summary>
        public int? ColumnCount { get; set; }
        /// <summary>Represents the formula in A1-style notation.</summary>
        public Json Formulas { get; set; }
        /// <summary>Represents the formula in A1-style notation, in the user's language and number-formatting locale. For example, the English '=SUM(A1, 1.5)' formula would become '=SUMME(A1; 1,5)' in German.</summary>
        public Json FormulasLocal { get; set; }
        /// <summary>Represents the formula in R1C1-style notation.</summary>
        public Json FormulasR1C1 { get; set; }
        /// <summary>Index of the range.</summary>
        public int? Index { get; set; }
        /// <summary>Represents Excel's number format code for the given cell. Read-only.</summary>
        public Json NumberFormat { get; set; }
        /// <summary>Returns the number of visible rows. Read-only.</summary>
        public int? RowCount { get; set; }
        /// <summary>Represents a collection of range views associated with the range. Read-only. Read-only.</summary>
        public List<WorkbookRangeView> Rows { get; set; }
        /// <summary>Text values of the specified range. The Text value will not depend on the cell width. The # sign substitution that happens in Excel UI will not affect the text value returned by the API. Read-only.</summary>
        public Json Text { get; set; }
        /// <summary>Represents the raw values of the specified range view. The data returned could be of type string, number, or a boolean. Cell that contain an error will return the error string.</summary>
        public Json Values { get; set; }
        /// <summary>Represents the type of data of each cell. Read-only. The possible values are: Unknown, Empty, String, Integer, Double, Boolean, Error.</summary>
        public Json ValueTypes { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"cellAddresses", (o,n) => { (o as WorkbookRangeView).CellAddresses = n.GetObjectValue<Json>(); } },
                {"columnCount", (o,n) => { (o as WorkbookRangeView).ColumnCount = n.GetIntValue(); } },
                {"formulas", (o,n) => { (o as WorkbookRangeView).Formulas = n.GetObjectValue<Json>(); } },
                {"formulasLocal", (o,n) => { (o as WorkbookRangeView).FormulasLocal = n.GetObjectValue<Json>(); } },
                {"formulasR1C1", (o,n) => { (o as WorkbookRangeView).FormulasR1C1 = n.GetObjectValue<Json>(); } },
                {"index", (o,n) => { (o as WorkbookRangeView).Index = n.GetIntValue(); } },
                {"numberFormat", (o,n) => { (o as WorkbookRangeView).NumberFormat = n.GetObjectValue<Json>(); } },
                {"rowCount", (o,n) => { (o as WorkbookRangeView).RowCount = n.GetIntValue(); } },
                {"rows", (o,n) => { (o as WorkbookRangeView).Rows = n.GetCollectionOfObjectValues<WorkbookRangeView>().ToList(); } },
                {"text", (o,n) => { (o as WorkbookRangeView).Text = n.GetObjectValue<Json>(); } },
                {"values", (o,n) => { (o as WorkbookRangeView).Values = n.GetObjectValue<Json>(); } },
                {"valueTypes", (o,n) => { (o as WorkbookRangeView).ValueTypes = n.GetObjectValue<Json>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Json>("cellAddresses", CellAddresses);
            writer.WriteIntValue("columnCount", ColumnCount);
            writer.WriteObjectValue<Json>("formulas", Formulas);
            writer.WriteObjectValue<Json>("formulasLocal", FormulasLocal);
            writer.WriteObjectValue<Json>("formulasR1C1", FormulasR1C1);
            writer.WriteIntValue("index", Index);
            writer.WriteObjectValue<Json>("numberFormat", NumberFormat);
            writer.WriteIntValue("rowCount", RowCount);
            writer.WriteCollectionOfObjectValues<WorkbookRangeView>("rows", Rows);
            writer.WriteObjectValue<Json>("text", Text);
            writer.WriteObjectValue<Json>("values", Values);
            writer.WriteObjectValue<Json>("valueTypes", ValueTypes);
        }
    }
}
