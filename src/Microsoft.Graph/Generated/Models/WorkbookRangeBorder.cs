using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class WorkbookRangeBorder : Entity, IParsable {
        /// <summary>HTML color code representing the color of the border line, of the form #RRGGBB (e.g. &apos;FFA500&apos;) or as a named HTML color (e.g. &apos;orange&apos;).</summary>
        public string Color {
            get { return BackingStore?.Get<string>("color"); }
            set { BackingStore?.Set("color", value); }
        }
        /// <summary>Constant value that indicates the specific side of the border. The possible values are: EdgeTop, EdgeBottom, EdgeLeft, EdgeRight, InsideVertical, InsideHorizontal, DiagonalDown, DiagonalUp. Read-only.</summary>
        public string SideIndex {
            get { return BackingStore?.Get<string>("sideIndex"); }
            set { BackingStore?.Set("sideIndex", value); }
        }
        /// <summary>One of the constants of line style specifying the line style for the border. The possible values are: None, Continuous, Dash, DashDot, DashDotDot, Dot, Double, SlantDashDot.</summary>
        public string Style {
            get { return BackingStore?.Get<string>("style"); }
            set { BackingStore?.Set("style", value); }
        }
        /// <summary>Specifies the weight of the border around a range. The possible values are: Hairline, Thin, Medium, Thick.</summary>
        public string Weight {
            get { return BackingStore?.Get<string>("weight"); }
            set { BackingStore?.Set("weight", value); }
        }
        /// <summary>
        /// Instantiates a new workbookRangeBorder and sets the default values.
        /// </summary>
        public WorkbookRangeBorder() : base() {
            OdataType = "#microsoft.graph.workbookRangeBorder";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WorkbookRangeBorder CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookRangeBorder();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"color", n => { Color = n.GetStringValue(); } },
                {"sideIndex", n => { SideIndex = n.GetStringValue(); } },
                {"style", n => { Style = n.GetStringValue(); } },
                {"weight", n => { Weight = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("color", Color);
            writer.WriteStringValue("sideIndex", SideIndex);
            writer.WriteStringValue("style", Style);
            writer.WriteStringValue("weight", Weight);
        }
    }
}
