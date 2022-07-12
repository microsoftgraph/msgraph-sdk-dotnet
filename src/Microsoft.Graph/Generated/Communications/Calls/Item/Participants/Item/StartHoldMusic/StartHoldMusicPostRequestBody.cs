using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Communications.Calls.Item.Participants.Item.StartHoldMusic {
    /// <summary>Provides operations to call the startHoldMusic method.</summary>
    public class StartHoldMusicPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The clientContext property</summary>
        public string ClientContext {
            get { return BackingStore?.Get<string>("clientContext"); }
            set { BackingStore?.Set("clientContext", value); }
        }
        /// <summary>The customPrompt property</summary>
        public Prompt CustomPrompt {
            get { return BackingStore?.Get<Prompt>("customPrompt"); }
            set { BackingStore?.Set("customPrompt", value); }
        }
        /// <summary>
        /// Instantiates a new startHoldMusicPostRequestBody and sets the default values.
        /// </summary>
        public StartHoldMusicPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static StartHoldMusicPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new StartHoldMusicPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"clientContext", n => { ClientContext = n.GetStringValue(); } },
                {"customPrompt", n => { CustomPrompt = n.GetObjectValue<Prompt>(Prompt.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("clientContext", ClientContext);
            writer.WriteObjectValue<Prompt>("customPrompt", CustomPrompt);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
