using Microsoft.Graph.Models.Security;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Security.Cases.EdiscoveryCases.Item.ReviewSets.Item.AddToReviewSet {
    /// <summary>Provides operations to call the addToReviewSet method.</summary>
    public class AddToReviewSetPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The additionalDataOptions property</summary>
        public Microsoft.Graph.Models.Security.AdditionalDataOptions? AdditionalDataOptions {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Security.AdditionalDataOptions?>("additionalDataOptions"); }
            set { BackingStore?.Set("additionalDataOptions", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The search property</summary>
        public EdiscoverySearch Search {
            get { return BackingStore?.Get<EdiscoverySearch>("search"); }
            set { BackingStore?.Set("search", value); }
        }
        /// <summary>
        /// Instantiates a new addToReviewSetPostRequestBody and sets the default values.
        /// </summary>
        public AddToReviewSetPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AddToReviewSetPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AddToReviewSetPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"additionalDataOptions", n => { AdditionalDataOptions = n.GetEnumValue<AdditionalDataOptions>(); } },
                {"search", n => { Search = n.GetObjectValue<EdiscoverySearch>(EdiscoverySearch.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<AdditionalDataOptions>("additionalDataOptions", AdditionalDataOptions);
            writer.WriteObjectValue<EdiscoverySearch>("search", Search);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
