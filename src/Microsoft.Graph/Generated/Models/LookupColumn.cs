using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class LookupColumn : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Indicates whether multiple values can be selected from the source.</summary>
        public bool? AllowMultipleValues {
            get { return BackingStore?.Get<bool?>("allowMultipleValues"); }
            set { BackingStore?.Set("allowMultipleValues", value); }
        }
        /// <summary>Indicates whether values in the column should be able to exceed the standard limit of 255 characters.</summary>
        public bool? AllowUnlimitedLength {
            get { return BackingStore?.Get<bool?>("allowUnlimitedLength"); }
            set { BackingStore?.Set("allowUnlimitedLength", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The name of the lookup source column.</summary>
        public string ColumnName {
            get { return BackingStore?.Get<string>("columnName"); }
            set { BackingStore?.Set("columnName", value); }
        }
        /// <summary>The unique identifier of the lookup source list.</summary>
        public string ListId {
            get { return BackingStore?.Get<string>("listId"); }
            set { BackingStore?.Set("listId", value); }
        }
        /// <summary>If specified, this column is a secondary lookup, pulling an additional field from the list item looked up by the primary lookup. Use the list item looked up by the primary as the source for the column named here.</summary>
        public string PrimaryLookupColumnId {
            get { return BackingStore?.Get<string>("primaryLookupColumnId"); }
            set { BackingStore?.Set("primaryLookupColumnId", value); }
        }
        /// <summary>
        /// Instantiates a new lookupColumn and sets the default values.
        /// </summary>
        public LookupColumn() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static LookupColumn CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LookupColumn();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allowMultipleValues", n => { AllowMultipleValues = n.GetBoolValue(); } },
                {"allowUnlimitedLength", n => { AllowUnlimitedLength = n.GetBoolValue(); } },
                {"columnName", n => { ColumnName = n.GetStringValue(); } },
                {"listId", n => { ListId = n.GetStringValue(); } },
                {"primaryLookupColumnId", n => { PrimaryLookupColumnId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("allowMultipleValues", AllowMultipleValues);
            writer.WriteBoolValue("allowUnlimitedLength", AllowUnlimitedLength);
            writer.WriteStringValue("columnName", ColumnName);
            writer.WriteStringValue("listId", ListId);
            writer.WriteStringValue("primaryLookupColumnId", PrimaryLookupColumnId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
