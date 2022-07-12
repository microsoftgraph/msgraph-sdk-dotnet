using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SearchAlterationOptions : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Indicates whether spelling modifications are enabled. If enabled, user will get the search results for corrected query when there are no results for the original query with typos and get the spelling modification information in queryAlterationResponse property of the response. Optional.</summary>
        public bool? EnableModification {
            get { return BackingStore?.Get<bool?>("enableModification"); }
            set { BackingStore?.Set("enableModification", value); }
        }
        /// <summary>Indicates whether spelling suggestions are enabled. If enabled, the user will get the search results for the original search query and suggestions for spelling correction in the queryAlterationResponse property of the response for the typos in the query. Optional.</summary>
        public bool? EnableSuggestion {
            get { return BackingStore?.Get<bool?>("enableSuggestion"); }
            set { BackingStore?.Set("enableSuggestion", value); }
        }
        /// <summary>
        /// Instantiates a new searchAlterationOptions and sets the default values.
        /// </summary>
        public SearchAlterationOptions() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SearchAlterationOptions CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SearchAlterationOptions();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"enableModification", n => { EnableModification = n.GetBoolValue(); } },
                {"enableSuggestion", n => { EnableSuggestion = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("enableModification", EnableModification);
            writer.WriteBoolValue("enableSuggestion", EnableSuggestion);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
