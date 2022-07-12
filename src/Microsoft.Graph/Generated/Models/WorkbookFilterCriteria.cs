using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkbookFilterCriteria : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The color property</summary>
        public string Color {
            get { return BackingStore?.Get<string>("color"); }
            set { BackingStore?.Set("color", value); }
        }
        /// <summary>The criterion1 property</summary>
        public string Criterion1 {
            get { return BackingStore?.Get<string>("criterion1"); }
            set { BackingStore?.Set("criterion1", value); }
        }
        /// <summary>The criterion2 property</summary>
        public string Criterion2 {
            get { return BackingStore?.Get<string>("criterion2"); }
            set { BackingStore?.Set("criterion2", value); }
        }
        /// <summary>The dynamicCriteria property</summary>
        public string DynamicCriteria {
            get { return BackingStore?.Get<string>("dynamicCriteria"); }
            set { BackingStore?.Set("dynamicCriteria", value); }
        }
        /// <summary>The filterOn property</summary>
        public string FilterOn {
            get { return BackingStore?.Get<string>("filterOn"); }
            set { BackingStore?.Set("filterOn", value); }
        }
        /// <summary>The icon property</summary>
        public WorkbookIcon Icon {
            get { return BackingStore?.Get<WorkbookIcon>("icon"); }
            set { BackingStore?.Set("icon", value); }
        }
        /// <summary>The operator property</summary>
        public string Operator {
            get { return BackingStore?.Get<string>("operator"); }
            set { BackingStore?.Set("operator", value); }
        }
        /// <summary>The values property</summary>
        public Json Values {
            get { return BackingStore?.Get<Json>("values"); }
            set { BackingStore?.Set("values", value); }
        }
        /// <summary>
        /// Instantiates a new workbookFilterCriteria and sets the default values.
        /// </summary>
        public WorkbookFilterCriteria() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static WorkbookFilterCriteria CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookFilterCriteria();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"color", n => { Color = n.GetStringValue(); } },
                {"criterion1", n => { Criterion1 = n.GetStringValue(); } },
                {"criterion2", n => { Criterion2 = n.GetStringValue(); } },
                {"dynamicCriteria", n => { DynamicCriteria = n.GetStringValue(); } },
                {"filterOn", n => { FilterOn = n.GetStringValue(); } },
                {"icon", n => { Icon = n.GetObjectValue<WorkbookIcon>(WorkbookIcon.CreateFromDiscriminatorValue); } },
                {"operator", n => { Operator = n.GetStringValue(); } },
                {"values", n => { Values = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("color", Color);
            writer.WriteStringValue("criterion1", Criterion1);
            writer.WriteStringValue("criterion2", Criterion2);
            writer.WriteStringValue("dynamicCriteria", DynamicCriteria);
            writer.WriteStringValue("filterOn", FilterOn);
            writer.WriteObjectValue<WorkbookIcon>("icon", Icon);
            writer.WriteStringValue("operator", Operator);
            writer.WriteObjectValue<Json>("values", Values);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
