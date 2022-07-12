using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class BucketAggregationDefinition : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>True to specify the sort order as descending. The default is false, with the sort order as ascending. Optional.</summary>
        public bool? IsDescending {
            get { return BackingStore?.Get<bool?>("isDescending"); }
            set { BackingStore?.Set("isDescending", value); }
        }
        /// <summary>The minimum number of items that should be present in the aggregation to be returned in a bucket. Optional.</summary>
        public int? MinimumCount {
            get { return BackingStore?.Get<int?>("minimumCount"); }
            set { BackingStore?.Set("minimumCount", value); }
        }
        /// <summary>A filter to define a matching criteria. The key should start with the specified prefix to be returned in the response. Optional.</summary>
        public string PrefixFilter {
            get { return BackingStore?.Get<string>("prefixFilter"); }
            set { BackingStore?.Set("prefixFilter", value); }
        }
        /// <summary>Specifies the manual ranges to compute the aggregations. This is only valid for non-string refiners of date or numeric type. Optional.</summary>
        public List<BucketAggregationRange> Ranges {
            get { return BackingStore?.Get<List<BucketAggregationRange>>("ranges"); }
            set { BackingStore?.Set("ranges", value); }
        }
        /// <summary>The sortBy property</summary>
        public BucketAggregationSortProperty? SortBy {
            get { return BackingStore?.Get<BucketAggregationSortProperty?>("sortBy"); }
            set { BackingStore?.Set("sortBy", value); }
        }
        /// <summary>
        /// Instantiates a new bucketAggregationDefinition and sets the default values.
        /// </summary>
        public BucketAggregationDefinition() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static BucketAggregationDefinition CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BucketAggregationDefinition();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"isDescending", n => { IsDescending = n.GetBoolValue(); } },
                {"minimumCount", n => { MinimumCount = n.GetIntValue(); } },
                {"prefixFilter", n => { PrefixFilter = n.GetStringValue(); } },
                {"ranges", n => { Ranges = n.GetCollectionOfObjectValues<BucketAggregationRange>(BucketAggregationRange.CreateFromDiscriminatorValue).ToList(); } },
                {"sortBy", n => { SortBy = n.GetEnumValue<BucketAggregationSortProperty>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("isDescending", IsDescending);
            writer.WriteIntValue("minimumCount", MinimumCount);
            writer.WriteStringValue("prefixFilter", PrefixFilter);
            writer.WriteCollectionOfObjectValues<BucketAggregationRange>("ranges", Ranges);
            writer.WriteEnumValue<BucketAggregationSortProperty>("sortBy", SortBy);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
