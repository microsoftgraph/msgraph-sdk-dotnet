using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkbookRangeView : Entity, IParsable {
        /// <summary>Represents the cell addresses</summary>
        public Json CellAddresses {
            get { return BackingStore?.Get<Json>("cellAddresses"); }
            set { BackingStore?.Set("cellAddresses", value); }
        }
        /// <summary>Returns the number of visible columns. Read-only.</summary>
        public int? ColumnCount {
            get { return BackingStore?.Get<int?>("columnCount"); }
            set { BackingStore?.Set("columnCount", value); }
        }
        /// <summary>Represents the formula in A1-style notation.</summary>
        public Json Formulas {
            get { return BackingStore?.Get<Json>("formulas"); }
            set { BackingStore?.Set("formulas", value); }
        }
        /// <summary>Represents the formula in A1-style notation, in the user&apos;s language and number-formatting locale. For example, the English &apos;=SUM(A1, 1.5)&apos; formula would become &apos;=SUMME(A1; 1,5)&apos; in German.</summary>
        public Json FormulasLocal {
            get { return BackingStore?.Get<Json>("formulasLocal"); }
            set { BackingStore?.Set("formulasLocal", value); }
        }
        /// <summary>Represents the formula in R1C1-style notation.</summary>
        public Json FormulasR1C1 {
            get { return BackingStore?.Get<Json>("formulasR1C1"); }
            set { BackingStore?.Set("formulasR1C1", value); }
        }
        /// <summary>Index of the range.</summary>
        public int? Index {
            get { return BackingStore?.Get<int?>("index"); }
            set { BackingStore?.Set("index", value); }
        }
        /// <summary>Represents Excel&apos;s number format code for the given cell. Read-only.</summary>
        public Json NumberFormat {
            get { return BackingStore?.Get<Json>("numberFormat"); }
            set { BackingStore?.Set("numberFormat", value); }
        }
        /// <summary>Returns the number of visible rows. Read-only.</summary>
        public int? RowCount {
            get { return BackingStore?.Get<int?>("rowCount"); }
            set { BackingStore?.Set("rowCount", value); }
        }
        /// <summary>Represents a collection of range views associated with the range. Read-only. Read-only.</summary>
        public List<WorkbookRangeView> Rows {
            get { return BackingStore?.Get<List<WorkbookRangeView>>("rows"); }
            set { BackingStore?.Set("rows", value); }
        }
        /// <summary>Text values of the specified range. The Text value will not depend on the cell width. The # sign substitution that happens in Excel UI will not affect the text value returned by the API. Read-only.</summary>
        public Json Text {
            get { return BackingStore?.Get<Json>("text"); }
            set { BackingStore?.Set("text", value); }
        }
        /// <summary>Represents the raw values of the specified range view. The data returned could be of type string, number, or a boolean. Cell that contain an error will return the error string.</summary>
        public Json Values {
            get { return BackingStore?.Get<Json>("values"); }
            set { BackingStore?.Set("values", value); }
        }
        /// <summary>Represents the type of data of each cell. Read-only. Possible values are: Unknown, Empty, String, Integer, Double, Boolean, Error.</summary>
        public Json ValueTypes {
            get { return BackingStore?.Get<Json>("valueTypes"); }
            set { BackingStore?.Set("valueTypes", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookRangeView CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookRangeView();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"cellAddresses", n => { CellAddresses = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"columnCount", n => { ColumnCount = n.GetIntValue(); } },
                {"formulas", n => { Formulas = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"formulasLocal", n => { FormulasLocal = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"formulasR1C1", n => { FormulasR1C1 = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"index", n => { Index = n.GetIntValue(); } },
                {"numberFormat", n => { NumberFormat = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"rowCount", n => { RowCount = n.GetIntValue(); } },
                {"rows", n => { Rows = n.GetCollectionOfObjectValues<WorkbookRangeView>(WorkbookRangeView.CreateFromDiscriminatorValue).ToList(); } },
                {"text", n => { Text = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"values", n => { Values = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"valueTypes", n => { ValueTypes = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
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
