using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AggregationOption : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The bucketDefinition property</summary>
        public BucketAggregationDefinition BucketDefinition {
            get { return BackingStore?.Get<BucketAggregationDefinition>("bucketDefinition"); }
            set { BackingStore?.Set("bucketDefinition", value); }
        }
        /// <summary>Computes aggregation on the field while the field exists in current entity type. Required.</summary>
        public string Field {
            get { return BackingStore?.Get<string>("field"); }
            set { BackingStore?.Set("field", value); }
        }
        /// <summary>The number of searchBucket resources to be returned. This is not required when the range is provided manually in the search request. Optional.</summary>
        public int? Size {
            get { return BackingStore?.Get<int?>("size"); }
            set { BackingStore?.Set("size", value); }
        }
        /// <summary>
        /// Instantiates a new aggregationOption and sets the default values.
        /// </summary>
        public AggregationOption() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AggregationOption CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AggregationOption();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"bucketDefinition", n => { BucketDefinition = n.GetObjectValue<BucketAggregationDefinition>(BucketAggregationDefinition.CreateFromDiscriminatorValue); } },
                {"field", n => { Field = n.GetStringValue(); } },
                {"size", n => { Size = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<BucketAggregationDefinition>("bucketDefinition", BucketDefinition);
            writer.WriteStringValue("field", Field);
            writer.WriteIntValue("size", Size);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
