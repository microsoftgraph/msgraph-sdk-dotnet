using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PendingOperations : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>A property that indicates that an operation that might update the binary content of a file is pending completion.</summary>
        public Microsoft.Graph.Models.PendingContentUpdate PendingContentUpdate {
            get { return BackingStore?.Get<Microsoft.Graph.Models.PendingContentUpdate>("pendingContentUpdate"); }
            set { BackingStore?.Set("pendingContentUpdate", value); }
        }
        /// <summary>
        /// Instantiates a new pendingOperations and sets the default values.
        /// </summary>
        public PendingOperations() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static PendingOperations CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PendingOperations();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"pendingContentUpdate", n => { PendingContentUpdate = n.GetObjectValue<Microsoft.Graph.Models.PendingContentUpdate>(Microsoft.Graph.Models.PendingContentUpdate.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Microsoft.Graph.Models.PendingContentUpdate>("pendingContentUpdate", PendingContentUpdate);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
