using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Sites.Item.ContentTypes.Item.CopyToDefaultContentLocation {
    /// <summary>Provides operations to call the copyToDefaultContentLocation method.</summary>
    public class CopyToDefaultContentLocationPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The destinationFileName property</summary>
        public string DestinationFileName {
            get { return BackingStore?.Get<string>("destinationFileName"); }
            set { BackingStore?.Set("destinationFileName", value); }
        }
        /// <summary>The sourceFile property</summary>
        public ItemReference SourceFile {
            get { return BackingStore?.Get<ItemReference>("sourceFile"); }
            set { BackingStore?.Set("sourceFile", value); }
        }
        /// <summary>
        /// Instantiates a new copyToDefaultContentLocationPostRequestBody and sets the default values.
        /// </summary>
        public CopyToDefaultContentLocationPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static CopyToDefaultContentLocationPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CopyToDefaultContentLocationPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"destinationFileName", n => { DestinationFileName = n.GetStringValue(); } },
                {"sourceFile", n => { SourceFile = n.GetObjectValue<ItemReference>(ItemReference.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("destinationFileName", DestinationFileName);
            writer.WriteObjectValue<ItemReference>("sourceFile", SourceFile);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
