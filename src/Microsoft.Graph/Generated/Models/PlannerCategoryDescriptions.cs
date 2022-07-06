using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PlannerCategoryDescriptions : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The label associated with Category 1</summary>
        public string Category1 {
            get { return BackingStore?.Get<string>("category1"); }
            set { BackingStore?.Set("category1", value); }
        }
        /// <summary>The label associated with Category 10</summary>
        public string Category10 {
            get { return BackingStore?.Get<string>("category10"); }
            set { BackingStore?.Set("category10", value); }
        }
        /// <summary>The label associated with Category 11</summary>
        public string Category11 {
            get { return BackingStore?.Get<string>("category11"); }
            set { BackingStore?.Set("category11", value); }
        }
        /// <summary>The label associated with Category 12</summary>
        public string Category12 {
            get { return BackingStore?.Get<string>("category12"); }
            set { BackingStore?.Set("category12", value); }
        }
        /// <summary>The label associated with Category 13</summary>
        public string Category13 {
            get { return BackingStore?.Get<string>("category13"); }
            set { BackingStore?.Set("category13", value); }
        }
        /// <summary>The label associated with Category 14</summary>
        public string Category14 {
            get { return BackingStore?.Get<string>("category14"); }
            set { BackingStore?.Set("category14", value); }
        }
        /// <summary>The label associated with Category 15</summary>
        public string Category15 {
            get { return BackingStore?.Get<string>("category15"); }
            set { BackingStore?.Set("category15", value); }
        }
        /// <summary>The label associated with Category 16</summary>
        public string Category16 {
            get { return BackingStore?.Get<string>("category16"); }
            set { BackingStore?.Set("category16", value); }
        }
        /// <summary>The label associated with Category 17</summary>
        public string Category17 {
            get { return BackingStore?.Get<string>("category17"); }
            set { BackingStore?.Set("category17", value); }
        }
        /// <summary>The label associated with Category 18</summary>
        public string Category18 {
            get { return BackingStore?.Get<string>("category18"); }
            set { BackingStore?.Set("category18", value); }
        }
        /// <summary>The label associated with Category 19</summary>
        public string Category19 {
            get { return BackingStore?.Get<string>("category19"); }
            set { BackingStore?.Set("category19", value); }
        }
        /// <summary>The label associated with Category 2</summary>
        public string Category2 {
            get { return BackingStore?.Get<string>("category2"); }
            set { BackingStore?.Set("category2", value); }
        }
        /// <summary>The label associated with Category 20</summary>
        public string Category20 {
            get { return BackingStore?.Get<string>("category20"); }
            set { BackingStore?.Set("category20", value); }
        }
        /// <summary>The label associated with Category 21</summary>
        public string Category21 {
            get { return BackingStore?.Get<string>("category21"); }
            set { BackingStore?.Set("category21", value); }
        }
        /// <summary>The label associated with Category 22</summary>
        public string Category22 {
            get { return BackingStore?.Get<string>("category22"); }
            set { BackingStore?.Set("category22", value); }
        }
        /// <summary>The label associated with Category 23</summary>
        public string Category23 {
            get { return BackingStore?.Get<string>("category23"); }
            set { BackingStore?.Set("category23", value); }
        }
        /// <summary>The label associated with Category 24</summary>
        public string Category24 {
            get { return BackingStore?.Get<string>("category24"); }
            set { BackingStore?.Set("category24", value); }
        }
        /// <summary>The label associated with Category 25</summary>
        public string Category25 {
            get { return BackingStore?.Get<string>("category25"); }
            set { BackingStore?.Set("category25", value); }
        }
        /// <summary>The label associated with Category 3</summary>
        public string Category3 {
            get { return BackingStore?.Get<string>("category3"); }
            set { BackingStore?.Set("category3", value); }
        }
        /// <summary>The label associated with Category 4</summary>
        public string Category4 {
            get { return BackingStore?.Get<string>("category4"); }
            set { BackingStore?.Set("category4", value); }
        }
        /// <summary>The label associated with Category 5</summary>
        public string Category5 {
            get { return BackingStore?.Get<string>("category5"); }
            set { BackingStore?.Set("category5", value); }
        }
        /// <summary>The label associated with Category 6</summary>
        public string Category6 {
            get { return BackingStore?.Get<string>("category6"); }
            set { BackingStore?.Set("category6", value); }
        }
        /// <summary>The label associated with Category 7</summary>
        public string Category7 {
            get { return BackingStore?.Get<string>("category7"); }
            set { BackingStore?.Set("category7", value); }
        }
        /// <summary>The label associated with Category 8</summary>
        public string Category8 {
            get { return BackingStore?.Get<string>("category8"); }
            set { BackingStore?.Set("category8", value); }
        }
        /// <summary>The label associated with Category 9</summary>
        public string Category9 {
            get { return BackingStore?.Get<string>("category9"); }
            set { BackingStore?.Set("category9", value); }
        }
        /// <summary>
        /// Instantiates a new plannerCategoryDescriptions and sets the default values.
        /// </summary>
        public PlannerCategoryDescriptions() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static PlannerCategoryDescriptions CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PlannerCategoryDescriptions();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"category1", n => { Category1 = n.GetStringValue(); } },
                {"category10", n => { Category10 = n.GetStringValue(); } },
                {"category11", n => { Category11 = n.GetStringValue(); } },
                {"category12", n => { Category12 = n.GetStringValue(); } },
                {"category13", n => { Category13 = n.GetStringValue(); } },
                {"category14", n => { Category14 = n.GetStringValue(); } },
                {"category15", n => { Category15 = n.GetStringValue(); } },
                {"category16", n => { Category16 = n.GetStringValue(); } },
                {"category17", n => { Category17 = n.GetStringValue(); } },
                {"category18", n => { Category18 = n.GetStringValue(); } },
                {"category19", n => { Category19 = n.GetStringValue(); } },
                {"category2", n => { Category2 = n.GetStringValue(); } },
                {"category20", n => { Category20 = n.GetStringValue(); } },
                {"category21", n => { Category21 = n.GetStringValue(); } },
                {"category22", n => { Category22 = n.GetStringValue(); } },
                {"category23", n => { Category23 = n.GetStringValue(); } },
                {"category24", n => { Category24 = n.GetStringValue(); } },
                {"category25", n => { Category25 = n.GetStringValue(); } },
                {"category3", n => { Category3 = n.GetStringValue(); } },
                {"category4", n => { Category4 = n.GetStringValue(); } },
                {"category5", n => { Category5 = n.GetStringValue(); } },
                {"category6", n => { Category6 = n.GetStringValue(); } },
                {"category7", n => { Category7 = n.GetStringValue(); } },
                {"category8", n => { Category8 = n.GetStringValue(); } },
                {"category9", n => { Category9 = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("category1", Category1);
            writer.WriteStringValue("category10", Category10);
            writer.WriteStringValue("category11", Category11);
            writer.WriteStringValue("category12", Category12);
            writer.WriteStringValue("category13", Category13);
            writer.WriteStringValue("category14", Category14);
            writer.WriteStringValue("category15", Category15);
            writer.WriteStringValue("category16", Category16);
            writer.WriteStringValue("category17", Category17);
            writer.WriteStringValue("category18", Category18);
            writer.WriteStringValue("category19", Category19);
            writer.WriteStringValue("category2", Category2);
            writer.WriteStringValue("category20", Category20);
            writer.WriteStringValue("category21", Category21);
            writer.WriteStringValue("category22", Category22);
            writer.WriteStringValue("category23", Category23);
            writer.WriteStringValue("category24", Category24);
            writer.WriteStringValue("category25", Category25);
            writer.WriteStringValue("category3", Category3);
            writer.WriteStringValue("category4", Category4);
            writer.WriteStringValue("category5", Category5);
            writer.WriteStringValue("category6", Category6);
            writer.WriteStringValue("category7", Category7);
            writer.WriteStringValue("category8", Category8);
            writer.WriteStringValue("category9", Category9);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
