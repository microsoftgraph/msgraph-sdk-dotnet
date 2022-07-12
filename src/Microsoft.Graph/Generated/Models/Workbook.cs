using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Workbook : Entity, IParsable {
        /// <summary>The application property</summary>
        public WorkbookApplication Application {
            get { return BackingStore?.Get<WorkbookApplication>("application"); }
            set { BackingStore?.Set("application", value); }
        }
        /// <summary>The comments property</summary>
        public List<WorkbookComment> Comments {
            get { return BackingStore?.Get<List<WorkbookComment>>("comments"); }
            set { BackingStore?.Set("comments", value); }
        }
        /// <summary>The functions property</summary>
        public WorkbookFunctions Functions {
            get { return BackingStore?.Get<WorkbookFunctions>("functions"); }
            set { BackingStore?.Set("functions", value); }
        }
        /// <summary>Represents a collection of workbooks scoped named items (named ranges and constants). Read-only.</summary>
        public List<WorkbookNamedItem> Names {
            get { return BackingStore?.Get<List<WorkbookNamedItem>>("names"); }
            set { BackingStore?.Set("names", value); }
        }
        /// <summary>The status of Workbook operations. Getting an operation collection is not supported, but you can get the status of a long-running operation if the Location header is returned in the response. Read-only. Nullable.</summary>
        public List<WorkbookOperation> Operations {
            get { return BackingStore?.Get<List<WorkbookOperation>>("operations"); }
            set { BackingStore?.Set("operations", value); }
        }
        /// <summary>Represents a collection of tables associated with the workbook. Read-only.</summary>
        public List<WorkbookTable> Tables {
            get { return BackingStore?.Get<List<WorkbookTable>>("tables"); }
            set { BackingStore?.Set("tables", value); }
        }
        /// <summary>Represents a collection of worksheets associated with the workbook. Read-only.</summary>
        public List<WorkbookWorksheet> Worksheets {
            get { return BackingStore?.Get<List<WorkbookWorksheet>>("worksheets"); }
            set { BackingStore?.Set("worksheets", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Workbook CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Workbook();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"application", n => { Application = n.GetObjectValue<WorkbookApplication>(WorkbookApplication.CreateFromDiscriminatorValue); } },
                {"comments", n => { Comments = n.GetCollectionOfObjectValues<WorkbookComment>(WorkbookComment.CreateFromDiscriminatorValue).ToList(); } },
                {"functions", n => { Functions = n.GetObjectValue<WorkbookFunctions>(WorkbookFunctions.CreateFromDiscriminatorValue); } },
                {"names", n => { Names = n.GetCollectionOfObjectValues<WorkbookNamedItem>(WorkbookNamedItem.CreateFromDiscriminatorValue).ToList(); } },
                {"operations", n => { Operations = n.GetCollectionOfObjectValues<WorkbookOperation>(WorkbookOperation.CreateFromDiscriminatorValue).ToList(); } },
                {"tables", n => { Tables = n.GetCollectionOfObjectValues<WorkbookTable>(WorkbookTable.CreateFromDiscriminatorValue).ToList(); } },
                {"worksheets", n => { Worksheets = n.GetCollectionOfObjectValues<WorkbookWorksheet>(WorkbookWorksheet.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<WorkbookApplication>("application", Application);
            writer.WriteCollectionOfObjectValues<WorkbookComment>("comments", Comments);
            writer.WriteObjectValue<WorkbookFunctions>("functions", Functions);
            writer.WriteCollectionOfObjectValues<WorkbookNamedItem>("names", Names);
            writer.WriteCollectionOfObjectValues<WorkbookOperation>("operations", Operations);
            writer.WriteCollectionOfObjectValues<WorkbookTable>("tables", Tables);
            writer.WriteCollectionOfObjectValues<WorkbookWorksheet>("worksheets", Worksheets);
        }
    }
}
