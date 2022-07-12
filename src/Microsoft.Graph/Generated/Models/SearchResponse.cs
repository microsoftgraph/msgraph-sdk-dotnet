using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SearchResponse : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>A collection of search results.</summary>
        public List<SearchHitsContainer> HitsContainers {
            get { return BackingStore?.Get<List<SearchHitsContainer>>("hitsContainers"); }
            set { BackingStore?.Set("hitsContainers", value); }
        }
        /// <summary>Provides details of query alteration response for spelling correction.</summary>
        public AlterationResponse QueryAlterationResponse {
            get { return BackingStore?.Get<AlterationResponse>("queryAlterationResponse"); }
            set { BackingStore?.Set("queryAlterationResponse", value); }
        }
        /// <summary>A dictionary of resultTemplateIds and associated values, which include the name and JSON schema of the result templates.</summary>
        public ResultTemplateDictionary ResultTemplates {
            get { return BackingStore?.Get<ResultTemplateDictionary>("resultTemplates"); }
            set { BackingStore?.Set("resultTemplates", value); }
        }
        /// <summary>Contains the search terms sent in the initial search query.</summary>
        public List<string> SearchTerms {
            get { return BackingStore?.Get<List<string>>("searchTerms"); }
            set { BackingStore?.Set("searchTerms", value); }
        }
        /// <summary>
        /// Instantiates a new searchResponse and sets the default values.
        /// </summary>
        public SearchResponse() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SearchResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SearchResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"hitsContainers", n => { HitsContainers = n.GetCollectionOfObjectValues<SearchHitsContainer>(SearchHitsContainer.CreateFromDiscriminatorValue).ToList(); } },
                {"queryAlterationResponse", n => { QueryAlterationResponse = n.GetObjectValue<AlterationResponse>(AlterationResponse.CreateFromDiscriminatorValue); } },
                {"resultTemplates", n => { ResultTemplates = n.GetObjectValue<ResultTemplateDictionary>(ResultTemplateDictionary.CreateFromDiscriminatorValue); } },
                {"searchTerms", n => { SearchTerms = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<SearchHitsContainer>("hitsContainers", HitsContainers);
            writer.WriteObjectValue<AlterationResponse>("queryAlterationResponse", QueryAlterationResponse);
            writer.WriteObjectValue<ResultTemplateDictionary>("resultTemplates", ResultTemplates);
            writer.WriteCollectionOfPrimitiveValues<string>("searchTerms", SearchTerms);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
