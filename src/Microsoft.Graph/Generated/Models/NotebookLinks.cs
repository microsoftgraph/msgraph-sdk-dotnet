using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class NotebookLinks : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Opens the notebook in the OneNote native client if it&apos;s installed.</summary>
        public ExternalLink OneNoteClientUrl {
            get { return BackingStore?.Get<ExternalLink>("oneNoteClientUrl"); }
            set { BackingStore?.Set("oneNoteClientUrl", value); }
        }
        /// <summary>Opens the notebook in OneNote on the web.</summary>
        public ExternalLink OneNoteWebUrl {
            get { return BackingStore?.Get<ExternalLink>("oneNoteWebUrl"); }
            set { BackingStore?.Set("oneNoteWebUrl", value); }
        }
        /// <summary>
        /// Instantiates a new notebookLinks and sets the default values.
        /// </summary>
        public NotebookLinks() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static NotebookLinks CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new NotebookLinks();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"oneNoteClientUrl", n => { OneNoteClientUrl = n.GetObjectValue<ExternalLink>(ExternalLink.CreateFromDiscriminatorValue); } },
                {"oneNoteWebUrl", n => { OneNoteWebUrl = n.GetObjectValue<ExternalLink>(ExternalLink.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ExternalLink>("oneNoteClientUrl", OneNoteClientUrl);
            writer.WriteObjectValue<ExternalLink>("oneNoteWebUrl", OneNoteWebUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
