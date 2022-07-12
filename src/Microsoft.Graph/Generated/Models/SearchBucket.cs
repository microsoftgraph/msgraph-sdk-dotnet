using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SearchBucket : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>A token containing the encoded filter to aggregate search matches by the specific key value. To use the filter, pass the token as part of the aggregationFilter property in a searchRequest object, in the format &apos;{field}:/&apos;{aggregationFilterToken}/&apos;&apos;. See an example.</summary>
        public string AggregationFilterToken {
            get { return BackingStore?.Get<string>("aggregationFilterToken"); }
            set { BackingStore?.Set("aggregationFilterToken", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The approximate number of search matches that share the same value specified in the key property. Note that this number is not the exact number of matches.</summary>
        public int? Count {
            get { return BackingStore?.Get<int?>("count"); }
            set { BackingStore?.Set("count", value); }
        }
        /// <summary>The discrete value of the field that an aggregation was computed on.</summary>
        public string Key {
            get { return BackingStore?.Get<string>("key"); }
            set { BackingStore?.Set("key", value); }
        }
        /// <summary>
        /// Instantiates a new searchBucket and sets the default values.
        /// </summary>
        public SearchBucket() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SearchBucket CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SearchBucket();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"aggregationFilterToken", n => { AggregationFilterToken = n.GetStringValue(); } },
                {"count", n => { Count = n.GetIntValue(); } },
                {"key", n => { Key = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("aggregationFilterToken", AggregationFilterToken);
            writer.WriteIntValue("count", Count);
            writer.WriteStringValue("key", Key);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
