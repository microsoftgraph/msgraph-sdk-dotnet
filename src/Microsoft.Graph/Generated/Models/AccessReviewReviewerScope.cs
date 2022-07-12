using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessReviewReviewerScope : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The query specifying who will be the reviewer. See table for examples.</summary>
        public string Query {
            get { return BackingStore?.Get<string>("query"); }
            set { BackingStore?.Set("query", value); }
        }
        /// <summary>In the scenario where reviewers need to be specified dynamically, this property is used to indicate the relative source of the query. This property is only required if a relative query, for example, ./manager, is specified. Possible value: decisions.</summary>
        public string QueryRoot {
            get { return BackingStore?.Get<string>("queryRoot"); }
            set { BackingStore?.Set("queryRoot", value); }
        }
        /// <summary>The type of query. Examples include MicrosoftGraph and ARM.</summary>
        public string QueryType {
            get { return BackingStore?.Get<string>("queryType"); }
            set { BackingStore?.Set("queryType", value); }
        }
        /// <summary>
        /// Instantiates a new accessReviewReviewerScope and sets the default values.
        /// </summary>
        public AccessReviewReviewerScope() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AccessReviewReviewerScope CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessReviewReviewerScope();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"query", n => { Query = n.GetStringValue(); } },
                {"queryRoot", n => { QueryRoot = n.GetStringValue(); } },
                {"queryType", n => { QueryType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("query", Query);
            writer.WriteStringValue("queryRoot", QueryRoot);
            writer.WriteStringValue("queryType", QueryType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
