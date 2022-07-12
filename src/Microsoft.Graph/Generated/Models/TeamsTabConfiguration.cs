using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class TeamsTabConfiguration : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Url used for rendering tab contents in Teams. Required.</summary>
        public string ContentUrl {
            get { return BackingStore?.Get<string>("contentUrl"); }
            set { BackingStore?.Set("contentUrl", value); }
        }
        /// <summary>Identifier for the entity hosted by the tab provider.</summary>
        public string EntityId {
            get { return BackingStore?.Get<string>("entityId"); }
            set { BackingStore?.Set("entityId", value); }
        }
        /// <summary>Url called by Teams client when a Tab is removed using the Teams Client.</summary>
        public string RemoveUrl {
            get { return BackingStore?.Get<string>("removeUrl"); }
            set { BackingStore?.Set("removeUrl", value); }
        }
        /// <summary>Url for showing tab contents outside of Teams.</summary>
        public string WebsiteUrl {
            get { return BackingStore?.Get<string>("websiteUrl"); }
            set { BackingStore?.Set("websiteUrl", value); }
        }
        /// <summary>
        /// Instantiates a new teamsTabConfiguration and sets the default values.
        /// </summary>
        public TeamsTabConfiguration() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TeamsTabConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TeamsTabConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"contentUrl", n => { ContentUrl = n.GetStringValue(); } },
                {"entityId", n => { EntityId = n.GetStringValue(); } },
                {"removeUrl", n => { RemoveUrl = n.GetStringValue(); } },
                {"websiteUrl", n => { WebsiteUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("contentUrl", ContentUrl);
            writer.WriteStringValue("entityId", EntityId);
            writer.WriteStringValue("removeUrl", RemoveUrl);
            writer.WriteStringValue("websiteUrl", WebsiteUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
