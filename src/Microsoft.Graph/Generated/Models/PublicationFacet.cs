using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PublicationFacet : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The state of publication for this document. Either published or checkout. Read-only.</summary>
        public string Level {
            get { return BackingStore?.Get<string>("level"); }
            set { BackingStore?.Set("level", value); }
        }
        /// <summary>The unique identifier for the version that is visible to the current caller. Read-only.</summary>
        public string VersionId {
            get { return BackingStore?.Get<string>("versionId"); }
            set { BackingStore?.Set("versionId", value); }
        }
        /// <summary>
        /// Instantiates a new publicationFacet and sets the default values.
        /// </summary>
        public PublicationFacet() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static PublicationFacet CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PublicationFacet();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"level", n => { Level = n.GetStringValue(); } },
                {"versionId", n => { VersionId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("level", Level);
            writer.WriteStringValue("versionId", VersionId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
